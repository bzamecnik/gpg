using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using VoronoiMosaic;

namespace VoronoiMosaic.GUI
{
    public partial class MosaicForm : Form
    {
        Bitmap originalImage;
        SampledImage sampledImage;
        Bitmap reconstructedImage;
        
        VoronoiVisualizer voronoiVisualizer = new VoronoiVisualizer();
        PointVisualizer pointVisualizer = new PointVisualizer();

        UniformImageSampler uniformSampler = new UniformImageSampler();
        GaussianImageSampler gaussianSampler = new GaussianImageSampler();

        ISampledImageVisualizer visualizer;
        IImageSampler imageSampler;

        bool shouldZoomPictureBoxes = true;

        public MosaicForm()
        {
            InitializeComponent();

            visualizer = voronoiVisualizer;
            imageSampler = uniformSampler;

            SetVoronoiVisualizerOptions();

            samplerTypeComboBox.SelectedIndex = 0;
            imageVisualizerComboBox.SelectedIndex = 0;
        }

        private void SetVoronoiVisualizerOptions()
        {
            showDelaunayCircumcirclesCheckBox.Checked = voronoiVisualizer.DelaunayCircumcirclesEnabled;
            showDelaunayTrianglesCheckBox.Checked = voronoiVisualizer.DelaunayTrianglesEnabled;
            showVoronoiCellsCheckBox.Checked = voronoiVisualizer.VoronoiCellsEnabled;
            showVoronoiCellBordersCheckBox.Checked = voronoiVisualizer.VoronoiCellBordersEnabled;
            showVoronoiVerticesCheckBox.Checked = voronoiVisualizer.VoronoiVerticesEnabled;
            enableAntialiasingCheckBox.Checked = voronoiVisualizer.AntiAliasingEnabled;
        }

        private void GetVoronoiVisualizerOptions()
        {
            voronoiVisualizer.DelaunayCircumcirclesEnabled = showDelaunayCircumcirclesCheckBox.Checked;
            voronoiVisualizer.DelaunayTrianglesEnabled = showDelaunayTrianglesCheckBox.Checked;
            voronoiVisualizer.VoronoiCellsEnabled = showVoronoiCellsCheckBox.Checked;
            voronoiVisualizer.VoronoiCellBordersEnabled = showVoronoiCellBordersCheckBox.Checked;
            voronoiVisualizer.VoronoiVerticesEnabled = showVoronoiVerticesCheckBox.Checked;
            voronoiVisualizer.AntiAliasingEnabled = enableAntialiasingCheckBox.Checked;
        }

        private void SampleImage()
        {
            sampledImage = imageSampler.SampleImage(originalImage, (int)sampleCountNumeric.Value);
        }

        private void ReconstructImage()
        {
            if (sampledImage == null)
            {
                return;
            }
            if (reconstructedImage != null)
            {
                reconstructedImage.Dispose();
            }
            GetVoronoiVisualizerOptions();
            reconstructedImage = visualizer.ReconstructImage(sampledImage);
            SetPictureBoxImage(reconstructedPictureBox, reconstructedImage);
            imageTabControl.SelectedIndex = 1;
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

        #region Event handlers

        private void loadButton_Click(object sender, EventArgs e)
        {
            originalImageOpenFileDialog.ShowDialog();
            imageTabControl.SelectedIndex = 0;
        }

        private void originalImageOpenFileDialog_FileOk(object sender, CancelEventArgs e)
        {
            if (originalImage != null)
            {
                originalImage.Dispose();
            }
            originalImage = (Bitmap)Bitmap.FromFile(originalImageOpenFileDialog.FileName);
            SetPictureBoxImage(originalPictureBox, originalImage);
        }

        private void sampleImageButton_Click(object sender, EventArgs e)
        {
            SampleImage();
        }

        private void reconstructImageButton_Click(object sender, EventArgs e)
        {
            ReconstructImage();
        }

        private void sampleAndReconstructImageButton_Click(object sender, EventArgs e)
        {
            SampleImage();
            ReconstructImage();
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

        #endregion
    }
}
