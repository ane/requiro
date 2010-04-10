using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Reflection;
using System.IO;
using System.Security.Permissions;

// Code comments yet to be written

namespace Requiro
{
    public partial class Mainform : Form
    {
        private Dictionary<string, long> m_DirectorySizes = new Dictionary<string,long>();
        private DirectoryCache m_DirectoryCache = new DirectoryCache();
        private Stopwatch m_Stopwatch = new Stopwatch();
        private Color[] m_Colors = new Color[64];
        private Version m_Version;
        private int m_MaxDirs = 0;
        private Dictionary<string, long> m_PieDirList = new Dictionary<string, long>();
        bool m_SearchSuccesful = false;
        private long m_TotalPieSize = 0;

        const string m_strStartAnalysis = "Start analysis";
        const string m_strStopAnalysis = "Stop analysis";

        public Mainform()
        {
            InitializeComponent();
        }

        private void Mainform_Load(object sender, EventArgs e)
        {
            m_Colors = GetColorArray();
            m_Version = Assembly.GetExecutingAssembly().GetName().Version;
            m_VersionLabel.Text += " v" + m_Version.Major + "." + m_Version.Minor + "." + m_Version.Build + " (build " + m_Version.Revision + ")";
            this.Text = String.Format("Requiro v{0}.{1}.{2}", m_Version.Major, m_Version.Minor, m_Version.Build); 
        }

        private void m_BrowseButton_Click(object sender, EventArgs e)
        {
            m_FolderBrowser.ShowDialog();
            m_PathBox.Text = m_FolderBrowser.SelectedPath;
        }

        private void m_AnalyzeButton_Click(object sender, EventArgs e)
        {
            StartSearch();
        }

        private void StartSearch()
        {
            ToolTip tip = new ToolTip();

            tip.IsBalloon = true;
            tip.InitialDelay = 5000;
            tip.ToolTipIcon = ToolTipIcon.Error;
            tip.UseFading = true;
            tip.ToolTipTitle = "Error";

            if (!Directory.Exists(m_PathBox.Text))
            {
                tip.Show("Invalid path. Please select a valid physical drive or network path.", m_PathBox, new Point(200, -65));
                return;
            }
            if (m_AnalyzeButton.Text == m_strStopAnalysis)
            {
                StopSearch();
                return;
            }

            if (m_DirectoryCache.HasPath(m_PathBox.Text))
            {
                m_Stopwatch.Reset();
                m_Stopwatch.Start();
                BuildListFromCache();
                return;
            }

            m_FileList.Items.Clear();
            //m_DirectorySizes.Clear();
            m_StatusLabel.Text = "Starting analysis...";
            m_AnalyzeButton.Text = m_strStopAnalysis;
            bgWorker.RunWorkerAsync(m_PathBox.Text);
            m_Stopwatch.Reset();
            m_Stopwatch.Start();
            m_StatusLabel.Text = "Analyzing " + m_PathBox.Text + " ... ";
        }

        private void StopSearch()
        {
            if (bgWorker.IsBusy)
                bgWorker.CancelAsync();
            m_StatusLabel.Text = "Analysis cancelled.";
            m_AnalyzeButton.Text = m_strStartAnalysis;
            m_SearchSuccesful = false;
        }

        private void bgWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker bg = sender as BackgroundWorker;
            
            string path = (string) e.Argument;

            try
            {
                this.ProcessDirectory(path, bg, e);
            }

            catch (Exception ex)
            {
                // Cancel the current search
                StopSearch();
                ExceptionForm exfm = new ExceptionForm(ex, m_Version);
                exfm.ShowDialog(this);
            }
        }

