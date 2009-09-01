namespace Requiro
{
    partial class Mainform
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Mainform));
            this.m_DirectoryBox = new System.Windows.Forms.GroupBox();
            this.m_AnalyzeButton = new System.Windows.Forms.Button();
            this.m_BrowseButton = new System.Windows.Forms.Button();
            this.m_PathBox = new System.Windows.Forms.TextBox();
            this.m_FileList = new System.Windows.Forms.ListView();
            this.path = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.totalSize = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.m_imageList = new System.Windows.Forms.ImageList(this.components);
            this.m_SizeCount = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.m_SubfoldersCount = new System.Windows.Forms.Label();
            this.m_VersionLabel = new System.Windows.Forms.Label();
            this.m_PieChart = new System.Windows.Forms.PictureBox();
            this.bgWorker = new System.ComponentModel.BackgroundWorker();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.m_FolderBrowser = new System.Windows.Forms.FolderBrowserDialog();
            this.m_StatusLabel = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.m_UsagePercent = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.m_PathLabel = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.m_DirectoryBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_PieChart)).BeginInit();
            this.panel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_DirectoryBox
            // 
            this.m_DirectoryBox.Controls.Add(this.m_AnalyzeButton);
            this.m_DirectoryBox.Controls.Add(this.m_BrowseButton);
            this.m_DirectoryBox.Controls.Add(this.m_PathBox);
            this.m_DirectoryBox.Location = new System.Drawing.Point(8, 12);
            this.m_DirectoryBox.Name = "m_DirectoryBox";
            this.m_DirectoryBox.Size = new System.Drawing.Size(815, 53);
            this.m_DirectoryBox.TabIndex = 0;
            this.m_DirectoryBox.TabStop = false;
            this.m_DirectoryBox.Text = "Full path to target directory";
            // 
            // m_AnalyzeButton
            // 
            this.m_AnalyzeButton.Location = new System.Drawing.Point(680, 18);
            this.m_AnalyzeButton.Name = "m_AnalyzeButton";
            this.m_AnalyzeButton.Size = new System.Drawing.Size(129, 23);
            this.m_AnalyzeButton.TabIndex = 2;
            this.m_AnalyzeButton.Text = "Start analysis";
            this.m_AnalyzeButton.UseVisualStyleBackColor = true;
            this.m_AnalyzeButton.Click += new System.EventHandler(this.m_AnalyzeButton_Click);
            // 
            // m_BrowseButton
            // 
            this.m_BrowseButton.Location = new System.Drawing.Point(642, 18);
            this.m_BrowseButton.Name = "m_BrowseButton";
            this.m_BrowseButton.Size = new System.Drawing.Size(32, 23);
            this.m_BrowseButton.TabIndex = 1;
            this.m_BrowseButton.Text = "...";
            this.m_BrowseButton.UseVisualStyleBackColor = true;
            this.m_BrowseButton.Click += new System.EventHandler(this.m_BrowseButton_Click);
            // 
            // m_PathBox
            // 
            this.m_PathBox.Location = new System.Drawing.Point(6, 20);
            this.m_PathBox.Name = "m_PathBox";
            this.m_PathBox.Size = new System.Drawing.Size(630, 21);
            this.m_PathBox.TabIndex = 0;
            // 
            // m_FileList
            // 
            this.m_FileList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_FileList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.path,
            this.totalSize});
            this.m_FileList.Location = new System.Drawing.Point(8, 71);
            this.m_FileList.Name = "m_FileList";
            this.m_FileList.Size = new System.Drawing.Size(391, 306);
            this.m_FileList.SmallImageList = this.m_imageList;
            this.m_FileList.TabIndex = 6;
            this.m_FileList.UseCompatibleStateImageBehavior = false;
            this.m_FileList.View = System.Windows.Forms.View.Details;
            // 
            // path
            // 
            this.path.Text = "Subfolder";
            this.path.Width = 250;
            // 
            // totalSize
            // 
            this.totalSize.Text = "Size";
            this.totalSize.Width = 100;
            // 
            // m_imageList
            // 
            this.m_imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("m_imageList.ImageStream")));
            this.m_imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.m_imageList.Images.SetKeyName(0, "folder.png");
            // 
            // m_SizeCount
            // 
            this.m_SizeCount.AutoSize = true;
            this.m_SizeCount.Location = new System.Drawing.Point(106, 35);
            this.m_SizeCount.Name = "m_SizeCount";
            this.m_SizeCount.Size = new System.Drawing.Size(39, 13);
            this.m_SizeCount.TabIndex = 5;
            this.m_SizeCount.Text = "0.0 GB";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 35);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "Total size:";
            // 
            // m_SubfoldersCount
            // 
            this.m_SubfoldersCount.AutoSize = true;
            this.m_SubfoldersCount.Location = new System.Drawing.Point(106, 22);
            this.m_SubfoldersCount.Name = "m_SubfoldersCount";
            this.m_SubfoldersCount.Size = new System.Drawing.Size(13, 13);
            this.m_SubfoldersCount.TabIndex = 2;
            this.m_SubfoldersCount.Text = "0";
            this.m_SubfoldersCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // m_VersionLabel
            // 
            this.m_VersionLabel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_VersionLabel.Location = new System.Drawing.Point(533, 382);
            this.m_VersionLabel.Name = "m_VersionLabel";
            this.m_VersionLabel.Size = new System.Drawing.Size(186, 13);
            this.m_VersionLabel.TabIndex = 10;
            this.m_VersionLabel.Text = "Requiro";
            this.m_VersionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // m_PieChart
            // 
            this.m_PieChart.Location = new System.Drawing.Point(7, 13);
            this.m_PieChart.Name = "m_PieChart";
            this.m_PieChart.Size = new System.Drawing.Size(405, 211);
            this.m_PieChart.TabIndex = 11;
            this.m_PieChart.TabStop = false;
            this.m_PieChart.Paint += new System.Windows.Forms.PaintEventHandler(this.m_PieChart_Paint);
            // 
            // bgWorker
            // 
            this.bgWorker.WorkerSupportsCancellation = true;
            this.bgWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgWorker_DoWork);
            this.bgWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgWorker_RunWorkerCompleted);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(621, 395);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(202, 13);
            this.linkLabel1.TabIndex = 12;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "http://sourceforge.net/projects/requiro/";
            // 
            // m_FolderBrowser
            // 
            this.m_FolderBrowser.Description = "Select the directory the contents of which you want to analyze.";
            this.m_FolderBrowser.RootFolder = System.Environment.SpecialFolder.MyComputer;
            this.m_FolderBrowser.ShowNewFolderButton = false;
            // 
            // m_StatusLabel
            // 
            this.m_StatusLabel.AutoSize = true;
            this.m_StatusLabel.Location = new System.Drawing.Point(5, 395);
            this.m_StatusLabel.Name = "m_StatusLabel";
            this.m_StatusLabel.Size = new System.Drawing.Size(107, 13);
            this.m_StatusLabel.TabIndex = 14;
            this.m_StatusLabel.Text = "Analysis not started.";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.m_UsagePercent);
            this.panel2.Controls.Add(this.m_SizeCount);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.m_SubfoldersCount);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.m_PathLabel);
            this.panel2.Location = new System.Drawing.Point(405, 307);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(418, 70);
            this.panel2.TabIndex = 9;
            // 
            // m_UsagePercent
            // 
            this.m_UsagePercent.AutoSize = true;
            this.m_UsagePercent.Location = new System.Drawing.Point(106, 48);
            this.m_UsagePercent.Name = "m_UsagePercent";
            this.m_UsagePercent.Size = new System.Drawing.Size(34, 13);
            this.m_UsagePercent.TabIndex = 6;
            this.m_UsagePercent.Text = "0.0%";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 48);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 13);
            this.label6.TabIndex = 4;
            this.label6.Text = "Volume usage:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Subfolders:";
            // 
            // m_PathLabel
            // 
            this.m_PathLabel.AutoSize = true;
            this.m_PathLabel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_PathLabel.Location = new System.Drawing.Point(3, 9);
            this.m_PathLabel.Name = "m_PathLabel";
            this.m_PathLabel.Size = new System.Drawing.Size(142, 13);
            this.m_PathLabel.TabIndex = 0;
            this.m_PathLabel.Text = "Info for: <no directory>";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.m_PieChart);
            this.groupBox1.Location = new System.Drawing.Point(405, 71);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(418, 230);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Disk usage chart";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(716, 382);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "by Antoine Kalmbach";
            // 
            // Mainform
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(832, 417);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.m_StatusLabel);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.m_VersionLabel);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.m_FileList);
            this.Controls.Add(this.m_DirectoryBox);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Mainform";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Requiro v0.1";
            this.Load += new System.EventHandler(this.Mainform_Load);
            this.m_DirectoryBox.ResumeLayout(false);
            this.m_DirectoryBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_PieChart)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox m_DirectoryBox;
        private System.Windows.Forms.Button m_BrowseButton;
        private System.Windows.Forms.TextBox m_PathBox;
        private System.Windows.Forms.Button m_AnalyzeButton;
        private System.Windows.Forms.ListView m_FileList;
        private System.Windows.Forms.ColumnHeader path;
        private System.Windows.Forms.ColumnHeader totalSize;
        private System.Windows.Forms.Label m_SizeCount;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label m_SubfoldersCount;
        private System.Windows.Forms.Label m_VersionLabel;
        private System.Windows.Forms.PictureBox m_PieChart;
        private System.ComponentModel.BackgroundWorker bgWorker;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.FolderBrowserDialog m_FolderBrowser;
        private System.Windows.Forms.Label m_StatusLabel;
        private System.Windows.Forms.ImageList m_imageList;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label m_UsagePercent;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label m_PathLabel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
    }
}

