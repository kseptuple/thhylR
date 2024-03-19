using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace thhylR
{
    public partial class FormSettings : Form
    {
        public FormSettings()
        {
            InitializeComponent();
            //tabControlMain.ItemSize = new Size(0, 1);
            listBoxTabs.DataSource = tabControlMain.TabPages;
            listBoxTabs.DisplayMember = "Text";
            comboBoxEncode1.SelectedIndex = 0;
        }

        private void FormSettings_Load(object sender, EventArgs e)
        {
            var nullItem = new { Name = "无", CodePage = -1 };
            comboBoxEncode2.Items.Add(nullItem);
            comboBoxEncode3.Items.Add(nullItem);
            comboBoxEncode4.Items.Add(nullItem);
            comboBoxEncode5.Items.Add(nullItem);

            var defaultItem = new { Name = "系统默认", CodePage = 0 };
            comboBoxEncode2.Items.Add(defaultItem);
            comboBoxEncode3.Items.Add(defaultItem);
            comboBoxEncode4.Items.Add(defaultItem);
            comboBoxEncode5.Items.Add(defaultItem);

            var encodingInfoList = Encoding.GetEncodings();
            foreach (var encodingInfo in encodingInfoList)
            {
                comboBoxEncode2.Items.Add(encodingInfo);
                comboBoxEncode3.Items.Add(encodingInfo);
                comboBoxEncode4.Items.Add(encodingInfo);
                comboBoxEncode5.Items.Add(encodingInfo);
            }
        }

        private void listBoxTabs_SelectedIndexChanged(object sender, EventArgs e)
        {
            tabControlMain.SelectedIndex = listBoxTabs.SelectedIndex;
        }

        private void comboBoxLifeStyle_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxLifeStyle.SelectedIndex == 0)
            {
                checkBoxShowEmpty.Enabled = false;
            }
            else
            {
                checkBoxShowEmpty.Enabled = true;
            }
            setLifeBombExample();
        }

        private void checkBoxShowEmpty_CheckedChanged(object sender, EventArgs e)
        {
            setLifeBombExample();
        }

        private void setLifeBombExample()
        {
            if (comboBoxLifeStyle.SelectedIndex == 0)
            {
                labelLife.Text = "3";
                labelBomb.Text = "4";
            }
            else if (comboBoxLifeStyle.SelectedIndex == 1 && checkBoxShowEmpty.Checked)
            {
                labelLife.Text = "\u2665\ufe0e\u2665\ufe0e\u2665\ufe0e\u2661\ufe0e\u2661\ufe0e\u2661\ufe0e\u2661\ufe0e\u2661\ufe0e";
                labelBomb.Text = "\u2605\ufe0e\u2605\ufe0e\u2605\ufe0e\u2605\ufe0e\u2606\ufe0e\u2606\ufe0e\u2606\ufe0e\u2606\ufe0e";
            }
            else if (comboBoxLifeStyle.SelectedIndex == 1 && !checkBoxShowEmpty.Checked)
            {
                labelLife.Text = "\u2665\ufe0e\u2665\ufe0e\u2665\ufe0e";
                labelBomb.Text = "\u2605\ufe0e\u2605\ufe0e\u2605\ufe0e\u2605\ufe0e";
            }
            else if (comboBoxLifeStyle.SelectedIndex == 2 && checkBoxShowEmpty.Checked)
            {
                labelLife.Text = "\u2605\ufe0e\u2605\ufe0e\u2605\ufe0e\u2606\ufe0e\u2606\ufe0e\u2606\ufe0e\u2606\ufe0e\u2606\ufe0e";
                labelBomb.Text = "\u2605\ufe0e\u2605\ufe0e\u2605\ufe0e\u2605\ufe0e\u2606\ufe0e\u2606\ufe0e\u2606\ufe0e\u2606\ufe0e";
            }
            else if (comboBoxLifeStyle.SelectedIndex == 2 && !checkBoxShowEmpty.Checked)
            {
                labelLife.Text = "\u2605\ufe0e\u2605\ufe0e\u2605\ufe0e";
                labelBomb.Text = "\u2605\ufe0e\u2605\ufe0e\u2605\ufe0e\u2605\ufe0e";
            }
        }
    }
}
