using System;
using System.Diagnostics;
using System.Drawing;

namespace VoronoiMosaic
{
    public class UniformImageSampler : AbstractImageSampler
    {
        protected override bool Next2DWithinImage(out int x, out int y)
        {
            x = random.Next(0, width - 1);
            y = random.Next(0, height - 1);
            return true;
        }
    }
}
