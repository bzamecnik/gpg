using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using OpenTK;
using Poly2Tri;

namespace VoronoiMosaic
{
    public class VoronoiVisualizer : ISampledImageVisualizer
    {
        public bool VoronoiCellsEnabled { get; set; }
        public bool DelaunayTrianglesEnabled { get; set; }
        public bool VoronoiVerticesEnabled { get; set; }
        public bool DelaunayCircumcirclesEnabled { get; set; }

        Random random = new Random();

        public VoronoiVisualizer()
        {
            VoronoiCellsEnabled = true;
        }

        public Bitmap ReconstructImage(SampledImage sampledImage)
        {
            int width = sampledImage.Width;
            int height = sampledImage.Height;
            Bitmap image = new Bitmap(width, height);

            PointSet polygon = VoronoiHelper.MakeDelaunayTriangulation(sampledImage);

            using (Graphics graphics = Graphics.FromImage(image))
            {
                // fill with black background
                //graphics.FillRectangle(Brushes.White, 0, 0, width, height);
                graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                
                if (VoronoiCellsEnabled)
                {
                    DrawVoronoiCells(polygon, graphics);
                }

                if (DelaunayTrianglesEnabled)
                {
                    DrawDelaunayTriangles(polygon, graphics);
                }

                DrawAdditionalFeatures(width, height, polygon, graphics);
            }

            return image;
        }

        private void DrawDelaunayTriangles(PointSet polygon, Graphics graphics)
        {
            foreach (DelaunayTriangle triangle in polygon.Triangles)
            {
                // draw Delaunay triangulation
                PointF[] points = triangle.ToPointFArray();
                graphics.DrawPolygon(Pens.Black, points);
                //graphics.FillPolygon(new Brush(), points);
            }
        }

        private void DrawVoronoiCells(PointSet polygon, Graphics graphics)
        {
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
        }

        private void DrawAdditionalFeatures(int width, int height, PointSet polygon, Graphics graphics)
        {
            if (VoronoiVerticesEnabled || DelaunayCircumcirclesEnabled)
            {
            foreach (DelaunayTriangle triangle in polygon.Triangles)
            {

                Vector2 voronoiVertex = VoronoiHelper.GetCircumcenter(triangle);
                if (VoronoiVerticesEnabled)
                {
                    DrawVoronoiVertex(width, height, voronoiVertex, graphics);
                }
                if (DelaunayCircumcirclesEnabled)
                {
                    DrawDelaunayCircumcircles(triangle, voronoiVertex, graphics);
                }
            }
            }
        }

        private static void DrawVoronoiVertex(int width, int height, Vector2 voronoiVertex, Graphics graphics)
        {
            float x = voronoiVertex.X;
            float y = voronoiVertex.Y;
            if ((x >= 0) && (x < width) && (y >= 0) && (y < height))
            {
                //image.SetPixel(x, y, Color.Red);
                graphics.FillRectangle(Brushes.Red, x - 2, y - 2, 4, 4);
            }
        }

        private static void DrawDelaunayCircumcircles(DelaunayTriangle triangle, Vector2 circumcenter, Graphics graphics)
        {
            float circumradius = VoronoiHelper.GetCircumradius(triangle);
            graphics.DrawEllipse(Pens.Green,
                circumcenter.X - circumradius, circumcenter.Y - circumradius,
                2 * circumradius, 2 * circumradius);
        }

        private Color GetRandomColor()
        {
            return Color.FromArgb(random.Next(0, 255), random.Next(0, 255), random.Next(0, 255));
        }
    }
}
