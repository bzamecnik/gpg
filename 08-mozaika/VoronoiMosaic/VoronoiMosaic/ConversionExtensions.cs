using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using OpenTK;
using Poly2Tri;

namespace VoronoiMosaic
{
    static class ConversionExtensions
    {
        public static Vector2 ToVector2(this TriangulationPoint point)
        {
            return new Vector2(point.Xf, point.Yf);
        }

        public static PointF ToPointF(this Vector2 point)
        {
            return new PointF(point.X, point.Y);
        }

        public static PointF[] ToPointFArray(this DelaunayTriangle triangle)
        {
            return new PointF[]{
                new PointF(triangle.Points[0].Xf, triangle.Points[0].Yf),
                new PointF(triangle.Points[1].Xf, triangle.Points[1].Yf),
                new PointF(triangle.Points[2].Xf, triangle.Points[2].Yf),
            };
        }
    }
}
