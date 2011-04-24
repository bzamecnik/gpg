namespace VoronoiMosaic.GUI
{
    partial class MosaicForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.imageSizeStretchButton = new System.Windows.Forms.Button();
            this.imageSizeOriginalButton = new System.Windows.Forms.Button();
            this.visualizationGroupBox = new System.Windows.Forms.GroupBox();
            this.reconstructImageButton = new System.Windows.Forms.Button();
            this.voronoiOptionsGroupBox = new System.Windows.Forms.GroupBox();
            this.cacheTriangulationCheckBox = new System.Windows.Forms.CheckBox();
            this.showVoronoiCellsCheckBox = new System.Windows.Forms.CheckBox();
            this.showDelaunayTrianglesCheckBox = new System.Windows.Forms.CheckBox();
            this.enableAntialiasingCheckBox = new System.Windows.Forms.CheckBox();
            this.showVoronoiVerticesCheckBox = new System.Windows.Forms.CheckBox();
            this.showVoronoiCellBordersCheckBox = new System.Windows.Forms.CheckBox();
            this.showDelaunayCircumcirclesCheckBox = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.sampleAndReconstructImageButton = new System.Windows.Forms.Button();
            this.imageVisualizerComboBox = new System.Windows.Forms.ComboBox();
            this.samplingGroupBox = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.sampleCountNumeric = new System.Windows.Forms.NumericUpDown();
            this.sampleImageButton = new System.Windows.Forms.Button();
            this.samplerTypeComboBox = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.saveSampledImageButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.loadSampledImageButton = new System.Windows.Forms.Button();
            this.loadButton = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.imageTabControl = new System.Windows.Forms.TabControl();
            this.originalImageTabPage = new System.Windows.Forms.TabPage();
            this.originalPictureBox = new System.Windows.Forms.PictureBox();
            this.reconstructedImagetabPage = new System.Windows.Forms.TabPage();
            this.reconstructedPictureBox = new System.Windows.Forms.PictureBox();
            this.originalImageOpenFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.reconstructedImageSaveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.sampledImageOpenFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.sampledImageSaveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.backgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.visualizationGroupBox.SuspendLayout();
            this.voronoiOptionsGroupBox.SuspendLayout();
            this.samplingGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sampleCountNumeric)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.imageTabControl.SuspendLayout();
            this.originalImageTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.originalPictureBox)).BeginInit();
            this.reconstructedImagetabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.reconstructedPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.AutoScroll = true;
            this.splitContainer1.Panel1.Controls.Add(this.groupBox5);
            this.splitContainer1.Panel1.Controls.Add(this.visualizationGroupBox);
            this.splitContainer1.Panel1.Controls.Add(this.samplingGroupBox);
            this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
            this.splitContainer1.Panel1MinSize = 220;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.progressBar1);
            this.splitContainer1.Panel2.Controls.Add(this.imageTabControl);
            this.splitContainer1.Size = new System.Drawing.Size(869, 599);
            this.splitContainer1.SplitterDistance = 220;
            this.splitContainer1.TabIndex = 0;
            // 
            // groupBox5
            // 
            this.groupBox5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox5.Controls.Add(this.label4);
            this.groupBox5.Controls.Add(this.imageSizeStretchButton);
            this.groupBox5.Controls.Add(this.imageSizeOriginalButton);
            this.groupBox5.Location = new System.Drawing.Point(3, 549);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(214, 46);
            this.groupBox5.TabIndex = 13;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Viewing";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 21);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Image size:";
            // 
            // imageSizeStretchButton
            // 
            this.imageSizeStretchButton.AutoSize = true;
            this.imageSizeStretchButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.imageSizeStretchButton.Location = new System.Drawing.Point(140, 16);
            this.imageSizeStretchButton.Margin = new System.Windows.Forms.Padding(0);
            this.imageSizeStretchButton.Name = "imageSizeStretchButton";
            this.imageSizeStretchButton.Size = new System.Drawing.Size(68, 23);
            this.imageSizeStretchButton.TabIndex = 11;
            this.imageSizeStretchButton.Text = "<->";
            this.imageSizeStretchButton.UseVisualStyleBackColor = true;
            this.imageSizeStretchButton.Click += new System.EventHandler(this.imageSizeStretchButton_Click);
            // 
            // imageSizeOriginalButton
            // 
            this.imageSizeOriginalButton.AutoSize = true;
            this.imageSizeOriginalButton.Location = new System.Drawing.Point(69, 16);
            this.imageSizeOriginalButton.Margin = new System.Windows.Forms.Padding(0);
            this.imageSizeOriginalButton.Name = "imageSizeOriginalButton";
            this.imageSizeOriginalButton.Size = new System.Drawing.Size(68, 23);
            this.imageSizeOriginalButton.TabIndex = 10;
            this.imageSizeOriginalButton.Text = "1:1";
            this.imageSizeOriginalButton.UseVisualStyleBackColor = true;
            this.imageSizeOriginalButton.Click += new System.EventHandler(this.imageSizeOriginalButton_Click);
            // 
            // visualizationGroupBox
            // 
            this.visualizationGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.visualizationGroupBox.Controls.Add(this.reconstructImageButton);
            this.visualizationGroupBox.Controls.Add(this.voronoiOptionsGroupBox);
            this.visualizationGroupBox.Controls.Add(this.label3);
            this.visualizationGroupBox.Controls.Add(this.sampleAndReconstructImageButton);
            this.visualizationGroupBox.Controls.Add(this.imageVisualizerComboBox);
            this.visualizationGroupBox.Location = new System.Drawing.Point(3, 253);
            this.visualizationGroupBox.Name = "visualizationGroupBox";
            this.visualizationGroupBox.Size = new System.Drawing.Size(214, 290);
            this.visualizationGroupBox.TabIndex = 2;
            this.visualizationGroupBox.TabStop = false;
            this.visualizationGroupBox.Text = "Image reconstruction / visualization";
            // 
            // reconstructImageButton
            // 
            this.reconstructImageButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.reconstructImageButton.Location = new System.Drawing.Point(9, 230);
            this.reconstructImageButton.Name = "reconstructImageButton";
            this.reconstructImageButton.Size = new System.Drawing.Size(199, 23);
            this.reconstructImageButton.TabIndex = 8;
            this.reconstructImageButton.Text = "Reconstruct sampled image";
            this.reconstructImageButton.UseVisualStyleBackColor = true;
            this.reconstructImageButton.Click += new System.EventHandler(this.reconstructImageButton_Click);
            // 
            // voronoiOptionsGroupBox
            // 
            this.voronoiOptionsGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.voronoiOptionsGroupBox.Controls.Add(this.cacheTriangulationCheckBox);
            this.voronoiOptionsGroupBox.Controls.Add(this.showVoronoiCellsCheckBox);
            this.voronoiOptionsGroupBox.Controls.Add(this.showDelaunayTrianglesCheckBox);
            this.voronoiOptionsGroupBox.Controls.Add(this.enableAntialiasingCheckBox);
            this.voronoiOptionsGroupBox.Controls.Add(this.showVoronoiVerticesCheckBox);
            this.voronoiOptionsGroupBox.Controls.Add(this.showVoronoiCellBordersCheckBox);
            this.voronoiOptionsGroupBox.Controls.Add(this.showDelaunayCircumcirclesCheckBox);
            this.voronoiOptionsGroupBox.Location = new System.Drawing.Point(9, 46);
            this.voronoiOptionsGroupBox.Name = "voronoiOptionsGroupBox";
            this.voronoiOptionsGroupBox.Size = new System.Drawing.Size(199, 178);
            this.voronoiOptionsGroupBox.TabIndex = 7;
            this.voronoiOptionsGroupBox.TabStop = false;
            this.voronoiOptionsGroupBox.Text = "Voronoi diagram options";
            // 
            // cacheTriangulationCheckBox
            // 
            this.cacheTriangulationCheckBox.AutoSize = true;
            this.cacheTriangulationCheckBox.Location = new System.Drawing.Point(6, 157);
            this.cacheTriangulationCheckBox.Name = "cacheTriangulationCheckBox";
            this.cacheTriangulationCheckBox.Size = new System.Drawing.Size(184, 17);
            this.cacheTriangulationCheckBox.TabIndex = 1;
            this.cacheTriangulationCheckBox.Text = "Cache last Delaunay triangulation";
            this.cacheTriangulationCheckBox.UseVisualStyleBackColor = true;
            // 
            // showVoronoiCellsCheckBox
            // 
            this.showVoronoiCellsCheckBox.AutoSize = true;
            this.showVoronoiCellsCheckBox.Checked = true;
            this.showVoronoiCellsCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.showVoronoiCellsCheckBox.Location = new System.Drawing.Point(6, 19);
            this.showVoronoiCellsCheckBox.Name = "showVoronoiCellsCheckBox";
            this.showVoronoiCellsCheckBox.Size = new System.Drawing.Size(116, 17);
            this.showVoronoiCellsCheckBox.TabIndex = 0;
            this.showVoronoiCellsCheckBox.Text = "Show Voronoi cells";
            this.showVoronoiCellsCheckBox.UseVisualStyleBackColor = true;
            // 
            // showDelaunayTrianglesCheckBox
            // 
            this.showDelaunayTrianglesCheckBox.AutoSize = true;
            this.showDelaunayTrianglesCheckBox.Location = new System.Drawing.Point(6, 42);
            this.showDelaunayTrianglesCheckBox.Name = "showDelaunayTrianglesCheckBox";
            this.showDelaunayTrianglesCheckBox.Size = new System.Drawing.Size(143, 17);
            this.showDelaunayTrianglesCheckBox.TabIndex = 0;
            this.showDelaunayTrianglesCheckBox.Text = "Show Delaunay triangles";
            this.showDelaunayTrianglesCheckBox.UseVisualStyleBackColor = true;
            // 
            // enableAntialiasingCheckBox
            // 
            this.enableAntialiasingCheckBox.AutoSize = true;
            this.enableAntialiasingCheckBox.Location = new System.Drawing.Point(6, 134);
            this.enableAntialiasingCheckBox.Name = "enableAntialiasingCheckBox";
            this.enableAntialiasingCheckBox.Size = new System.Drawing.Size(103, 17);
            this.enableAntialiasingCheckBox.TabIndex = 0;
            this.enableAntialiasingCheckBox.Text = "Use anti-aliasing";
            this.enableAntialiasingCheckBox.UseVisualStyleBackColor = true;
            // 
            // showVoronoiVerticesCheckBox
            // 
            this.showVoronoiVerticesCheckBox.AutoSize = true;
            this.showVoronoiVerticesCheckBox.Location = new System.Drawing.Point(6, 65);
            this.showVoronoiVerticesCheckBox.Name = "showVoronoiVerticesCheckBox";
            this.showVoronoiVerticesCheckBox.Size = new System.Drawing.Size(132, 17);
            this.showVoronoiVerticesCheckBox.TabIndex = 0;
            this.showVoronoiVerticesCheckBox.Text = "Show Voronoi vertices";
            this.showVoronoiVerticesCheckBox.UseVisualStyleBackColor = true;
            // 
            // showVoronoiCellBordersCheckBox
            // 
            this.showVoronoiCellBordersCheckBox.AutoSize = true;
            this.showVoronoiCellBordersCheckBox.Location = new System.Drawing.Point(6, 111);
            this.showVoronoiCellBordersCheckBox.Name = "showVoronoiCellBordersCheckBox";
            this.showVoronoiCellBordersCheckBox.Size = new System.Drawing.Size(166, 17);
            this.showVoronoiCellBordersCheckBox.TabIndex = 0;
            this.showVoronoiCellBordersCheckBox.Text = "Show borders of Voronoi cells";
            this.showVoronoiCellBordersCheckBox.UseVisualStyleBackColor = true;
            // 
            // showDelaunayCircumcirclesCheckBox
            // 
            this.showDelaunayCircumcirclesCheckBox.AutoSize = true;
            this.showDelaunayCircumcirclesCheckBox.Location = new System.Drawing.Point(6, 88);
            this.showDelaunayCircumcirclesCheckBox.Name = "showDelaunayCircumcirclesCheckBox";
            this.showDelaunayCircumcirclesCheckBox.Size = new System.Drawing.Size(165, 17);
            this.showDelaunayCircumcirclesCheckBox.TabIndex = 0;
            this.showDelaunayCircumcirclesCheckBox.Text = "Show Delaunay circumcircles";
            this.showDelaunayCircumcirclesCheckBox.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Method:";
            // 
            // sampleAndReconstructImageButton
            // 
            this.sampleAndReconstructImageButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.sampleAndReconstructImageButton.Location = new System.Drawing.Point(9, 259);
            this.sampleAndReconstructImageButton.Name = "sampleAndReconstructImageButton";
            this.sampleAndReconstructImageButton.Size = new System.Drawing.Size(199, 23);
            this.sampleAndReconstructImageButton.TabIndex = 2;
            this.sampleAndReconstructImageButton.Text = "Sample and reconstruct image";
            this.sampleAndReconstructImageButton.UseVisualStyleBackColor = true;
            this.sampleAndReconstructImageButton.Click += new System.EventHandler(this.sampleAndReconstructImageButton_Click);
            // 
            // imageVisualizerComboBox
            // 
            this.imageVisualizerComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.imageVisualizerComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.imageVisualizerComboBox.FormattingEnabled = true;
            this.imageVisualizerComboBox.Location = new System.Drawing.Point(61, 19);
            this.imageVisualizerComboBox.Name = "imageVisualizerComboBox";
            this.imageVisualizerComboBox.Size = new System.Drawing.Size(147, 21);
            this.imageVisualizerComboBox.TabIndex = 5;
            this.imageVisualizerComboBox.SelectedIndexChanged += new System.EventHandler(this.imageVisualizerComboBox_SelectedIndexChanged);
            // 
            // samplingGroupBox
            // 
            this.samplingGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.samplingGroupBox.Controls.Add(this.label2);
            this.samplingGroupBox.Controls.Add(this.label1);
            this.samplingGroupBox.Controls.Add(this.sampleCountNumeric);
            this.samplingGroupBox.Controls.Add(this.sampleImageButton);
            this.samplingGroupBox.Controls.Add(this.samplerTypeComboBox);
            this.samplingGroupBox.Location = new System.Drawing.Point(3, 147);
            this.samplingGroupBox.Name = "samplingGroupBox";
            this.samplingGroupBox.Size = new System.Drawing.Size(214, 100);
            this.samplingGroupBox.TabIndex = 1;
            this.samplingGroupBox.TabStop = false;
            this.samplingGroupBox.Text = "Image sampling";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Method:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Number of samples:";
            // 
            // sampleCountNumeric
            // 
            this.sampleCountNumeric.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.sampleCountNumeric.Location = new System.Drawing.Point(115, 47);
            this.sampleCountNumeric.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.sampleCountNumeric.Name = "sampleCountNumeric";
            this.sampleCountNumeric.Size = new System.Drawing.Size(93, 20);
            this.sampleCountNumeric.TabIndex = 2;
            this.sampleCountNumeric.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            // 
            // sampleImageButton
            // 
            this.sampleImageButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.sampleImageButton.Location = new System.Drawing.Point(9, 73);
            this.sampleImageButton.Name = "sampleImageButton";
            this.sampleImageButton.Size = new System.Drawing.Size(199, 23);
            this.sampleImageButton.TabIndex = 1;
            this.sampleImageButton.Text = "Sample image";
            this.sampleImageButton.UseVisualStyleBackColor = true;
            this.sampleImageButton.Click += new System.EventHandler(this.sampleImageButton_Click);
            // 
            // samplerTypeComboBox
            // 
            this.samplerTypeComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.samplerTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.samplerTypeComboBox.FormattingEnabled = true;
            this.samplerTypeComboBox.Location = new System.Drawing.Point(61, 20);
            this.samplerTypeComboBox.Name = "samplerTypeComboBox";
            this.samplerTypeComboBox.Size = new System.Drawing.Size(147, 21);
            this.samplerTypeComboBox.TabIndex = 0;
            this.samplerTypeComboBox.SelectedIndexChanged += new System.EventHandler(this.samplerTypeComboBox_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.saveSampledImageButton);
            this.groupBox1.Controls.Add(this.saveButton);
            this.groupBox1.Controls.Add(this.loadSampledImageButton);
            this.groupBox1.Controls.Add(this.loadButton);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(214, 138);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "File control";
            // 
            // saveSampledImageButton
            // 
            this.saveSampledImageButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.saveSampledImageButton.Location = new System.Drawing.Point(9, 106);
            this.saveSampledImageButton.Name = "saveSampledImageButton";
            this.saveSampledImageButton.Size = new System.Drawing.Size(199, 23);
            this.saveSampledImageButton.TabIndex = 1;
            this.saveSampledImageButton.Text = "Save sampled image";
            this.saveSampledImageButton.UseVisualStyleBackColor = true;
            this.saveSampledImageButton.Click += new System.EventHandler(this.saveSampledImageButton_Click);
            // 
            // saveButton
            // 
            this.saveButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.saveButton.Location = new System.Drawing.Point(9, 48);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(199, 23);
            this.saveButton.TabIndex = 3;
            this.saveButton.Text = "Save reconstructed image";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // loadSampledImageButton
            // 
            this.loadSampledImageButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.loadSampledImageButton.Location = new System.Drawing.Point(9, 77);
            this.loadSampledImageButton.Name = "loadSampledImageButton";
            this.loadSampledImageButton.Size = new System.Drawing.Size(199, 23);
            this.loadSampledImageButton.TabIndex = 0;
            this.loadSampledImageButton.Text = "Load sampled image";
            this.loadSampledImageButton.UseVisualStyleBackColor = true;
            this.loadSampledImageButton.Click += new System.EventHandler(this.loadSampledImageButton_Click);
            // 
            // loadButton
            // 
            this.loadButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.loadButton.Location = new System.Drawing.Point(9, 19);
            this.loadButton.Name = "loadButton";
            this.loadButton.Size = new System.Drawing.Size(199, 23);
            this.loadButton.TabIndex = 1;
            this.loadButton.Text = "Load original image";
            this.loadButton.UseVisualStyleBackColor = true;
            this.loadButton.Click += new System.EventHandler(this.loadButton_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar1.Location = new System.Drawing.Point(3, 573);
            this.progressBar1.MarqueeAnimationSpeed = 10;
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(639, 23);
            this.progressBar1.TabIndex = 0;
            // 
            // imageTabControl
            // 
            this.imageTabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.imageTabControl.Controls.Add(this.originalImageTabPage);
            this.imageTabControl.Controls.Add(this.reconstructedImagetabPage);
            this.imageTabControl.Location = new System.Drawing.Point(3, 3);
            this.imageTabControl.Name = "imageTabControl";
            this.imageTabControl.Padding = new System.Drawing.Point(0, 0);
            this.imageTabControl.SelectedIndex = 0;
            this.imageTabControl.Size = new System.Drawing.Size(639, 566);
            this.imageTabControl.TabIndex = 0;
            // 
            // originalImageTabPage
            // 
            this.originalImageTabPage.AutoScroll = true;
            this.originalImageTabPage.BackColor = System.Drawing.Color.Transparent;
            this.originalImageTabPage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.originalImageTabPage.Controls.Add(this.originalPictureBox);
            this.originalImageTabPage.Location = new System.Drawing.Point(4, 22);
            this.originalImageTabPage.Margin = new System.Windows.Forms.Padding(0);
            this.originalImageTabPage.Name = "originalImageTabPage";
            this.originalImageTabPage.Size = new System.Drawing.Size(631, 540);
            this.originalImageTabPage.TabIndex = 0;
            this.originalImageTabPage.Text = "Original image";
            this.originalImageTabPage.Resize += new System.EventHandler(this.originalImageTabPage_Resize);
            // 
            // originalPictureBox
            // 
            this.originalPictureBox.BackColor = System.Drawing.Color.Transparent;
            this.originalPictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.originalPictureBox.Location = new System.Drawing.Point(0, 0);
            this.originalPictureBox.Margin = new System.Windows.Forms.Padding(0);
            this.originalPictureBox.Name = "originalPictureBox";
            this.originalPictureBox.Size = new System.Drawing.Size(629, 538);
            this.originalPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.originalPictureBox.TabIndex = 0;
            this.originalPictureBox.TabStop = false;
            // 
            // reconstructedImagetabPage
            // 
            this.reconstructedImagetabPage.AutoScroll = true;
            this.reconstructedImagetabPage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.reconstructedImagetabPage.Controls.Add(this.reconstructedPictureBox);
            this.reconstructedImagetabPage.Location = new System.Drawing.Point(4, 22);
            this.reconstructedImagetabPage.Margin = new System.Windows.Forms.Padding(0);
            this.reconstructedImagetabPage.Name = "reconstructedImagetabPage";
            this.reconstructedImagetabPage.Size = new System.Drawing.Size(631, 542);
            this.reconstructedImagetabPage.TabIndex = 1;
            this.reconstructedImagetabPage.Text = "Reconstructed image";
            this.reconstructedImagetabPage.Resize += new System.EventHandler(this.reconstructedImageTabPage_Resize);
            // 
            // reconstructedPictureBox
            // 
            this.reconstructedPictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reconstructedPictureBox.Location = new System.Drawing.Point(0, 0);
            this.reconstructedPictureBox.Name = "reconstructedPictureBox";
            this.reconstructedPictureBox.Size = new System.Drawing.Size(629, 540);
            this.reconstructedPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.reconstructedPictureBox.TabIndex = 0;
            this.reconstructedPictureBox.TabStop = false;
            // 
            // originalImageOpenFileDialog
            // 
            this.originalImageOpenFileDialog.Filter = "PNG Files|*.png|JPEG Files|*.jpg|GIF Files|*.gif|Bitmap Files|*.bmp|TIFF Files|*." +
                "tif|All Image types|*.png;*.bmp;*.gif;*.jpg;*.tif";
            this.originalImageOpenFileDialog.FilterIndex = 6;
            this.originalImageOpenFileDialog.Title = "Open original image";
            this.originalImageOpenFileDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.originalImageOpenFileDialog_FileOk);
            // 
            // reconstructedImageSaveFileDialog
            // 
            this.reconstructedImageSaveFileDialog.Filter = "PNG Files|*.png|JPEG Files|*.jpg|GIF Files|*.gif|Bitmap Files|*.bmp|TIFF Files|*." +
                "tif|All Image types|*.png;*.bmp;*.gif;*.jpg;*.tif";
            this.reconstructedImageSaveFileDialog.Title = "Save reconstructed image";
            this.reconstructedImageSaveFileDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.reconstructedImageSaveFileDialog_FileOk);
            // 
            // sampledImageOpenFileDialog
            // 
            this.sampledImageOpenFileDialog.Filter = "Text|*.txt|All file types|*.*";
            this.sampledImageOpenFileDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.sampledImageOpenFileDialog_FileOk);
            // 
            // sampledImageSaveFileDialog
            // 
            this.sampledImageSaveFileDialog.Filter = "Text|*.txt|All file types|*.*";
            this.sampledImageSaveFileDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.sampledImageSaveFileDialog_FileOk);
            // 
            // backgroundWorker
            // 
            this.backgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker_DoWork);
            this.backgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker_RunWorkerCompleted);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 602);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(869, 22);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // MosaicForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(869, 624);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.splitContainer1);
            this.Name = "MosaicForm";
            this.Text = "Voronoi mosaic - Bohumír Zámečník - MFF UK - 2011 - uses poly2tri-cs library";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.visualizationGroupBox.ResumeLayout(false);
            this.visualizationGroupBox.PerformLayout();
            this.voronoiOptionsGroupBox.ResumeLayout(false);
            this.voronoiOptionsGroupBox.PerformLayout();
            this.samplingGroupBox.ResumeLayout(false);
            this.samplingGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sampleCountNumeric)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.imageTabControl.ResumeLayout(false);
            this.originalImageTabPage.ResumeLayout(false);
            this.originalImageTabPage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.originalPictureBox)).EndInit();
            this.reconstructedImagetabPage.ResumeLayout(false);
            this.reconstructedImagetabPage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.reconstructedPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TabControl imageTabControl;
        private System.Windows.Forms.TabPage originalImageTabPage;
        private System.Windows.Forms.PictureBox originalPictureBox;
        private System.Windows.Forms.TabPage reconstructedImagetabPage;
        private System.Windows.Forms.GroupBox samplingGroupBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.PictureBox reconstructedPictureBox;
        private System.Windows.Forms.GroupBox visualizationGroupBox;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button loadButton;
        private System.Windows.Forms.ComboBox samplerTypeComboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown sampleCountNumeric;
        private System.Windows.Forms.Button sampleImageButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox showDelaunayCircumcirclesCheckBox;
        private System.Windows.Forms.CheckBox showVoronoiVerticesCheckBox;
        private System.Windows.Forms.CheckBox showDelaunayTrianglesCheckBox;
        private System.Windows.Forms.CheckBox showVoronoiCellsCheckBox;
        private System.Windows.Forms.CheckBox showVoronoiCellBordersCheckBox;
        private System.Windows.Forms.CheckBox enableAntialiasingCheckBox;
        private System.Windows.Forms.GroupBox voronoiOptionsGroupBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox imageVisualizerComboBox;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button reconstructImageButton;
        private System.Windows.Forms.Button saveSampledImageButton;
        private System.Windows.Forms.Button loadSampledImageButton;
        private System.Windows.Forms.OpenFileDialog originalImageOpenFileDialog;
        private System.Windows.Forms.Button sampleAndReconstructImageButton;
        private System.Windows.Forms.Button imageSizeStretchButton;
        private System.Windows.Forms.Button imageSizeOriginalButton;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.SaveFileDialog reconstructedImageSaveFileDialog;
        private System.Windows.Forms.OpenFileDialog sampledImageOpenFileDialog;
        private System.Windows.Forms.SaveFileDialog sampledImageSaveFileDialog;
        private System.Windows.Forms.CheckBox cacheTriangulationCheckBox;
        private System.ComponentModel.BackgroundWorker backgroundWorker;
        private System.Windows.Forms.StatusStrip statusStrip1;
    }
}

