using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text;
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

        public FormMain()
        {
            InitializeComponent();
            GameData.Init();
            EnumData.Init();
            SettingProvider.Init();
            ResourceLoader.Init();
            ResourceLoader.SetText(this);
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            dataGridInfo.AutoGenerateColumns = false;
            dataGridInfo.DefaultCellStyle.Font = SettingProvider.Settings.NormalFont;

            normalFont = SettingProvider.Settings.NormalFont;
            symbolFont = SettingProvider.Settings.SymbolFont;

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

            setFileIsOpen(false);

            var args = Environment.GetCommandLineArgs();
            if (args.Length > 1)
            {
                string filename = args[1];
                openReplay(filename);
            }
        }

        private TouhouReplay currentReplay = null;

        private string fileToOpen = null;

        private Font normalFont;
        private Font symbolFont;

        private bool isFileOpen = false;

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
                MessageBox.Show(string.Format(ResourceLoader.getTextResource("NotSupportedFile"), Path.GetFileName(fileName)),
                    Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            byte[] fileData = File.ReadAllBytes(fileName);
            currentReplay = ReplayAnalyzer.Analyze(fileData);
            if (currentReplay != null)
            {
                textBoxPath.Text = fileName;
                currentReplay.FilePath = fileName;
                displayData();

                if (refreshFileList)
                {
                    var replayPath = Path.GetDirectoryName(fileName);
                    setFiles(replayPath, Path.GetFileName(fileName));
                    fileSystemWatcherFolder.Path = replayPath;
                }
                setFileIsOpen(true);
            }
            else
            {
                MessageBox.Show(string.Format(ResourceLoader.getTextResource("NotSupportedFile"), Path.GetFileName(fileName)),
                    Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void displayData()
        {
            if (currentReplay == null) return;
            DataTable allData = currentReplay.DisplayData.Select("Visible <> 0").CopyToDataTable();
            dataGridInfo.DataSource = allData;

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

        private bool setFiles(string path, string filename)
        {
            treeViewFiles.Nodes.Clear();
            treeViewFiles.Nodes.Add(path);
            bool hasFile = false;
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
                    currentFilePos = i;
                    isSelecting = false;
                    hasFile = true;
                }
            }
            treeViewFiles.Nodes[0].Expand();
            return hasFile;
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
            if (!string.IsNullOrEmpty(fileSystemWatcherFolder.Path) && currentReplay != null)
            {
                if (fileToOpen != null)
                {
                    string newFile = fileToOpen;
                    fileToOpen = null;
                    openReplay(newFile);
                }
                else
                {
                    var hasFile = setFiles(fileSystemWatcherFolder.Path, Path.GetFileName(currentReplay.FilePath));
                    if (!hasFile)
                    {
                        setFileIsOpen(false);
                        currentReplay.ReplayProblem |= ReplayProblemEnum.FileNotExist;
                    }
                }
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

        private void OptionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormSettings formSettings = new FormSettings();
            formSettings.ShowDialog(this);

            normalFont = SettingProvider.Settings.NormalFont;
            symbolFont = SettingProvider.Settings.SymbolFont;
            dataGridInfo.DefaultCellStyle.Font = normalFont;

            if (currentReplay != null)
            {
                ReplayAnalyzer.ReformatData(ref currentReplay);
                displayData();
            }

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

        private void cutCommand()
        {
            if (currentReplay != null)
            {
                ClipboardHelper.FileToClipboard(new string[] { currentReplay.FilePath }, true);
            }
        }

        private void copyCommand()
        {
            if (currentReplay != null)
            {
                ClipboardHelper.FileToClipboard(new string[] { currentReplay.FilePath }, false);
            }
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

        private void setFileIsOpen(bool isExist)
        {
            isFileOpen = isExist;

            CutToolStripMenuItem.Enabled = isExist;
            CopyToolStripMenuItem.Enabled = isExist;
            MoveToToolStripMenuItem.Enabled = isExist;
            CopyToToolStripMenuItem.Enabled = isExist;
            RenameToolStripMenuItem.Enabled = isExist;
            DeleteToolStripMenuItem.Enabled = isExist;

            toolStripButtonCut.Enabled = isExist;
            toolStripButtonCopy.Enabled = isExist;
            toolStripButtonMoveTo.Enabled = isExist;
            toolStripButtonCopyTo.Enabled = isExist;
            toolStripButtonRename.Enabled = isExist;
            toolStripButtonDelete.Enabled = isExist;

            if (currentReplay != null)
            {
                currentReplay.ReplayProblem |= ReplayProblemEnum.FileNotExist;
            }
        }

        private void RenameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RenameCommand();
        }

        private void toolStripButtonRename_Click(object sender, EventArgs e)
        {
            RenameCommand();
        }

        private void RenameCommand()
        {
            if (currentReplay != null)
            {
                FormRename formRename = new FormRename(currentReplay.FilePath);
                var result = formRename.ShowDialog(this);
                if (result == DialogResult.OK)
                {
                    string path = Path.GetDirectoryName(currentReplay.FilePath);
                    string currentFileName = formRename.FileName + ".rpy";
                    string fullName = Path.Combine(path, currentFileName);
                    string targetFileName = null;
                    if (fullName == currentReplay.FilePath) return;
                    if (File.Exists(fullName))
                    {
                        FormFileExist formFileExist = new FormFileExist();
                        var formFileExistResult = formFileExist.ShowDialog(this);
                        if (formFileExistResult == DialogResult.OK)
                        {
                            if (formFileExist.Result == FileExistResult.Rename)
                            {
                                targetFileName = autoRename(path, currentFileName);
                                if (targetFileName != null)
                                {
                                    fullName = Path.Combine(path, targetFileName);
                                }
                                else
                                {
                                    MessageBox.Show(string.Format(ResourceLoader.getTextResource("AutoRenameFail"), targetFileName),
                                        Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }
                            }
                        }
                        else
                        {
                            return;
                        }
                    }
                    File.Move(currentReplay.FilePath, fullName, true);
                    currentReplay.FilePath = fullName;
                    if (targetFileName != null)
                    {
                        MessageBox.Show(string.Format(ResourceLoader.getTextResource("AutoRenameComplete"), targetFileName),
                            Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
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

        private void MoveCopyToCommnad(bool isMove)
        {
            if (currentReplay == null) return;
            var dialogResult = folderBrowserDialogMoveCopy.ShowDialog(this);
            if (dialogResult == DialogResult.OK)
            {
                string currentFileName = Path.GetFileName(currentReplay.FilePath);
                string path = Path.Combine(folderBrowserDialogMoveCopy.SelectedPath, currentFileName);
                string targetFileName = null;
                if (File.Exists(path))
                {
                    FormFileExist formFileExist = new FormFileExist();
                    var result = formFileExist.ShowDialog(this);
                    if (result == DialogResult.OK)
                    {
                        if (formFileExist.Result == FileExistResult.Rename)
                        {
                            targetFileName = autoRename(folderBrowserDialogMoveCopy.SelectedPath, currentFileName);
                            if (targetFileName != null)
                            {
                                path = Path.Combine(folderBrowserDialogMoveCopy.SelectedPath, targetFileName);
                            }
                            else
                            {
                                MessageBox.Show(string.Format(ResourceLoader.getTextResource("AutoRenameFail"), targetFileName),
                                    Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                        }
                    }
                    else
                    {
                        return;
                    }
                }
                if (isMove)
                {
                    File.Move(currentReplay.FilePath, path, true);
                    switch (SettingProvider.Settings.OperAfterMove)
                    {
                        case FileOperate.KeepOrClose:
                            break;
                        case FileOperate.Next:
                            TreeNode rootNode = treeViewFiles.Nodes[0];
                            if (rootNode.Nodes.Count == 0)
                            {
                                break;
                            }
                            else if (currentFilePos < rootNode.Nodes.Count - 1)
                            {
                                fileToOpen = Path.Combine(rootNode.Text, rootNode.Nodes[currentFilePos + 1].Text);
                            }
                            else
                            {
                                fileToOpen = Path.Combine(rootNode.Text, rootNode.Nodes[^1].Text);
                            }
                            break;
                        case FileOperate.New:
                            openReplay(path);
                            break;
                    }
                }
                else
                {
                    File.Copy(currentReplay.FilePath, path, true);
                    switch (SettingProvider.Settings.OperAfterCopy)
                    {
                        case FileOperate.New:
                            openReplay(path);
                            break;
                        case FileOperate.KeepOrClose:
                        default:
                            break;
                    }
                }
                if (targetFileName != null)
                {
                    MessageBox.Show(string.Format(ResourceLoader.getTextResource("AutoRenameComplete"), targetFileName),
                        Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void toolStripButtonDelete_Click(object sender, EventArgs e)
        {
            DeleteCommand();
        }

        private void DeleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeleteCommand();
        }

        private void DeleteCommand()
        {
            var result = MessageBox.Show(ResourceLoader.getTextResource("DeleteWarning"), Text, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                File.Delete(currentReplay.FilePath);
                switch (SettingProvider.Settings.OperAfterDelete)
                {
                    case FileOperate.Next:
                        TreeNode rootNode = treeViewFiles.Nodes[0];
                        if (rootNode.Nodes.Count == 0)
                        {
                            break;
                        }
                        else if (currentFilePos < rootNode.Nodes.Count - 1)
                        {
                            fileToOpen = Path.Combine(rootNode.Text, rootNode.Nodes[currentFilePos + 1].Text);
                        }
                        else
                        {
                            fileToOpen = Path.Combine(rootNode.Text, rootNode.Nodes[^1].Text);
                        }
                        break;
                    case FileOperate.KeepOrClose:
                    default:
                        break;
                }
            }
        }

        private string autoRename(string path, string filename)
        {
            uint currentNum = 0;
            uint originalNum = 0;
            string[] fileParts = Path.GetFileNameWithoutExtension(filename).Split('_');
            string result = null;
            if (fileParts.Length < 2) return null;
            string fileIdentifyPart = string.Join('_', fileParts[1..]).ToLower();
            if (!fileIdentifyPart.StartsWith("ud"))
            {
                if (uint.TryParse(fileIdentifyPart, out currentNum))
                {
                    originalNum = currentNum;
                    do
                    {
                        result = fileParts[0] + "_" + currentNum.ToString("00") + ".rpy";
                        if (!File.Exists(Path.Join(path, result)))
                        {
                            return result;
                        }
                        currentNum++;
                        if (currentNum > 25)
                        {
                            currentNum = 1;
                        }
                    } while (currentNum != originalNum);
                }
                fileIdentifyPart = "ud0000";
            }
            fileIdentifyPart = fileIdentifyPart[2..];
            try
            {
                currentNum = Base36Converter.ToDecimal(fileIdentifyPart);
            }
            catch
            {
                currentNum = 0;
            }

            originalNum = currentNum;
            do
            {
                result = fileParts[0] + "_ud" + Base36Converter.ToBase36(currentNum).PadLeft(4, '0') + ".rpy";
                if (!File.Exists(Path.Join(path, result)))
                {
                    return result;
                }
                currentNum++;
                if (currentNum >= 1679616)
                {
                    currentNum = 0;
                }
            } while (currentNum != originalNum);
            return null;
        }
    }
}
