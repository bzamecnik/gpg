using System;
using System.Diagnostics;
using System.Drawing;

namespace VoronoiMosaic
{
    public class UniformImageSampler : IImageSampler
    {
        private Random random = new Random();

        public ProgressReporter Progress { get; private set; }

        public UniformImageSampler()
            : this(new ProgressReporter())
        {
        }

        public UniformImageSampler(ProgressReporter progress)
        {
            Progress = progress;
        }

        public SampledImage SampleImage(Bitmap image, int sampleCount)
        {
            int width = image.Width;
            int height = image.Height;
            sampleCount = Math.Min(sampleCount, image.Width * image.Height);

            SampledImage sampledImage = new SampledImage()
            {
                Width = width,
                Height = height
            };

            Progress.ReportProgress(0);

            int samplePercent = sampleCount / 100;
            int percentDone = 0;
            int maxIterations = 10 * sampleCount;

            Stopwatch stopwatch = Stopwatch.StartNew();
            for (int i = 0; (sampledImage.Samples.Count < sampleCount) && (i < maxIterations); i++)
            {
                int x = random.Next(0, width - 1);
                int y = random.Next(0, height - 1);
                Color color = image.GetPixel(x, y);
                sampledImage.AddSample(new ImageSample(x, y, color));

                if ((samplePercent > 500) && (sampledImage.Samples.Count % samplePercent == 0))
                {
                    percentDone++;
                    Progress.ReportProgress(percentDone);
                }
            }
            stopwatch.Stop();
            Progress.TimeReport["sampler"] = stopwatch.ElapsedMilliseconds;

            Progress.ReportProgress(100);

            return sampledImage;
        }
    }
}