        private void BuildListFromCache()
        {
            Dictionary<string, long> files = m_DirectoryCache.GetPathFiles(m_PathBox.Text);
            m_Stopwatch.Stop();
            
            m_FileList.Items.Clear();
            AddParentDirectoryItem();
            long totalSize = 0;
            foreach (KeyValuePair<string, long> kvp in files)
            {
                string path = kvp.Key;
                long size = kvp.Value;
                path = path.Replace(m_PathBox.Text, "");
                if (path.StartsWith("\\"))
                    path = path.Remove(0, 1);
                AddToList(path, kvp.Key, size);
                totalSize += size;
            }

            AddCurrentDirectoryFiles(m_PathBox.Text);
            BuildDirectoryData();
            BuildTextStatistics(totalSize);
            m_PieChart.Refresh();
            UpdateWithStopwatch(true);
        }

        private void AddFilesToCache()
        {
            Dictionary<string, long> files = new Dictionary<string, long>();

            foreach (ListViewItem lvi in m_FileList.Items)
            {
                if (!Directory.Exists(lvi.Tag.ToString()))
                    continue;
                if (lvi.Text == "Parent directory")
                    continue;
                files.Add(lvi.Tag.ToString(), Convert.ToInt64(lvi.SubItems[1].Tag.ToString()));
            }
            if (files.Count > 0)
                m_DirectoryCache.AddPathFiles(m_PathBox.Text, files);
        }

