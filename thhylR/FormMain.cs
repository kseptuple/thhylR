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

        public TouhouReplay CurrentReplay { get; set; }

        private string fileToOpen = null;

        private Font normalFont;
        private Font symbolFont;

        private bool isFileOpen = false;

        private bool showAllEncodingsOld = false;

        private List<ToolStripMenuItem> encodingMenuItem = new List<ToolStripMenuItem>();
        private readonly List<Keys> encodingMenuHotkeys = new List<Keys>() { Keys.F5, Keys.F6, Keys.F7, Keys.F8 };

        private List<EncodingInfo> encodingList = new List<EncodingInfo>();
        private bool isEncodingChanging = false;

        public FormMain()
        {
            InitializeComponent();
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            GameData.Init();
            EnumData.Init();
            SettingProvider.Init();
            ResourceLoader.Init();
            EncodingHelper.Init();

            ResourceLoader.SetFormText(this);
            ResourceLoader.InitTextResource();

            splitContainerMain.Panel1.Name = "MainPanel1";
            splitContainerMain.Panel2.Name = "MainPanel2";
            splitContainerInfo.Panel1.Name = "InfoPanel1";
            splitContainerInfo.Panel2.Name = "InfoPanel2";

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

            toolStripButtonEditComment.ToolTipText = ResourceLoader.getTextResource("EditCommentTip");

            toolStripButtonExportAll.ToolTipText = ResourceLoader.getTextResource("ExportAllTip");
            toolStripButtonExportCustom.ToolTipText = ResourceLoader.getTextResource("ExportCustomTip");

            toolStripButtonOption.ToolTipText = ResourceLoader.getTextResource("OptionTip");

            toolStripStatusLabelInfo.Text = ResourceLoader.getTextResource("ProblemNotOpen");

            encodingMenuItem.Add(Encoding1ToolStripMenuItem);
            encodingMenuItem.Add(Encoding2ToolStripMenuItem);
            encodingMenuItem.Add(Encoding3ToolStripMenuItem);
            encodingMenuItem.Add(Encoding4ToolStripMenuItem);

            openReplayDialog.Filter = ResourceLoader.getTextResource("ReplayFileFilter");

            textBoxPath.Left = label1.Left + label1.Width + textBoxPath.Margin.Left;
            comboBoxEncoding.Left = label2.Left + label2.Width + comboBoxEncoding.Margin.Left;
            textBoxPath.Width = splitContainerInfo.Panel1.Width - textBoxPath.Left;
            comboBoxEncoding.Width = splitContainerInfo.Panel2.Width - comboBoxEncoding.Left;

            if (SettingProvider.Settings.MainFormLeft < 0 || SettingProvider.Settings.MainFormTop < 0)
            {
                StartPosition = FormStartPosition.CenterScreen;
            }
            else
            {
                StartPosition = FormStartPosition.Manual;
                Left = SettingProvider.Settings.MainFormLeft;
                Top = SettingProvider.Settings.MainFormTop;
            }

            Width = SettingProvider.Settings.MainFormWidth;
            Height = SettingProvider.Settings.MainFormHeight;
            splitContainerMain.SplitterDistance = SettingProvider.Settings.MainFormSplitter1Pos;
            splitContainerInfo.SplitterDistance = SettingProvider.Settings.MainFormSplitter2Pos;

            encodingList = EncodingHelper.EncodingList;
            loadEncodingList();

            isEncodingChanging = true;
            comboBoxEncoding.SetSelectedValue(SettingProvider.Settings.CurrentCodePage);
            isEncodingChanging = false;

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
            ExportAllCommand();
        }

        private void ExportCustomToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CustomExportCommand();
        }

        private void toolStripButtonExportAll_Click(object sender, EventArgs e)
        {
            ExportAllCommand();
        }

        private void toolStripButtonExportCustom_Click(object sender, EventArgs e)
        {
            CustomExportCommand();
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

        private void toolStripButtonOption_Click(object sender, EventArgs e)
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
            if (isEncodingChanging) return;
            isEncodingChanging = true;
            SettingProvider.Settings.CurrentCodePage = (int)comboBoxEncoding.GetSelectedValue();
            if (CurrentReplay != null)
            {
                ReplayAnalyzer.changeEncoding(CurrentReplay, SettingProvider.Settings.CurrentCodePage);
                displayData(false);
            }
            isEncodingChanging = false;
        }

        private void EditCommentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditCommentCommand();
        }

        private void toolStripButtonEditComment_Click(object sender, EventArgs e)
        {
            EditCommentCommand();
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            SettingProvider.Settings.MainFormLeft = Left;
            SettingProvider.Settings.MainFormTop = Top;
            SettingProvider.Settings.MainFormHeight = Height;
            SettingProvider.Settings.MainFormWidth = Width;
            SettingProvider.Settings.MainFormSplitter1Pos = splitContainerMain.SplitterDistance;
            SettingProvider.Settings.MainFormSplitter2Pos = splitContainerInfo.SplitterDistance;

            SettingProvider.SaveSettings();
        }

        private void FormMain_Shown(object sender, EventArgs e)
        {
            if (CurrentReplay != null)
            {
                DataTable allData = CurrentReplay.DisplayDataList.Where(d => d["Visible"].ToString() != "0").CopyToDataTable();
                //DataTable allData = CurrentReplay.DisplayData.Select("Visible <> 0").CopyToDataTable();

                for (int i = 0; i < allData.Rows.Count; i++)
                {
                    if ((bool)allData.Rows[i]["IsSymbol"])
                    {
                        dataGridInfo.Rows[i].Cells["dataGridColumnValue"].Style.Font = symbolFont;
                    }
                    else
                    {
                        dataGridInfo.Rows[i].Cells["dataGridColumnValue"].Style.Font = normalFont;
                    }
                }
            }
        }

        private void toolStripStatusLabelInfo_Click(object sender, EventArgs e)
        {
            FormReplayProblem formReplayProblem = null;
            if (CurrentReplay == null)
            {
                formReplayProblem = new FormReplayProblem();
            }
            else
            {
                formReplayProblem = new FormReplayProblem(CurrentReplay.ReplayProblem);
            }
            formReplayProblem.ShowDialog(this);
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
