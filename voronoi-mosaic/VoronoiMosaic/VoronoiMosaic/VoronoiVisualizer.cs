using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using OpenTK;
using Poly2Tri;

namespace VoronoiMosaic
{
    public class VoronoiVisualizer : ISampledImageVisualizer
    {
        public bool VoronoiCellsEnabled { get; set; }
        public bool VoronoiCellBordersEnabled { get; set; }
        public bool DelaunayTrianglesEnabled { get; set; }
        public bool VoronoiVerticesEnabled { get; set; }
        public bool DelaunayCircumcirclesEnabled { get; set; }
        public bool AntiAliasingEnabled { get; set; }
        public bool TriangulationCachingEnabled { get; set; }
        public ProgressReporter Progress { get; private set; }

        private Random random = new Random();

        private VoronoiHelper voronoiHelper;

        private SampledImage previousSampledImage;
        /// <summary>
        /// Cached Delaunay triangulation of the previously sampled image.
        /// </summary>
        private PointSet previousTriMesh;

        public VoronoiVisualizer()
            : this(new ProgressReporter())
        {
        }

        public VoronoiVisualizer(ProgressReporter progress)
        {
            VoronoiCellsEnabled = true;
            TriangulationCachingEnabled = true;
            Progress = progress;
            voronoiHelper = new VoronoiHelper(progress);
        }

        public Bitmap ReconstructImage(SampledImage sampledImage)
        {
            int width = sampledImage.Width;
            int height = sampledImage.Height;
            Bitmap image = new Bitmap(width, height);

            Progress.ReportProgress(0);

            Stopwatch stopwatch = Stopwatch.StartNew();

            // use cached triangulation if possible
            PointSet triMesh =
                (TriangulationCachingEnabled && sampledImage.Equals(previousSampledImage)) ?
                    previousTriMesh : voronoiHelper.MakeDelaunayTriangulation(sampledImage);

            stopwatch.Stop();
            Progress.TimeReport["delaunay"] = stopwatch.ElapsedMilliseconds;

            previousTriMesh = triMesh;
            previousSampledImage = sampledImage;

            Progress.ReportProgress(25);

            stopwatch.Reset();
            stopwatch.Start();

            using (Graphics graphics = Graphics.FromImage(image))
            {
                // fill with black background
                //graphics.FillRectangle(Brushes.White, 0, 0, width, height);

                graphics.SmoothingMode = AntiAliasingEnabled ?
                    System.Drawing.Drawing2D.SmoothingMode.AntiAlias :
                    System.Drawing.Drawing2D.SmoothingMode.None;

                if (VoronoiCellsEnabled)
                {
                    DrawVoronoiCells(triMesh, graphics, sampledImage);
                }

                Progress.ReportProgress(50);

                if (DelaunayTrianglesEnabled)
                {
                    DrawDelaunayTriangles(triMesh, graphics);
                }

                Progress.ReportProgress(75);

                DrawAdditionalFeatures(width, height, triMesh, graphics, image);

                Progress.ReportProgress(100);
            }
            Progress.TimeReport["visualizer"] = stopwatch.ElapsedMilliseconds;

            return image;
        }

        private void DrawDelaunayTriangles(PointSet triMesh, Graphics graphics)
        {
            int samplePercent = 4 * triMesh.Triangles.Count / 100;
            int trianglesDone = 0;
            int percentDone = 0;

            foreach (DelaunayTriangle triangle in triMesh.Triangles)
            {
                // draw Delaunay triangulation
                PointF[] points = triangle.ToPointFArray();
                graphics.DrawPolygon(Pens.Black, points);

                trianglesDone++;
                if ((samplePercent > 500) && (trianglesDone % samplePercent == 0))
                {
                    percentDone++;
                    Progress.ReportProgress(50 + percentDone);
                }
            }
        }

        private void DrawVoronoiCells(PointSet triMesh, Graphics graphics, SampledImage sampledImage)
        {
            int samplePercent = 4 * triMesh.Triangles.Count / 100;
            int trianglesDone = 0;
            int percentDone = 0;

            // Voronoi cell which have already been drawn onto the image
            HashSet<Vector2> drawnVoronoiCells = new HashSet<Vector2>();

            foreach (DelaunayTriangle triangle in triMesh.Triangles)
            {
                // draw Voronoi cells, one around each Delaunay triangle vertex
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

                    //Color sampleColor = GetRandomColor();
                    ImageSample imageSample;
                    Color sampleColor = Color.Pink;  // DEBUG
                    if (sampledImage.SampleMap.TryGetValue((int)triVertex.Y * sampledImage.Width + (int)triVertex.X, out imageSample))
                    {
                        sampleColor = imageSample.color;
                    }
                    graphics.FillPolygon(new SolidBrush(sampleColor), voronoiCellPolygon);
                    if (VoronoiCellBordersEnabled)
                    {
                        graphics.DrawPolygon(Pens.Gray, voronoiCellPolygon);
                    }
                }
                trianglesDone++;
                if ((samplePercent > 500) && (trianglesDone % samplePercent == 0))
                {
                    percentDone++;
                    Progress.ReportProgress(25 + percentDone);
                }
            }
        }

        private void DrawAdditionalFeatures(int width, int height, PointSet triMesh, Graphics graphics, Bitmap image)
        {
            int samplePercent = 4 * triMesh.Triangles.Count / 100;
            int trianglesDone = 0;
            int percentDone = 0;

            if (VoronoiVerticesEnabled || DelaunayCircumcirclesEnabled)
            {
                foreach (DelaunayTriangle triangle in triMesh.Triangles)
                {

                    Vector2 voronoiVertex = VoronoiHelper.GetCircumcenter(triangle);
                    if (VoronoiVerticesEnabled)
                    {
                        DrawVoronoiVertex(width, height, voronoiVertex, graphics, image);
                    }
                    if (DelaunayCircumcirclesEnabled)
                    {
                        DrawDelaunayCircumcircles(triangle, voronoiVertex, graphics);
                    }

                    trianglesDone++;
                    if ((samplePercent > 500) && (trianglesDone % samplePercent == 0))
                    {
                        percentDone++;
                        Progress.ReportProgress(75 + percentDone);
                    }
                }
            }
        }

        private static void DrawVoronoiVertex(int width, int height, Vector2 voronoiVertex, Graphics graphics, Bitmap image)
        {
            int x = (int)voronoiVertex.X;
            int y = (int)voronoiVertex.Y;
            if ((x >= 0) && (x < width) && (y >= 0) && (y < height))
            {
                //image.SetPixel((int)x, (int)y, Color.Red);
                graphics.FillRectangle(Brushes.Red, x - 1, y - 1, 2, 2);
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
