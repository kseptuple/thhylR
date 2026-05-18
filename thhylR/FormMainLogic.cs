using System.Data;
using System.Text;
using thhylR.Common;
using thhylR.Games;
using thhylR.Helper;
using thhylR.Properties;
using YamlDotNet.Serialization;
using static System.Net.Mime.MediaTypeNames;

namespace thhylR
{
    public partial class FormMain : Form
    {
        private void setFileIsOpen(bool isOpen, bool isExist, bool isChanged = false)
        {
            CutToolStripMenuItem.Enabled = isExist && !isChanged;
            CopyToolStripMenuItem.Enabled = isExist && !isChanged;
            MoveToToolStripMenuItem.Enabled = isExist && !isChanged;
            CopyToToolStripMenuItem.Enabled = isExist && !isChanged;
            RenameToolStripMenuItem.Enabled = isExist && !isChanged;
            DeleteToolStripMenuItem.Enabled = isExist && !isChanged;

            toolStripButtonCut.Enabled = isExist && !isChanged;
            toolStripButtonCopy.Enabled = isExist && !isChanged;
            toolStripButtonMoveTo.Enabled = isExist && !isChanged;
            toolStripButtonCopyTo.Enabled = isExist && !isChanged;
            toolStripButtonRename.Enabled = isExist && !isChanged;
            toolStripButtonDelete.Enabled = isExist && !isChanged;

            FirstReplayToolStripMenuItem.Enabled = isExist;
            PreviousReplayToolStripMenuItem.Enabled = isExist;
            NextReplayToolStripMenuItem.Enabled = isExist;
            LastReplayToolStripMenuItem.Enabled = isExist;

            toolStripButtonFirst.Enabled = isExist;
            toolStripButtonPrevious.Enabled = isExist;
            toolStripButtonNext.Enabled = isExist;
            toolStripButtonLast.Enabled = isExist;

            CurrentFolderToolStripMenuItem.Enabled = isExist;

            ExportToolStripMenuItem.Enabled = isOpen;
            ExportAllToolStripMenuItem.Enabled = isOpen;
            ExportCustomToolStripMenuItem.Enabled = isOpen;

            toolStripButtonExportAll.Enabled = isOpen;
            toolStripButtonExportCustom.Enabled = isOpen;

            ViewKeysToolStripMenuItem.Enabled = isOpen;
            toolStripButtonViewKeys.Enabled = isOpen;

            SaveReplayInfoToolStripMenuItem.Enabled = isOpen;
            CopyInfoToolStripMenuItem.Enabled = isOpen;

            DataGridCopyAllToolStripMenuItem.Enabled = isOpen;
            DataGridCopyToolStripMenuItem.Enabled = isOpen;

            if (!isOpen)
            {
                toolStripButtonEditComment.Enabled = false;
                EditCommentToolStripMenuItem.Enabled = false;
            }
        }

        private void closeReplayByFileMissing()
        {
            CurrentReplay = new TouhouReplay();
            setReplayProblem(ReplayProblemEnum.FileNotExist);
            displayData();
            textBoxInfo.Text = string.Empty;
            textBoxPath.Text = string.Empty;
        }

        private void closeReplayByInvalidFile(string filePath)
        {
            CurrentReplay = new TouhouReplay();
            CurrentReplay.FilePath = filePath;
            displayData();
            textBoxInfo.Text = string.Empty;
            textBoxPath.Text = filePath;
            setReplayProblem(ReplayProblemEnum.InvalidFile);
        }

        //private void closeReplay()
        //{
        //    CurrentReplay = null;
        //    toolStripStatusLabelInfo.Text = ResourceLoader.GetText("ProblemNotOpen");
        //    isFileOpen = false;
        //    setFileIsOpen(false);
        //}

