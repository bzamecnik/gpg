using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

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
                image.SetPixel(sample.x, sample.y, sample.color);
            }

            return image;
        }
    }
}
