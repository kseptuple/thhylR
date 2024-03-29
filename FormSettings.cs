using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using thhylR.Helper;
using thhylR.Properties;

namespace thhylR
{
    public partial class FormSettings : Form
    {
        public FormSettings()
        {
            InitializeComponent();
            ResourceLoader.SetText(this);
            listBoxTabs.DataSource = tabControlMain.TabPages;
            listBoxTabs.DisplayMember = "Text";
            comboBoxEncode1.SelectedIndex = 0;

            comboBoxScoreStyle.Items.Add(ResourceLoader.getTextResource("ScoreType1"));
            comboBoxScoreStyle.Items.Add(ResourceLoader.getTextResource("ScoreType2"));
            comboBoxScoreStyle.Items.Add(ResourceLoader.getTextResource("ScoreType3"));
            comboBoxLifeStyle.Items.Add(ResourceLoader.getTextResource("LifeBombType1"));
            comboBoxLifeStyle.Items.Add(ResourceLoader.getTextResource("LifeBombType2"));
            comboBoxLifeStyle.Items.Add(ResourceLoader.getTextResource("LifeBombType3"));

            isAdmin = PrivilegeHelper.IsAdministrator();
        }

        private Font symbolFont;
        private Font systemFont;

        private bool isAdmin;

        private void FormSettings_Load(object sender, EventArgs e)
        {
            systemFont = labelLife.Font;
            symbolFont = new Font("Segoe UI Symbol", systemFont.Size);

            var nullItem = new { Name = ResourceLoader.getTextResource("EncodingNone"), CodePage = -1 };
            comboBoxEncode2.Items.Add(nullItem);
            comboBoxEncode3.Items.Add(nullItem);
            comboBoxEncode4.Items.Add(nullItem);
            comboBoxEncode5.Items.Add(nullItem);

            var defaultItem = new { Name = ResourceLoader.getTextResource("EncodingDefault"), CodePage = 0 };
            comboBoxEncode2.Items.Add(defaultItem);
            comboBoxEncode3.Items.Add(defaultItem);
            comboBoxEncode4.Items.Add(defaultItem);
            comboBoxEncode5.Items.Add(defaultItem);

            var encodingInfoList = Encoding.GetEncodings().ToList();
            encodingInfoList = encodingInfoList.OrderBy(e => e.Name.ToLower()).ToList();
            foreach (var encodingInfo in encodingInfoList)
            {
                comboBoxEncode2.Items.Add(encodingInfo);
                comboBoxEncode3.Items.Add(encodingInfo);
                comboBoxEncode4.Items.Add(encodingInfo);
                comboBoxEncode5.Items.Add(encodingInfo);
            }
            ProgramSettings settings = SettingProvider.Settings;
            comboBoxScoreStyle.SelectedIndex = (int)settings.ScoreType;
            comboBoxLifeStyle.SelectedIndex = (int)settings.LifeBombType;
            if (settings.LifeBombType != LifeBombFormat.Number)
            {
                checkBoxShowEmpty.Checked = settings.ShowEmptyIcon;
            }

            checkBoxOnTop.Checked = settings.OnTop;
            checkBoxConfirmDelete.Checked = settings.ConfirmOnDelete;
            checkBoxAutoSwitch.Checked = settings.NextFileOnDelete;
            checkBoxRegisterCurrent.Checked = settings.RegisterReplayUser;
            checkBoxRegisterAll.Checked = settings.RegisterReplaySystem;

            radioButtonAllEncoding.Checked = settings.ShowAllEncodings;
            radioButtonCommonEncoding.Checked = !settings.ShowAllEncodings;

            checkBoxEncode2.Checked = settings.Encodings[0].UseEncoding;
            comboBoxEncode2.SetSelectedValue(settings.Encodings[0].EncodingId);
            checkBoxEncode3.Checked = settings.Encodings[1].UseEncoding;
            comboBoxEncode3.SetSelectedValue(settings.Encodings[1].EncodingId);
            checkBoxEncode4.Checked = settings.Encodings[2].UseEncoding;
            comboBoxEncode4.SetSelectedValue(settings.Encodings[2].EncodingId);
            checkBoxEncode5.Checked = settings.Encodings[3].UseEncoding;
            comboBoxEncode5.SetSelectedValue(settings.Encodings[3].EncodingId);

            setEncodingComboEnable(checkBoxEncode2, comboBoxEncode2);
            setEncodingComboEnable(checkBoxEncode3, comboBoxEncode3);
            setEncodingComboEnable(checkBoxEncode4, comboBoxEncode4);
            setEncodingComboEnable(checkBoxEncode5, comboBoxEncode5);

            foreach (TabPage tabPage in tabControlMain.TabPages)
            {
                BindApplyButtonEvents(tabPage.Controls);
            }

            void BindApplyButtonEvents(Control.ControlCollection controls)
            {
                foreach (Control control in controls)
                {
                    if (control is ComboBox ctrlComboBox)
                    {
                        ctrlComboBox.SelectedIndexChanged += ControlsChanged;
                    }
                    else if (control is CheckBox ctrlCheckBox)
                    {
                        ctrlCheckBox.CheckedChanged += ControlsChanged;
                    }
                    else if (control is RadioButton ctrlRadioButton)
                    {
                        ctrlRadioButton.CheckedChanged += ControlsChanged;
                    }
                    else if (control.Controls != null && control.Controls.Count != 0)
                    {
                        BindApplyButtonEvents(control.Controls);
                    }
                }
            }
        }

