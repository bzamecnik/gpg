using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace VoronoiMosaic
{
    public interface IImageSampler
    {
        SampledImage SampleImage(Bitmap image, int sampleCount);
    }
}
