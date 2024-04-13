using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using thhylR.Common;
using thhylR.Games;
using thhylR.Helper;
using YamlDotNet.Serialization.TypeInspectors;

namespace thhylR
{
    public partial class FormMain : Form
    {
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

            FirstReplayToolStripMenuItem.Enabled = isExist;
            PreviousReplayToolStripMenuItem.Enabled = isExist;
            NextReplayToolStripMenuItem.Enabled = isExist;
            LastReplayToolStripMenuItem.Enabled = isExist;

            toolStripButtonFirst.Enabled = isExist;
            toolStripButtonPrevious.Enabled = isExist;
            toolStripButtonNext.Enabled = isExist;
            toolStripButtonLast.Enabled = isExist;

            if (currentReplay != null)
            {
                currentReplay.ReplayProblem |= ReplayProblemEnum.FileNotExist;
            }
        }

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
            currentReplay = ReplayAnalyzer.Analyze(fileData, currentCodePage);
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

        private void displayData(bool resetSelectedRows = true)
        {
            if (currentReplay == null) return;
            int selectedRow = -1;
            int scrollRowIndex = -1;
            if (!resetSelectedRows)
            {
                if (dataGridInfo.SelectedRows.Count > 0)
                {
                    selectedRow = dataGridInfo.SelectedRows[0].Index;
                    
                }
                scrollRowIndex = dataGridInfo.FirstDisplayedScrollingRowIndex;
            }
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

            if (!resetSelectedRows)
            {
                if (dataGridInfo.SelectedRows.Count > 0)
                {
                    dataGridInfo.Rows[selectedRow].Selected = true;
                }
                dataGridInfo.FirstDisplayedScrollingRowIndex = scrollRowIndex;
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

        private void changeReplay(ReplayChangeType changeType)
        {
            TreeNode rootNode = treeViewFiles.Nodes[0];
            TreeNode targetNode = null;
            if (rootNode.Nodes.Count == 0)
            {
                return;
            }
            switch (changeType)
            {
                case ReplayChangeType.First:
                    if (currentFilePos == 0) return;
                    targetNode = rootNode.Nodes[0];
                    break;
                case ReplayChangeType.Previous:
                    if (currentFilePos == 0) return;
                    targetNode = rootNode.Nodes[currentFilePos - 1];
                    break;
                case ReplayChangeType.Next:
                    if (currentFilePos == rootNode.Nodes.Count - 1) return;
                    targetNode = rootNode.Nodes[currentFilePos + 1];
                    break;
                case ReplayChangeType.Last:
                    if (currentFilePos == rootNode.Nodes.Count - 1) return;
                    targetNode = rootNode.Nodes[^1];
                    break;
            }
            if (targetNode != null)
            {
                treeViewFiles.SelectedNode = targetNode;
            }
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

        private void OptionCommand()
        {
            FormSettings formSettings = new FormSettings();
            formSettings.ShowDialog(this);

            normalFont = SettingProvider.Settings.NormalFont;
            symbolFont = SettingProvider.Settings.SymbolFont;
            dataGridInfo.DefaultCellStyle.Font = normalFont;

            TopMost = SettingProvider.Settings.OnTop;

            loadEncodingList();

            if (currentReplay != null)
            {
                ReplayAnalyzer.ReformatData(ref currentReplay);
                displayData(false);
            }
        }

        private void loadEncodingList()
        {
            var encodings = SettingProvider.Settings.Encodings;
            var nullItem = new { Name = ResourceLoader.getTextResource("EncodingNone"), CodePage = -1 };
            var defaultItem = new { Name = ResourceLoader.getTextResource("EncodingDefault"), CodePage = 0 };
            var codePage = -1;

            List<int> tmpEncodings = new List<int>();

            bool showAllEncodings = SettingProvider.Settings.ShowAllEncodings;
            bool comboBoxRequireInit = true;
            if (comboBoxEncoding.Items.Count > 0)
            {
                comboBoxRequireInit = !(showAllEncodings && showAllEncodingsOld);
                if (comboBoxRequireInit)
                {
                    comboBoxEncoding.Items.Clear();
                }
                showAllEncodingsOld = showAllEncodings;
            }

            if (showAllEncodings)
            {
                comboBoxEncoding.Items.Add(defaultItem);

                foreach (var encodingInfo in encodingList)
                {
                    comboBoxEncoding.Items.Add(encodingInfo);
                }
            }

            for (int i = 0; i < encodings.Count; i++)
            {
                var encodingItem = encodings[i];
                if (encodingItem.EncodingId == -1)
                {
                    encodingMenuItem[i].Text = ResourceLoader.getTextResource("EncodingNone");
                    encodingMenuItem[i].Enabled = false;
                }
                else if (encodingItem.EncodingId == 0)
                {
                    if (!showAllEncodings && !tmpEncodings.Contains(encodingItem.EncodingId))
                    {
                        comboBoxEncoding.Items.Add(defaultItem);
                    }
                    encodingMenuItem[i].Text = ResourceLoader.getTextResource("EncodingDefault");
                    encodingMenuItem[i].Enabled = true;
                    if (codePage == -1)
                    {
                        codePage = 0;
                    }
                }
                else
                {
                    var encodingInfoItem = encodingList.FirstOrDefault(e => e.CodePage == encodingItem.EncodingId);
                    if (encodingInfoItem != null)
                    {
                        if (!showAllEncodings && !tmpEncodings.Contains(encodingItem.EncodingId))
                        {
                            comboBoxEncoding.Items.Add(encodingInfoItem);
                        }
                        encodingMenuItem[i].Text = encodingInfoItem.Name;
                        encodingMenuItem[i].Enabled = true;
                        if (codePage == -1)
                        {
                            codePage = encodingItem.EncodingId;
                        }
                    }
                }
                if (encodingItem.UseEncoding)
                {
                    encodingMenuItem[i].ShortcutKeys = encodingMenuHotkeys[i];
                }
                else
                {
                    encodingMenuItem[i].ShortcutKeys = Keys.None;
                }

                tmpEncodings.Add(encodingItem.EncodingId);
            }

            if (comboBoxEncoding.Items.Count == 0)
            {
                comboBoxEncoding.Items.Add(Encoding.GetEncoding(932));
                currentCodePage = 932;
            }
            else
            {
                currentCodePage = codePage;
            }
            comboBoxEncoding.SelectedIndex = 0;
        }

        private void setEncodingFromMenu(int itemNumber)
        {
            var encodingItem = SettingProvider.Settings.Encodings[itemNumber];
            if (encodingItem.EncodingId != -1)
            {
                comboBoxEncoding.SetSelectedValue(encodingItem.EncodingId);
            }
        }

    }
}
