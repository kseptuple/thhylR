using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text;
using System.Text.Encodings.Web;
using thhylR.Common;
using thhylR.Games;
using thhylR.Helper;
using thhylR.Properties;

namespace thhylR
{
    public partial class FormMain : Form
    {
        private bool isSelecting = false;

        private int currentFilePos = -1;

        public BindingList<string> currentPathFiles = new BindingList<string>();

        private TouhouReplay currentReplay = null;

        private string fileToOpen = null;

        private Font normalFont;
        private Font symbolFont;

        private bool isFileOpen = false;

        private bool showAllEncodingsOld = false;

        private List<ToolStripMenuItem> encodingMenuItem = new List<ToolStripMenuItem>();
        private readonly List<Keys> encodingMenuHotkeys = new List<Keys>() { Keys.F5, Keys.F6, Keys.F7, Keys.F8 };

        private int currentCodePage = 0;

        List<EncodingInfo> encodingList = new List<EncodingInfo>();

        public FormMain()
        {
            InitializeComponent();
            splitContainerMain.Panel1.Name = "MainPanel1";
            splitContainerMain.Panel2.Name = "MainPanel2";
            splitContainerInfo.Panel1.Name = "InfoPanel1";
            splitContainerInfo.Panel2.Name = "InfoPanel2";
            GameData.Init();
            EnumData.Init();
            SettingProvider.Init();
            ResourceLoader.Init();

            ResourceLoader.SetFormText(this);
            ResourceLoader.InitTextResource();
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            dataGridInfo.AutoGenerateColumns = false;
            dataGridInfo.DefaultCellStyle.Font = SettingProvider.Settings.NormalFont;

            normalFont = SettingProvider.Settings.NormalFont;
            symbolFont = SettingProvider.Settings.SymbolFont;

            TopMost = SettingProvider.Settings.OnTop;

            if (PrivilegeHelper.IsAdministrator())
            {
                Text += $" {ResourceLoader.getTextResource("AdminHint")}";
            }

            toolStripButtonOpen.ToolTipText = ResourceLoader.getTextResource("OpenTip");
            toolStripButtonCut.ToolTipText = ResourceLoader.getTextResource("CutTip");
            toolStripButtonCopy.ToolTipText = ResourceLoader.getTextResource("CopyTip");
            toolStripButtonMoveTo.ToolTipText = ResourceLoader.getTextResource("MoveToTip");
            toolStripButtonCopyTo.ToolTipText = ResourceLoader.getTextResource("CopyToTip");
            toolStripButtonDelete.ToolTipText = ResourceLoader.getTextResource("DeleteTip");
            toolStripButtonRename.ToolTipText = ResourceLoader.getTextResource("RenameTip");

            toolStripButtonFirst.ToolTipText = ResourceLoader.getTextResource("FirstReplayTip");
            toolStripButtonPrevious.ToolTipText = ResourceLoader.getTextResource("PreviousReplayTip");
            toolStripButtonNext.ToolTipText = ResourceLoader.getTextResource("NextReplayTip");
            toolStripButtonLast.ToolTipText = ResourceLoader.getTextResource("LastReplayTip");

            encodingMenuItem.Add(Encoding1ToolStripMenuItem);
            encodingMenuItem.Add(Encoding2ToolStripMenuItem);
            encodingMenuItem.Add(Encoding3ToolStripMenuItem);
            encodingMenuItem.Add(Encoding4ToolStripMenuItem);

            textBoxPath.Left = label1.Left + label1.Width + textBoxPath.Margin.Left;
            comboBoxEncoding.Left = label2.Left + label2.Width + comboBoxEncoding.Margin.Left;
            textBoxPath.Width = splitContainerInfo.Panel1.Width - textBoxPath.Left;
            comboBoxEncoding.Width = splitContainerInfo.Panel2.Width - comboBoxEncoding.Left;

            encodingList = Encoding.GetEncodings().ToList();
            loadEncodingList();

            setFileIsOpen(false);

            var args = Environment.GetCommandLineArgs();
            if (args.Length > 1)
            {
                string filename = args[1];
                if (File.Exists(filename))
                {
                    openReplay(filename);
                }
                else
                {
                    MessageBox.Show(string.Format(ResourceLoader.getTextResource("NotExistedFile"), filename), Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
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
                int resultLength = currentReplay.Header.Length + currentReplay.RawData.Length;
                if (currentReplay.InfoBlockRawData != null)
                {
                    resultLength += currentReplay.InfoBlockRawData.Length;
                }
                byte[] result = new byte[resultLength];
                Array.Copy(currentReplay.Header, 0, result, 0, currentReplay.Header.Length);
                Array.Copy(currentReplay.RawData, 0, result, currentReplay.Header.Length, currentReplay.RawData.Length);
                if (currentReplay.InfoBlockRawData != null)
                {
                    Array.Copy(currentReplay.InfoBlockRawData, 0,
                        result, currentReplay.Header.Length + currentReplay.RawData.Length, currentReplay.InfoBlockRawData.Length);
                }

                saveFileDialog.Filter = ResourceLoader.getTextResource("RawDataFilter");
                var dialogResult = saveFileDialog.ShowDialog(this);
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
                currentFilePos = treeViewFiles.SelectedNode.Index;
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

        private void OptionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OptionCommand();
        }

        private void toolStripButtonOpen_Click(object sender, EventArgs e)
        {
            openReplayCommand();
        }

        private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openReplayCommand();
        }

        private void openReplayCommand()
        {
            showOpenReplayDialog();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cutCommand();
        }

        private void toolStripButtonCut_Click(object sender, EventArgs e)
        {
            cutCommand();
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            copyCommand();
        }

        private void toolStripButtonCopy_Click(object sender, EventArgs e)
        {
            copyCommand();
        }

        private void RenameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RenameCommand();
        }

        private void toolStripButtonRename_Click(object sender, EventArgs e)
        {
            RenameCommand();
        }

        private void toolStripButtonMoveTo_Click(object sender, EventArgs e)
        {
            MoveCopyToCommnad(true);
        }


        private void toolStripButtonCopyTo_Click(object sender, EventArgs e)
        {
            MoveCopyToCommnad(false);
        }


        private void MoveToToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MoveCopyToCommnad(true);
        }

