﻿using thhylR.Common;
using thhylR.Games;
using thhylR.Helper;

namespace thhylR
{
    public partial class FormExport : Form
    {
        private CheckBox checkBoxSelectAll = new CheckBox();

        public TouhouReplay CurrentReplay { get; set; }

        private Dictionary<ReplayBlockType, string> replayBlockName = new Dictionary<ReplayBlockType, string>();
        private bool isSelectAll = false;

        private List<ReplayBlock> replayBlocks = null;

        public FormExport()
        {
            InitializeComponent();
            ResourceLoader.SetFormText(this);
            TopMost = SettingProvider.Settings.OnTop;

            dataGridViewExport.Columns["Id"].HeaderText = ResourceLoader.GetText("ExportId");
            dataGridViewExport.Columns["FileName"].HeaderText = ResourceLoader.GetText("ExportFileName");
            dataGridViewExport.Columns["BlockType"].HeaderText = ResourceLoader.GetText("ExportBlockType");
            dataGridViewExport.Columns["Stage"].HeaderText = ResourceLoader.GetText("ExportStage");
            dataGridViewExport.Columns["Offset"].HeaderText = ResourceLoader.GetText("ExportOffset");
            dataGridViewExport.Columns["Length"].HeaderText = ResourceLoader.GetText("ExportLength");
            dataGridViewExport.Columns["ExportResult"].HeaderText = ResourceLoader.GetText("ExportResult");

            replayBlockName.Add(ReplayBlockType.Header, ResourceLoader.GetText("BlockTypeHeader"));
            replayBlockName.Add(ReplayBlockType.StageHeader, ResourceLoader.GetText("BlockTypeStageHeader"));
            replayBlockName.Add(ReplayBlockType.KeyData, ResourceLoader.GetText("BlockTypeKeyData"));
            replayBlockName.Add(ReplayBlockType.FPSData, ResourceLoader.GetText("BlockTypeFPSData"));
            replayBlockName.Add(ReplayBlockType.InfoBlock, ResourceLoader.GetText("BlockTypeUserInfo"));
        }

        public FormExport(TouhouReplay replay) : this()
        {
            CurrentReplay = replay;
        }

        private void InitDataGridView()
        {
            Rectangle headerCellRectangle = dataGridViewExport.GetCellDisplayRectangle(0, -1, true);

            checkBoxSelectAll.BackColor = Color.Transparent;
            checkBoxSelectAll.Location = new Point(
                headerCellRectangle.Left + (headerCellRectangle.Width - 18) / 2,
                headerCellRectangle.Top + (headerCellRectangle.Height - 16) / 2);
            checkBoxSelectAll.BackColor = Color.White;
            checkBoxSelectAll.Size = new Size(16, 16);
            checkBoxSelectAll.CheckedChanged += CheckBoxSelectAll_CheckedChanged;
            dataGridViewExport.Controls.Add(checkBoxSelectAll);
        }

        private void CheckBoxSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            if (isSelectAll) return;
            isSelectAll = true;
            foreach (DataGridViewRow row in dataGridViewExport.Rows)
            {
                row.Cells["IsChecked"].Value = checkBoxSelectAll.Checked;
            }
            dataGridViewExport.CommitEdit(DataGridViewDataErrorContexts.Commit);
            dataGridViewExport.RefreshEdit();
            isSelectAll = false;
        }

        private void InitData()
        {
            if (CurrentReplay != null)
            {
                replayBlocks = ReplayExporter.GetBlocks(CurrentReplay);

                for (int i = 0; i < replayBlocks.Count; i++)
                {
                    var replayBlock = replayBlocks[i];
                    string replayFilename = Path.GetFileNameWithoutExtension(CurrentReplay.FilePath);
                    string filename = $"{replayFilename}_{replayBlock.Name}.bin";
                    string stage = replayBlock.Stage;
                    if (string.IsNullOrEmpty(stage))
                    {
                        stage = "-";
                    }

                    dataGridViewExport.Rows.Add(false, i + 1, filename, replayBlockName[replayBlock.Type], stage,
                        replayBlock.Offset, replayBlock.Length, ResourceLoader.GetText("ExportNotStart"));
                }
            }
        }

        private void FormExport_Load(object sender, EventArgs e)
        {
            InitDataGridView();
            InitData();
        }

        private void dataGridViewExport_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dataGridViewExport.CurrentCell.ColumnIndex == 0)
            {
                dataGridViewExport.CommitEdit(DataGridViewDataErrorContexts.Commit);
                bool allChecked = isAllLineChecked();
                if (allChecked != checkBoxSelectAll.Checked)
                {
                    isSelectAll = true;
                    checkBoxSelectAll.Checked = allChecked;
                    isSelectAll = false;
                }
            }
        }

        private bool isAllLineChecked()
        {
            if (dataGridViewExport.Rows.Count == 0) return false;
            foreach (DataGridViewRow row in dataGridViewExport.Rows)
            {
                if (!(bool)row.Cells["IsChecked"].Value)
                {
                    return false;
                }
            }
            return true;
        }

        private bool isNoLineChecked()
        {
            if (dataGridViewExport.Rows.Count == 0) return true;
            foreach (DataGridViewRow row in dataGridViewExport.Rows)
            {
                if ((bool)row.Cells["IsChecked"].Value)
                {
                    return false;
                }
            }
            return true;
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void buttonSelectFolder_Click(object sender, EventArgs e)
        {
            if (isNoLineChecked())
            {
                MessageBox.Show(ResourceLoader.GetText("ExportNotSelected"), Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            folderBrowserDialogSaveTo.InitialDirectory = Path.GetDirectoryName(CurrentReplay.FilePath);
            var result = folderBrowserDialogSaveTo.ShowDialog(this);
            if (result == DialogResult.OK)
            {
                string directory = folderBrowserDialogSaveTo.SelectedPath;
                foreach (DataGridViewRow row in dataGridViewExport.Rows)
                {
                    if ((bool)row.Cells["IsChecked"].Value)
                    {
                        int id = (int)row.Cells["Id"].Value - 1;
                        var replayBlock = replayBlocks[id];
                        var data = ReplayExporter.GetBlockData(replayBlock, CurrentReplay);
                        if (data != null)
                        {
                            var filename = row.Cells["FileName"].Value.ToString();
                            var currentPath = Path.Combine(directory, filename);

                            var filenameWithoutExtension = Path.GetFileNameWithoutExtension(currentPath);
                            int currentNo = 2;
                            bool needRename = false;
                            while (File.Exists(currentPath))
                            {
                                needRename = true;
                                var newFileName = $"{filenameWithoutExtension} ({currentNo}).bin";
                                currentPath = Path.Combine(directory, newFileName);
                                currentNo++;
                            }
                            try
                            {
                                File.WriteAllBytes(currentPath, data);
                                if (needRename)
                                {
                                    row.Cells["ExportResult"].Value = ResourceLoader.GetText("ExportRename");
                                }
                                else
                                {
                                    row.Cells["ExportResult"].Value = ResourceLoader.GetText("ExportSuccess");
                                }
                            }
                            catch
                            {
                                row.Cells["ExportResult"].Value = ResourceLoader.GetText("ExportFail");
                            }
                        }
                        else
                        {
                            row.Cells["ExportResult"].Value = ResourceLoader.GetText("ExportFail");
                        }
                    }
                }
            }
        }
    }
}
