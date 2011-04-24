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
            this.label5 = new System.Windows.Forms.Label();
            this.samplingClusterCountNumeric = new System.Windows.Forms.NumericUpDown();
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
            this.reconstructedImageTabPage = new System.Windows.Forms.TabPage();
            this.reconstructedPictureBox = new System.Windows.Forms.PictureBox();
            this.originalImageOpenFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.reconstructedImageSaveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.sampledImageOpenFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.sampledImageSaveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.backgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.timeToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.visualizationGroupBox.SuspendLayout();
            this.voronoiOptionsGroupBox.SuspendLayout();
            this.samplingGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.samplingClusterCountNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sampleCountNumeric)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.imageTabControl.SuspendLayout();
            this.originalImageTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.originalPictureBox)).BeginInit();
            this.reconstructedImageTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.reconstructedPictureBox)).BeginInit();
            this.statusStrip.SuspendLayout();
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
            this.splitContainer1.Size = new System.Drawing.Size(869, 629);
            this.splitContainer1.SplitterDistance = 220;
            this.splitContainer1.TabIndex = 0;
            this.splitContainer1.TabStop = false;
            // 
            // groupBox5
            // 
            this.groupBox5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox5.Controls.Add(this.label4);
            this.groupBox5.Controls.Add(this.imageSizeStretchButton);
            this.groupBox5.Controls.Add(this.imageSizeOriginalButton);
            this.groupBox5.Location = new System.Drawing.Point(3, 580);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(214, 46);
            this.groupBox5.TabIndex = 0;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Viewing";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 21);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 13);
            this.label4.TabIndex = 0;
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
            this.imageSizeStretchButton.TabIndex = 20;
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
            this.imageSizeOriginalButton.TabIndex = 19;
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
            this.visualizationGroupBox.Location = new System.Drawing.Point(3, 284);
            this.visualizationGroupBox.Name = "visualizationGroupBox";
            this.visualizationGroupBox.Size = new System.Drawing.Size(214, 290);
            this.visualizationGroupBox.TabIndex = 0;
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
            this.reconstructImageButton.TabIndex = 17;
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
            this.voronoiOptionsGroupBox.TabIndex = 0;
            this.voronoiOptionsGroupBox.TabStop = false;
            this.voronoiOptionsGroupBox.Text = "Voronoi diagram options";
            // 
            // cacheTriangulationCheckBox
            // 
            this.cacheTriangulationCheckBox.AutoSize = true;
            this.cacheTriangulationCheckBox.Location = new System.Drawing.Point(6, 157);
            this.cacheTriangulationCheckBox.Name = "cacheTriangulationCheckBox";
            this.cacheTriangulationCheckBox.Size = new System.Drawing.Size(184, 17);
            this.cacheTriangulationCheckBox.TabIndex = 16;
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
            this.showVoronoiCellsCheckBox.TabIndex = 10;
            this.showVoronoiCellsCheckBox.Text = "Show Voronoi cells";
            this.showVoronoiCellsCheckBox.UseVisualStyleBackColor = true;
            // 
            // showDelaunayTrianglesCheckBox
            // 
            this.showDelaunayTrianglesCheckBox.AutoSize = true;
            this.showDelaunayTrianglesCheckBox.Location = new System.Drawing.Point(6, 42);
            this.showDelaunayTrianglesCheckBox.Name = "showDelaunayTrianglesCheckBox";
            this.showDelaunayTrianglesCheckBox.Size = new System.Drawing.Size(143, 17);
            this.showDelaunayTrianglesCheckBox.TabIndex = 11;
            this.showDelaunayTrianglesCheckBox.Text = "Show Delaunay triangles";
            this.showDelaunayTrianglesCheckBox.UseVisualStyleBackColor = true;
            // 
            // enableAntialiasingCheckBox
            // 
            this.enableAntialiasingCheckBox.AutoSize = true;
            this.enableAntialiasingCheckBox.Location = new System.Drawing.Point(6, 134);
            this.enableAntialiasingCheckBox.Name = "enableAntialiasingCheckBox";
            this.enableAntialiasingCheckBox.Size = new System.Drawing.Size(103, 17);
            this.enableAntialiasingCheckBox.TabIndex = 15;
            this.enableAntialiasingCheckBox.Text = "Use anti-aliasing";
            this.enableAntialiasingCheckBox.UseVisualStyleBackColor = true;
            // 
            // showVoronoiVerticesCheckBox
            // 
            this.showVoronoiVerticesCheckBox.AutoSize = true;
            this.showVoronoiVerticesCheckBox.Location = new System.Drawing.Point(6, 65);
            this.showVoronoiVerticesCheckBox.Name = "showVoronoiVerticesCheckBox";
            this.showVoronoiVerticesCheckBox.Size = new System.Drawing.Size(132, 17);
            this.showVoronoiVerticesCheckBox.TabIndex = 12;
            this.showVoronoiVerticesCheckBox.Text = "Show Voronoi vertices";
            this.showVoronoiVerticesCheckBox.UseVisualStyleBackColor = true;
            // 
            // showVoronoiCellBordersCheckBox
            // 
            this.showVoronoiCellBordersCheckBox.AutoSize = true;
            this.showVoronoiCellBordersCheckBox.Location = new System.Drawing.Point(6, 111);
            this.showVoronoiCellBordersCheckBox.Name = "showVoronoiCellBordersCheckBox";
            this.showVoronoiCellBordersCheckBox.Size = new System.Drawing.Size(166, 17);
            this.showVoronoiCellBordersCheckBox.TabIndex = 14;
            this.showVoronoiCellBordersCheckBox.Text = "Show borders of Voronoi cells";
            this.showVoronoiCellBordersCheckBox.UseVisualStyleBackColor = true;
            // 
            // showDelaunayCircumcirclesCheckBox
            // 
            this.showDelaunayCircumcirclesCheckBox.AutoSize = true;
            this.showDelaunayCircumcirclesCheckBox.Location = new System.Drawing.Point(6, 88);
            this.showDelaunayCircumcirclesCheckBox.Name = "showDelaunayCircumcirclesCheckBox";
            this.showDelaunayCircumcirclesCheckBox.Size = new System.Drawing.Size(165, 17);
            this.showDelaunayCircumcirclesCheckBox.TabIndex = 13;
            this.showDelaunayCircumcirclesCheckBox.Text = "Show Delaunay circumcircles";
            this.showDelaunayCircumcirclesCheckBox.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Method:";
            // 
            // sampleAndReconstructImageButton
            // 
            this.sampleAndReconstructImageButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.sampleAndReconstructImageButton.Location = new System.Drawing.Point(9, 259);
            this.sampleAndReconstructImageButton.Name = "sampleAndReconstructImageButton";
            this.sampleAndReconstructImageButton.Size = new System.Drawing.Size(199, 23);
            this.sampleAndReconstructImageButton.TabIndex = 18;
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
            this.imageVisualizerComboBox.TabIndex = 9;
            this.imageVisualizerComboBox.SelectedIndexChanged += new System.EventHandler(this.imageVisualizerComboBox_SelectedIndexChanged);
            // 
            // samplingGroupBox
            // 
            this.samplingGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.samplingGroupBox.Controls.Add(this.label5);
            this.samplingGroupBox.Controls.Add(this.samplingClusterCountNumeric);
            this.samplingGroupBox.Controls.Add(this.label2);
            this.samplingGroupBox.Controls.Add(this.label1);
            this.samplingGroupBox.Controls.Add(this.sampleCountNumeric);
            this.samplingGroupBox.Controls.Add(this.sampleImageButton);
            this.samplingGroupBox.Controls.Add(this.samplerTypeComboBox);
            this.samplingGroupBox.Location = new System.Drawing.Point(3, 147);
            this.samplingGroupBox.Name = "samplingGroupBox";
            this.samplingGroupBox.Size = new System.Drawing.Size(214, 131);
            this.samplingGroupBox.TabIndex = 0;
            this.samplingGroupBox.TabStop = false;
            this.samplingGroupBox.Text = "Image sampling";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 75);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(98, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Number of clusters:";
            // 
            // samplingClusterCountNumeric
            // 
            this.samplingClusterCountNumeric.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.samplingClusterCountNumeric.Location = new System.Drawing.Point(115, 73);
            this.samplingClusterCountNumeric.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.samplingClusterCountNumeric.Name = "samplingClusterCountNumeric";
            this.samplingClusterCountNumeric.Size = new System.Drawing.Size(93, 20);
            this.samplingClusterCountNumeric.TabIndex = 7;
            this.samplingClusterCountNumeric.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.samplingClusterCountNumeric.ValueChanged += new System.EventHandler(this.samplingClusterCountNumeric_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Method:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 13);
            this.label1.TabIndex = 0;
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
            this.sampleCountNumeric.TabIndex = 6;
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
            this.sampleImageButton.Location = new System.Drawing.Point(9, 99);
            this.sampleImageButton.Name = "sampleImageButton";
            this.sampleImageButton.Size = new System.Drawing.Size(199, 23);
            this.sampleImageButton.TabIndex = 8;
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
            this.samplerTypeComboBox.TabIndex = 5;
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
            this.saveSampledImageButton.TabIndex = 4;
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
            this.saveButton.TabIndex = 2;
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
            this.loadSampledImageButton.TabIndex = 3;
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
            this.progressBar1.Location = new System.Drawing.Point(3, 603);
            this.progressBar1.MarqueeAnimationSpeed = 1;
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(639, 23);
            this.progressBar1.TabIndex = 0;
            this.progressBar1.TabStop = false;
            // 
            // imageTabControl
            // 
            this.imageTabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.imageTabControl.Controls.Add(this.originalImageTabPage);
            this.imageTabControl.Controls.Add(this.reconstructedImageTabPage);
            this.imageTabControl.Location = new System.Drawing.Point(3, 3);
            this.imageTabControl.Name = "imageTabControl";
            this.imageTabControl.Padding = new System.Drawing.Point(0, 0);
            this.imageTabControl.SelectedIndex = 0;
            this.imageTabControl.Size = new System.Drawing.Size(639, 596);
            this.imageTabControl.TabIndex = 22;
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
            this.originalImageTabPage.Size = new System.Drawing.Size(631, 570);
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
            this.originalPictureBox.Size = new System.Drawing.Size(629, 568);
            this.originalPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.originalPictureBox.TabIndex = 0;
            this.originalPictureBox.TabStop = false;
            // 
            // reconstructedImageTabPage
            // 
            this.reconstructedImageTabPage.AutoScroll = true;
            this.reconstructedImageTabPage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.reconstructedImageTabPage.Controls.Add(this.reconstructedPictureBox);
            this.reconstructedImageTabPage.Location = new System.Drawing.Point(4, 22);
            this.reconstructedImageTabPage.Margin = new System.Windows.Forms.Padding(0);
            this.reconstructedImageTabPage.Name = "reconstructedImageTabPage";
            this.reconstructedImageTabPage.Size = new System.Drawing.Size(631, 570);
            this.reconstructedImageTabPage.TabIndex = 0;
            this.reconstructedImageTabPage.Text = "Reconstructed image";
            this.reconstructedImageTabPage.Resize += new System.EventHandler(this.reconstructedImageTabPage_Resize);
            // 
            // reconstructedPictureBox
            // 
            this.reconstructedPictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reconstructedPictureBox.Location = new System.Drawing.Point(0, 0);
            this.reconstructedPictureBox.Name = "reconstructedPictureBox";
            this.reconstructedPictureBox.Size = new System.Drawing.Size(629, 568);
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
            this.backgroundWorker.WorkerReportsProgress = true;
            this.backgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker_DoWork);
            this.backgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker_RunWorkerCompleted);
            this.backgroundWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker_ProgressChanged);
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.timeToolStripStatusLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 632);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(869, 22);
            this.statusStrip.TabIndex = 0;
            // 
            // timeToolStripStatusLabel
            // 
            this.timeToolStripStatusLabel.Name = "timeToolStripStatusLabel";
            this.timeToolStripStatusLabel.Size = new System.Drawing.Size(42, 17);
            this.timeToolStripStatusLabel.Text = "Ready.";
            // 
            // MosaicForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(869, 654);
            this.Controls.Add(this.statusStrip);
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
            ((System.ComponentModel.ISupportInitialize)(this.samplingClusterCountNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sampleCountNumeric)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.imageTabControl.ResumeLayout(false);
            this.originalImageTabPage.ResumeLayout(false);
            this.originalImageTabPage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.originalPictureBox)).EndInit();
            this.reconstructedImageTabPage.ResumeLayout(false);
            this.reconstructedImageTabPage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.reconstructedPictureBox)).EndInit();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TabControl imageTabControl;
        private System.Windows.Forms.TabPage originalImageTabPage;
        private System.Windows.Forms.PictureBox originalPictureBox;
        private System.Windows.Forms.TabPage reconstructedImageTabPage;
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
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown samplingClusterCountNumeric;
        private System.Windows.Forms.ToolStripStatusLabel timeToolStripStatusLabel;
    }
}

