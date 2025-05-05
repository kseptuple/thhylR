using System.Data;
using System.Text;
using thhylR.Common;
using thhylR.Games;
using thhylR.Helper;
using thhylR.Properties;

namespace thhylR
{
    public partial class FormMain : Form
    {
        private void setFileIsOpen(bool isExist)
        {
            if (isExist)
            {
                isFileOpen = true;
            }

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

            CurrentFolderToolStripMenuItem.Enabled = isExist;

            ExportToolStripMenuItem.Enabled = isFileOpen;
            ExportAllToolStripMenuItem.Enabled = isFileOpen;
            ExportCustomToolStripMenuItem.Enabled = isFileOpen;

            toolStripButtonExportAll.Enabled = isFileOpen;
            toolStripButtonExportCustom.Enabled = isFileOpen;

            ViewKeysToolStripMenuItem.Enabled = isFileOpen;
            toolStripButtonViewKeys.Enabled = isFileOpen;

            SaveReplayInfoToolStripMenuItem.Enabled = isFileOpen;
            CopyInfoToolStripMenuItem.Enabled = isFileOpen;

            if (!isExist)
            {
                toolStripButtonEditComment.Enabled = false;
                EditCommentToolStripMenuItem.Enabled = false;
            }

            if (CurrentReplay != null && !isExist)
            {
                CurrentReplay.ReplayProblem |= ReplayProblemEnum.FileNotExist;
                toolStripStatusLabelInfo.Image = Resources.StatusWarning;
                toolStripStatusLabelInfo.Text = ResourceLoader.GetText("ReplayWarning");
            }
        }

        //private void closeReplay()
        //{
        //    CurrentReplay = null;
        //    toolStripStatusLabelInfo.Text = ResourceLoader.GetText("ProblemNotOpen");
        //    isFileOpen = false;
        //    setFileIsOpen(false);
        //}

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

        private void showOpenFolderDialog()
        {
            var dialogResult = folderBrowserDialog.ShowDialog(this);
            if (dialogResult != DialogResult.OK)
            {
                return;
            }
            var folderName = folderBrowserDialog.SelectedPath;
            openFolder(folderName);
        }

