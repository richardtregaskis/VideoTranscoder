namespace VideoTranscoder
{
	partial class Form1
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
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
			this.txtSourceFilename = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.btnBrowseSource = new System.Windows.Forms.Button();
			this.ddlProResSetting = new System.Windows.Forms.ComboBox();
			this.label2 = new System.Windows.Forms.Label();
			this.lblStatus = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.ddlCodec = new System.Windows.Forms.ComboBox();
			this.label4 = new System.Windows.Forms.Label();
			this.ddlFrameRate = new System.Windows.Forms.ComboBox();
			this.label5 = new System.Windows.Forms.Label();
			this.ddlResolution = new System.Windows.Forms.ComboBox();
			this.label6 = new System.Windows.Forms.Label();
			this.ddlColorDepth = new System.Windows.Forms.ComboBox();
			this.label7 = new System.Windows.Forms.Label();
			this.ddlChromaSampling = new System.Windows.Forms.ComboBox();
			this.grpDNxOptions = new System.Windows.Forms.GroupBox();
			this.btnTranscode = new System.Windows.Forms.Button();
			this.grpProResOptions = new System.Windows.Forms.GroupBox();
			this.label8 = new System.Windows.Forms.Label();
			this.txtSourceFolder = new System.Windows.Forms.TextBox();
			this.btnBrowseFolder = new System.Windows.Forms.Button();
			this.btnBatch = new System.Windows.Forms.Button();
			this.rtbStatus = new System.Windows.Forms.RichTextBox();
			this.label9 = new System.Windows.Forms.Label();
			this.ddlThreads = new System.Windows.Forms.ComboBox();
			this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this._encodeBackgroundWorker = new System.ComponentModel.BackgroundWorker();
			this.btnBatchCancel = new System.Windows.Forms.Button();
			this.btnSingleCancel = new System.Windows.Forms.Button();
			this.grpDNxOptions.SuspendLayout();
			this.grpProResOptions.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.SuspendLayout();
			// 
			// txtSourceFilename
			// 
			this.txtSourceFilename.Location = new System.Drawing.Point(66, 24);
			this.txtSourceFilename.Name = "txtSourceFilename";
			this.txtSourceFilename.Size = new System.Drawing.Size(236, 20);
			this.txtSourceFilename.TabIndex = 0;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(16, 27);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(44, 13);
			this.label1.TabIndex = 1;
			this.label1.Text = "Source:";
			// 
			// btnBrowseSource
			// 
			this.btnBrowseSource.Location = new System.Drawing.Point(311, 22);
			this.btnBrowseSource.Name = "btnBrowseSource";
			this.btnBrowseSource.Size = new System.Drawing.Size(31, 23);
			this.btnBrowseSource.TabIndex = 2;
			this.btnBrowseSource.Text = ". . .";
			this.btnBrowseSource.UseVisualStyleBackColor = true;
			this.btnBrowseSource.Click += new System.EventHandler(this.btnBrowseSource_Click);
			// 
			// ddlProResSetting
			// 
			this.ddlProResSetting.FormattingEnabled = true;
			this.ddlProResSetting.Items.AddRange(new object[] {
            "422Proxy",
            "422LT",
            "422",
            "422HQ",
            "4444",
            "4444XQ"});
			this.ddlProResSetting.Location = new System.Drawing.Point(53, 19);
			this.ddlProResSetting.Name = "ddlProResSetting";
			this.ddlProResSetting.Size = new System.Drawing.Size(179, 21);
			this.ddlProResSetting.TabIndex = 3;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(5, 22);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(39, 13);
			this.label2.TabIndex = 4;
			this.label2.Text = "Profile:";
			// 
			// lblStatus
			// 
			this.lblStatus.AutoSize = true;
			this.lblStatus.Location = new System.Drawing.Point(12, 268);
			this.lblStatus.Name = "lblStatus";
			this.lblStatus.Size = new System.Drawing.Size(40, 13);
			this.lblStatus.TabIndex = 5;
			this.lblStatus.Text = "Status:";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(12, 15);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(75, 13);
			this.label3.TabIndex = 7;
			this.label3.Text = "Target Codec:";
			// 
			// ddlCodec
			// 
			this.ddlCodec.FormattingEnabled = true;
			this.ddlCodec.Items.AddRange(new object[] {
            "ProRes",
            "DNxHD/DNxHR"});
			this.ddlCodec.Location = new System.Drawing.Point(93, 12);
			this.ddlCodec.Name = "ddlCodec";
			this.ddlCodec.Size = new System.Drawing.Size(292, 21);
			this.ddlCodec.TabIndex = 6;
			this.ddlCodec.SelectedIndexChanged += new System.EventHandler(this.ddlCodec_SelectedIndexChanged);
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(157, 26);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(65, 13);
			this.label4.TabIndex = 6;
			this.label4.Text = "Frame Rate:";
			// 
			// ddlFrameRate
			// 
			this.ddlFrameRate.FormattingEnabled = true;
			this.ddlFrameRate.Items.AddRange(new object[] {
            "23.97",
            "24",
            "25",
            "29.97",
            "50",
            "59.94",
            "60"});
			this.ddlFrameRate.Location = new System.Drawing.Point(228, 23);
			this.ddlFrameRate.Name = "ddlFrameRate";
			this.ddlFrameRate.Size = new System.Drawing.Size(74, 21);
			this.ddlFrameRate.TabIndex = 5;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(6, 26);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(60, 13);
			this.label5.TabIndex = 8;
			this.label5.Text = "Resolution:";
			// 
			// ddlResolution
			// 
			this.ddlResolution.FormattingEnabled = true;
			this.ddlResolution.Items.AddRange(new object[] {
            "720P",
            "1080P",
            "4K"});
			this.ddlResolution.Location = new System.Drawing.Point(72, 23);
			this.ddlResolution.Name = "ddlResolution";
			this.ddlResolution.Size = new System.Drawing.Size(74, 21);
			this.ddlResolution.TabIndex = 7;
			this.ddlResolution.SelectedIndexChanged += new System.EventHandler(this.ddlResolution_SelectedIndexChanged);
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(319, 26);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(66, 13);
			this.label6.TabIndex = 10;
			this.label6.Text = "Color Depth:";
			// 
			// ddlColorDepth
			// 
			this.ddlColorDepth.FormattingEnabled = true;
			this.ddlColorDepth.Items.AddRange(new object[] {
            "8 Bit",
            "10 Bit"});
			this.ddlColorDepth.Location = new System.Drawing.Point(390, 23);
			this.ddlColorDepth.Name = "ddlColorDepth";
			this.ddlColorDepth.Size = new System.Drawing.Size(74, 21);
			this.ddlColorDepth.TabIndex = 9;
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(5, 58);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(92, 13);
			this.label7.TabIndex = 12;
			this.label7.Text = "Chroma Sampling:";
			// 
			// ddlChromaSampling
			// 
			this.ddlChromaSampling.FormattingEnabled = true;
			this.ddlChromaSampling.Items.AddRange(new object[] {
            "4:2:0",
            "4:2:2",
            "4:4:4"});
			this.ddlChromaSampling.Location = new System.Drawing.Point(103, 55);
			this.ddlChromaSampling.Name = "ddlChromaSampling";
			this.ddlChromaSampling.Size = new System.Drawing.Size(74, 21);
			this.ddlChromaSampling.TabIndex = 11;
			// 
			// grpDNxOptions
			// 
			this.grpDNxOptions.Controls.Add(this.label7);
			this.grpDNxOptions.Controls.Add(this.label5);
			this.grpDNxOptions.Controls.Add(this.ddlChromaSampling);
			this.grpDNxOptions.Controls.Add(this.ddlFrameRate);
			this.grpDNxOptions.Controls.Add(this.label6);
			this.grpDNxOptions.Controls.Add(this.label4);
			this.grpDNxOptions.Controls.Add(this.ddlColorDepth);
			this.grpDNxOptions.Controls.Add(this.ddlResolution);
			this.grpDNxOptions.Location = new System.Drawing.Point(15, 43);
			this.grpDNxOptions.Name = "grpDNxOptions";
			this.grpDNxOptions.Size = new System.Drawing.Size(501, 87);
			this.grpDNxOptions.TabIndex = 9;
			this.grpDNxOptions.TabStop = false;
			this.grpDNxOptions.Text = "DNxHD Options";
			this.grpDNxOptions.Visible = false;
			// 
			// btnTranscode
			// 
			this.btnTranscode.Location = new System.Drawing.Point(171, 60);
			this.btnTranscode.Name = "btnTranscode";
			this.btnTranscode.Size = new System.Drawing.Size(75, 23);
			this.btnTranscode.TabIndex = 10;
			this.btnTranscode.Text = "Transcode";
			this.btnTranscode.UseVisualStyleBackColor = true;
			this.btnTranscode.Click += new System.EventHandler(this.btnTranscode_Click);
			// 
			// grpProResOptions
			// 
			this.grpProResOptions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.grpProResOptions.Controls.Add(this.ddlProResSetting);
			this.grpProResOptions.Controls.Add(this.label2);
			this.grpProResOptions.Location = new System.Drawing.Point(15, 43);
			this.grpProResOptions.Name = "grpProResOptions";
			this.grpProResOptions.Size = new System.Drawing.Size(742, 87);
			this.grpProResOptions.TabIndex = 11;
			this.grpProResOptions.TabStop = false;
			this.grpProResOptions.Text = "ProRes Options";
			this.grpProResOptions.Visible = false;
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(14, 30);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(36, 13);
			this.label8.TabIndex = 11;
			this.label8.Text = "Folder";
			// 
			// txtSourceFolder
			// 
			this.txtSourceFolder.Location = new System.Drawing.Point(56, 27);
			this.txtSourceFolder.Name = "txtSourceFolder";
			this.txtSourceFolder.Size = new System.Drawing.Size(140, 20);
			this.txtSourceFolder.TabIndex = 12;
			// 
			// btnBrowseFolder
			// 
			this.btnBrowseFolder.Location = new System.Drawing.Point(202, 25);
			this.btnBrowseFolder.Name = "btnBrowseFolder";
			this.btnBrowseFolder.Size = new System.Drawing.Size(31, 23);
			this.btnBrowseFolder.TabIndex = 13;
			this.btnBrowseFolder.Text = ". . .";
			this.btnBrowseFolder.UseVisualStyleBackColor = true;
			this.btnBrowseFolder.Click += new System.EventHandler(this.btnBrowseFolder_Click);
			// 
			// btnBatch
			// 
			this.btnBatch.Location = new System.Drawing.Point(202, 60);
			this.btnBatch.Name = "btnBatch";
			this.btnBatch.Size = new System.Drawing.Size(75, 23);
			this.btnBatch.TabIndex = 14;
			this.btnBatch.Text = "Transcode";
			this.btnBatch.UseVisualStyleBackColor = true;
			this.btnBatch.Click += new System.EventHandler(this.btnBatch_Click);
			// 
			// rtbStatus
			// 
			this.rtbStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.rtbStatus.Location = new System.Drawing.Point(55, 265);
			this.rtbStatus.Name = "rtbStatus";
			this.rtbStatus.Size = new System.Drawing.Size(702, 263);
			this.rtbStatus.TabIndex = 15;
			this.rtbStatus.Text = "";
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(251, 30);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(72, 13);
			this.label9.TabIndex = 16;
			this.label9.Text = "Max Threads:";
			this.toolTip1.SetToolTip(this.label9, "Max number of files to process at once. Recommend no more than 1 thread per 8 cor" +
        "es.");
			// 
			// ddlThreads
			// 
			this.ddlThreads.FormattingEnabled = true;
			this.ddlThreads.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20"});
			this.ddlThreads.Location = new System.Drawing.Point(330, 27);
			this.ddlThreads.Name = "ddlThreads";
			this.ddlThreads.Size = new System.Drawing.Size(38, 21);
			this.ddlThreads.TabIndex = 17;
			this.toolTip1.SetToolTip(this.ddlThreads, "Max number of files to process at once. Recommend no more than 1 thread per 8 cor" +
        "es.");
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.btnSingleCancel);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.txtSourceFilename);
			this.groupBox1.Controls.Add(this.btnBrowseSource);
			this.groupBox1.Controls.Add(this.btnTranscode);
			this.groupBox1.Location = new System.Drawing.Point(15, 136);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(348, 113);
			this.groupBox1.TabIndex = 18;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Single File";
			// 
			// groupBox2
			// 
			this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox2.Controls.Add(this.btnBatchCancel);
			this.groupBox2.Controls.Add(this.txtSourceFolder);
			this.groupBox2.Controls.Add(this.label8);
			this.groupBox2.Controls.Add(this.ddlThreads);
			this.groupBox2.Controls.Add(this.btnBrowseFolder);
			this.groupBox2.Controls.Add(this.label9);
			this.groupBox2.Controls.Add(this.btnBatch);
			this.groupBox2.Location = new System.Drawing.Point(369, 136);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(388, 113);
			this.groupBox2.TabIndex = 19;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Batch Convert";
			// 
			// _encodeBackgroundWorker
			// 
			this._encodeBackgroundWorker.WorkerReportsProgress = true;
			this._encodeBackgroundWorker.WorkerSupportsCancellation = true;
			this._encodeBackgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this._encodeBackgroundWorker_DoWork);
			this._encodeBackgroundWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this._encodeBackgroundWorker_ProgressChanged);
			this._encodeBackgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this._encodeBackgroundWorker_RunWorkerCompleted);
			// 
			// btnBatchCancel
			// 
			this.btnBatchCancel.Enabled = false;
			this.btnBatchCancel.Location = new System.Drawing.Point(293, 60);
			this.btnBatchCancel.Name = "btnBatchCancel";
			this.btnBatchCancel.Size = new System.Drawing.Size(75, 23);
			this.btnBatchCancel.TabIndex = 18;
			this.btnBatchCancel.Text = "Cancel";
			this.btnBatchCancel.UseVisualStyleBackColor = true;
			this.btnBatchCancel.Click += new System.EventHandler(this.btnBatchCancel_Click);
			// 
			// btnSingleCancel
			// 
			this.btnSingleCancel.Enabled = false;
			this.btnSingleCancel.Location = new System.Drawing.Point(267, 60);
			this.btnSingleCancel.Name = "btnSingleCancel";
			this.btnSingleCancel.Size = new System.Drawing.Size(75, 23);
			this.btnSingleCancel.TabIndex = 19;
			this.btnSingleCancel.Text = "Cancel";
			this.btnSingleCancel.UseVisualStyleBackColor = true;
			this.btnSingleCancel.Click += new System.EventHandler(this.btnSingleCancel_Click);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(769, 540);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.rtbStatus);
			this.Controls.Add(this.grpProResOptions);
			this.Controls.Add(this.grpDNxOptions);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.ddlCodec);
			this.Controls.Add(this.lblStatus);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "Form1";
			this.Text = "Intermediate Codec Transcoder";
			this.grpDNxOptions.ResumeLayout(false);
			this.grpDNxOptions.PerformLayout();
			this.grpProResOptions.ResumeLayout(false);
			this.grpProResOptions.PerformLayout();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox txtSourceFilename;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button btnBrowseSource;
		private System.Windows.Forms.ComboBox ddlProResSetting;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label lblStatus;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.ComboBox ddlCodec;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.ComboBox ddlFrameRate;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.ComboBox ddlColorDepth;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.ComboBox ddlResolution;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.ComboBox ddlChromaSampling;
		private System.Windows.Forms.GroupBox grpDNxOptions;
		private System.Windows.Forms.Button btnTranscode;
		private System.Windows.Forms.GroupBox grpProResOptions;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.TextBox txtSourceFolder;
		private System.Windows.Forms.Button btnBrowseFolder;
		private System.Windows.Forms.Button btnBatch;
		private System.Windows.Forms.RichTextBox rtbStatus;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.ComboBox ddlThreads;
		private System.Windows.Forms.ToolTip toolTip1;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.ComponentModel.BackgroundWorker _encodeBackgroundWorker;
		private System.Windows.Forms.Button btnBatchCancel;
		private System.Windows.Forms.Button btnSingleCancel;
	}
}

