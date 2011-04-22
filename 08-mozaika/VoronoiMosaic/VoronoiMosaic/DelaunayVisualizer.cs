using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using Poly2Tri;
using OpenTK;

namespace VoronoiMosaic
{
    public class DelaunayVisualizer : ISampledImageVisualizer
    {
        Random random = new Random();

        public Bitmap ReconstructImage(SampledImage sampledImage)
        {
            int width = sampledImage.Width;
            int height = sampledImage.Height;
            Bitmap image = new Bitmap(width, height);

            PointSet polygon = VoronoiHelper.MakeDelaunayTriangulation(sampledImage);
            
            using (Graphics graphics = Graphics.FromImage(image))
            {
                // fill with black background
                graphics.FillRectangle(Brushes.White, 0, 0, width, height);
                graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

                HashSet<Vector2> drawnVoronoiCells = new HashSet<Vector2>();

                foreach (DelaunayTriangle triangle in polygon.Triangles)
                {
                    // draw Voronoi cells
                    foreach (TriangulationPoint triVertex in triangle.Points)
                    {
                        // each cell corresponds to a triangulation vertex
                        Vector2 point = triVertex.ToVector2();
                        if (drawnVoronoiCells.Contains(point))
                        {
                            // this Voronoi cell was already drawn
                            continue;
                        }
                        drawnVoronoiCells.Add(point);
                        IList<DelaunayTriangle> surroundingTriangles =
                            VoronoiHelper.GetSurroundingTriangles(triangle, triVertex);
                        if (surroundingTriangles.Count < 3)
                        {
                            // there are not enough vertices to make a polygon
                            continue;
                        }
                        // TODO: the computation of the circumference could
                        // be cached since the voronoi vertices are usually
                        // share among multiple triangles
                        IEnumerable<Vector2> voronoiCellVertices = surroundingTriangles.Select(
                            (DelaunayTriangle tri) => VoronoiHelper.GetCircumcenter(tri));
                        PointF[] voronoiCellPolygon = voronoiCellVertices.Select(
                            (Vector2 vertex) => vertex.ToPointF()).ToArray();
                        // TODO: use the color from the corresponding image sample
                        graphics.FillPolygon(new SolidBrush(GetRandomColor()), voronoiCellPolygon);
                        graphics.DrawPolygon(Pens.Gray, voronoiCellPolygon);
                    }
                }

                foreach (DelaunayTriangle triangle in polygon.Triangles)
                {
                    // draw Delaunay triangulation

                    PointF[] points = triangle.ToPointFArray();
                    graphics.DrawPolygon(Pens.Black, points);
                    //graphics.FillPolygon(new Brush(), points);
                    
                    Vector2 voronoiPoint = VoronoiHelper.GetCircumcenter(triangle);
                    float x = voronoiPoint.X;
                    float y = voronoiPoint.Y;
                    if ((x >= 0) && (x < width) && (y >= 0) && (y < height))
                    {
                        //image.SetPixel(x, y, Color.Red);
                        graphics.FillRectangle(Brushes.Red, x - 2, y - 2, 4, 4);
                    }
                    //float circumradius = VoronoiHelper.GetCircumradius(triangle);
                    //graphics.DrawEllipse(Pens.Green, x - circumradius, y - circumradius,
                    //    2 * circumradius, 2 * circumradius);
                }
            }

            return image;
        }

        private Color GetRandomColor()
        {
            return Color.FromArgb(random.Next(0, 255), random.Next(0, 255), random.Next(0, 255));
        }
    }
}
