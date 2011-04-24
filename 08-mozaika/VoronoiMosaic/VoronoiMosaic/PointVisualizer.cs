using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace VoronoiMosaic
{
    public class PointVisualizer : ISampledImageVisualizer
    {
        public ProgressReporter Progress { get; private set; }

        public PointVisualizer()
            : this(new ProgressReporter())
        {
        }

        public PointVisualizer(ProgressReporter progress)
        {
            Progress = progress;
        }

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

            // TODO:
            // - directly write into the image via pointers
            //   - at least for RGBA images

            int samplePercent = sampledImage.Samples.Count / 100;
            int currentSample = 0;
            int percentDone = 0;
            foreach(ImageSample sample in sampledImage.Samples)
            {
                image.SetPixel(sample.X, sample.Y, sample.color);
                currentSample++;
                if ((samplePercent > 500) && (currentSample % samplePercent == 0))
                {
                    percentDone++;
                    Progress.ReportProgress(percentDone);
                }
            }

            Progress.ReportProgress(100);

            return image;
        }
    }
}
