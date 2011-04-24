using System;
using System.Diagnostics;
using System.Drawing;

namespace VoronoiMosaic
{
    public class GaussianImageSampler : AbstractImageSampler
    {
        private GaussianDistribution2D gaussRandom = new GaussianDistribution2D();

        private double halfWidth;
        private double halfHeight;
        private double stdDev;

        protected override bool Next2DWithinImage(out int x, out int y)
        {
            double xGauss, yGauss;
            gaussRandom.Next2D(halfWidth, halfHeight, stdDev, out xGauss, out yGauss);
            x = (int)xGauss;
            y = (int)yGauss;
            return ((x >= 0) && (x < width) && (y >= 0) && (y < height));
        }

        protected override void Init(Bitmap image, int sampleCount)
        {
            base.Init(image, sampleCount);

            halfWidth = width / 2;
            halfHeight = height / 2;
            double halfMinSide = Math.Min(halfWidth, halfHeight);
            //stdDev = Math.Sqrt(1 / (6 * halfMinSide));
            //stdDev = 1 / (6 * halfMinSide);
            //stdDev = Math.Sqrt(6 * halfMinSide);
            stdDev = 8 * Math.Sqrt(halfMinSide);
        }
    }
}
