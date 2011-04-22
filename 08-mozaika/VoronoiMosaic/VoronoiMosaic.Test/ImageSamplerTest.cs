using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using VoronoiMosaic;
using Xunit;

namespace VoronoiMosaic.Test
{
    public class ImageSamplerTest
    {
        private static readonly string DATA_DIR = "../../../Data/";
        private static readonly string RESULTS_DIR = DATA_DIR + "Results/";
        private static readonly string INPUT_IMAGE = "kvetina.jpg";
        private static readonly int SAMPLE_COUNT = 1000;

        [Fact]
        public void UniformSampleImage()
        {
            SampledImage sampledImage = SampleImage(new UniformImageSampler());
            SaveSamplesToFile(sampledImage, "uniform");
            ReconstructImage(sampledImage, new PointVisualizer(), "uniform");
        }

        [Fact]
        public void GaussianSampleImage()
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Reset();
            stopwatch.Start();
            SampledImage sampledImage = SampleImage(new GaussianImageSampler());
            stopwatch.Stop();
            Console.WriteLine("Sampling - elapsed time: {0} ms", stopwatch.ElapsedMilliseconds);

            stopwatch.Reset();
            stopwatch.Start();
            SaveSamplesToFile(sampledImage, "gaussian");
            stopwatch.Stop();
            Console.WriteLine("Saving samples - elapsed time: {0} ms", stopwatch.ElapsedMilliseconds);

            stopwatch.Reset();
            stopwatch.Start();
            ReconstructImage(sampledImage, new PointVisualizer(), "gaussian");
            stopwatch.Stop();
            Console.WriteLine("Visualizing - elapsed time: {0} ms", stopwatch.ElapsedMilliseconds);
        }

        [Fact]
        public void SaveAndLoadSamples()
        {
            SampledImage sampledImage = SampleImage(new UniformImageSampler());
            SaveSamplesToFile(sampledImage, "uniform");
            SampledImage loadedSampledImage = LoadSamplesFromFile("uniform");
            //Assert.Equal(sampledImage, loadedSampledImage);
            ReconstructImage(loadedSampledImage, new PointVisualizer(), "uniform");
        }

        [Fact]
        public void DelaunayVisualize()
        {
            SampledImage sampledImage = SampleImage(new UniformImageSampler());
            ReconstructImage(sampledImage, new DelaunayVisualizer(), "uniform_delaunay");
        }

        private static SampledImage SampleImage(IImageSampler sampler)
        {
            Bitmap image = (Bitmap)Bitmap.FromFile(DATA_DIR + INPUT_IMAGE);
            return sampler.SampleImage(image, SAMPLE_COUNT);
        }

        private static void SaveSamplesToFile(SampledImage sampledImage, string sampler)
        {
            sampledImage.SaveToFile(string.Format("{0}{1}_samples_{2}_{3}.txt", RESULTS_DIR, INPUT_IMAGE, sampler, SAMPLE_COUNT));
        }

        private static SampledImage LoadSamplesFromFile(string sampler)
        {
            return SampledImage.LoadFromFile(string.Format("{0}{1}_samples_{2}_{3}.txt", RESULTS_DIR, INPUT_IMAGE, sampler, SAMPLE_COUNT));
        }

        private static void ReconstructImage(SampledImage sampledImage, ISampledImageVisualizer visualizer, string sampler)
        {
            Bitmap reconstructedImage = visualizer.ReconstructImage(sampledImage);
            reconstructedImage.Save(string.Format("{0}{1}_reconstructed_{2}_{3}.png", RESULTS_DIR, INPUT_IMAGE, sampler, SAMPLE_COUNT));
        }
    }
}
