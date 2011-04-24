using System;
using System.Diagnostics;
using System.Drawing;

namespace VoronoiMosaic
{
    /// <summary>
    /// Samples an image with uniformly distributed clusters, each with
    /// a Gaussian distribution.
    /// </summary>
    public class HybridGaussianImageSampler : IImageSampler
    {
        private Random random = new Random();

        GaussianDistribution2D gaussRandom = new GaussianDistribution2D();

        /// <summary>
        /// The requested number of Gaussian clusters.
        /// </summary>
        public int ClusterCount { get; set; }

        public ProgressReporter Progress { get; private set; }

        public HybridGaussianImageSampler()
            : this(new ProgressReporter())
        {
        }

        public HybridGaussianImageSampler(ProgressReporter progress)
        {
            ClusterCount = 1;
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

            double halfWidth = width / 2;
            double halfHeight = height / 2;
            double halfMinSide = Math.Min(halfWidth, halfHeight);
            double meanStdDev = 4 * Math.Sqrt(halfMinSide);

            Progress.ReportProgress(0);

            int samplePercent = sampleCount / 100;
            int percentDone = 0;

            // NOTE: some random position candidates may go outside the image
            // and thus are do not contribute as the real image samples
            int samplesPerCluster = sampleCount / ClusterCount;
            int targetSampleCount = sampleCount % ClusterCount;
            Stopwatch stopwatch = Stopwatch.StartNew();
            for (int cluster = 0; cluster < ClusterCount; cluster++)
            {
                targetSampleCount += samplesPerCluster;
                int maxIterations = 10 * targetSampleCount;

                // standard deviation of the cluster
                //double stdDev = maxStdDev * random.NextDouble();
                double stdDev = meanStdDev * gaussRandom.Next(1, 0.5);
                // center of the cluster
                int centerX = random.Next(0, width - 1);
                int centerY = random.Next(0, height - 1);

                for (int i = 0; (sampledImage.Samples.Count < targetSampleCount) && (i < maxIterations); i++)
                {
                    double xGauss, yGauss;
                    gaussRandom.Next2D(centerX, centerY, stdDev, out xGauss, out yGauss);
                    int x = (int)xGauss;
                    int y = (int)yGauss;
                    if ((x >= 0) && (x < width) && (y >= 0) && (y < height))
                    {
                        Color color = image.GetPixel(x, y);
                        sampledImage.AddSample(new ImageSample(x, y, color));
                    }

                    if ((samplePercent > 500) && (sampledImage.Samples.Count % samplePercent == 0))
                    {
                        percentDone++;
                        Progress.ReportProgress(percentDone);
                    }
                }
            }
            Progress.TimeReport["sampler"] = stopwatch.ElapsedMilliseconds;

            Progress.ReportProgress(100);

            return sampledImage;
        }
    }
}
