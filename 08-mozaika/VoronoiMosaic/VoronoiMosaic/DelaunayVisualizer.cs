using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using Poly2Tri;

namespace VoronoiMosaic
{
    public class DelaunayVisualizer : ISampledImageVisualizer
    {
        public Bitmap ReconstructImage(SampledImage sampledImage)
        {
            int width = sampledImage.Width;
            int height = sampledImage.Height;
            Bitmap image = new Bitmap(width, height);

            PointSet polygon = MakeDelaunayTriangulation(sampledImage);
            
            using (Graphics graphics = Graphics.FromImage(image))
            {
                // fill with black background
                graphics.FillRectangle(Brushes.White, 0, 0, width, height);
                graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

                int polygonCount = polygon.Triangles.Count;
                foreach (DelaunayTriangle triangle in polygon.Triangles)
                {
                    PointF[] points = new PointF[]{
                        new PointF(triangle.Points[0].Xf, triangle.Points[0].Yf),
                        new PointF(triangle.Points[1].Xf, triangle.Points[1].Yf),
                        new PointF(triangle.Points[2].Xf, triangle.Points[2].Yf),
                    };
                    graphics.DrawPolygon(Pens.Black, points);
                    //graphics.FillPolygon(new Brush(), points);
                }
            }

            return image;
        }

        private PointSet MakeDelaunayTriangulation(SampledImage sampledImage)
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>();
            foreach (ImageSample sample in sampledImage.Samples) {
                points.Add(new PolygonPoint(sample.x, sample.y));
            }
            PointSet polygon = new PointSet(points);
            try
            {
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Reset();
                stopwatch.Start();
                P2T.Triangulate(polygon);
                stopwatch.Stop();
                Console.WriteLine("Delaunay triangulation - elapsed time: {0} ms", stopwatch.ElapsedMilliseconds);
            }
            catch (NotImplementedException ex)
            {
                Console.WriteLine("Delaunay triangulation - exception: {0}", ex.Message);
            }
            //catch (NullReferenceException ex)
            //{
            //    Console.WriteLine("Delaunay triangulation - exception: {0}", ex.Message);
            //}
            return polygon;
        }
    }
}
