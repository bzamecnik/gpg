using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace VoronoiMosaic
{
    public class PointVisualizer : ISampledImageVisualizer
    {
        public Bitmap ReconstructImage(SampledImage sampledImage)
        {
            int width = sampledImage.Width;
            int height = sampledImage.Height;
            Bitmap image = new Bitmap(width, height);

            // fill with black background
            using (Graphics graphics = Graphics.FromImage(image))
            {
                graphics.FillRectangle(Brushes.Black, 0, 0, width, height);
            }

            foreach(ImageSample sample in sampledImage.Samples)
            {
                image.SetPixel(sample.X, sample.Y, sample.color);
            }

            return image;
        }
    }
}