        private void ControlsChanged(object sender, EventArgs e)
        {
            buttonApply.Enabled = true;
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
                buttonFontSymbol.Enabled = false;
            }
            else
            {
                checkBoxShowEmpty.Enabled = true;
                buttonFontSymbol.Enabled = true;
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
                labelLife.Font = systemFont;
                labelBomb.Font = systemFont;
            }
            else
            {
                if (comboBoxLifeStyle.SelectedIndex == 1 && checkBoxShowEmpty.Checked)
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
                labelLife.Font = symbolFont;
                labelBomb.Font = symbolFont;
            }
        }

        private void buttonApply_Click(object sender, EventArgs e)
        {
            buttonApply.Enabled = false;
            SaveSettings();
        }

        private void checkBoxEncode2_CheckedChanged(object sender, EventArgs e)
        {
            setEncodingComboEnable(checkBoxEncode2, comboBoxEncode2);
        }

        private void checkBoxEncode3_CheckedChanged(object sender, EventArgs e)
        {
            setEncodingComboEnable(checkBoxEncode3, comboBoxEncode3);
        }

        private void checkBoxEncode4_CheckedChanged(object sender, EventArgs e)
        {
            setEncodingComboEnable(checkBoxEncode4, comboBoxEncode4);
        }

        private void checkBoxEncode5_CheckedChanged(object sender, EventArgs e)
        {
            setEncodingComboEnable(checkBoxEncode5, comboBoxEncode5);
        }

        private void setEncodingComboEnable(CheckBox checkBox, ComboBox comboBox)
        {
            comboBox.Enabled = checkBox.Checked;
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            SaveSettings();
            Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void SaveSettings()
        {
            ProgramSettings settings = SettingProvider.Settings;
            settings.ScoreType = (ScoreFormat)comboBoxScoreStyle.SelectedIndex;
            settings.LifeBombType = (LifeBombFormat)comboBoxLifeStyle.SelectedIndex;

            if (settings.LifeBombType != LifeBombFormat.Number)
            {
                settings.ShowEmptyIcon = checkBoxShowEmpty.Checked;
            }

            settings.OnTop = checkBoxOnTop.Checked;
            settings.ConfirmOnDelete = checkBoxConfirmDelete.Checked;
            settings.NextFileOnDelete = checkBoxAutoSwitch.Checked;


            settings.ShowAllEncodings = radioButtonAllEncoding.Checked;

            settings.Encodings[0].UseEncoding = checkBoxEncode2.Checked;

            settings.Encodings[0].EncodingId = (int)comboBoxEncode2.GetSelectedValue();
            settings.Encodings[1].UseEncoding = checkBoxEncode3.Checked;
            settings.Encodings[1].EncodingId = (int)comboBoxEncode3.GetSelectedValue();
            settings.Encodings[2].UseEncoding = checkBoxEncode4.Checked;
            settings.Encodings[2].EncodingId = (int)comboBoxEncode4.GetSelectedValue();
            settings.Encodings[3].UseEncoding = checkBoxEncode5.Checked;
            settings.Encodings[3].EncodingId = (int)comboBoxEncode5.GetSelectedValue();

            SettingProvider.SaveSettings();
            try
            {
                settings.RegisterReplayUser = checkBoxRegisterCurrent.Checked;
            }
            catch
            {
                MessageBox.Show(ResourceLoader.getTextResource("RegistrySetFail"), Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                checkBoxRegisterCurrent.Checked = settings.RegisterReplayUser;
                buttonApply.Enabled = false;
                return;
            }

            try
            {
                settings.RegisterReplaySystem = checkBoxRegisterAll.Checked;
            }
            catch
            {
                if (isAdmin)
                {
                    MessageBox.Show(ResourceLoader.getTextResource("RegistrySetFail"), Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    checkBoxRegisterAll.Checked = settings.RegisterReplaySystem;
                    buttonApply.Enabled = false;
                }
                else
                {
                    var result = MessageBox.Show(ResourceLoader.getTextResource("RegistrySetFailAdmin"), Text,
                    MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                    if (result == DialogResult.Yes)
                    {
                        if (!PrivilegeHelper.Promote())
                        {
                            MessageBox.Show(ResourceLoader.getTextResource("RestartFail"), Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        checkBoxRegisterAll.Checked = settings.RegisterReplaySystem;
                        buttonApply.Enabled = false;
                    }
                }
                return;
            }
        }

        private void buttonFontNormal_Click(object sender, EventArgs e)
        {
            fontDialogSetting.ShowDialog(this);
        }
    }

    public static class ComboBoxHelper
    {
        public static void SetSelectedValue(this ComboBox comboBox, object value)
        {
            if (comboBox.Items.Count > 0)
            {
                for (int i = 0; i < comboBox.Items.Count; i++)
                {
                    object item = comboBox.Items[i];
                    object thisValue = item.GetType().GetProperty(comboBox.ValueMember).GetValue(item);
                    if (thisValue != null && thisValue.Equals(value))
                    {
                        comboBox.SelectedIndex = i;
                        return;
                    }
                }
                comboBox.SelectedIndex = 0;
            }
        }

        public static object GetSelectedValue(this ComboBox comboBox)
        {
            if (comboBox.SelectedIndex != -1)
            {
                object item = comboBox.Items[comboBox.SelectedIndex];
                return item.GetType().GetProperty(comboBox.ValueMember).GetValue(item);
            }
            else
            {
                return null;
            }
        }
    }
}
