﻿using thhylR.Helper;

namespace thhylR
{
    public partial class FormSettings : Form
    {
        public FormSettings()
        {
            InitializeComponent();
            ResourceLoader.SetFormText(this);
            TopMost = SettingProvider.Settings.OnTop;
            listBoxTabs.DataSource = tabControlMain.TabPages;
            listBoxTabs.DisplayMember = "Text";
            tabControlMain.ItemSize = new Size(0, 1);
            comboBoxScoreType.Items.Add(ResourceLoader.GetText("ScoreShown1"));
            comboBoxScoreType.Items.Add(ResourceLoader.GetText("ScoreShown2"));
            comboBoxScoreType.Items.Add(ResourceLoader.GetText("ScoreShown3"));
            comboBoxScoreStyle.Items.Add(ResourceLoader.GetText("ScoreType1"));
            comboBoxScoreStyle.Items.Add(ResourceLoader.GetText("ScoreType2"));
            comboBoxScoreStyle.Items.Add(ResourceLoader.GetText("ScoreType3"));
            comboBoxLifeStyle.Items.Add(ResourceLoader.GetText("LifeBombType1"));
            comboBoxLifeStyle.Items.Add(ResourceLoader.GetText("LifeBombType2"));
            comboBoxLifeStyle.Items.Add(ResourceLoader.GetText("LifeBombType3"));

            isAdmin = PrivilegeHelper.IsAdministrator();
            DialogResult = DialogResult.Cancel;
        }

        private Font symbolFont;
        private Font systemFont;

        public bool IsExit { get; private set; } = false;

        private Font SystemFont
        {
            get
            {
                return systemFont;
            }
            set
            {
                systemFont = value;
                systemFontDemo = new Font(value.FontFamily, 9, value.Style);
            }
        }

        private Font SymbolFont
        {
            get
            {
                return symbolFont;
            }
            set
            {
                symbolFont = value;
                symbolFontDemo = new Font(value.FontFamily, 9, value.Style);
            }
        }

        private Font symbolFontDemo;
        private Font systemFontDemo;

        private bool isAdmin;

        private void FormSettings_Load(object sender, EventArgs e)
        {
            var nullItem = new { Name = ResourceLoader.GetText("EncodingNone"), CodePage = -1 };
            comboBoxEncode1.Items.Add(nullItem);
            comboBoxEncode2.Items.Add(nullItem);
            comboBoxEncode3.Items.Add(nullItem);
            comboBoxEncode4.Items.Add(nullItem);


            var defaultItem = new { Name = ResourceLoader.GetText("EncodingDefault"), CodePage = 0 };
            comboBoxEncode1.Items.Add(defaultItem);
            comboBoxEncode2.Items.Add(defaultItem);
            comboBoxEncode3.Items.Add(defaultItem);
            comboBoxEncode4.Items.Add(defaultItem);

            var encodingInfoList = EncodingHelper.EncodingList;
            foreach (var encodingInfo in encodingInfoList)
            {
                comboBoxEncode1.Items.Add(encodingInfo);
                comboBoxEncode2.Items.Add(encodingInfo);
                comboBoxEncode3.Items.Add(encodingInfo);
                comboBoxEncode4.Items.Add(encodingInfo);
            }
            ProgramSettings settings = SettingProvider.Settings;

            SystemFont = settings.NormalFont;
            SymbolFont = settings.SymbolFont;

            labelScore.Font = systemFontDemo;

            comboBoxScoreType.SelectedIndex = (int)settings.ShownScore;
            comboBoxScoreStyle.SelectedIndex = (int)settings.ScoreType;
            comboBoxLifeStyle.SelectedIndex = (int)settings.LifeBombType;
            if (settings.LifeBombType != LifeBombFormat.Number)
            {
                checkBoxShowEmpty.Checked = settings.ShowEmptyIcon;
            }

            checkBoxOnTop.Checked = settings.OnTop;
            checkBoxRegisterCurrent.Checked = settings.RegisterReplayUser;
            checkBoxRegisterAll.Checked = settings.RegisterReplaySystem;

            comboBoxOperAfterMove.Items.Add(ResourceLoader.GetText("KeepFile"));
            comboBoxOperAfterMove.Items.Add(ResourceLoader.GetText("NextFile"));
            comboBoxOperAfterMove.Items.Add(ResourceLoader.GetText("NewFile"));

            comboBoxOperAfterCopy.Items.Add(ResourceLoader.GetText("KeepFile"));
            comboBoxOperAfterCopy.Items.Add(ResourceLoader.GetText("NewFile"));

            comboBoxOperAfterDelete.Items.Add(ResourceLoader.GetText("KeepFile"));
            comboBoxOperAfterDelete.Items.Add(ResourceLoader.GetText("NextFile"));

            comboBoxOperAfterMove.SelectedIndex = (int)settings.OperAfterMove;
            comboBoxOperAfterCopy.SelectedIndex = settings.OperAfterCopy == FileOperate.KeepOrClose ? 0 : 1;
            comboBoxOperAfterDelete.SelectedIndex = settings.OperAfterDelete == FileOperate.KeepOrClose ? 0 : 1;

            radioButtonAllEncoding.Checked = settings.ShowAllEncodings;
            radioButtonCommonEncoding.Checked = !settings.ShowAllEncodings;

            checkBoxEncode1.Checked = settings.Encodings[0].UseEncoding;
            comboBoxEncode1.SetSelectedValue(settings.Encodings[0].EncodingId);
            checkBoxEncode2.Checked = settings.Encodings[1].UseEncoding;
            comboBoxEncode2.SetSelectedValue(settings.Encodings[1].EncodingId);
            checkBoxEncode3.Checked = settings.Encodings[2].UseEncoding;
            comboBoxEncode3.SetSelectedValue(settings.Encodings[2].EncodingId);
            checkBoxEncode4.Checked = settings.Encodings[3].UseEncoding;
            comboBoxEncode4.SetSelectedValue(settings.Encodings[3].EncodingId);

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

        private void comboBoxScoreStyle_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxScoreStyle.SelectedIndex == 0)
            {
                labelScore.Text = ResourceLoader.GetText("ScoreType1");
            }
            else if (comboBoxScoreStyle.SelectedIndex == 1)
            {
                labelScore.Text = ResourceLoader.GetText("ScoreType2");
            }
            else if (comboBoxScoreStyle.SelectedIndex == 2)
            {
                labelScore.Text = ResourceLoader.GetText("ScoreType3");
            }
        }

