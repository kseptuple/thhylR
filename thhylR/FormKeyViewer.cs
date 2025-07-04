﻿using System.Text;
using thhylR.Common;
using thhylR.Games;
using thhylR.Helper;

namespace thhylR
{
    public partial class FormKeyViewer : Form
    {
        public FormKeyViewer()
        {
            InitializeComponent();
            ResourceLoader.SetFormText(this);
            dpiScale = DeviceDpi / 96.0;
            TopMost = SettingProvider.Settings.OnTop;

            Width = (int)(SettingProvider.Settings.KeyViewerFormWidth * dpiScale);
            Height = (int)(SettingProvider.Settings.KeyViewerFormHeight * dpiScale);
        }

        private List<FullKeyStats> fullKeyStats = new List<FullKeyStats>();

        private FullKeyStats currentKeyStats = null;
        private bool isRadioButtonClicking = false;
        private double dpiScale = 0d;

        private List<string> keyDetailTips = new List<string>();

        public FormKeyViewer(TouhouReplay replay) : this()
        {
            CurrentReplay = replay;
            foreach (var item in CurrentReplay.Stages)
            {
                listBoxStages.Items.Add(item.StageName);
                fullKeyStats.Add(null);
            }
            DataGridViewColumn frameColumn = new DataGridViewTextBoxColumn();
            frameColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            frameColumn.Width = 75;
            frameColumn.SortMode = DataGridViewColumnSortMode.NotSortable;
            frameColumn.Resizable = DataGridViewTriState.False;
            frameColumn.ReadOnly = true;
            frameColumn.DataPropertyName = "Frame";
            frameColumn.HeaderText = ResourceLoader.GetText("FrameNumber");
            frameColumn.Frozen = true;

            dataGridViewKeys.Columns.Add(frameColumn);
            var keys = replay.GameData.StageSetting.KeyData.KeyNames;
            var allKeys = EnumData.EnumDataList.FirstOrDefault(e => e.Name == "KeyEnum").EnumValues;
            int keyBitIndex = 0;
            foreach (var item in allKeys)
            {
                var index = keys.IndexOf(item.Value);
                if (index != -1)
                {
                    keyBits.Add(index);
                    DataGridViewColumn col = new DataGridViewTextBoxColumn();
                    col.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
                    col.SortMode = DataGridViewColumnSortMode.NotSortable;
                    col.Resizable = DataGridViewTriState.False;
                    col.ReadOnly = true;
                    col.DataPropertyName = keyBitIndex.ToString();
                    col.HeaderText = item.Value;
                    col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                    dataGridViewKeys.Columns.Add(col);
                    keyBitIndex++;
                }
            }

            if (replay.GameData.StageSetting.FPSStartData != -1 || replay.GameData.ReplayStructVersion != 1)
            {
                DataGridViewColumn col = new DataGridViewTextBoxColumn();
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
                col.SortMode = DataGridViewColumnSortMode.NotSortable;
                col.Resizable = DataGridViewTriState.False;
                col.ReadOnly = true;
                col.DataPropertyName = "FPS";
                col.HeaderText = ResourceLoader.GetText("FPS");

                dataGridViewKeys.Columns.Add(col);
            }

            dataGridViewStats.Rows.Add(ResourceLoader.GetText("StatFramCount"), null, ResourceLoader.GetText("StatConfilctKey"), null);
            dataGridViewStats.Rows.Add(ResourceLoader.GetText("StatKeyPressCount"), null, ResourceLoader.GetText("Stat1FPress"), null);
            dataGridViewStats.Rows.Add(ResourceLoader.GetText("StatAverageKeyLength"), null, ResourceLoader.GetText("Stat2FPress"), null);
            dataGridViewStats.Rows.Add(ResourceLoader.GetText("StatPeekKeyPress"), null, ResourceLoader.GetText("Stat3FPress"), null);

            chartKeys.Titles[0].Text = ResourceLoader.GetText("KeyPressChartTitle");

            saveFileDialogExport.Filter = ResourceLoader.GetText("ExportFileFilter");
            saveFileDialogExport.InitialDirectory = Path.GetDirectoryName(replay.FilePath);

            keyDetailTips.Add(string.Format(ResourceLoader.GetText("KeyDetail"), ResourceLoader.GetText("Key0Frame")));
            keyDetailTips.Add(string.Format(ResourceLoader.GetText("KeyDetail"), ResourceLoader.GetText("Key1Frame")));
            keyDetailTips.Add(string.Format(ResourceLoader.GetText("KeyDetail"), ResourceLoader.GetText("Key2Frame")));
            keyDetailTips.Add(string.Format(ResourceLoader.GetText("KeyDetail"), ResourceLoader.GetText("Key3Frame")));

            for (int i = 0; i <= 3; i++)
            {
                comboBoxFrameDiff.Items.Add(i + ResourceLoader.GetText("KeyDiffUnit"));
            }
            var selectedTolerance = SettingProvider.Settings.KeyboardInputFrameTolerance;
            if (selectedTolerance < comboBoxFrameDiff.Items.Count)
            {
                comboBoxFrameDiff.SelectedIndex = selectedTolerance;
            }
            else
            {
                comboBoxFrameDiff.SelectedIndex = 0;
            }

            labelDiff.Left = comboBoxFrameDiff.Left - comboBoxFrameDiff.Margin.Left - labelDiff.Width;
        }

