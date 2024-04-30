using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
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
            TopMost = SettingProvider.Settings.OnTop;
        }

        public FormKeyViewer(TouhouReplay replay) : this()
        {
            CurrentReplay = replay;
            foreach (var item in CurrentReplay.Stages)
            {
                listBoxStages.Items.Add(item.StageName);
            }
            DataGridViewColumn frameColumn = new DataGridViewTextBoxColumn();
            frameColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            frameColumn.Width = 75;
            frameColumn.SortMode = DataGridViewColumnSortMode.NotSortable;
            frameColumn.Resizable = DataGridViewTriState.False;
            frameColumn.ReadOnly = true;
            frameColumn.DataPropertyName = "Frame";
            frameColumn.HeaderText = "F";
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
                    //DataGridViewCellStyle dataGridViewCellStyle = new DataGridViewCellStyle();
                    //dataGridViewCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
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
                col.HeaderText = "FPS";

                dataGridViewKeys.Columns.Add(col);
            }
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
            KeyAndFrameData.ReadKeys(CurrentReplay, listBoxStages.SelectedIndex);
            dataGridViewKeys.Rows.Clear();
            keyList = CurrentReplay.Stages[listBoxStages.SelectedIndex].KeyList;
            fpsList = CurrentReplay.Stages[listBoxStages.SelectedIndex].FPSList;
            var stageData = CurrentReplay.Stages[listBoxStages.SelectedIndex];
            dataGridViewKeys.RowCount = stageData.FrameCount;
            textBoxFrame.Text = stageData.FrameCount.ToString();
            textBox1Frame.Text = stageData.QuickPressCount[0].ToString();
            textBox2Frame.Text = stageData.QuickPressCount[1].ToString();
            textBox3Frame.Text = stageData.QuickPressCount[2].ToString();
            textBoxAverage.Text = stageData.AverageKeyLength.ToString("0.000");
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
                    e.Value = fpsList[e.RowIndex];
                }
            }
        }
    }
}