        private void setLifeBombExample()
        {
            if (comboBoxLifeStyle.SelectedIndex == 0)
            {
                labelLife.Text = "3";
                labelBomb.Text = "4";
                labelLife.Font = systemFontDemo;
                labelBomb.Font = systemFontDemo;
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
                labelLife.Font = symbolFontDemo;
                labelBomb.Font = symbolFontDemo;
            }
        }

        private void buttonApply_Click(object sender, EventArgs e)
        {
            buttonApply.Enabled = false;
            SaveSettings();
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            SaveSettings();
            DialogResult = DialogResult.OK;
            Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void SaveSettings()
        {
            ProgramSettings settings = SettingProvider.Settings;
            settings.ShownScore = (ShownScoreType)comboBoxScoreType.SelectedIndex;
            settings.ScoreType = (ScoreFormat)comboBoxScoreStyle.SelectedIndex;
            settings.LifeBombType = (LifeBombFormat)comboBoxLifeStyle.SelectedIndex;

            if (settings.LifeBombType != LifeBombFormat.Number)
            {
                settings.ShowEmptyIcon = checkBoxShowEmpty.Checked;
            }

            settings.OnTop = checkBoxOnTop.Checked;
            settings.ShowAllEncodings = radioButtonAllEncoding.Checked;

            settings.OperAfterMove = (FileOperate)comboBoxOperAfterMove.SelectedIndex;
            settings.OperAfterCopy = comboBoxOperAfterCopy.SelectedIndex == 0 ? FileOperate.KeepOrClose : FileOperate.New;
            settings.OperAfterDelete = comboBoxOperAfterDelete.SelectedIndex == 0 ? FileOperate.KeepOrClose : FileOperate.Next;

            settings.Encodings[0].UseEncoding = checkBoxEncode1.Checked;
            settings.Encodings[0].EncodingId = (int)comboBoxEncode1.GetSelectedValue();
            settings.Encodings[1].UseEncoding = checkBoxEncode2.Checked;
            settings.Encodings[1].EncodingId = (int)comboBoxEncode2.GetSelectedValue();
            settings.Encodings[2].UseEncoding = checkBoxEncode3.Checked;
            settings.Encodings[2].EncodingId = (int)comboBoxEncode3.GetSelectedValue();
            settings.Encodings[3].UseEncoding = checkBoxEncode4.Checked;
            settings.Encodings[3].EncodingId = (int)comboBoxEncode4.GetSelectedValue();

            if (settings.Encodings[0].EncodingId == -1 && settings.Encodings[1].EncodingId == -1
                && settings.Encodings[2].EncodingId == -1 && settings.Encodings[3].EncodingId == -1)
            {
                settings.ShowAllEncodings = true;
                radioButtonAllEncoding.Checked = true;
            }

            settings.NormalFont = SystemFont;
            settings.SymbolFont = SymbolFont;

            SettingProvider.SaveSettings();
            try
            {
                settings.RegisterReplayUser = checkBoxRegisterCurrent.Checked;
            }
            catch
            {
                MessageBox.Show(ResourceLoader.GetText("RegistrySetFail"), Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    MessageBox.Show(ResourceLoader.GetText("RegistrySetFail"), Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    checkBoxRegisterAll.Checked = settings.RegisterReplaySystem;
                    buttonApply.Enabled = false;
                }
                else
                {
                    var result = MessageBox.Show(ResourceLoader.GetText("RegistrySetFailAdmin"), Text,
                    MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                    if (result == DialogResult.Yes)
                    {
                        var owner = (FormMain)Owner;
                        string[] arguments = null;
                        if (owner.CurrentReplay != null)
                        {
                            arguments = [owner.CurrentReplay.FilePath];
                        }
                        IsExit = PrivilegeHelper.Promote(arguments);
                        if (!IsExit)
                        {
                            MessageBox.Show(ResourceLoader.GetText("RestartFail"), Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            fontDialogSetting.Font = SystemFont;
            var result = fontDialogSetting.ShowDialog(this);
            if (result == DialogResult.OK)
            {
                buttonApply.Enabled = true;
                SystemFont = fontDialogSetting.Font;
                labelScore.Font = systemFontDemo;
                setLifeBombExample();
            }
        }

        private void buttonFontSymbol_Click(object sender, EventArgs e)
        {
            fontDialogSetting.Font = SymbolFont;
            var result = fontDialogSetting.ShowDialog(this);
            if (result == DialogResult.OK)
            {
                buttonApply.Enabled = true;
                SymbolFont = fontDialogSetting.Font;
                setLifeBombExample();
            }

        }
    }
}
