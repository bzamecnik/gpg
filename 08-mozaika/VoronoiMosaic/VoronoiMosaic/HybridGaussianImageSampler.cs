using System;
using System.Diagnostics;
using System.Drawing;

namespace VoronoiMosaic
{
    /// <summary>
    /// Samples an image with uniformly distributed clusters, each with
    /// a Gaussian distribution.
    /// </summary>
    public class HybridGaussianImageSampler : AbstractImageSampler
    {
        private GaussianDistribution2D gaussRandom = new GaussianDistribution2D();

        private int centerX;
        private int centerY;
        private double stdDev;
        private double meanStdDev;

        /// <summary>
        /// The requested number of Gaussian clusters.
        /// </summary>
        public int ClusterCount { get; set; }

        public HybridGaussianImageSampler()
        {
            ClusterCount = 1;
        }

        protected override void GenerateSamples(Bitmap image, int sampleCount, SampledImage sampledImage)
        {
            // NOTE: some random position candidates may go outside the image
            // and thus are do not contribute as the real image samples
            int samplePercent = sampleCount / 100;
            int percentDone = 0;
            int samplesPerCluster = sampleCount / ClusterCount;
            int targetSampleCount = sampleCount % ClusterCount;
            for (int cluster = 0; cluster < ClusterCount; cluster++)
            {
                targetSampleCount += samplesPerCluster;
                int maxIterations = 10 * targetSampleCount;

                // standard deviation of the cluster
                //double stdDev = maxStdDev * random.NextDouble();
                stdDev = meanStdDev * gaussRandom.Next(1, 0.5);
                // center of the cluster
                centerX = random.Next(0, width - 1);
                centerY = random.Next(0, height - 1);

                percentDone = GenerateCluster(image, targetSampleCount, sampledImage, samplePercent, percentDone, maxIterations);
            }
        }

        protected override bool Next2DWithinImage(out int x, out int y)
        {
            double xGauss, yGauss;
            gaussRandom.Next2D(centerX, centerY, stdDev, out xGauss, out yGauss);
            x = (int)xGauss;
            y = (int)yGauss;
            return ((x >= 0) && (x < width) && (y >= 0) && (y < height));
        }

        protected override void Init(Bitmap image, int sampleCount)
        {
            base.Init(image, sampleCount);

            double halfWidth = width / 2;
            double halfHeight = height / 2;
            double halfMinSide = Math.Min(halfWidth, halfHeight);
            meanStdDev = 4 * Math.Sqrt(halfMinSide);
        }
    }
}
