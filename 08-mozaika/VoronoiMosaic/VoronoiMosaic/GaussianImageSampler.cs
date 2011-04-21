using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace VoronoiMosaic
{
    public class GaussianImageSampler : IImageSampler
    {
        private Random random = new Random();

        GaussianDistribution2D gaussRandom = new GaussianDistribution2D();

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
            //double stdDev = Math.Sqrt(1 / (6 * halfMinSide));
            //double stdDev = 1 / (6 * halfMinSide);
            double stdDev = Math.Sqrt(12 * halfMinSide);

            // NOTE: some random position candidates may go outside the image
            // and thus are do not contribute as the real image samples
            int maxIterations = 10 * sampleCount;
            for (int i = 0; (sampledImage.Samples.Count < sampleCount) && (i < maxIterations); i++)
            {
                double xGauss, yGauss;
                gaussRandom.Next2D(halfWidth, halfHeight, stdDev, out xGauss, out yGauss);
                int x = (int)xGauss;
                int y = (int)yGauss;
                if ((x >= 0) && (x < width) && (y >= 0) && (y < height))
                {
                    Color color = image.GetPixel(x, y);
                    sampledImage.AddSample(new ImageSample(x, y, color));
                }
            }

            return sampledImage;
        }
    }
}
