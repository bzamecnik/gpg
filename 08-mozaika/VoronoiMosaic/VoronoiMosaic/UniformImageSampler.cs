using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace VoronoiMosaic
{
    public class UniformImageSampler : IImageSampler
    {
        private Random random = new Random();

        public SampledImage SampleImage(Bitmap image, int sampleCount)
        {
            int width = image.Width;
            int height = image.Height;

            SampledImage sampledImage = new SampledImage()
            {
                Width = width,
                Height = height
            };

            int maxIterations = 10 * sampleCount;
            for (int i = 0; (sampledImage.Samples.Count < sampleCount) && (i < maxIterations); i++)
            {
                int x = random.Next(0, width - 1);
                int y = random.Next(0, height - 1);
                Color color = image.GetPixel(x, y);
                sampledImage.AddSample(new ImageSample(x, y, color));
            }

            return sampledImage;
        }
    }
}
