using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace VoronoiMosaic
{
    public interface ISampledImageVisualizer
    {
        Bitmap ReconstructImage(SampledImage sampledImage);
    }
}
