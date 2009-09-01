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

// Code comments yet to be written

namespace Requiro
{
    public partial class Mainform : Form
    {
        private Dictionary<string, long> m_DirectorySizes = new Dictionary<string,long>();
        private Stopwatch m_Stopwatch = new Stopwatch();

        public Mainform()
        {
            InitializeComponent();
        }

        private void Mainform_Load(object sender, EventArgs e)
        {
            Version version = Assembly.GetExecutingAssembly().GetName().Version;
            m_VersionLabel.Text += " " + version.Major + "." + version.Minor + " alpha (build " + version.Build + ")";
            this.Text = String.Format("Requiro v{0}.{1}.{2}", version.Major, version.Minor, version.Build); 
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
            if (!Directory.Exists(m_PathBox.Text))
                return;
            if (m_AnalyzeButton.Text == "Stop" && bgWorker.IsBusy)
            {
                bgWorker.CancelAsync();
                return;
            }

            m_DirectorySizes.Clear();
            m_FileList.Items.Clear();

            m_StatusLabel.Text = "Starting analysis...";
            m_AnalyzeButton.Text = "Stop";
            bgWorker.RunWorkerAsync(m_PathBox.Text);
            m_Stopwatch.Reset();
            m_Stopwatch.Start();
            m_StatusLabel.Text = "Analysing " + m_PathBox.Text + " ... ";
        }

        private void bgWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker bg = sender as BackgroundWorker;

            string path = (string) e.Argument;

            this.ProcessDirectory(path, bg, e);
        }

