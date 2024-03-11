using System.Data;
using System.Drawing;
using thhylR.Common;
using thhylR.Games;

namespace thhylR
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
            GameData.Init();
            EnumData.Init();
            //dataGridInfo.Font = new Font(dataGridInfo.Font.FontFamily, 12);
            dataGridInfo.AutoGenerateColumns = false;
        }

        private TouhouReplay currentReplay = null;

        private void buttonOpen_Click(object sender, EventArgs e)
        {
            var dialogResult = openReplayDialog.ShowDialog(this);
            if (dialogResult != DialogResult.OK)
            {
                return;
            }
            byte[] fileData = File.ReadAllBytes(openReplayDialog.FileName);
            currentReplay = ReplayAnalyzer.Analyze(fileData);

            dataGridInfo.DataSource = currentReplay.DisplayData.Select("Visible <> 0").CopyToDataTable();

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
                saveFileDialog.Filter = "原始数据|*.bin";
                var dialogResult = saveFileDialog.ShowDialog();
                if (dialogResult == DialogResult.OK)
                {
                    File.WriteAllBytes(saveFileDialog.FileName, result);
                }
            }
        }
    }
}
