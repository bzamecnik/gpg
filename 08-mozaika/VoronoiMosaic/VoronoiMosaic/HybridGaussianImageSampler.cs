using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

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

        public HybridGaussianImageSampler()
        {
            ClusterCount = 1;
        }

        public SampledImage SampleImage(Bitmap image, int sampleCount)
        {
            int width = image.Width;
            int height = image.Height;

            SampledImage sampledImage = new SampledImage()
            {
                Width = width,
                Height = height
            };

            double halfWidth = width / 2;
            double halfHeight = height / 2;
            double halfMinSide = Math.Min(halfWidth, halfHeight);
            double meanStdDev = Math.Sqrt(6 * halfMinSide);

            // NOTE: some random position candidates may go outside the image
            // and thus are do not contribute as the real image samples
            int samplesPerCluster = sampleCount / ClusterCount;
            int targetSampleCount = sampleCount % ClusterCount;
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
                }
            }

            Console.WriteLine("Hybrid Gaussian sampler: Requested samples: {0}, actual samples: {1}",
                sampleCount, sampledImage.Samples.Count);

            return sampledImage;
        }
    }
}
