﻿using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.Text;
using System.Windows.Forms;

namespace VoronoiMosaic.GUI
{
    public partial class MosaicForm : Form
    {
        Bitmap originalImage;
        /// <summary>
        /// A separate original images are needed for processing and showing
        /// within a picture box in order to prevent from concurrent access
        /// from multiple threads.
        /// </summary>
        Bitmap originalImageToShow;
        SampledImage sampledImage;
        Bitmap reconstructedImage;

        VoronoiVisualizer voronoiVisualizer;
        PointVisualizer pointVisualizer;

        UniformImageSampler uniformSampler;
        GaussianImageSampler gaussianSampler;
        HybridGaussianImageSampler hybridGaussianSampler;

        ISampledImageVisualizer visualizer;
        IImageSampler imageSampler;

        ProgressReporter samplingProgress = new ProgressReporter();
        ProgressReporter reconstructionProgress = new ProgressReporter();

        bool shouldZoomPictureBoxes = true;

        public MosaicForm()
        {
            InitializeComponent();

            uniformSampler = new UniformImageSampler() { Progress = samplingProgress };
            gaussianSampler = new GaussianImageSampler() { Progress = samplingProgress };
            hybridGaussianSampler = new HybridGaussianImageSampler()
            {
                Progress = samplingProgress,
                ClusterCount = 10
            };

            voronoiVisualizer = new VoronoiVisualizer(reconstructionProgress);
            pointVisualizer = new PointVisualizer(reconstructionProgress);

            visualizer = voronoiVisualizer;
            imageSampler = uniformSampler;

            SetVoronoiVisualizerOptions();

            this.samplerTypeComboBox.DataSource = System.Enum.GetValues(typeof(ImageSamplerType));
            this.imageVisualizerComboBox.DataSource = System.Enum.GetValues(typeof(VisualizerType));

            samplerTypeComboBox.SelectedIndex = 0;
            imageVisualizerComboBox.SelectedIndex = 0;

            samplingProgress.ProgressChanged += ReportProgress;
            reconstructionProgress.ProgressChanged += ReportProgress;
        }

        #region Private methods

        private void ReportProgress(int progress)
        {
            backgroundWorker.ReportProgress(progress, progress == 0);
        }

        private void SetVoronoiVisualizerOptions()
        {
            showDelaunayCircumcirclesCheckBox.Checked = voronoiVisualizer.DelaunayCircumcirclesEnabled;
            showDelaunayTrianglesCheckBox.Checked = voronoiVisualizer.DelaunayTrianglesEnabled;
            showVoronoiCellsCheckBox.Checked = voronoiVisualizer.VoronoiCellsEnabled;
            showVoronoiCellBordersCheckBox.Checked = voronoiVisualizer.VoronoiCellBordersEnabled;
            showVoronoiVerticesCheckBox.Checked = voronoiVisualizer.VoronoiVerticesEnabled;
            enableAntialiasingCheckBox.Checked = voronoiVisualizer.AntiAliasingEnabled;
            cacheTriangulationCheckBox.Checked = voronoiVisualizer.TriangulationCachingEnabled;
        }

        private void GetVoronoiVisualizerOptions()
        {
            voronoiVisualizer.DelaunayCircumcirclesEnabled = showDelaunayCircumcirclesCheckBox.Checked;
            voronoiVisualizer.DelaunayTrianglesEnabled = showDelaunayTrianglesCheckBox.Checked;
            voronoiVisualizer.VoronoiCellsEnabled = showVoronoiCellsCheckBox.Checked;
            voronoiVisualizer.VoronoiCellBordersEnabled = showVoronoiCellBordersCheckBox.Checked;
            voronoiVisualizer.VoronoiVerticesEnabled = showVoronoiVerticesCheckBox.Checked;
            voronoiVisualizer.AntiAliasingEnabled = enableAntialiasingCheckBox.Checked;
            voronoiVisualizer.TriangulationCachingEnabled = cacheTriangulationCheckBox.Checked;
        }