        public TouhouReplay CurrentReplay { get; set; }
        private List<int> keyBits = new List<int>();
        private List<string[]> keyList = null;
        private List<int> fpsList = null;

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void listBoxStages_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxStages.SelectedIndex == -1) return;
            KeyAndFrameData.ReadKeys(CurrentReplay, listBoxStages.SelectedIndex);
            dataGridViewKeys.Rows.Clear();
            keyList = CurrentReplay.Stages[listBoxStages.SelectedIndex].KeyList;
            fpsList = CurrentReplay.Stages[listBoxStages.SelectedIndex].FPSList;
            dataGridViewKeys.RowCount = CurrentReplay.Stages[listBoxStages.SelectedIndex].FrameCount;
            if (tabControlKeys.SelectedIndex == 1)
            {
                showCharts();
            }
        }

        private void dataGridViewKeys_CellValueNeeded(object sender, DataGridViewCellValueEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                e.Value = e.RowIndex + 1;
            }
            else if (e.ColumnIndex >= 1 && e.ColumnIndex <= keyBits.Count)
            {
                e.Value = keyList[e.RowIndex][keyBits[e.ColumnIndex - 1]];
            }
            else
            {
                if (fpsList != null)
                {
                    if (e.RowIndex >= fpsList.Count)
                    {
                        e.Value = "-";          //TH09 bug
                    }
                    else
                    {
                        e.Value = fpsList[e.RowIndex];
                    }
                }
            }
        }

        private void showCharts()
        {
            int stageId = listBoxStages.SelectedIndex;
            if (stageId == -1) return;
            bool hasConflictKey = CurrentReplay.Stages[stageId].HasConflictKeys;

            if (fullKeyStats[stageId] == null)
            {
                fullKeyStats[stageId] = KeyAndFrameData.GetKeyStats(CurrentReplay.Stages[stageId].ArrowKeyList, hasConflictKey);
            }
            currentKeyStats = fullKeyStats[stageId];

            isRadioButtonClicking = true;
            if (hasConflictKey)
            {
                if (!radioButtonKey.Checked)
                {
                    radioButtonKey.Checked = true;
                    comboBoxFrameDiff.Enabled = true;
                }
                setChartContent(currentKeyStats.KeyboardKey);
                radioButtonController.Enabled = false;
                dataGridViewStats.Rows[0].Cells[3].Value = ResourceLoader.GetText("StatConflictYes");
            }
            else
            {
                radioButtonController.Enabled = true;
                if (radioButtonKey.Checked)
                {
                    setChartContent(currentKeyStats.KeyboardKey);
                }
                else
                {
                    radioButtonController.Checked = true;
                    comboBoxFrameDiff.Enabled = false;
                    setChartContent(currentKeyStats.ControllerKey);
                }

                dataGridViewStats.Rows[0].Cells[3].Value = ResourceLoader.GetText("StatConflictNo");
            }
            dataGridViewStats.Rows[0].Cells[1].Value = currentKeyStats.TotalFrames;
            isRadioButtonClicking = false;
        }

        private void radioButtonController_CheckedChanged(object sender, EventArgs e)
        {
            if (isRadioButtonClicking) return;
            isRadioButtonClicking = true;
            if (currentKeyStats != null)
            {
                setChartContent(currentKeyStats.ControllerKey);
            }
            comboBoxFrameDiff.Enabled = false;
            isRadioButtonClicking = false;
        }

        private void radioButtonKey_CheckedChanged(object sender, EventArgs e)
        {
            if (isRadioButtonClicking) return;
            if (currentKeyStats == null) return;
            isRadioButtonClicking = true;
            if (currentKeyStats != null)
            {
                setChartContent(currentKeyStats.KeyboardKey);
            }
            comboBoxFrameDiff.Enabled = true;
            isRadioButtonClicking = false;
        }

        private void tabControlKeys_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControlKeys.SelectedIndex == 1)
            {
                showCharts();
            }
        }

        private void setChartContent(KeyStats keyStats)
        {
            int keyStatIndex = 0;
            if (keyStats.Type == KeyType.Keyboard)
            {
                keyStatIndex = comboBoxFrameDiff.SelectedIndex;
            }
            chartKeys.Series[0].Points.DataBindY(keyStats.KeyPressCount[keyStatIndex], string.Empty);
            dataGridViewStats.Rows[1].Cells[1].Value = keyStats.TotalKeys;
            dataGridViewStats.Rows[2].Cells[1].Value = keyStats.AverageKeyLength.ToString("0.000");
            dataGridViewStats.Rows[3].Cells[1].Value = keyStats.GetMaxKeyPressCount(keyStatIndex);
            dataGridViewStats.Rows[1].Cells[3].Value = keyStats.QuickKeyPressCount[0];
            dataGridViewStats.Rows[2].Cells[3].Value = keyStats.QuickKeyPressCount[1];
            dataGridViewStats.Rows[3].Cells[3].Value = keyStats.QuickKeyPressCount[2];
        }

        private readonly byte[] utf8BOM = [0xEF, 0xBB, 0xBF];
        private void buttonExport_Click(object sender, EventArgs e)
        {
            int stageId = listBoxStages.SelectedIndex;
            if (stageId == -1) return;
            var dialogResult = saveFileDialogExport.ShowDialog(this);
            if (dialogResult == DialogResult.OK)
            {
                try
                {
                    FileStream fs = File.OpenWrite(saveFileDialogExport.FileName);
                    fs.Write(utf8BOM);
                    fs.Write(Encoding.UTF8.GetBytes(getExportFileLines()));
                    fs.Flush();
                    fs.Close();
                    MessageBox.Show(ResourceLoader.GetText("ExportKeySuccess"), Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch
                {
                    MessageBox.Show(ResourceLoader.GetText("ExportKeyFail"), Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private string getExportFileLines()
        {
            StringBuilder sb = new StringBuilder();
            foreach (DataGridViewColumn item in dataGridViewKeys.Columns)
            {
                sb.Append('"').Append(item.HeaderText).Append("\",");
            }
            sb.AppendLine();
            for (int i = 0; i < keyList.Count; i++)
            {
                sb.Append('"').Append(i + 1).Append("\",");
                for (int j = 0; j < keyBits.Count; j++)
                {
                    sb.Append('"').Append(keyList[i][keyBits[j]]).Append("\",");
                }
                if (fpsList != null)
                {
                    sb.Append('"').Append(fpsList[i]).Append("\",");
                }
                sb.AppendLine();
            }
            return sb.ToString();
        }

        private void FormKeyViewer_DpiChanged(object sender, DpiChangedEventArgs e)
        {
            dpiScale = DeviceDpi / 96.0;
            MinimumSize = new Size((int)(940 * dpiScale), (int)(540 * dpiScale));
        }

        private void FormKeyViewer_FormClosing(object sender, FormClosingEventArgs e)
        {
            SettingProvider.Settings.KeyViewerFormWidth = (int)(Width / dpiScale);
            SettingProvider.Settings.KeyViewerFormHeight = (int)(Height / dpiScale);
            SettingProvider.Settings.KeyboardInputFrameTolerance = comboBoxFrameDiff.SelectedIndex;
        }

        private void comboBoxFrameDiff_SelectedIndexChanged(object sender, EventArgs e)
        {
            labelDetail.Text = keyDetailTips[comboBoxFrameDiff.SelectedIndex];
            showCharts();
        }
    }
}