        private void setReplayProblem(ReplayProblemEnum problem)
        {
            if (CurrentReplay != null)
            {
                CurrentReplay.ReplayProblem = problem;
                toolStripStatusLabelInfo.Image = Resources.StatusWarning;
                toolStripStatusLabelInfo.Text = ResourceLoader.GetText("ReplayWarning");
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

        private bool openReplay(string fileName, bool changeFolder = true, bool allowInvalidFile = false, bool quietMode = false)
        {
            var fileExt = Path.GetExtension(fileName);
            if (!fileExt.Equals(".rpy", StringComparison.OrdinalIgnoreCase))
            {
                if (allowInvalidFile)
                {
                    openInvalidFile();
                }
                if (!quietMode)
                {
                    MessageBox.Show(string.Format(ResourceLoader.GetText("NotSupportedFile"), Path.GetFullPath(fileName)),
                        Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                return false;
            }
            byte[] fileData = null;
            try
            {
                fileData = File.ReadAllBytes(fileName);
            }
            catch
            {
                if (allowInvalidFile)
                {
                    openInvalidFile();
                }
                if (!quietMode)
                {
                    MessageBox.Show(ResourceLoader.GetText("ReplayOpenFail"), Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                return false;
            }
            TouhouReplay lastReplay = CurrentReplay;
            CurrentReplay = ReplayAnalyzer.Analyze(fileData, SettingProvider.Settings.CurrentCodePage);

            if (CurrentReplay != null)
            {
                textBoxPath.Text = fileName;
                CurrentReplay.FilePath = fileName;
                displayData();

                if (changeFolder)
                {
                    var replayPath = Path.GetDirectoryName(fileName);
                    loadFolderAndPickFileInTreeView(replayPath, Path.GetFileName(fileName));
                    fileSystemWatcherFolder.Path = replayPath;
                    fileSystemWatcherParent.EnableRaisingEvents = false;
                    var parentFolder = Directory.GetParent(replayPath);
                    if (parentFolder != null)
                    {
                        fileSystemWatcherParent.Path = parentFolder.FullName;
                        fileSystemWatcherParent.Filter = Path.GetFileName(replayPath);
                        fileSystemWatcherParent.EnableRaisingEvents = true;
                    }
                }
                setFileIsOpen(true, true);

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
                return true;
            }
            else
            {
                if (allowInvalidFile)
                {
                    openInvalidFile();
                }
                if (!quietMode)
                {
                    MessageBox.Show(string.Format(ResourceLoader.GetText("NotSupportedFile"), Path.GetFullPath(fileName)),
                    Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                if (!allowInvalidFile)
                {
                    CurrentReplay = lastReplay;
                }
                return false;
            }


            void openInvalidFile()
            {
                setFileIsOpen(false, true);
                closeReplayByInvalidFile(fileName);
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
            for (int i = 0; i < replayFiles.Length; i++)
            {
                if (openReplay(replayFiles[i], quietMode: true))
                {
                    return;
                }
            }
            MessageBox.Show(string.Format(ResourceLoader.GetText("NoReplayInFolder"), folderName),
                Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                if (dataGridInfo.Rows.Count > 0)
                {
                    scrollRowIndex = dataGridInfo.FirstDisplayedScrollingRowIndex;
                }
            }
            var dataRowCollection = CurrentReplay.DisplayDataList.Where(d => d["Visible"].ToString() != "0");
            DataTable allData = dataRowCollection.Any() ? dataRowCollection.CopyToDataTable() : emptyDisplayTable;
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
                if (dataGridInfo.Rows.Count > 0)
                {
                    dataGridInfo.FirstDisplayedScrollingRowIndex = scrollRowIndex;
                }
            }
        }

        private bool loadFolderAndPickFileInTreeView(string path, string filename)
        {
            treeViewFiles.Nodes.Clear();
            treeViewFiles.Nodes.Add(path);
            bool hasFile = false;
            List<string> fileList = null;
            try
            {
                fileList = Directory.GetFiles(path, "*.rpy").ToList();
                fileList.Sort();
            }
            catch
            {
                return false;
            }
            for (int i = 0; i < fileList.Count; i++)
            {
                var file = fileList[i];
                var currentFileName = Path.GetFileName(file);
                treeViewFiles.Nodes[0].Nodes.Add(currentFileName);
                if (currentFileName == filename)
                {
                    bypassTreeviewSelectEvent = true;
                    treeViewFiles.SelectedNode = treeViewFiles.Nodes[0].Nodes[i];
                    bypassTreeviewSelectEvent = false;
                    currentFilePos = i;
                    hasFile = true;
                }
            }
            treeViewFiles.Nodes[0].Expand();
            return hasFile;
        }

        private bool loadFolderAndOpenNextFileInTreeView(string path, string filename)
        {
            treeViewFiles.Nodes.Clear();
            treeViewFiles.Nodes.Add(path);
            bool hasFile = false;
            bool hasOriginalFile = false;
            bool foundOriginalFile = false;
            string[] fileFullNames = null;
            List<string> fileList = new List<string>();
            try
            {
                fileFullNames = Directory.GetFiles(path, "*.rpy");
            }
            catch
            {
                return false;
            }

            for (int i = 0; i < fileFullNames.Length; i++)
            {
                fileList.Add(Path.GetFileName(fileFullNames[i]));
            }
            if (!fileList.Contains(filename))
            {
                fileList.Add(filename);
            }
            else
            {
                hasOriginalFile = true;
            }
            fileList.Sort();

            if (fileList.Count == 1)
            {
                treeViewFiles.Nodes[0].Expand();
                return false;
            }
            var pos = -1;
            for (int i = 0; i < fileList.Count; i++)
            {
                var currentFileName = fileList[i];
                if (currentFileName == filename && !foundOriginalFile)
                {
                    foundOriginalFile = true;
                    if (hasOriginalFile)
                    {
                        treeViewFiles.Nodes[0].Nodes.Add(currentFileName);
                    }

                    if (i == fileList.Count - 1)
                    {
                        pos = i - 1;
                        hasFile = true;
                    }
                }
                else
                {
                    treeViewFiles.Nodes[0].Nodes.Add(currentFileName);
                    if (foundOriginalFile && !hasFile)
                    {
                        pos = hasOriginalFile ? i : i - 1;
                        hasFile = true;
                    }
                }
            }
            if (hasFile)
            {
                treeViewFiles.SelectedNode = treeViewFiles.Nodes[0].Nodes[pos];
            }
            treeViewFiles.Nodes[0].Expand();
            return hasFile;
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
                ClipboardHelper.FileToClipboard([CurrentReplay.FilePath], true);
            }
        }

        private void copyCommand()
        {
            if (CurrentReplay != null)
            {
                ClipboardHelper.FileToClipboard([CurrentReplay.FilePath], false);
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
                    textBoxPath.Text = fullName;
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
                        case FileOperate.New:
                            if (!CurrentReplay.ReplayProblem.HasFlag(ReplayProblemEnum.InvalidFile))
                            {
                                openReplay(path);
                                break;
                            }
                            goto case FileOperate.Next;
                        case FileOperate.Next:
                        default:
                            System.Windows.Forms.TreeNode rootNode = treeViewFiles.Nodes[0];
                            if (rootNode.Nodes.Count == 1)
                            {
                                setFileIsOpen(false, false);
                                closeReplayByFileMissing();
                                MessageBox.Show(ResourceLoader.GetText("NoNextFile"), Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                break;
                            }
                            else if (currentFilePos < rootNode.Nodes.Count - 1)
                            {
                                treeViewFiles.SelectedNode = rootNode.Nodes[currentFilePos + 1];
                            }
                            else
                            {
                                treeViewFiles.SelectedNode = rootNode.Nodes[^2];
                            }
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
                            if (!CurrentReplay.ReplayProblem.HasFlag(ReplayProblemEnum.InvalidFile))
                            {
                                openReplay(path);
                                break;
                            }
                            goto case FileOperate.KeepOrClose;
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
                if (!FileDeleteHelper.DeleteFile(CurrentReplay.FilePath))
                {
                    MessageBox.Show(ResourceLoader.GetText("DeleteFail"), Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                System.Windows.Forms.TreeNode rootNode = treeViewFiles.Nodes[0];
                if (rootNode.Nodes.Count == 1)
                {
                    setFileIsOpen(false, false);
                    closeReplayByFileMissing();
                    MessageBox.Show(ResourceLoader.GetText("NoNextFile"), Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else if (currentFilePos < rootNode.Nodes.Count - 1)
                {
                    treeViewFiles.SelectedNode = rootNode.Nodes[currentFilePos + 1];
                }
                else
                {
                    treeViewFiles.SelectedNode = rootNode.Nodes[^2];
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

                if (CurrentReplay != null && CurrentReplay.DisplayDataList.Count != 0)
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
                FormCommentEditor editor = new FormCommentEditor(this, CurrentReplay.FilePath, CurrentReplay.InfoBlocks,
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

        private string InfoLineToString()
        {
            if (CurrentReplay == null) return null;
            if (dataGridInfo.SelectedRows.Count == 0) return null;

            StringBuilder sb = new StringBuilder();
            var dataRow = ((DataRowView)dataGridInfo.SelectedRows[0].DataBoundItem).Row;

            if (dataRow["Visible"].ToString() == "0") return null;
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

        private void AppExit(object sender, EventArgs e)
        {
            lock (locker)
            {
                if (isExitRoutineExecuted) return;
                isExitRoutineExecuted = true;
            }
            SettingProvider.Settings.MainFormLeft = Left;
            SettingProvider.Settings.MainFormTop = Top;
            SettingProvider.Settings.MainFormHeight = (int)(Height / dpiScale);
            SettingProvider.Settings.MainFormWidth = (int)(Width / dpiScale);
            SettingProvider.Settings.MainFormSplitter1Pos = (int)(splitContainerMain.SplitterDistance / dpiScale);
            SettingProvider.Settings.MainFormSplitter2Pos = (int)(splitContainerInfo.SplitterDistance / dpiScale);

            SettingProvider.SaveSettings();
        }
    }
}
