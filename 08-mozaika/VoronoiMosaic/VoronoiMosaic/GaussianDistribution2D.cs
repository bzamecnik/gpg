using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VoronoiMosaic
{
    class GaussianDistribution2D
    {
        private Random random = new Random();

        public void Next2D(out double x, out double y)
        {
            Next2D(0, 0, 1, out x, out y);
        }

        /// <summary>
        /// Generate a 2D random vector from Gaussian distribution using the
        /// Box-Muller Transform.
        /// </summary>
        /// <remarks>
        /// See http://mathworld.wolfram.com/Box-MullerTransformation.html
        /// </remarks>
        /// <param name="meanX"></param>
        /// <param name="meanY"></param>
        /// <param name="stdDev"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public void Next2D(double meanX, double meanY, double stdDev, out double x, out double y)
        {
            double uniformX = random.NextDouble();
            double uniformY = random.NextDouble();
            double prefix = Math.Sqrt(-2.0 * Math.Log(uniformX));
            double uniformY2Pi = 2.0 * Math.PI * uniformY;
            // random numbers from standard normal distribution normal(0, 1)
            double randStdNormalX = prefix * Math.Cos(uniformY2Pi);
            double randStdNormalY = prefix * Math.Sin(uniformY2Pi);
            // random numbers from ordinary normal distribution normal(mean, stdDev^2)
            x = meanX + stdDev * randStdNormalX;
            y = meanY + stdDev * randStdNormalY;
        }
    }
}
