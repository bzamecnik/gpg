using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;

namespace VoronoiMosaic
{
    public class SampledImage
    {
        public ICollection<ImageSample> Samples { get; private set; }

        public SampledImage()
        {
            Samples = new HashSet<ImageSample>();
        }

        public int Width { get; set; }
        
        public int Height { get; set; }

        public void AddSample(ImageSample sample) {
            Samples.Add(sample);
        }

        public void SaveToFile(string fileName) {
            using (StreamWriter writer = new StreamWriter(fileName))
            {
                writer.WriteLine(Width);
                writer.WriteLine(Height);
                foreach (ImageSample sample in Samples)
                {
                    writer.WriteLine("{0} {1} {2}", sample.X, sample.Y, sample.color.ToArgb());
                }
            }
        }

        public static SampledImage LoadFromFile(string fileName)
        {
            SampledImage sampledImage = new SampledImage();
            using (StreamReader reader = new StreamReader(fileName))
            {
                try
                {
                    sampledImage.Width = Int32.Parse(reader.ReadLine());
                    sampledImage.Height = Int32.Parse(reader.ReadLine());

                    string line = reader.ReadLine();
                    while ((line != null) && (line.Length != 0))
                    {
                        string[] sampleFields = line.Split(new char[] { ' ' }, 3);
                        int x = Int32.Parse(sampleFields[0]);
                        int y = Int32.Parse(sampleFields[1]);
                        int argb = Int32.Parse(sampleFields[2]);
                        Color color = Color.FromArgb(argb);
                        sampledImage.AddSample(new ImageSample(x, y, color));
                        line = reader.ReadLine();
                    }
                }
                catch (FormatException ex)
                {
                    Console.Error.WriteLine(ex.Message);
                    return null;
                }
            }

            return sampledImage;
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

            SampledImage other = (SampledImage)obj;
            return (this.Width == other.Width) && (this.Height == other.Height) &&
                this.Samples.Equals(other.Samples);
        }

        // override object.GetHashCode
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