        private void openReplay(string fileName, bool refreshFileList = true)
        {
            var fileExt = Path.GetExtension(fileName);
            if (fileExt.ToLower() != ".rpy")
            {
                MessageBox.Show(string.Format(ResourceLoader.GetText("NotSupportedFile"), Path.GetFileName(fileName)),
                    Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            byte[] fileData = null;
            try
            {
                fileData = File.ReadAllBytes(fileName);
            }
            catch
            {
                MessageBox.Show(ResourceLoader.GetText("ReplayOpenFail"), Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            CurrentReplay = ReplayAnalyzer.Analyze(fileData, SettingProvider.Settings.CurrentCodePage);
            if (CurrentReplay != null)
            {
                textBoxPath.Text = fileName;
                CurrentReplay.FilePath = fileName;
                displayData();

                if (refreshFileList)
                {
                    var replayPath = Path.GetDirectoryName(fileName);
                    setFiles(replayPath, Path.GetFileName(fileName));
                    fileSystemWatcherFolder.Path = replayPath;
                }
                setFileIsOpen(true);

                EditCommentToolStripMenuItem.Enabled = CurrentReplay.InfoBlocks != null;
                toolStripButtonEditComment.Enabled = CurrentReplay.InfoBlocks != null;

                if (CurrentReplay.ReplayProblem == ReplayProblemEnum.None)
                {
                    toolStripStatusLabelInfo.Image = Resources.StatusOK;
                    toolStripStatusLabelInfo.Text = ResourceLoader.GetText("ReplayOK");
                }
                else
                {
                    toolStripStatusLabelInfo.Image = Resources.StatusWarning;
                    toolStripStatusLabelInfo.Text = ResourceLoader.GetText("ReplayWarning");
                }
            }
            else
            {
                MessageBox.Show(string.Format(ResourceLoader.GetText("NotSupportedFile"), Path.GetFileName(fileName)),
                    Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void openFolder(string folderName)
        {
            var replayFiles = Directory.GetFiles(folderName, "*.rpy");
            if (replayFiles.Length == 0)
            {
                MessageBox.Show(string.Format(ResourceLoader.GetText("NoReplayInFolder"), folderName),
                    Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            openReplay(replayFiles[0]);
        }

        private void displayData(bool resetSelectedRows = true)
        {
            if (CurrentReplay == null) return;
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
            DataTable allData = CurrentReplay.DisplayDataList.Where(d => d["Visible"].ToString() != "0").CopyToDataTable();
            //DataTable allData = CurrentReplay.DisplayData.Select("Visible <> 0").CopyToDataTable();
            dataGridInfo.DataSource = allData;

            for (int i = 0; i < allData.Rows.Count; i++)
            {
                if (!Convert.IsDBNull(allData.Rows[i]["IsSymbol"]) && (bool)allData.Rows[i]["IsSymbol"])
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
            if (!string.IsNullOrEmpty(fileSystemWatcherFolder.Path) && CurrentReplay != null)
            {
                if (fileToOpen != null)
                {
                    string newFile = fileToOpen;
                    fileToOpen = null;
                    openReplay(newFile);
                }
                else
                {
                    var hasFile = setFiles(fileSystemWatcherFolder.Path, Path.GetFileName(CurrentReplay.FilePath));
                    if (!hasFile)
                    {
                        setFileIsOpen(false);
                        CurrentReplay.ReplayProblem |= ReplayProblemEnum.FileNotExist;
                        toolStripStatusLabelInfo.Image = Resources.StatusWarning;
                        toolStripStatusLabelInfo.Text = ResourceLoader.GetText("ReplayWarning");
                    }
                }
            }
        }

        private void changeReplay(ReplayChangeType changeType)
        {
            System.Windows.Forms.TreeNode rootNode = treeViewFiles.Nodes[0];
            System.Windows.Forms.TreeNode targetNode = null;
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
            if (CurrentReplay != null)
            {
                ClipboardHelper.FileToClipboard(new string[] { CurrentReplay.FilePath }, true);
            }
        }

        private void copyCommand()
        {
            if (CurrentReplay != null)
            {
                ClipboardHelper.FileToClipboard(new string[] { CurrentReplay.FilePath }, false);
            }
        }

        private void RenameCommand()
        {
            if (CurrentReplay != null)
            {
                FormRename formRename = new FormRename(CurrentReplay.FilePath);
                var result = formRename.ShowDialog(this);
                if (result == DialogResult.OK)
                {
                    string path = Path.GetDirectoryName(CurrentReplay.FilePath);
                    string currentFileName = formRename.FileName + ".rpy";
                    string fullName = Path.Combine(path, currentFileName);
                    string targetFileName = null;
                    if (fullName == CurrentReplay.FilePath) return;
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
                                    MessageBox.Show(string.Format(ResourceLoader.GetText("AutoRenameFail"), targetFileName),
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
                    try
                    {
                        File.Move(CurrentReplay.FilePath, fullName, true);
                    }
                    catch
                    {
                        MessageBox.Show(ResourceLoader.GetText("RenameFail"), Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    CurrentReplay.FilePath = fullName;
                    if (targetFileName != null)
                    {
                        MessageBox.Show(string.Format(ResourceLoader.GetText("AutoRenameComplete"), targetFileName),
                            Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        private void MoveCopyToCommnad(bool isMove)
        {
            if (CurrentReplay == null) return;
            var dialogResult = folderBrowserDialog.ShowDialog(this);
            if (dialogResult == DialogResult.OK)
            {
                string currentFileName = Path.GetFileName(CurrentReplay.FilePath);
                string path = Path.Combine(folderBrowserDialog.SelectedPath, currentFileName);
                string targetFileName = null;
                if (File.Exists(path))
                {
                    FormFileExist formFileExist = new FormFileExist();
                    var result = formFileExist.ShowDialog(this);
                    if (result == DialogResult.OK)
                    {
                        if (formFileExist.Result == FileExistResult.Rename)
                        {
                            targetFileName = autoRename(folderBrowserDialog.SelectedPath, currentFileName);
                            if (targetFileName != null)
                            {
                                path = Path.Combine(folderBrowserDialog.SelectedPath, targetFileName);
                            }
                            else
                            {
                                MessageBox.Show(string.Format(ResourceLoader.GetText("AutoRenameFail"), targetFileName),
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
                    try
                    {
                        File.Move(CurrentReplay.FilePath, path, true);
                    }
                    catch
                    {
                        MessageBox.Show(ResourceLoader.GetText("MoveFail"), Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    switch (SettingProvider.Settings.OperAfterMove)
                    {
                        case FileOperate.KeepOrClose:
                            break;
                        case FileOperate.Next:
                            System.Windows.Forms.TreeNode rootNode = treeViewFiles.Nodes[0];
                            if (rootNode.Nodes.Count == 0)
                            {
                                MessageBox.Show(ResourceLoader.GetText("NoNextFile"), Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                    try
                    {
                        File.Copy(CurrentReplay.FilePath, path, true);
                    }
                    catch
                    {
                        MessageBox.Show(ResourceLoader.GetText("CopyFail"), Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

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
                    MessageBox.Show(string.Format(ResourceLoader.GetText("AutoRenameComplete"), targetFileName),
                        Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void DeleteCommand()
        {
            var result = MessageBox.Show(ResourceLoader.GetText("DeleteWarning"), Text, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                try
                {
                    File.Delete(CurrentReplay.FilePath);
                }
                catch
                {
                    MessageBox.Show(ResourceLoader.GetText("DeleteFail"), Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                switch (SettingProvider.Settings.OperAfterDelete)
                {
                    case FileOperate.Next:
                        System.Windows.Forms.TreeNode rootNode = treeViewFiles.Nodes[0];
                        if (rootNode.Nodes.Count == 0)
                        {
                            MessageBox.Show(ResourceLoader.GetText("NoNextFile"), Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
            var result = formSettings.ShowDialog(this);

            if (result == DialogResult.OK)
            {
                normalFont = SettingProvider.Settings.NormalFont;
                symbolFont = SettingProvider.Settings.SymbolFont;
                dataGridInfo.DefaultCellStyle.Font = normalFont;

                TopMost = SettingProvider.Settings.OnTop;

                if (formSettings.IsExit)
                {
                    return;
                }

                loadEncodingList();

                if (CurrentReplay != null)
                {
                    ReplayAnalyzer.FormatData(CurrentReplay.DisplayDataList);
                    ReplayAnalyzer.ShiftScore(CurrentReplay);
                    displayData(false);
                }
            }
        }

        private void EditCommentCommand()
        {
            if (CurrentReplay != null && CurrentReplay.InfoBlocks != null)
            {
                FormCommentEditor editor = new FormCommentEditor(CurrentReplay.FilePath, CurrentReplay.InfoBlocks,
                    SettingProvider.Settings.CurrentCodePage, CurrentReplay.InfoBlockStart);
                var result = editor.ShowDialog(this);
                if (result == DialogResult.OK)
                {
                    openReplay(editor.FileName);
                }
            }
        }

        private void loadEncodingList()
        {
            var encodings = SettingProvider.Settings.Encodings;
            var nullItem = new { Name = ResourceLoader.GetText("EncodingNone"), CodePage = -1 };
            var defaultItem = new { Name = ResourceLoader.GetText("EncodingDefault"), CodePage = 0 };
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

            if (showAllEncodings && comboBoxRequireInit)
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
                    encodingMenuItem[i].Text = ResourceLoader.GetText("EncodingNone");
                    encodingMenuItem[i].Enabled = false;
                }
                else if (encodingItem.EncodingId == 0)
                {
                    if (!showAllEncodings && !tmpEncodings.Contains(encodingItem.EncodingId))
                    {
                        comboBoxEncoding.Items.Add(defaultItem);
                    }
                    encodingMenuItem[i].Text = ResourceLoader.GetText("EncodingDefault");
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
                SettingProvider.Settings.CurrentCodePage = 932;
            }
            else
            {
                SettingProvider.Settings.CurrentCodePage = codePage;
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

        private void ExportAllCommand()
        {
            if (CurrentReplay != null)
            {
                saveFileDialog.Filter = ResourceLoader.GetText("RawDataFilter");
                saveFileDialog.InitialDirectory = Path.GetDirectoryName(CurrentReplay.FilePath);
                var dialogResult = saveFileDialog.ShowDialog(this);
                if (dialogResult == DialogResult.OK)
                {
                    var result = ReplayExporter.GetAllData(CurrentReplay);
                    try
                    {
                        File.WriteAllBytes(saveFileDialog.FileName, result);
                        MessageBox.Show(ResourceLoader.GetText("ExportAllSuccess"), Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch
                    {
                        MessageBox.Show(ResourceLoader.GetText("ExportAllFail"), Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void CustomExportCommand()
        {
            if (CurrentReplay != null)
            {
                FormExport formExport = new FormExport(CurrentReplay);
                formExport.ShowDialog(this);
            }
        }

        private void ViewKeysCommand()
        {
            if (CurrentReplay != null)
            {
                FormKeyViewer formKeyViewer = new FormKeyViewer(CurrentReplay);
                formKeyViewer.ShowDialog(this);
            }
        }

        private readonly string exportInfoColon = null;

        private string InfoToString()
        {
            if (CurrentReplay == null) return null;
            StringBuilder sb = new StringBuilder();
            foreach (var dataRow in CurrentReplay.DisplayDataList)
            {
                if (dataRow["Visible"].ToString() == "0") continue;
                string name = dataRow["Name"].ToString();
                if (!string.IsNullOrEmpty(name))
                {
                    sb.Append(name).Append(exportInfoColon);
                    string id = dataRow["Id"].ToString();
                    if (id == "ReplaySummary" || id == "Comment")
                    {
                        sb.AppendLine();
                    }
                    string value = dataRow["Value"].ToString().TrimEnd();
                    sb.Append(value);
                }
                sb.AppendLine();
            }
            return sb.ToString();
        }

        private void DpiChange()
        {
            dpiScale = DeviceDpi / 96.0;
            MinimumSize = new Size((int)(885 * dpiScale), (int)(550 * dpiScale));
            SetDpiAtStart();
        }

        private void SetDpiAtStart()
        {
            splitContainerMain.Panel1MinSize = (int)(200 * dpiScale);
            splitContainerMain.Panel2MinSize = (int)(660 * dpiScale);
            splitContainerInfo.Panel1MinSize = (int)(400 * dpiScale);
            splitContainerInfo.Panel2MinSize = (int)(250 * dpiScale);
        }
    }
}
