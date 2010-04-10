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
            this.m_DriveSize = new System.Windows.Forms.Label();
            this.m_AvailableSpace = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.m_UsedSpace = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.m_DriveInfoLabel = new System.Windows.Forms.Label();
            this.m_UsagePercent = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.m_PathLabel = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.m_RefreshCurrentDirButton = new System.Windows.Forms.Button();
            this.m_DeleteSelectedDirectoryButton = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.m_PathBox = new System.Windows.Forms.ComboBox();
            this.m_DirectoryBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_PieChart)).BeginInit();
            this.panel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_DirectoryBox
            // 
            this.m_DirectoryBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_DirectoryBox.Controls.Add(this.m_PathBox);
            this.m_DirectoryBox.Controls.Add(this.m_AnalyzeButton);
            this.m_DirectoryBox.Controls.Add(this.m_BrowseButton);
            this.m_DirectoryBox.Location = new System.Drawing.Point(8, 12);
            this.m_DirectoryBox.Name = "m_DirectoryBox";
            this.m_DirectoryBox.Size = new System.Drawing.Size(1127, 53);
            this.m_DirectoryBox.TabIndex = 0;
            this.m_DirectoryBox.TabStop = false;
            this.m_DirectoryBox.Text = "Full path to target directory";
            // 
            // m_AnalyzeButton
            // 
            this.m_AnalyzeButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_AnalyzeButton.Location = new System.Drawing.Point(992, 18);
            this.m_AnalyzeButton.Name = "m_AnalyzeButton";
            this.m_AnalyzeButton.Size = new System.Drawing.Size(129, 23);
            this.m_AnalyzeButton.TabIndex = 2;
            this.m_AnalyzeButton.Text = "Start analysis";
            this.m_AnalyzeButton.UseVisualStyleBackColor = true;
            this.m_AnalyzeButton.Click += new System.EventHandler(this.m_AnalyzeButton_Click);
            // 
            // m_BrowseButton
            // 
            this.m_BrowseButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_BrowseButton.Location = new System.Drawing.Point(954, 18);
            this.m_BrowseButton.Name = "m_BrowseButton";
            this.m_BrowseButton.Size = new System.Drawing.Size(33, 23);
            this.m_BrowseButton.TabIndex = 1;
            this.m_BrowseButton.Text = "...";
            this.m_BrowseButton.UseVisualStyleBackColor = true;
            this.m_BrowseButton.Click += new System.EventHandler(this.m_BrowseButton_Click);
            // 
            // m_FileList
            // 
            this.m_FileList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_FileList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.path,
            this.totalSize});
            this.m_FileList.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_FileList.FullRowSelect = true;
            this.m_FileList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.m_FileList.Location = new System.Drawing.Point(8, 90);
            this.m_FileList.MultiSelect = false;
            this.m_FileList.Name = "m_FileList";
            this.m_FileList.Size = new System.Drawing.Size(653, 330);
            this.m_FileList.SmallImageList = this.m_imageList;
            this.m_FileList.TabIndex = 6;
            this.m_FileList.UseCompatibleStateImageBehavior = false;
            this.m_FileList.View = System.Windows.Forms.View.Details;
            this.m_FileList.Click += new System.EventHandler(this.m_FileList_Click);
            // 
            // path
            // 
            this.path.Text = "Subfolder";
            this.path.Width = 450;
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
            this.m_imageList.Images.SetKeyName(1, "arrow_undo.png");
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
            this.m_VersionLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.m_VersionLabel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_VersionLabel.Location = new System.Drawing.Point(846, 425);
            this.m_VersionLabel.Name = "m_VersionLabel";
            this.m_VersionLabel.Size = new System.Drawing.Size(186, 13);
            this.m_VersionLabel.TabIndex = 10;
            this.m_VersionLabel.Text = "Requiro";
            this.m_VersionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // m_PieChart
            // 
            this.m_PieChart.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_PieChart.Location = new System.Drawing.Point(7, 13);
            this.m_PieChart.Name = "m_PieChart";
            this.m_PieChart.Size = new System.Drawing.Size(455, 240);
            this.m_PieChart.TabIndex = 11;
            this.m_PieChart.TabStop = false;
            this.m_PieChart.LoadCompleted += new System.ComponentModel.AsyncCompletedEventHandler(this.m_PieChart_LoadCompleted);
            this.m_PieChart.SizeChanged += new System.EventHandler(this.m_PieChart_SizeChanged);
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
            this.linkLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(933, 438);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(202, 13);
            this.linkLabel1.TabIndex = 12;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "http://sourceforge.net/projects/requiro/";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // m_FolderBrowser
            // 
            this.m_FolderBrowser.Description = "Select the directory the contents of which you want to analyze.";
            this.m_FolderBrowser.RootFolder = System.Environment.SpecialFolder.MyComputer;
            this.m_FolderBrowser.ShowNewFolderButton = false;
            // 
            // m_StatusLabel
            // 
            this.m_StatusLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.m_StatusLabel.AutoSize = true;
            this.m_StatusLabel.Location = new System.Drawing.Point(5, 433);
            this.m_StatusLabel.Name = "m_StatusLabel";
            this.m_StatusLabel.Size = new System.Drawing.Size(107, 13);
            this.m_StatusLabel.TabIndex = 14;
            this.m_StatusLabel.Text = "Analysis not started.";
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.m_DriveSize);
            this.panel2.Controls.Add(this.m_AvailableSpace);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.m_UsedSpace);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.m_DriveInfoLabel);
            this.panel2.Controls.Add(this.m_UsagePercent);
            this.panel2.Controls.Add(this.m_SizeCount);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.m_SubfoldersCount);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.m_PathLabel);
            this.panel2.Location = new System.Drawing.Point(667, 350);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(468, 70);
            this.panel2.TabIndex = 9;
            // 
            // m_DriveSize
            // 
            this.m_DriveSize.Location = new System.Drawing.Point(333, 22);
            this.m_DriveSize.Name = "m_DriveSize";
            this.m_DriveSize.Size = new System.Drawing.Size(67, 13);
            this.m_DriveSize.TabIndex = 13;
            this.m_DriveSize.Text = "0.0 GB";
            this.m_DriveSize.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // m_AvailableSpace
            // 
            this.m_AvailableSpace.Location = new System.Drawing.Point(282, 35);
            this.m_AvailableSpace.Name = "m_AvailableSpace";
            this.m_AvailableSpace.Size = new System.Drawing.Size(118, 13);
            this.m_AvailableSpace.TabIndex = 12;
            this.m_AvailableSpace.Text = "0.0 GB";
            this.m_AvailableSpace.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(230, 48);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(66, 13);
            this.label8.TabIndex = 11;
            this.label8.Text = "Used space:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(230, 22);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(57, 13);
            this.label7.TabIndex = 10;
            this.label7.Text = "Drive size:";
            // 
            // m_UsedSpace
            // 
            this.m_UsedSpace.Location = new System.Drawing.Point(294, 48);
            this.m_UsedSpace.Name = "m_UsedSpace";
            this.m_UsedSpace.Size = new System.Drawing.Size(106, 13);
            this.m_UsedSpace.TabIndex = 9;
            this.m_UsedSpace.Text = "0.0 GB";
            this.m_UsedSpace.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(230, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Available:";
            // 
            // m_DriveInfoLabel
            // 
            this.m_DriveInfoLabel.AutoSize = true;
            this.m_DriveInfoLabel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_DriveInfoLabel.Location = new System.Drawing.Point(230, 9);
            this.m_DriveInfoLabel.Name = "m_DriveInfoLabel";
            this.m_DriveInfoLabel.Size = new System.Drawing.Size(170, 13);
            this.m_DriveInfoLabel.TabIndex = 7;
            this.m_DriveInfoLabel.Text = "Info for: <no drive selected>";
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
            this.label3.Size = new System.Drawing.Size(79, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Subdirectories:";
            // 
            // m_PathLabel
            // 
            this.m_PathLabel.AutoSize = true;
            this.m_PathLabel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_PathLabel.Location = new System.Drawing.Point(3, 9);
            this.m_PathLabel.Name = "m_PathLabel";
            this.m_PathLabel.Size = new System.Drawing.Size(193, 13);
            this.m_PathLabel.TabIndex = 0;
            this.m_PathLabel.Text = "Info for: <no directory selected>";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.m_PieChart);
            this.groupBox1.Location = new System.Drawing.Point(667, 85);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(468, 259);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1028, 425);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "by Antoine Kalmbach";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(5, 72);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(93, 14);
            this.label4.TabIndex = 18;
            this.label4.Text = "Search results";
            // 
            // m_RefreshCurrentDirButton
            // 
            this.m_RefreshCurrentDirButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.m_RefreshCurrentDirButton.Location = new System.Drawing.Point(504, 426);
            this.m_RefreshCurrentDirButton.Name = "m_RefreshCurrentDirButton";
            this.m_RefreshCurrentDirButton.Size = new System.Drawing.Size(75, 27);
            this.m_RefreshCurrentDirButton.TabIndex = 19;
            this.m_RefreshCurrentDirButton.Text = "Refresh";
            this.m_RefreshCurrentDirButton.UseVisualStyleBackColor = true;
            // 
            // m_DeleteSelectedDirectoryButton
            // 
            this.m_DeleteSelectedDirectoryButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.m_DeleteSelectedDirectoryButton.Location = new System.Drawing.Point(586, 426);
            this.m_DeleteSelectedDirectoryButton.Name = "m_DeleteSelectedDirectoryButton";
            this.m_DeleteSelectedDirectoryButton.Size = new System.Drawing.Size(75, 27);
            this.m_DeleteSelectedDirectoryButton.TabIndex = 20;
            this.m_DeleteSelectedDirectoryButton.Text = "Delete";
            this.m_DeleteSelectedDirectoryButton.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(664, 72);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(64, 14);
            this.label9.TabIndex = 21;
            this.label9.Text = "Statistics";
            // 
            // m_PathBox
            // 
            this.m_PathBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_PathBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.m_PathBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.FileSystemDirectories;
            this.m_PathBox.FormattingEnabled = true;
            this.m_PathBox.Location = new System.Drawing.Point(6, 20);
            this.m_PathBox.Name = "m_PathBox";
            this.m_PathBox.Size = new System.Drawing.Size(942, 21);
            this.m_PathBox.TabIndex = 3;
            // 
            // Mainform
            // 
            this.AcceptButton = this.m_AnalyzeButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1144, 460);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.m_DeleteSelectedDirectoryButton);
            this.Controls.Add(this.m_RefreshCurrentDirButton);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.m_StatusLabel);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.m_VersionLabel);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.m_FileList);
            this.Controls.Add(this.m_DirectoryBox);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Mainform";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Requiro";
            this.Load += new System.EventHandler(this.Mainform_Load);
            this.m_DirectoryBox.ResumeLayout(false);
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
        private System.Windows.Forms.Label m_DriveSize;
        private System.Windows.Forms.Label m_AvailableSpace;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label m_UsedSpace;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label m_DriveInfoLabel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button m_RefreshCurrentDirButton;
        private System.Windows.Forms.Button m_DeleteSelectedDirectoryButton;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox m_PathBox;
    }
}

