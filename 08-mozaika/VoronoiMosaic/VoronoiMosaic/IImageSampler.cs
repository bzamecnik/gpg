using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace VoronoiMosaic
{
    public interface IImageSampler
    {
        SampledImage SampleImage(Bitmap image, int sampleCount);
    }
}
