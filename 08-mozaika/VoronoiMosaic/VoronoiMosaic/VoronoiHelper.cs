using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using OpenTK;
using Poly2Tri;

namespace VoronoiMosaic
{
    class VoronoiHelper
    {
        public static PointSet MakeDelaunayTriangulation(SampledImage sampledImage)
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>();
            foreach (ImageSample sample in sampledImage.Samples)
            {
                points.Add(new TriangulationPoint(sample.position.X, sample.position.Y));
            }

            int width = sampledImage.Width;
            int height = sampledImage.Height;

            // add a bounding box in order to make Voronoi cells bounded
            // inside the image
            points.Add(new TriangulationPoint(-width, -height));
            points.Add(new TriangulationPoint(-width, 2 * height));
            points.Add(new TriangulationPoint(2 * width, 2 * height));
            points.Add(new TriangulationPoint(2 * width, -height));

            return MakeDelaunayTriangulation(points);
        }

        public static PointSet MakeDelaunayTriangulation(List<TriangulationPoint> points)
        {
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

        public static IList<DelaunayTriangle> GetSurroundingTriangles(
            DelaunayTriangle triangle,
            TriangulationPoint point)
        {
            IList<DelaunayTriangle> surroundingTriangles = new List<DelaunayTriangle>();

            DelaunayTriangle startTriangle = triangle;
            DelaunayTriangle currentTriangle = triangle;
            do
            {
                surroundingTriangles.Add(currentTriangle);
                currentTriangle = currentTriangle.NeighborCWFrom(point);
            } while ((currentTriangle != null) && (currentTriangle != startTriangle));

            return surroundingTriangles;
        }

        public static Vector2 GetCircumcenter(DelaunayTriangle triangle)
        {
            Vector2 a = triangle.Points[0].ToVector2();
            Vector2 b = triangle.Points[1].ToVector2();
            Vector2 c = triangle.Points[2].ToVector2();
            return GetCircumcenter(a, b, c);
        }

        /// <summary>
        /// Computes position of the center of the circumscribed circle of the
        /// triangle (A, B, C).
        /// </summary>
        /// <remarks>
        /// Source: http://en.wikipedia.org/wiki/Circumscribed_circle
        /// </remarks>
        /// <param name="a">triangle vertex A</param>
        /// <param name="b">triangle vertex B</param>
        /// <param name="c">triangle vertex C</param>
        /// <returns></returns>
        public static Vector2 GetCircumcenter(Vector2 a, Vector2 b, Vector2 c)
        {
            //float aNormSq = a.X * a.X + a.Y * a.Y;
            //float bNormSq = b.X * b.X + b.Y * b.Y;
            //float cNormSq = c.X * c.X + c.Y * c.Y;

            //float dInv = 1 / (2 * (a.X * (b.Y - c.Y) + b.X * (c.Y - a.Y) + c.X * (a.Y - b.Y)));

            //return new Vector2(
            //    (aNormSq * (b.Y - c.Y) + bNormSq * (c.Y - a.Y) + cNormSq * (a.Y - b.Y)) * dInv,
            //    (aNormSq * (b.X - c.X) + bNormSq * (c.X - a.X) + cNormSq * (a.X - b.X)) * dInv);

            // translate the triangle by -A in order to simplify the formulas
            b = b - a;
            c = c - a;

            //float bNormSq = b.X * b.X + b.Y * b.Y;
            //float cNormSq = c.X * c.X + c.Y * c.Y;
            float bNormSq = b.LengthSquared;
            float cNormSq = c.LengthSquared;

            float dInv = 1 / (2 * (b.X * c.Y - b.Y * c.X));
            Vector2 circumcenter = a + new Vector2(
                ((c.Y * bNormSq - b.Y * cNormSq) * dInv),
                ((b.X * cNormSq - c.X * bNormSq) * dInv));

            return circumcenter;
        }

        public static float GetCircumradius(DelaunayTriangle triangle)
        {
            Vector2 a = triangle.Points[0].ToVector2();
            Vector2 b = triangle.Points[1].ToVector2();
            Vector2 c = triangle.Points[2].ToVector2();
            return GetCircumradius(a, b, c);
        }

        /// <summary>
        /// Computes radius of the circumscribed circle of the triangle (A, B, C).
        /// </summary>
        /// <remarks>
        /// Source: http://en.wikipedia.org/wiki/Circumscribed_circle
        /// </remarks>
        /// <param name="a">triangle vertex A</param>
        /// <param name="b">triangle vertex B</param>
        /// <param name="c">triangle vertex C</param>
        public static float GetCircumradius(Vector2 a, Vector2 b, Vector2 c)
        {
            // compute circumscribed circle radius
            float aLen = (b - c).Length;
            float bLen = (c - a).Length;
            float cLen = (a - b).Length;
            return (float)(aLen * bLen * cLen / Math.Sqrt(
                (aLen + bLen + cLen) * (bLen + cLen - aLen) *
                (cLen + aLen - bLen) * (aLen + bLen - cLen)
                ));
        }

        /// <summary>
        /// Computes position of the center of the circumscribed circle of the
        /// triangle (a, b, c).
        /// </summary>
        /// <remarks>
        /// The formulas use barycentric coordinates. Source:
        /// http://en.wikipedia.org/wiki/Circumscribed_circle
        /// Also the triangle vertices are represented in 3D Euclidean space.
        /// </remarks>
        /// <param name="vertexA"></param>
        /// <param name="vertexB"></param>
        /// <param name="vertexC"></param>
        /// <returns></returns>
        private static Vector2 GetCircumcenterUsing3dProducts(Vector2 vertexA, Vector2 vertexB, Vector2 vertexC)
        {
            // convert to homogeneous (z = 1)
            Vector3 a = new Vector3(vertexA.X, vertexA.Y, 1);
            Vector3 b = new Vector3(vertexB.X, vertexB.Y, 1);
            Vector3 c  = new Vector3(vertexC.X, vertexC.Y, 1);

            Vector3 aMinusB = a - b;
            Vector3 bMinusC = b - c;
            Vector3 cMinusA = c - a;
            
            float normalizationFactor = Vector3.Cross(aMinusB, bMinusC).Length;
            normalizationFactor = 1 / (2 * normalizationFactor * normalizationFactor);

            Vector3 aMinusC = a - c;
            Vector3 cMinusB = c - b;
            Vector3 bMinusA = b - a;

            float alpha = bMinusC.Length * bMinusC.Length * Vector3.Dot(aMinusB, aMinusC);
            float beta = aMinusC.Length * aMinusC.Length * Vector3.Dot(bMinusA, bMinusC);
            float gamma = cMinusA.Length * cMinusA.Length * Vector3.Dot(cMinusA, cMinusB);
            
            // circumcenter is a linear combination of triangle vertices
            Vector3 circumcenter = alpha * a + beta * b + gamma  * c;
            
            // convert back from homogeneous form
            // TODO: is it ok/needed?
            circumcenter.X /= circumcenter.Z;
            circumcenter.Y /= circumcenter.Z;
            return circumcenter.Xy;
        }

        
    }
}
