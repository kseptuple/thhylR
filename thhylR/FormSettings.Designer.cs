namespace thhylR
{
    partial class FormSettings
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            tabControlMain = new TabControl();
            tabPage1 = new TabPage();
            buttonFontSymbol = new Button();
            buttonFontNormal = new Button();
            groupBox1 = new GroupBox();
            labelScore = new Label();
            label3 = new Label();
            labelBomb = new Label();
            labelLife = new Label();
            label4 = new Label();
            label5 = new Label();
            label2 = new Label();
            label1 = new Label();
            checkBoxShowEmpty = new CheckBox();
            comboBoxLifeStyle = new ComboBox();
            comboBoxScoreStyle = new ComboBox();
            tabPage2 = new TabPage();
            comboBoxOperAfterDelete = new ComboBox();
            label8 = new Label();
            comboBoxOperAfterCopy = new ComboBox();
            label7 = new Label();
            comboBoxOperAfterMove = new ComboBox();
            label6 = new Label();
            checkBoxRegisterAll = new CheckBox();
            checkBoxRegisterCurrent = new CheckBox();
            checkBoxOnTop = new CheckBox();
            tabPage3 = new TabPage();
            groupBox2 = new GroupBox();
            checkBoxEncode5 = new CheckBox();
            checkBoxEncode4 = new CheckBox();
            checkBoxEncode3 = new CheckBox();
            checkBoxEncode2 = new CheckBox();
            checkBoxEncode1 = new CheckBox();
            comboBoxEncode5 = new ComboBox();
            comboBoxEncode4 = new ComboBox();
            comboBoxEncode3 = new ComboBox();
            comboBoxEncode2 = new ComboBox();
            comboBoxEncode1 = new ComboBox();
            radioButtonCommonEncoding = new RadioButton();
            radioButtonAllEncoding = new RadioButton();
            listBoxTabs = new ListBox();
            buttonOK = new Button();
            buttonCancel = new Button();
            buttonApply = new Button();
            fontDialogSetting = new FontDialog();
            tabControlMain.SuspendLayout();
            tabPage1.SuspendLayout();
            groupBox1.SuspendLayout();
            tabPage2.SuspendLayout();
            tabPage3.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // tabControlMain
            // 
            tabControlMain.Appearance = TabAppearance.FlatButtons;
            tabControlMain.Controls.Add(tabPage1);
            tabControlMain.Controls.Add(tabPage2);
            tabControlMain.Controls.Add(tabPage3);
            tabControlMain.ItemSize = new Size(40, 20);
            tabControlMain.Location = new Point(168, 12);
            tabControlMain.Name = "tabControlMain";
            tabControlMain.SelectedIndex = 0;
            tabControlMain.Size = new Size(419, 274);
            tabControlMain.SizeMode = TabSizeMode.Fixed;
            tabControlMain.TabIndex = 7;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(buttonFontSymbol);
            tabPage1.Controls.Add(buttonFontNormal);
            tabPage1.Controls.Add(groupBox1);
            tabPage1.Controls.Add(label2);
            tabPage1.Controls.Add(label1);
            tabPage1.Controls.Add(checkBoxShowEmpty);
            tabPage1.Controls.Add(comboBoxLifeStyle);
            tabPage1.Controls.Add(comboBoxScoreStyle);
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(411, 246);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "显示格式";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // buttonFontSymbol
            // 
            buttonFontSymbol.Enabled = false;
            buttonFontSymbol.Location = new Point(208, 203);
            buttonFontSymbol.Name = "buttonFontSymbol";
            buttonFontSymbol.Size = new Size(193, 29);
            buttonFontSymbol.TabIndex = 16;
            buttonFontSymbol.Text = "符号字体...";
            buttonFontSymbol.UseVisualStyleBackColor = true;
            buttonFontSymbol.Click += buttonFontSymbol_Click;
            // 
            // buttonFontNormal
            // 
            buttonFontNormal.Location = new Point(9, 203);
            buttonFontNormal.Name = "buttonFontNormal";
            buttonFontNormal.Size = new Size(193, 29);
            buttonFontNormal.TabIndex = 15;
            buttonFontNormal.Text = "字体...";
            buttonFontNormal.UseVisualStyleBackColor = true;
            buttonFontNormal.Click += buttonFontNormal_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(labelScore);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(labelBomb);
            groupBox1.Controls.Add(labelLife);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label5);
            groupBox1.Location = new Point(9, 107);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(392, 90);
            groupBox1.TabIndex = 14;
            groupBox1.TabStop = false;
            groupBox1.Text = "效果示例";
            // 
            // labelScore
            // 
            labelScore.AutoSize = true;
            labelScore.Location = new Point(84, 23);
            labelScore.Name = "labelScore";
            labelScore.Size = new Size(99, 20);
            labelScore.TabIndex = 17;
            labelScore.Text = "1234567890";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(6, 23);
            label3.Name = "label3";
            label3.Size = new Size(54, 20);
            label3.TabIndex = 16;
            label3.Text = "得分：";
            // 
            // labelBomb
            // 
            labelBomb.AutoSize = true;
            labelBomb.Font = new Font("Segoe UI Symbol", 9F, FontStyle.Regular, GraphicsUnit.Point);
            labelBomb.Location = new Point(84, 63);
            labelBomb.Name = "labelBomb";
            labelBomb.Size = new Size(17, 20);
            labelBomb.TabIndex = 15;
            labelBomb.Text = "3";
            // 
            // labelLife
            // 
            labelLife.AutoSize = true;
            labelLife.Location = new Point(84, 43);
            labelLife.Name = "labelLife";
            labelLife.Size = new Size(18, 20);
            labelLife.TabIndex = 14;
            labelLife.Text = "4";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(6, 43);
            label4.Name = "label4";
            label4.Size = new Size(54, 20);
            label4.TabIndex = 12;
            label4.Text = "残机：";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(6, 63);
            label5.Name = "label5";
            label5.Size = new Size(54, 20);
            label5.TabIndex = 13;
            label5.Text = "符卡：";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(9, 46);
            label2.Name = "label2";
            label2.Size = new Size(114, 20);
            label2.TabIndex = 10;
            label2.Text = "残机符卡显示：";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(9, 12);
            label1.Name = "label1";
            label1.Size = new Size(84, 20);
            label1.TabIndex = 9;
            label1.Text = "得分显示：";
            // 
            // checkBoxShowEmpty
            // 
            checkBoxShowEmpty.AutoSize = true;
            checkBoxShowEmpty.Enabled = false;
            checkBoxShowEmpty.Location = new Point(12, 77);
            checkBoxShowEmpty.Name = "checkBoxShowEmpty";
            checkBoxShowEmpty.Size = new Size(205, 24);
            checkBoxShowEmpty.TabIndex = 8;
            checkBoxShowEmpty.Text = "数量小于8时显示空心符号";
            checkBoxShowEmpty.UseVisualStyleBackColor = true;
            checkBoxShowEmpty.CheckedChanged += checkBoxShowEmpty_CheckedChanged;
            // 
            // comboBoxLifeStyle
            // 
            comboBoxLifeStyle.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxLifeStyle.FormattingEnabled = true;
            comboBoxLifeStyle.Location = new Point(192, 43);
            comboBoxLifeStyle.Name = "comboBoxLifeStyle";
            comboBoxLifeStyle.Size = new Size(209, 28);
            comboBoxLifeStyle.TabIndex = 7;
            comboBoxLifeStyle.SelectedIndexChanged += comboBoxLifeStyle_SelectedIndexChanged;
            // 
            // comboBoxScoreStyle
            // 
            comboBoxScoreStyle.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxScoreStyle.FormattingEnabled = true;
            comboBoxScoreStyle.Location = new Point(192, 9);
            comboBoxScoreStyle.Name = "comboBoxScoreStyle";
            comboBoxScoreStyle.Size = new Size(209, 28);
            comboBoxScoreStyle.TabIndex = 6;
            comboBoxScoreStyle.SelectedIndexChanged += comboBoxScoreStyle_SelectedIndexChanged;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(comboBoxOperAfterDelete);
            tabPage2.Controls.Add(label8);
            tabPage2.Controls.Add(comboBoxOperAfterCopy);
            tabPage2.Controls.Add(label7);
            tabPage2.Controls.Add(comboBoxOperAfterMove);
            tabPage2.Controls.Add(label6);
            tabPage2.Controls.Add(checkBoxRegisterAll);
            tabPage2.Controls.Add(checkBoxRegisterCurrent);
            tabPage2.Controls.Add(checkBoxOnTop);
            tabPage2.Location = new Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(411, 246);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "程序";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // comboBoxOperAfterDelete
            // 
            comboBoxOperAfterDelete.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxOperAfterDelete.FormattingEnabled = true;
            comboBoxOperAfterDelete.Location = new Point(170, 98);
            comboBoxOperAfterDelete.Name = "comboBoxOperAfterDelete";
            comboBoxOperAfterDelete.Size = new Size(151, 28);
            comboBoxOperAfterDelete.TabIndex = 10;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(6, 101);
            label8.Name = "label8";
            label8.Size = new Size(99, 20);
            label8.TabIndex = 9;
            label8.Text = "删除文件后：";
            // 
            // comboBoxOperAfterCopy
            // 
            comboBoxOperAfterCopy.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxOperAfterCopy.FormattingEnabled = true;
            comboBoxOperAfterCopy.Location = new Point(170, 64);
            comboBoxOperAfterCopy.Name = "comboBoxOperAfterCopy";
            comboBoxOperAfterCopy.Size = new Size(151, 28);
            comboBoxOperAfterCopy.TabIndex = 8;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(6, 67);
            label7.Name = "label7";
            label7.Size = new Size(99, 20);
            label7.TabIndex = 7;
            label7.Text = "复制文件后：";
            // 
            // comboBoxOperAfterMove
            // 
            comboBoxOperAfterMove.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxOperAfterMove.FormattingEnabled = true;
            comboBoxOperAfterMove.Location = new Point(170, 30);
            comboBoxOperAfterMove.Name = "comboBoxOperAfterMove";
            comboBoxOperAfterMove.Size = new Size(151, 28);
            comboBoxOperAfterMove.TabIndex = 6;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(6, 33);
            label6.Name = "label6";
            label6.Size = new Size(99, 20);
            label6.TabIndex = 5;
            label6.Text = "移动文件后：";
            // 
            // checkBoxRegisterAll
            // 
            checkBoxRegisterAll.AutoSize = true;
            checkBoxRegisterAll.Location = new Point(6, 162);
            checkBoxRegisterAll.Name = "checkBoxRegisterAll";
            checkBoxRegisterAll.Size = new Size(344, 24);
            checkBoxRegisterAll.TabIndex = 4;
            checkBoxRegisterAll.Text = "关联.rpy文件（所有用户）（需要管理员权限）";
            checkBoxRegisterAll.UseVisualStyleBackColor = true;
            // 
            // checkBoxRegisterCurrent
            // 
            checkBoxRegisterCurrent.AutoSize = true;
            checkBoxRegisterCurrent.Location = new Point(6, 132);
            checkBoxRegisterCurrent.Name = "checkBoxRegisterCurrent";
            checkBoxRegisterCurrent.Size = new Size(209, 24);
            checkBoxRegisterCurrent.TabIndex = 3;
            checkBoxRegisterCurrent.Text = "关联.rpy文件（当前用户）";
            checkBoxRegisterCurrent.UseVisualStyleBackColor = true;
            // 
            // checkBoxOnTop
            // 
            checkBoxOnTop.AutoSize = true;
            checkBoxOnTop.Location = new Point(6, 6);
            checkBoxOnTop.Name = "checkBoxOnTop";
            checkBoxOnTop.Size = new Size(91, 24);
            checkBoxOnTop.TabIndex = 1;
            checkBoxOnTop.Text = "窗口置顶";
            checkBoxOnTop.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            tabPage3.Controls.Add(groupBox2);
            tabPage3.Controls.Add(radioButtonCommonEncoding);
            tabPage3.Controls.Add(radioButtonAllEncoding);
            tabPage3.Location = new Point(4, 24);
            tabPage3.Name = "tabPage3";
            tabPage3.Size = new Size(411, 246);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "编码切换";
            tabPage3.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(checkBoxEncode5);
            groupBox2.Controls.Add(checkBoxEncode4);
            groupBox2.Controls.Add(checkBoxEncode3);
            groupBox2.Controls.Add(checkBoxEncode2);
            groupBox2.Controls.Add(checkBoxEncode1);
            groupBox2.Controls.Add(comboBoxEncode5);
            groupBox2.Controls.Add(comboBoxEncode4);
            groupBox2.Controls.Add(comboBoxEncode3);
            groupBox2.Controls.Add(comboBoxEncode2);
            groupBox2.Controls.Add(comboBoxEncode1);
            groupBox2.Location = new Point(6, 66);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(534, 193);
            groupBox2.TabIndex = 3;
            groupBox2.TabStop = false;
            groupBox2.Text = "常用编码";
            // 
            // checkBoxEncode5
            // 
            checkBoxEncode5.AutoSize = true;
            checkBoxEncode5.Location = new Point(6, 160);
            checkBoxEncode5.Name = "checkBoxEncode5";
            checkBoxEncode5.Size = new Size(153, 24);
            checkBoxEncode5.TabIndex = 9;
            checkBoxEncode5.Text = "启用快捷键（F5）";
            checkBoxEncode5.UseVisualStyleBackColor = true;
            checkBoxEncode5.CheckedChanged += checkBoxEncode5_CheckedChanged;
            // 
            // checkBoxEncode4
            // 
            checkBoxEncode4.AutoSize = true;
            checkBoxEncode4.Location = new Point(6, 128);
            checkBoxEncode4.Name = "checkBoxEncode4";
            checkBoxEncode4.Size = new Size(153, 24);
            checkBoxEncode4.TabIndex = 8;
            checkBoxEncode4.Text = "启用快捷键（F4）";
            checkBoxEncode4.UseVisualStyleBackColor = true;
            checkBoxEncode4.CheckedChanged += checkBoxEncode4_CheckedChanged;
            // 
            // checkBoxEncode3
            // 
            checkBoxEncode3.AutoSize = true;
            checkBoxEncode3.Location = new Point(6, 94);
            checkBoxEncode3.Name = "checkBoxEncode3";
            checkBoxEncode3.Size = new Size(153, 24);
            checkBoxEncode3.TabIndex = 7;
            checkBoxEncode3.Text = "启用快捷键（F3）";
            checkBoxEncode3.UseVisualStyleBackColor = true;
            checkBoxEncode3.CheckedChanged += checkBoxEncode3_CheckedChanged;
            // 
            // checkBoxEncode2
            // 
            checkBoxEncode2.AutoSize = true;
            checkBoxEncode2.Location = new Point(6, 60);
            checkBoxEncode2.Name = "checkBoxEncode2";
            checkBoxEncode2.Size = new Size(153, 24);
            checkBoxEncode2.TabIndex = 6;
            checkBoxEncode2.Text = "启用快捷键（F2）";
            checkBoxEncode2.UseVisualStyleBackColor = true;
            checkBoxEncode2.CheckedChanged += checkBoxEncode2_CheckedChanged;
            // 
            // checkBoxEncode1
            // 
            checkBoxEncode1.AutoSize = true;
            checkBoxEncode1.Checked = true;
            checkBoxEncode1.CheckState = CheckState.Checked;
            checkBoxEncode1.Enabled = false;
            checkBoxEncode1.Location = new Point(6, 26);
            checkBoxEncode1.Name = "checkBoxEncode1";
            checkBoxEncode1.Size = new Size(153, 24);
            checkBoxEncode1.TabIndex = 5;
            checkBoxEncode1.Text = "启用快捷键（F1）";
            checkBoxEncode1.UseVisualStyleBackColor = true;
            // 
            // comboBoxEncode5
            // 
            comboBoxEncode5.DisplayMember = "Name";
            comboBoxEncode5.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxEncode5.FormattingEnabled = true;
            comboBoxEncode5.Location = new Point(202, 158);
            comboBoxEncode5.Name = "comboBoxEncode5";
            comboBoxEncode5.Size = new Size(200, 28);
            comboBoxEncode5.TabIndex = 4;
            comboBoxEncode5.ValueMember = "CodePage";
            // 
            // comboBoxEncode4
            // 
            comboBoxEncode4.DisplayMember = "Name";
            comboBoxEncode4.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxEncode4.FormattingEnabled = true;
            comboBoxEncode4.Location = new Point(202, 126);
            comboBoxEncode4.Name = "comboBoxEncode4";
            comboBoxEncode4.Size = new Size(200, 28);
            comboBoxEncode4.TabIndex = 3;
            comboBoxEncode4.ValueMember = "CodePage";
            // 
            // comboBoxEncode3
            // 
            comboBoxEncode3.DisplayMember = "Name";
            comboBoxEncode3.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxEncode3.FormattingEnabled = true;
            comboBoxEncode3.Location = new Point(202, 92);
            comboBoxEncode3.Name = "comboBoxEncode3";
            comboBoxEncode3.Size = new Size(200, 28);
            comboBoxEncode3.TabIndex = 2;
            comboBoxEncode3.ValueMember = "CodePage";
            // 
            // comboBoxEncode2
            // 
            comboBoxEncode2.DisplayMember = "Name";
            comboBoxEncode2.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxEncode2.FormattingEnabled = true;
            comboBoxEncode2.Location = new Point(202, 58);
            comboBoxEncode2.Name = "comboBoxEncode2";
            comboBoxEncode2.Size = new Size(200, 28);
            comboBoxEncode2.TabIndex = 1;
            comboBoxEncode2.ValueMember = "CodePage";
            // 
            // comboBoxEncode1
            // 
            comboBoxEncode1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxEncode1.Enabled = false;
            comboBoxEncode1.FormattingEnabled = true;
            comboBoxEncode1.Items.AddRange(new object[] { "自动选择" });
            comboBoxEncode1.Location = new Point(202, 24);
            comboBoxEncode1.Name = "comboBoxEncode1";
            comboBoxEncode1.Size = new Size(200, 28);
            comboBoxEncode1.TabIndex = 0;
            // 
            // radioButtonCommonEncoding
            // 
            radioButtonCommonEncoding.AutoSize = true;
            radioButtonCommonEncoding.Location = new Point(6, 36);
            radioButtonCommonEncoding.Name = "radioButtonCommonEncoding";
            radioButtonCommonEncoding.Size = new Size(180, 24);
            radioButtonCommonEncoding.TabIndex = 2;
            radioButtonCommonEncoding.Text = "主界面只显示常用编码";
            radioButtonCommonEncoding.UseVisualStyleBackColor = true;
            // 
            // radioButtonAllEncoding
            // 
            radioButtonAllEncoding.AutoSize = true;
            radioButtonAllEncoding.Checked = true;
            radioButtonAllEncoding.Location = new Point(6, 6);
            radioButtonAllEncoding.Name = "radioButtonAllEncoding";
            radioButtonAllEncoding.Size = new Size(165, 24);
            radioButtonAllEncoding.TabIndex = 1;
            radioButtonAllEncoding.TabStop = true;
            radioButtonAllEncoding.Text = "主界面显示全部编码";
            radioButtonAllEncoding.UseVisualStyleBackColor = true;
            // 
            // listBoxTabs
            // 
            listBoxTabs.FormattingEnabled = true;
            listBoxTabs.ItemHeight = 20;
            listBoxTabs.Location = new Point(12, 12);
            listBoxTabs.Name = "listBoxTabs";
            listBoxTabs.Size = new Size(150, 264);
            listBoxTabs.TabIndex = 8;
            listBoxTabs.SelectedIndexChanged += listBoxTabs_SelectedIndexChanged;
            // 
            // buttonOK
            // 
            buttonOK.Location = new Point(289, 288);
            buttonOK.Name = "buttonOK";
            buttonOK.Size = new Size(94, 29);
            buttonOK.TabIndex = 9;
            buttonOK.Text = "确定";
            buttonOK.UseVisualStyleBackColor = true;
            buttonOK.Click += buttonOK_Click;
            // 
            // buttonCancel
            // 
            buttonCancel.Location = new Point(389, 288);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(94, 29);
            buttonCancel.TabIndex = 10;
            buttonCancel.Text = "取消";
            buttonCancel.UseVisualStyleBackColor = true;
            buttonCancel.Click += buttonCancel_Click;
            // 
            // buttonApply
            // 
            buttonApply.Enabled = false;
            buttonApply.Location = new Point(489, 288);
            buttonApply.Name = "buttonApply";
            buttonApply.Size = new Size(94, 29);
            buttonApply.TabIndex = 11;
            buttonApply.Text = "应用";
            buttonApply.UseVisualStyleBackColor = true;
            buttonApply.Click += buttonApply_Click;
            // 
            // fontDialogSetting
            // 
            fontDialogSetting.AllowVerticalFonts = false;
            fontDialogSetting.FontMustExist = true;
            fontDialogSetting.ShowEffects = false;
            // 
            // FormSettings
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(595, 324);
            Controls.Add(buttonApply);
            Controls.Add(buttonCancel);
            Controls.Add(buttonOK);
            Controls.Add(listBoxTabs);
            Controls.Add(tabControlMain);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormSettings";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "设置";
            Load += FormSettings_Load;
            tabControlMain.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
            tabPage3.ResumeLayout(false);
            tabPage3.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControlMain;
        private TabPage tabPage1;
        private GroupBox groupBox1;
        private Label labelBomb;
        private Label labelLife;
        private Label label4;
        private Label label5;
        private Label label2;
        private Label label1;
        private CheckBox checkBoxShowEmpty;
        private ComboBox comboBoxLifeStyle;
        private ComboBox comboBoxScoreStyle;
        private TabPage tabPage2;
        private ListBox listBoxTabs;
        private TabPage tabPage3;
        private CheckBox checkBoxOnTop;
        private GroupBox groupBox2;
        private ComboBox comboBoxEncode4;
        private ComboBox comboBoxEncode3;
        private ComboBox comboBoxEncode2;
        private ComboBox comboBoxEncode1;
        private RadioButton radioButtonCommonEncoding;
        private RadioButton radioButtonAllEncoding;
        private CheckBox checkBoxEncode5;
        private CheckBox checkBoxEncode4;
        private CheckBox checkBoxEncode3;
        private CheckBox checkBoxEncode2;
        private CheckBox checkBoxEncode1;
        private ComboBox comboBoxEncode5;
        private CheckBox checkBoxRegisterAll;
        private CheckBox checkBoxRegisterCurrent;
        private Button buttonOK;
        private Button buttonCancel;
        private Button buttonApply;
        private FontDialog fontDialogSetting;
        private Button buttonFontSymbol;
        private Button buttonFontNormal;
        private Label label3;
        private Label labelScore;
        private ComboBox comboBoxOperAfterDelete;
        private Label label8;
        private ComboBox comboBoxOperAfterCopy;
        private Label label7;
        private ComboBox comboBoxOperAfterMove;
        private Label label6;
    }
}