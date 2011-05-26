using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using OpenTK;

namespace VoronoiMosaic
{
    public struct ImageSample : IEquatable<ImageSample>
    {
        public Vector2 position;
        public Color color;

        public int X { get { return (int)position.X; } }
        public int Y { get { return (int)position.Y; } }

        public ImageSample(int x, int y, Color color)
            : this(new Vector2(x, y), color)
        {
        }

        public ImageSample(Vector2 position, Color color)
        {
            this.position = position;
            this.color = color;
        }

        public bool Equals(ImageSample other)
        {
            if (other == null)
            {
                return false;
            }

            return this.position.Equals(other.position) && this.color.Equals(other.color);
        }

        // override object.Equals
        public override bool Equals(object obj)
        {
            //       
            // See the full list of guidelines at
            //   http://go.microsoft.com/fwlink/?LinkID=85237  
            // and also the guidance for operator== at
            //   http://go.microsoft.com/fwlink/?LinkId=85238
            //

            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            return Equals((ImageSample)obj);
        }

        public override int GetHashCode()
        {
            return position.GetHashCode() ^ color.GetHashCode();
        }

        public static bool operator ==(ImageSample sample1, ImageSample sample2)
        {
            if (object.ReferenceEquals(sample1, sample2)) return true;
            if (object.ReferenceEquals(sample1, null)) return false;
            if (object.ReferenceEquals(sample2, null)) return false;

            return sample1.Equals(sample2);
        }

        public static bool operator !=(ImageSample sample1, ImageSample sample2)
        {
            if (object.ReferenceEquals(sample1, sample2)) return false;
            if (object.ReferenceEquals(sample1, null)) return true;
            if (object.ReferenceEquals(sample2, null)) return true;

            return !sample1.Equals(sample2);
        }
    }
}