        private void bgWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            m_Stopwatch.Stop();
            if (e.Cancelled)
            {
                m_StatusLabel.Text = "Analysis cancelled before it could finish.";
            }
            else
            {
                AddParentDirectoryItem();
                if (m_DirectorySizes.Count == 0)
                {
                    m_StatusLabel.Text = "No subfolders were found.";
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

                        // Check whether the folder exists - we're not showing subfolders of subfolders (yet)
                        bool matched = false;
                        foreach (string sf in subfolders)
                        {
                            Match m = Regex.Match(subfolder, sf);
                            if (m.Success)
                                matched = true;
                        }
                        // Didn't exit add it
                        if (!matched)
                        {
                            subfolders.Add(subfolder);
                            AddToList(subfolder, kvp.Key, size);
                            totalSize += size;
                        }
                    }

                    m_StatusLabel.Text = "Analysis complete. Processed a total of " + m_DirectorySizes.Count.ToString() + " directories ";
                    String secs = String.Format("{0}.{1:##}", m_Stopwatch.Elapsed.Seconds, m_Stopwatch.Elapsed.Milliseconds);
                    m_StatusLabel.Text += "in " + secs + " seconds.";

                    // Set directory info
                    string root = Directory.GetDirectoryRoot(m_PathBox.Text);
                    m_PathLabel.Text = "Info for " + m_PathBox.Text;
                    m_DriveInfoLabel.Text = "Info for " + root;
                    m_SubfoldersCount.Text = String.Format("{0} ({1} shown)", m_DirectorySizes.Count, m_FileList.Items.Count);
                    m_SizeCount.Text = FormatBytes(totalSize);
                    // Check if the root matches to the drives in the system (meaning it's a valid drive)
                    foreach (DriveInfo di in (from drive in DriveInfo.GetDrives() where drive.Name.Equals(root) select drive))
                    {
                        m_UsagePercent.Text = String.Format("{0:P} of used space", (float)totalSize / (di.TotalSize - di.AvailableFreeSpace),
                            FormatBytes(di.TotalSize - di.AvailableFreeSpace), FormatBytes(di.AvailableFreeSpace), di.Name);
                        m_DriveSize.Text = FormatBytes(di.TotalSize);
                        m_AvailableSpace.Text = FormatBytes(di.AvailableFreeSpace) + String.Format(" ({0:##%})", (float)di.AvailableFreeSpace / di.TotalSize);
                        m_UsedSpace.Text = FormatBytes(di.TotalSize - di.AvailableFreeSpace) + String.Format(" ({0:##%})", (float)(di.TotalSize - di.AvailableFreeSpace) / di.TotalSize);
                    }
                    m_DirectorySizes.Clear();
                    DrawPiechart();
                }
                m_TipLabel.Visible = true;
                m_AnalyzeButton.Text = "Start analysis";
            }
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
                return;

            ListViewItem newItem = new ListViewItem();
            newItem.Text = name;
            newItem.Tag = realPath;
            newItem.SubItems.Add(FormatBytes(size));
            newItem.SubItems[1].Tag = size;
            newItem.ImageIndex = 0;
            newItem.Name = name;

            m_FileList.Items.Add(newItem);
        }

        private long GetDirectorySize(string path)
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
          return "0B";
        }

        private void ProcessDirectory(string path, BackgroundWorker worker, DoWorkEventArgs e)
        {
            if (!System.IO.Directory.Exists(path))
                throw new System.IO.DirectoryNotFoundException("Invalid path");

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
                        // Skip hidden files
                        if ((File.GetAttributes(currentDir) & FileAttributes.Hidden) == FileAttributes.Hidden)
                            continue;
       
                        long length = GetDirectorySize(currentDir);
                        if (!m_DirectorySizes.ContainsKey(currentDir))
                            m_DirectorySizes.Add(currentDir, length);

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

            catch (DirectoryNotFoundException)
            {
                MessageBox.Show("AUGH");
            }

            catch (UnauthorizedAccessException)
            {
            }

            catch (FileNotFoundException)
            {
            }
        }

        private void DrawPiechart()
        {
            m_PieChart.Invalidate();
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

        private void m_PieChart_Paint(object sender, PaintEventArgs e)
        {
            PictureBox pb = sender as PictureBox;
          
            Graphics g = e.Graphics;
            

            Pen pen = new Pen(Color.Black, 1);
            long totalSize = 0;
            Dictionary<string, long> dirList = new Dictionary<string, long>();
            List<float> pieslices = new List<float>(m_FileList.Items.Count);
            Size sz = new Size((int)(m_PieChart.Size.Width * 0.6), (int)(m_PieChart.Size.Height * 0.9));
            Point pt = new Point(0, (int)(sz.Height * 0.05));
            Rectangle rec = new Rectangle(pt, sz);
            Color[] colors = GetColorArray();
            Random rand = new Random();

            if (m_FileList.Items.Count == 0)
            {
                g.DrawString("Select a path to analyse...", new Font("Tahoma", 8.0f), new SolidBrush(Color.Black), new Point(sz.Width - 100, sz.Height - 100));
                return;
            }

            // Calculate size
            foreach (ListViewItem lvi in m_FileList.Items)
            {
                if (lvi.Text == "Parent directory")
                    continue;
                long size = (long)lvi.SubItems[1].Tag;
                dirList.Add(lvi.Text, size);
                totalSize += size;
            }

            // Sort the dictionary first (insignifcant directories can be left out when there's too much to draw)
            var directories = (from entry in dirList orderby entry.Value descending select entry);
            // Calculate pieslices 
            foreach (KeyValuePair<string, long> kvp in directories)
            {
                float size = (kvp.Value / (float)totalSize) * 360;
                pieslices.Add(size);
            }
            g.Clear(Mainform.DefaultBackColor);
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            // Draw pie slices
            float startLoc = 0;
            for (int i = 0; i < pieslices.Count; i++)
            {
                g.DrawPie(pen, rec, startLoc, pieslices[i]);
                g.FillPie(new SolidBrush(colors[i]), rec, startLoc, pieslices[i]);
                startLoc += pieslices[i];
            }
            int count = 0;
            int y = 0;
            int boxSize = 12;
            
            // Draw Legend
            foreach (KeyValuePair<string, long> kvp in directories)
            {
                if (count >= 16)
                {
                    g.DrawString("(" + (dirList.Count - 16).ToString() + " more)", new Font("Tahoma", 7.5F), new SolidBrush(Color.Black), new Point(sz.Width + 8, y + 5));
                    break;
                }
                string percentage = String.Format(" - {0:P}", ((pieslices[count] / 360)));
                Color rectColor = colors[count];
                Brush rectBrush = new SolidBrush(colors[count]);
                g.DrawRectangle(new Pen(Color.Black), new Rectangle(sz.Width + 10, y, boxSize, boxSize));
                g.FillRectangle(rectBrush, sz.Width + 10, y, boxSize, boxSize);
                g.DrawString(Truncate(kvp.Key, 15) + percentage, new Font("Tahoma", 7.5F), new SolidBrush(Color.Black), new Point(sz.Width + 25, y));
                y += boxSize;
                count += 1;
            }
        }

        private void m_FileList_Click(object sender, EventArgs e)
        {
            if (m_FileList.SelectedItems.Count > 0)
            {
                m_PathBox.Text = m_FileList.SelectedItems[0].Tag.ToString();
                StartSearch();
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(linkLabel1.Text);
        }
    }
}