        private void bgWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                m_Stopwatch.Stop();
                m_SearchSuccesful = false;
                if (!e.Cancelled)
                {
                    AddParentDirectoryItem();
                    if (m_DirectorySizes.Count == 0)
                    {
                        long size = AddCurrentDirectoryFiles(m_PathBox.Text);
                        //AddFilesToCache();
                        UpdateWithStopwatch(false);
                        BuildTextStatistics(size);
                        BuildDirectoryData();
                        m_PieChart.Refresh();
                        MessageBox.Show("Pluts");
                    }
                    else
                    {
                        List<string> subfolders = new List<string>();
                        long totalSize = 0;
                        foreach (KeyValuePair<string, long> kvp in m_DirectorySizes)
                        {
                            string subfolder = kvp.Key;
                            long size = kvp.Value;

                            // Remove start slash and initial path
                            subfolder = subfolder.Replace(m_PathBox.Text, "");
                            if (subfolder.StartsWith("\\"))
                                subfolder = subfolder.Remove(0, 1);

                            // Check if it's a direct subfolder
                            bool matched = false;
                            foreach (string sf in subfolders)
                            {                              
                                Match m = Regex.Match(subfolder, Regex.Escape(sf));
                                //Match m = Regex.Match(subfolder, sf);
                                if (m.Success)
                                    matched = true;
                            }
                            // Not a subfolder's subfolder, so we can add it to the list of current directories
                            if (!matched)
                            {
                                subfolders.Add(subfolder);
                                AddToList(subfolder, kvp.Key, size);
                                totalSize += size;
                            }
                        }

                        totalSize += AddCurrentDirectoryFiles(m_PathBox.Text);
                        UpdateWithStopwatch(false);

                        BuildTextStatistics(totalSize);
                        m_SearchSuccesful = true;
                        m_DirectorySizes.Clear();
                        m_MaxDirs = (int)(((m_PieChart.Size.Height - 10)) / 10);
                        BuildDirectoryData();
                        AddFilesToCache();
                        m_PieChart.Refresh();
                    }
                    m_AnalyzeButton.Text = m_strStartAnalysis;
                }
            }

            catch (Exception ex)
            {
                StopSearch();
                ExceptionForm exfm = new ExceptionForm(ex, m_Version);
                exfm.ShowDialog(this);   
            }
        }

        private void UpdateWithStopwatch(bool cached)
        {
            string count, cacheAppend = "";
            if (cached)
            {
                count = m_FileList.Items.Count.ToString();
                cacheAppend = " (Cached)";
            }
            else
            {
                count = m_DirectorySizes.Count.ToString();
            }
            m_StatusLabel.Text = "Analysis complete. Processed a total of " + count + " directories ";
            String secs = String.Format("{0}.{1:##}", m_Stopwatch.Elapsed.Seconds, m_Stopwatch.Elapsed.Milliseconds);
            m_StatusLabel.Text += "in " + secs + " seconds.";
            m_StatusLabel.Text += cacheAppend;
        }

        private void BuildTextStatistics(long size)
        {
            // Set directory info
            string root = Directory.GetDirectoryRoot(m_PathBox.Text);
            m_PathLabel.Text = "Info for " + m_PathBox.Text;
            m_DriveInfoLabel.Text = "Info for " + root;
            m_SubfoldersCount.Text = String.Format("{0} ({1} shown)", m_DirectorySizes.Count, m_FileList.Items.Count);
            m_SizeCount.Text = FormatBytes(size);
            // Check if the root matches to the drives in the system (meaning it's a valid drive)
            foreach (DriveInfo di in (from drive in DriveInfo.GetDrives() where drive.Name.Equals(root) select drive))
            {
                m_UsagePercent.Text = String.Format("{0:P} of used space", (float)size / (di.TotalSize - di.AvailableFreeSpace),
                    FormatBytes(di.TotalSize - di.AvailableFreeSpace), FormatBytes(di.AvailableFreeSpace), di.Name);
                m_DriveSize.Text = FormatBytes(di.TotalSize);
                m_AvailableSpace.Text = FormatBytes(di.AvailableFreeSpace) + String.Format(" ({0:##%})", (float)di.AvailableFreeSpace / di.TotalSize);
                m_UsedSpace.Text = FormatBytes(di.TotalSize - di.AvailableFreeSpace) + String.Format(" ({0:##%})", (float)(di.TotalSize - di.AvailableFreeSpace) / di.TotalSize);
            }
        }

        private void ProcessDirectory(string path, BackgroundWorker worker, DoWorkEventArgs e)
        {
            if (!System.IO.Directory.Exists(path))
                throw new System.IO.DirectoryNotFoundException("Invalid path");

            // Check if we can access the path
            try
            {
                FileIOPermission perm = new FileIOPermission(FileIOPermissionAccess.Read, path);
            }
            catch (System.Security.SecurityException)
            {
                worker.CancelAsync();
            }

            try
            {
                if (worker.CancellationPending)
                {
                    e.Cancel = true;
                }
                else
                {
                    string[] entries = Directory.GetDirectories(path);
                    foreach (string currentDir in entries)
                    {
                        // Check for errors
                        // - Skip hidden files
                        // - Skip directories that don't exist
                        // - Skip directories that we don't have access to
                        try
                        {
                            FileIOPermission perm = new FileIOPermission(FileIOPermissionAccess.Read, currentDir);
                        }
                        catch (System.Security.SecurityException se)
                        {
                            continue;
                        }

                        if ((File.GetAttributes(currentDir) & FileAttributes.Hidden) == FileAttributes.Hidden)
                            continue;
                        if (!Directory.Exists(currentDir))
                            continue;

                        long length = 0;

                        if (m_DirectorySizes.ContainsKey(currentDir))
                        {
                            length = m_DirectorySizes[currentDir];
                        }
                        else
                        {
                            length = GetDirectoryFileSize(currentDir);
                            m_DirectorySizes.Add(currentDir, length);
                        }

                        DirectoryInfo parent = new DirectoryInfo(currentDir).Parent;

                        // Since we have to take the size of sub-folders into account the algorithm
                        // must iterate backwards towards the parent directories and add the size of the current
                        // directory to it.
                        while (parent != null && !this.bgWorker.CancellationPending)
                        {
                            if (m_DirectorySizes.ContainsKey(parent.FullName))
                            {
                                m_DirectorySizes[parent.FullName] += length;
                                parent = parent.Parent;
                            }
                            else
                                break;
                        }

                        ProcessDirectory(currentDir, worker, e);
                    }
                }
            }

            catch (Exception ex)
            {
                StopSearch();
                ExceptionForm exfm = new ExceptionForm(ex, m_Version);
                exfm.ShowDialog(this);
            }
        }


        private long AddCurrentDirectoryFiles(string path)
        {
            System.IO.DirectoryInfo di = new DirectoryInfo(path);
            long size = 0;
            foreach (System.IO.FileInfo file in di.GetFiles())
            {
                string key = file.Extension;

                switch (key.ToUpperInvariant())
                {
                    case ".EXE":
                    case ".LNK":
                        key = System.IO.Path.GetFileNameWithoutExtension(file.FullName);
                        break;
                }

                if (!this.m_imageList.Images.Keys.Contains(key))
                {
                    this.m_imageList.Images.Add(key, System.Drawing.Icon.ExtractAssociatedIcon(file.FullName));
                }

                int index = this.m_imageList.Images.Keys.IndexOf(key);
                long fileSize = file.Length;
                ListViewItem item = new ListViewItem();

                item.Text = file.Name;
    
                item.ImageIndex = index;
                item.SubItems.Add(FormatBytes(fileSize));
                item.SubItems[1].Tag = fileSize;
                size += fileSize;
                item.Tag = file.FullName;

                this.m_FileList.Items.Add(item);
            }
            return size;
        }

        private void AddParentDirectoryItem()
        {
            string path = m_PathBox.Text;
            if (Directory.GetDirectoryRoot(path) != path)
            {
                ListViewItem lvi = new ListViewItem();
                string parentPath = Directory.GetParent(path).FullName;
                lvi.Text = "Parent directory";
                lvi.Tag = parentPath;
                lvi.ImageIndex = 1;
                m_FileList.Items.Add(lvi);
            }
        }

        private void AddToList(string name, string realPath, long size)
        {
            if (name == null)
            {
                MessageBox.Show("APUA");
                return;
            }
            ListViewItem newItem = new ListViewItem();
            newItem.Text = name;
            newItem.Tag = realPath;
            newItem.SubItems.Add(FormatBytes(size));
            newItem.SubItems[1].Tag = size;
            newItem.ImageIndex = 0;
            newItem.Name = name;

            m_FileList.Items.Add(newItem);
        }

        private long GetDirectoryFileSize(string path)
        {
            DirectoryInfo di = new DirectoryInfo(path);
            long size = 0;
            foreach (FileInfo fi in di.GetFiles())
                size += fi.Length;
            return size;
        }

        public string FormatBytes(long bytes)
        {
          const int scale = 1024;
          string[] orders = new string[] { "TB", "GB", "MB", "KB", "B" };
          long max = (long)Math.Pow(scale, 4);

          foreach (string order in orders)
          {
            if ( bytes > max )
              return string.Format("{0:##.##} {1}", decimal.Divide( bytes, max ), order);

            max /= scale;
          }
          return "0 B";
        }


        Color[] GetColorArray()
        {

            // declare an Array for 64 colors
            Color[] colors = new Color[64];
            Random r = new Random();

            // fill the array of colors for chart items
            // use browser-safe colors (multiples of #33)
            for (int i = 0; i < 64; i++)
            {
                colors[i] = Color.FromArgb(r.Next(0, 255), r.Next(0, 255), r.Next(0, 255));
            }

            return colors;
        }

        private string Truncate(string str, int maxLen)
        {
            if (str.Length > maxLen)
                return str.Substring(0, maxLen) + "...";
            else return str;
        }

        private void m_FileList_Click(object sender, EventArgs e)
        {
            if (m_FileList.SelectedItems.Count > 0)
            {
                string selectedPath = m_FileList.SelectedItems[0].Tag.ToString();
                if (Directory.Exists(selectedPath)) {
                    m_PathBox.Text = m_FileList.SelectedItems[0].Tag.ToString();
                    StartSearch();
                }
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start(linkLabel1.Text);
            }
            catch (Exception ex)
            {
                // Do nothing. If Windows Firewall blocks the start of the browser the process will not start and we ignore it.
            }
        }

        private void BuildDirectoryData()
        {
            m_TotalPieSize = 0;
            m_PieDirList.Clear();
            // Calculate size
            for (int c = 0; c < m_MaxDirs && c < m_FileList.Items.Count; c++)
            {                
                ListViewItem lvi = m_FileList.Items[c];
                // Skip files
                //if (!Directory.Exists(lvi.Tag.ToString()))
                //    continue;
                if (lvi.Text == "Parent directory")
                    continue;
                long size = (long)lvi.SubItems[1].Tag;
                m_PieDirList.Add(lvi.Text, size);
                m_TotalPieSize += size;
            }
        }

        private void m_PieChart_Paint(object sender, PaintEventArgs e)
        {
            if (!m_SearchSuccesful)
                return;

            if (m_PieChart.Size.Width == 1 || m_PieChart.Size.Height == 1)
                return;

            int boxSize = 12;

            Graphics g = e.Graphics;
            g.Clear(this.BackColor);
            Pen pen = new Pen(Color.Transparent, 1.0f);
            
            Size sz = new Size((int)(m_PieChart.Size.Width * 0.6), (int)(m_PieChart.Size.Height * 0.9));
            Point pt = new Point(0, (int)(sz.Height * 0.05));
            Rectangle rec = new Rectangle(pt, sz);
            Random rand = new Random();

            // Calculate the approximate size for the legends
            // The font we use is 7.5 points high, the default Windows points per pixel is 96
            // So 7.5 points is about 10 pixels, thus divide the leftover size by that
            // Our width is the remaining drawing area plus the size of a box and 10 pixels for padding
            int truncateLen = (int)(((sz.Width * 0.6) + boxSize + 10) / 10);
            List<float> pieslices = new List<float>(m_MaxDirs);

            if (m_FileList.Items.Count == 1)
            {
                g.DrawString("Empty directory or no directory selected.", new Font("Tahoma", 8.0f), new SolidBrush(Color.Black), new Point(sz.Width - 130, sz.Height - 100));
                return;
            }

            // Sort the dictionary first (insignificant directories can be left out when there's too much to draw)
            var directories = (from entry in m_PieDirList orderby entry.Value descending select entry).Take(m_MaxDirs);
            // Calculate pieslices 
            foreach (KeyValuePair<string, long> kvp in directories)
            {
                float size = (kvp.Value / (float)m_TotalPieSize) * 360;
                pieslices.Add(size);
            }
            g.Clear(Mainform.DefaultBackColor);
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

            // Draw pie slices
            float startLoc = 0;
            for (int i = 0; i < pieslices.Count; i++)
            {
                g.DrawPie(pen, rec, startLoc, pieslices[i]);
                g.FillPie(new SolidBrush(m_Colors[i]), rec, startLoc, pieslices[i]);
                startLoc += pieslices[i];
            }
            int count = 0;
            int y = 0;

            // Draw Legend
            foreach (KeyValuePair<string, long> kvp in directories)
            {
                if (count >= m_MaxDirs)
                {
                    g.DrawString("(" + (m_PieDirList.Count - m_MaxDirs).ToString() + " more)", new Font("Tahoma", 7.5F), new SolidBrush(Color.Black), new Point(sz.Width + 8, y + 5));
                    break;
                }
                string percentage = String.Format(" - {0:P}", ((pieslices[count] / 360)));
                Color rectColor = m_Colors[count];
                Brush rectBrush = new SolidBrush(m_Colors[count]);
                g.DrawRectangle(new Pen(Color.Black), new Rectangle(sz.Width + 10, y, boxSize, boxSize));
                g.FillRectangle(rectBrush, sz.Width + 10, y, boxSize, boxSize);
                g.DrawString(Truncate(kvp.Key, truncateLen) + percentage, new Font("Tahoma", 7.5F), new SolidBrush(Color.Black), new Point(sz.Width + 25, y));
                y += boxSize;
                count++;
            }
        }

        private void m_PieChart_SizeChanged(object sender, EventArgs e)
        {
            m_PieChart.Refresh();
        }

        private void m_PieChart_LoadCompleted(object sender, AsyncCompletedEventArgs e)
        {

        }
    }
}