        private void SetPictureBoxImage(PictureBox pictureBox, Image image)
        {
            pictureBox.Image = image;
            SetPictureBoxSize(pictureBox);
        }

        private void SetPictureBoxesSize()
        {
            SetPictureBoxSize(originalPictureBox);
            SetPictureBoxSize(reconstructedPictureBox);
        }

        private void SetPictureBoxSize(PictureBox pictureBox)
        {
            if ((pictureBox.Image != null) &&
                (pictureBox.Image.Width < pictureBox.Parent.Width) &&
                (pictureBox.Image.Height < pictureBox.Parent.Height))
            {
                pictureBox.SizeMode = PictureBoxSizeMode.CenterImage;
                pictureBox.Dock = DockStyle.Fill;
            }
            else if (shouldZoomPictureBoxes)
            {
                pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
                pictureBox.Dock = DockStyle.Fill;
            }
            else
            {
                pictureBox.SizeMode = PictureBoxSizeMode.AutoSize;
                pictureBox.Dock = DockStyle.None;
            }
        }

        private ImageFormat GetFormatFromFileName(string fileName)
        {
            string fileNameLower = fileName.ToLower();
            if (fileNameLower.EndsWith(".png"))
            {
                return ImageFormat.Png;
            }
            else if (fileNameLower.EndsWith(".jpg") || fileNameLower.EndsWith(".jpeg"))
            {
                return ImageFormat.Jpeg;
            }
            else if (fileNameLower.EndsWith(".gif"))
            {
                return ImageFormat.Gif;
            }
            else if (fileNameLower.EndsWith(".tif") || fileNameLower.EndsWith(".tiff"))
            {
                return ImageFormat.Tiff;
            }
            else if (fileNameLower.EndsWith(".bmp"))
            {
                return ImageFormat.Bmp;
            }
            return ImageFormat.Png;
        }

        private string GetDefaultSampledImageFileName()
        {
            return System.IO.Path.GetFileNameWithoutExtension(
                originalImageOpenFileDialog.FileName) + ".txt";
        }

        private void SetControlsEnabled(bool enabled)
        {
            samplingGroupBox.Enabled = enabled;
            visualizationGroupBox.Enabled = enabled;
        }

        #endregion

        #region Inner classes and enums

        enum VisualizerType
        {
            Voronoi,
            Point,
        }

        enum ImageSamplerType
        {
            Uniform,
            Gaussian,
            [Description("Uniform Gaussian clusters")]
            HybridGaussianUniform,
        }

        class BackgroundWorkerArguments
        {
            public int sampleCount;
            public bool sample;
            public bool reconstruct;

            public BackgroundWorkerArguments(int sampleCount, bool sample, bool reconstruct)
            {
                this.sampleCount = sampleCount;
                this.sample = sample;
                this.reconstruct = reconstruct;
            }
        }

        #endregion

        #region Event handlers

        private void loadButton_Click(object sender, EventArgs e)
        {
            originalImageOpenFileDialog.ShowDialog();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (reconstructedImage != null)
            {
                reconstructedImageSaveFileDialog.ShowDialog();
            }
        }

        private void loadSampledImageButton_Click(object sender, EventArgs e)
        {
            sampledImageOpenFileDialog.ShowDialog();
        }

        private void saveSampledImageButton_Click(object sender, EventArgs e)
        {
            if (sampledImage != null)
            {
                sampledImageSaveFileDialog.FileName = GetDefaultSampledImageFileName();
                sampledImageSaveFileDialog.ShowDialog();
            }
        }

