using System.Data;
using System.Drawing;
using thhylR.Common;
using thhylR.Games;
using thhylR.Properties;

namespace thhylR
{
    public partial class FormMain : Form
    {
        private bool isSelecting = false;
        public FormMain()
        {
            InitializeComponent();
            GameData.Init();
            EnumData.Init();
            dataGridInfo.AutoGenerateColumns = false;
        }

        private TouhouReplay currentReplay = null;

        private void showOpenReplayDialog()
        {
            var dialogResult = openReplayDialog.ShowDialog(this);
            if (dialogResult != DialogResult.OK)
            {
                return;
            }
            var fileName = openReplayDialog.FileName;
            openReplay(fileName);
        }

        private void openReplay(string fileName, bool refreshFileList = true)
        {
            var fileExt = Path.GetExtension(fileName);
            if (fileExt.ToLower() != ".rpy")
            {
                MessageBox.Show(string.Format(Resources.NotSupportedFile, Path.GetFileName(fileName)), Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            byte[] fileData = File.ReadAllBytes(fileName);
            currentReplay = ReplayAnalyzer.Analyze(fileData);
            if (currentReplay != null)
            {
                textBoxPath.Text = fileName;
                currentReplay.FilePath = fileName;
                dataGridInfo.DataSource = currentReplay.DisplayData.Select("Visible <> 0").CopyToDataTable();
                if (refreshFileList)
                {
                    var replayPath = Path.GetDirectoryName(fileName);
                    setFiles(replayPath, Path.GetFileName(fileName));
                    fileSystemWatcherFolder.Path = replayPath;
                }
            }
            else
            {
                MessageBox.Show(string.Format(Resources.NotSupportedFile, Path.GetFileName(fileName)), Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void setFiles(string path, string filename)
        {
            treeViewFiles.Nodes.Clear();
            treeViewFiles.Nodes.Add(path);
            var fileList = Directory.GetFiles(path, "*.rpy");
            for (int i = 0; i < fileList.Length; i++)
            {
                var file = fileList[i];
                var currentFileName = Path.GetFileName(file);
                treeViewFiles.Nodes[0].Nodes.Add(currentFileName);
                if (!isSelecting && currentFileName == filename)
                {
                    isSelecting = true;
                    treeViewFiles.SelectedNode = treeViewFiles.Nodes[0].Nodes[i];
                    isSelecting = false;
                }
            }
            treeViewFiles.Nodes[0].Expand();
        }

        private void buttonOpen_Click(object sender, EventArgs e)
        {
            showOpenReplayDialog();
        }

        private void dataGridInfo_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridInfo.SelectedRows.Count != 0)
            {
                DataRow dr = ((DataRowView)dataGridInfo.SelectedRows[0].DataBoundItem).Row;
                textBoxInfo.Text = dr["Value"].ToString();
            }
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void ExportAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (currentReplay != null)
            {
                byte[] result = new byte[currentReplay.Header.Length + currentReplay.RawData.Length + currentReplay.InfoBlockRawData.Length];
                Array.Copy(currentReplay.Header, 0, result, 0, currentReplay.Header.Length);
                Array.Copy(currentReplay.RawData, 0, result, currentReplay.Header.Length, currentReplay.RawData.Length);
                Array.Copy(currentReplay.InfoBlockRawData, 0,
                    result, currentReplay.Header.Length + currentReplay.RawData.Length, currentReplay.InfoBlockRawData.Length);
                saveFileDialog.Filter = Resources.RawDataFilter;
                var dialogResult = saveFileDialog.ShowDialog();
                if (dialogResult == DialogResult.OK)
                {
                    File.WriteAllBytes(saveFileDialog.FileName, result);
                }
            }
        }

        private void treeViewFiles_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (isSelecting)
            {
                return;
            }
            isSelecting = true;
            if (treeViewFiles.SelectedNode != treeViewFiles.Nodes[0])
            {
                string path = Path.Combine(treeViewFiles.Nodes[0].Text, treeViewFiles.SelectedNode.Text);
                openReplay(path, false);
            }
            isSelecting = false;
        }

        private void FormMain_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                var files = (string[])e.Data.GetData(DataFormats.FileDrop);
                if (files.Length > 0)
                {
                    openReplay(files[0]);
                }
            }
        }

        private void FormMain_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Move;

            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void fileSystemWatcherFolder_Events(object sender, FileSystemEventArgs e)
        {
            folderChanged();
        }

        private void fileSystemWatcherFolder_Renamed(object sender, RenamedEventArgs e)
        {
            folderChanged();
        }

        private void folderChanged()
        {
            if (!string.IsNullOrEmpty(fileSystemWatcherFolder.Path))
            {
                setFiles(fileSystemWatcherFolder.Path, Path.GetFileName(currentReplay.FilePath));
            }
        }

        private void treeViewFiles_DrawNode(object sender, DrawTreeNodeEventArgs e)
        {
            if (e.Node == null) return;

            if (!e.Node.TreeView.Focused && e.State.HasFlag(TreeNodeStates.Selected))
            {
                var font = e.Node.NodeFont ?? e.Node.TreeView.Font;
                e.Graphics.FillRectangle(SystemBrushes.Highlight, e.Bounds);
                TextRenderer.DrawText(e.Graphics, e.Node.Text, font, e.Bounds, SystemColors.HighlightText, TextFormatFlags.GlyphOverhangPadding);
            }
            else
            {
                e.DrawDefault = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("\u2665\uFE0E");
        }
    }
}
