using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace VoronoiMosaic
{
    public interface ISampledImageVisualizer
    {
        Bitmap ReconstructImage(SampledImage sampledImage);
    }
}