        private void CopyToToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MoveCopyToCommnad(false);
        }

        private void toolStripButtonDelete_Click(object sender, EventArgs e)
        {
            DeleteCommand();
        }

        private void DeleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeleteCommand();
        }

        private void textBoxPath_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Tab)
            {
                e.IsInputKey = true;
            }
        }

        private void toolStripButtonFirst_Click(object sender, EventArgs e)
        {
            changeReplay(ReplayChangeType.First);
        }

        private void toolStripButtonPrevious_Click(object sender, EventArgs e)
        {
            changeReplay(ReplayChangeType.Previous);
        }

        private void toolStripButtonNext_Click(object sender, EventArgs e)
        {
            changeReplay(ReplayChangeType.Next);
        }

        private void toolStripButtonLast_Click(object sender, EventArgs e)
        {
            changeReplay(ReplayChangeType.Last);
        }

        private void FirstReplayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            changeReplay(ReplayChangeType.First);
        }

        private void PreviousReplayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            changeReplay(ReplayChangeType.Previous);
        }

        private void NextReplayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            changeReplay(ReplayChangeType.Next);
        }

        private void LastReplayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            changeReplay(ReplayChangeType.Last);
        }

        private void textBoxPath_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                string filename = textBoxPath.Text;
                if (File.Exists(filename))
                {
                    openReplay(filename);
                }
                else
                {
                    MessageBox.Show(string.Format(ResourceLoader.getTextResource("NotExistedFile"), filename), Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void Encoding1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            setEncodingFromMenu(0);
        }

        private void Encoding2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            setEncodingFromMenu(1);
        }

        private void Encoding3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            setEncodingFromMenu(2);
        }

        private void Encoding4ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            setEncodingFromMenu(3);
        }

        private void comboBoxEncoding_SelectedIndexChanged(object sender, EventArgs e)
        {
            currentCodePage = (int)comboBoxEncoding.GetSelectedValue();
            if (currentReplay != null)
            {
                ReplayAnalyzer.changeEncoding(currentReplay, currentCodePage);
                displayData(false);
            }
        }

        public enum ReplayChangeType
        {
            First,
            Previous,
            Next,
            Last
        }
    }


}