        private void originalImageOpenFileDialog_FileOk(object sender, CancelEventArgs e)
        {
            if (originalImage != null)
            {
                originalImage.Dispose();
            }
            originalImage = (Bitmap)Bitmap.FromFile(originalImageOpenFileDialog.FileName);
            sampledImage = null;
            if (originalImageToShow != null)
            {
                originalImageToShow.Dispose();
            }
            originalImageToShow = (Bitmap)Bitmap.FromFile(originalImageOpenFileDialog.FileName);
            SetPictureBoxImage(originalPictureBox, originalImageToShow);
            SetPictureBoxImage(reconstructedPictureBox, null);
            if (reconstructedImage != null)
            {
                reconstructedImage.Dispose();
            }
            imageTabControl.SelectedIndex = 0;
            progressBar1.Value = 0;
        }

        private void reconstructedImageSaveFileDialog_FileOk(object sender, CancelEventArgs e)
        {
            if (reconstructedImage == null)
            {
                return;
            }
            string fileName = reconstructedImageSaveFileDialog.FileName;
            reconstructedImage.Save(fileName, GetFormatFromFileName(fileName));
        }

        private void sampledImageOpenFileDialog_FileOk(object sender, CancelEventArgs e)
        {
            sampledImage = SampledImage.LoadFromFile(sampledImageOpenFileDialog.FileName);
            progressBar1.Value = 0;
            if (originalImage != null)
            {
                originalImage.Dispose();
                originalImage = null;
            }
            SetPictureBoxImage(originalPictureBox, null);
            if (originalImageToShow != null)
            {
                originalImageToShow.Dispose();
                originalImageToShow = null;
            }
            SetPictureBoxImage(reconstructedPictureBox, null);
            if (reconstructedImage != null)
            {
                reconstructedImage.Dispose();
            }
        }

        private void sampledImageSaveFileDialog_FileOk(object sender, CancelEventArgs e)
        {
            if (sampledImage == null)
            {
                return;
            }
            sampledImage.SaveToFile(sampledImageSaveFileDialog.FileName);
        }

        private void sampleImageButton_Click(object sender, EventArgs e)
        {
            if ((originalImage == null) || backgroundWorker.IsBusy)
            {
                return;
            }
            SetControlsEnabled(false);
            backgroundWorker.RunWorkerAsync(new BackgroundWorkerArguments(
                (int)sampleCountNumeric.Value, true, false));
        }

        private void reconstructImageButton_Click(object sender, EventArgs e)
        {
            if ((sampledImage == null) || backgroundWorker.IsBusy)
            {
                return;
            }
            GetVoronoiVisualizerOptions();
            SetControlsEnabled(false);
            backgroundWorker.RunWorkerAsync(new BackgroundWorkerArguments(0, false, true));
        }

        private void sampleAndReconstructImageButton_Click(object sender, EventArgs e)
        {
            if ((originalImage == null) || backgroundWorker.IsBusy)
            {
                return;
            }
            GetVoronoiVisualizerOptions();
            SetControlsEnabled(false);
            backgroundWorker.RunWorkerAsync(new BackgroundWorkerArguments(
               (int)sampleCountNumeric.Value, true, true));
        }

        private void imageSizeOriginalButton_Click(object sender, EventArgs e)
        {
            shouldZoomPictureBoxes = false;
            SetPictureBoxesSize();
            imageSizeOriginalButton.Font = new Font(imageSizeOriginalButton.Font, FontStyle.Bold);
            imageSizeStretchButton.Font = new Font(imageSizeStretchButton.Font, FontStyle.Regular);
        }

        private void imageSizeStretchButton_Click(object sender, EventArgs e)
        {
            shouldZoomPictureBoxes = true;
            SetPictureBoxesSize();
            imageSizeOriginalButton.Font = new Font(imageSizeOriginalButton.Font, FontStyle.Regular);
            imageSizeStretchButton.Font = new Font(imageSizeStretchButton.Font, FontStyle.Bold);
        }

        private void originalImageTabPage_Resize(object sender, EventArgs e)
        {
            SetPictureBoxSize(originalPictureBox);
        }

