using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;

namespace VoronoiMosaic
{
    public abstract class AbstractImageSampler : IImageSampler
    {
        public ProgressReporter Progress { get; set; }

        protected Random random = new Random();
        protected int width;
        protected int height;

        private BitmapData imageData;
        private bool hasAlpha;
        private int bands;
        private bool canReadImageDirectly;
        private unsafe byte* imagePtrBase;

        public SampledImage SampleImage(Bitmap image, int sampleCount)
        {
            Init(image, sampleCount);

            sampleCount = Math.Min(sampleCount, image.Width * image.Height);

            SampledImage sampledImage = new SampledImage()
            {
                Width = width,
                Height = height
            };

            Progress.ReportProgress(0);

            // NOTE: some random position candidates may go outside the image
            // and thus are do not contribute as the real image samples
            Stopwatch stopwatch = Stopwatch.StartNew();

            GenerateSamples(image, sampleCount, sampledImage);

            if (canReadImageDirectly)
            {
                image.UnlockBits(imageData);
            }

            stopwatch.Stop();

            Progress.TimeReport["sampler"] = stopwatch.ElapsedMilliseconds;
            Progress.ReportProgress(100);

            return sampledImage;
        }

        protected virtual void GenerateSamples(Bitmap image, int sampleCount, SampledImage sampledImage)
        {
            int maxIterations = 10 * sampleCount;
            int samplePercent = sampleCount / 100;
            int percentDone = 0;
            GenerateCluster(image, sampleCount, sampledImage, samplePercent, percentDone, maxIterations);
        }

        protected int GenerateCluster(Bitmap image, int sampleCount, SampledImage sampledImage, int samplePercent, int percentDone, int maxIterations)
        {
            for (int i = 0; (sampledImage.Samples.Count < sampleCount) && (i < maxIterations); i++)
            {
                int x;
                int y;
                if (!Next2DWithinImage(out x, out y))
                {
                    continue;
                }
                Color color;
                if (canReadImageDirectly)
                {
                    // faster, only for BGR or BGRA
                    unsafe
                    {
                        byte* imagePtr = imagePtrBase + (y * imageData.Stride) + x * bands;
                        byte b = imagePtr[0];
                        byte g = imagePtr[1];
                        byte r = imagePtr[2];
                        byte a = 255;
                        if (hasAlpha)
                        {
                            a = imagePtr[3];
                        }
                        color = Color.FromArgb(a, r, g, b);
                    }
                }
                else
                {
                    // slower, more general
                    color = image.GetPixel(x, y);
                }
                sampledImage.AddSample(new ImageSample(x, y, color));

                if ((samplePercent > 500) && (sampledImage.Samples.Count % samplePercent == 0))
                {
                    percentDone++;
                    Progress.ReportProgress(percentDone);
                }
            }
            return percentDone;
        }

        /// <summary>
        /// Generates a random 2D integer coordinates within image space.
        /// </summary>
        /// <param name="x">[0; width - 1]</param>
        /// <param name="y">[0; height - 1]</param>
        /// <returns></returns>
        protected abstract bool Next2DWithinImage(out int x, out int y);

        protected virtual void Init(Bitmap image, int sampleCount)
        {
            width = image.Width;
            height = image.Height;
            imageData = null;
            hasAlpha = image.PixelFormat == PixelFormat.Format32bppArgb;
            bands = hasAlpha ? 4 : 3;
            canReadImageDirectly = false && (
                (image.PixelFormat == PixelFormat.Format32bppArgb) ||
                (image.PixelFormat == PixelFormat.Format24bppRgb));
            if (canReadImageDirectly)
            {
                imageData = image.LockBits(new Rectangle(0, 0, width, height),
                    ImageLockMode.WriteOnly, image.PixelFormat);
                unsafe
                {
                    imagePtrBase = (byte*)imageData.Scan0;
                }
            }
        }
    }
}
