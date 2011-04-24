using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;

namespace VoronoiMosaic
{
    public class PointVisualizer : ISampledImageVisualizer
    {
        public ProgressReporter Progress { get; private set; }

        public PointVisualizer()
            : this(new ProgressReporter())
        {
        }

        public PointVisualizer(ProgressReporter progress)
        {
            Progress = progress;
        }

        public Bitmap ReconstructImage(SampledImage sampledImage)
        {
            int width = sampledImage.Width;
            int height = sampledImage.Height;

            Stopwatch stopwatch = Stopwatch.StartNew();
            
            Bitmap image = new Bitmap(width, height);

            // fill with black background
            using (Graphics graphics = Graphics.FromImage(image))
            {
                graphics.FillRectangle(Brushes.Black, 0, 0, width, height);
            }

            // TODO:
            // - directly write into the image via pointers
            //   - at least for RGBA images

            int samplePercent = sampledImage.Samples.Count / 100;
            int currentSample = 0;
            int percentDone = 0;

            if ((image.PixelFormat == PixelFormat.Format32bppArgb) ||
                (image.PixelFormat == PixelFormat.Format24bppRgb))
            {
                // faster, only for BGR or BGRA
                BitmapData imageData = image.LockBits(new Rectangle(0, 0, width, height),
                    ImageLockMode.WriteOnly, image.PixelFormat);
                bool hasAlpha = image.PixelFormat == PixelFormat.Format32bppArgb;
                int bands =  hasAlpha ? 4 : 3;

                unsafe
                {
                    byte* imagePtrBase = (byte*)imageData.Scan0;

                    foreach (ImageSample sample in sampledImage.Samples)
                    {
                        byte* imagePtr = imagePtrBase + (sample.Y * imageData.Stride) + sample.X * bands;
                        imagePtr[0] = sample.color.B;
                        imagePtr[1] = sample.color.G;
                        imagePtr[2] = sample.color.R;
                        if (hasAlpha)
                        {
                            imagePtr[3] = sample.color.A;
                        }
                        ReportProgress(samplePercent, ref currentSample, ref percentDone);
                    }
                }
                image.UnlockBits(imageData);
            }
            else
            {
                // slower, more general
                foreach (ImageSample sample in sampledImage.Samples)
                {
                    image.SetPixel(sample.X, sample.Y, sample.color);
                    ReportProgress(samplePercent, ref currentSample, ref percentDone);
                }
            }

            Progress.TimeReport["visualizer"] = stopwatch.ElapsedMilliseconds;

            Progress.ReportProgress(100);

            return image;
        }

        private void ReportProgress(int samplePercent, ref int currentSample, ref int percentDone)
        {
            currentSample++;
            if ((samplePercent > 500) && (currentSample % samplePercent == 0))
            {
                percentDone++;
                Progress.ReportProgress(percentDone);
            }
        }
    }
}