        private void reconstructedImageTabPage_Resize(object sender, EventArgs e)
        {
            SetPictureBoxSize(reconstructedPictureBox);
        }

        private void samplerTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch ((ImageSamplerType)samplerTypeComboBox.SelectedValue)
            {
                case ImageSamplerType.Uniform:
                    imageSampler = uniformSampler;
                    samplingClusterCountNumeric.Enabled = false;
                    break;
                case ImageSamplerType.Gaussian:
                    imageSampler = gaussianSampler;
                    samplingClusterCountNumeric.Enabled = false;
                    break;
                case ImageSamplerType.HybridGaussianUniform:
                    imageSampler = hybridGaussianSampler;
                    samplingClusterCountNumeric.Enabled = true;
                    break;
                default:
                    throw new NotImplementedException();
            }
        }

        private void imageVisualizerComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch ((VisualizerType)imageVisualizerComboBox.SelectedValue)
            {
                case VisualizerType.Voronoi:
                    visualizer = voronoiVisualizer;
                    voronoiOptionsGroupBox.Enabled = true;
                    break;
                case VisualizerType.Point:
                    visualizer = pointVisualizer;
                    voronoiOptionsGroupBox.Enabled = false;
                    break;
                default:
                    throw new NotImplementedException();
            }
        }

        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            backgroundWorker.ReportProgress(0);
            BackgroundWorkerArguments args = (BackgroundWorkerArguments)e.Argument;
            if (args.sample)
            {
                sampledImage = imageSampler.SampleImage(originalImage, args.sampleCount);
            }
            if (args.reconstruct)
            {
                e.Result = visualizer.ReconstructImage(sampledImage);
            }
            backgroundWorker.ReportProgress(100);
        }

        private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Result != null)
            {
                if (reconstructedImage != null)
                {
                    reconstructedImage.Dispose();
                }
                reconstructedImage = (Bitmap)e.Result;
                SetPictureBoxImage(reconstructedPictureBox, reconstructedImage);
                imageTabControl.SelectedIndex = 1;
            }
            SetControlsEnabled(true);
            UpdateTimeToStatusBar();
        }

        private void UpdateTimeToStatusBar()
        {
            StringBuilder sb = new StringBuilder();
            long samplingTime = 0;
            if (samplingProgress.TimeReport.ContainsKey("sampler"))
            {
                samplingTime = samplingProgress.TimeReport["sampler"];
                
            }
            sb.AppendFormat("Sampler: {0} ms", samplingTime);
            long delaunayTime = 0;
            if (reconstructionProgress.TimeReport.ContainsKey("delaunay"))
            {
                delaunayTime = reconstructionProgress.TimeReport["delaunay"];
            }
            sb.AppendFormat(", Delaunay triangulation: {0} ms", delaunayTime);
            long reconstructionTime = 0;
            if (reconstructionProgress.TimeReport.ContainsKey("visualizer"))
            {
                reconstructionTime = reconstructionProgress.TimeReport["visualizer"];
            }
            sb.AppendFormat(", Visualization: {0} ms", reconstructionTime);
            sb.AppendFormat(", Total: {0} ms", samplingTime + delaunayTime + reconstructionTime);
            timeToolStripStatusLabel.Text = sb.ToString();
            samplingProgress.TimeReport.Clear();
            reconstructionProgress.TimeReport.Clear();
        }

        private void backgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
            bool? marqueeEnabled = e.UserState as bool?;
            if (marqueeEnabled.HasValue)
            {
                progressBar1.Style = (marqueeEnabled.Value) ?
                    ProgressBarStyle.Marquee : ProgressBarStyle.Blocks;
            }
        }

        #endregion

        private void samplingClusterCountNumeric_ValueChanged(object sender, EventArgs e)
        {
            hybridGaussianSampler.ClusterCount = (int)samplingClusterCountNumeric.Value;
        }
    }
}
