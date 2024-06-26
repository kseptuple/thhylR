﻿namespace thhylR
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
            comboBoxScoreType = new ComboBox();
            label9 = new Label();
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
            checkBoxEncode4 = new CheckBox();
            checkBoxEncode3 = new CheckBox();
            checkBoxEncode2 = new CheckBox();
            checkBoxEncode1 = new CheckBox();
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
            tabControlMain.Location = new Point(131, 10);
            tabControlMain.Margin = new Padding(2, 3, 2, 3);
            tabControlMain.Name = "tabControlMain";
            tabControlMain.SelectedIndex = 0;
            tabControlMain.Size = new Size(326, 241);
            tabControlMain.SizeMode = TabSizeMode.Fixed;
            tabControlMain.TabIndex = 7;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(comboBoxScoreType);
            tabPage1.Controls.Add(label9);
            tabPage1.Controls.Add(buttonFontSymbol);
            tabPage1.Controls.Add(buttonFontNormal);
            tabPage1.Controls.Add(groupBox1);
            tabPage1.Controls.Add(label2);
            tabPage1.Controls.Add(label1);
            tabPage1.Controls.Add(checkBoxShowEmpty);
            tabPage1.Controls.Add(comboBoxLifeStyle);
            tabPage1.Controls.Add(comboBoxScoreStyle);
            tabPage1.Location = new Point(4, 24);
            tabPage1.Margin = new Padding(2, 3, 2, 3);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(2, 3, 2, 3);
            tabPage1.Size = new Size(318, 213);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "显示格式";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // comboBoxScoreType
            // 
            comboBoxScoreType.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxScoreType.FormattingEnabled = true;
            comboBoxScoreType.Location = new Point(147, 5);
            comboBoxScoreType.Margin = new Padding(2, 3, 2, 3);
            comboBoxScoreType.Name = "comboBoxScoreType";
            comboBoxScoreType.Size = new Size(163, 25);
            comboBoxScoreType.TabIndex = 18;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(5, 8);
            label9.Margin = new Padding(2, 0, 2, 0);
            label9.Name = "label9";
            label9.Size = new Size(92, 17);
            label9.TabIndex = 17;
            label9.Text = "关卡得分显示：";
            // 
            // buttonFontSymbol
            // 
            buttonFontSymbol.Enabled = false;
            buttonFontSymbol.Location = new Point(159, 199);
            buttonFontSymbol.Margin = new Padding(2, 3, 2, 3);
            buttonFontSymbol.Name = "buttonFontSymbol";
            buttonFontSymbol.Size = new Size(150, 25);
            buttonFontSymbol.TabIndex = 16;
            buttonFontSymbol.Text = "符号字体...";
            buttonFontSymbol.UseVisualStyleBackColor = true;
            buttonFontSymbol.Click += buttonFontSymbol_Click;
            // 
            // buttonFontNormal
            // 
            buttonFontNormal.Location = new Point(5, 199);
            buttonFontNormal.Margin = new Padding(2, 3, 2, 3);
            buttonFontNormal.Name = "buttonFontNormal";
            buttonFontNormal.Size = new Size(150, 25);
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
            groupBox1.Location = new Point(5, 117);
            groupBox1.Margin = new Padding(2, 3, 2, 3);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(2, 3, 2, 3);
            groupBox1.Size = new Size(305, 76);
            groupBox1.TabIndex = 14;
            groupBox1.TabStop = false;
            groupBox1.Text = "效果示例";
            // 
            // labelScore
            // 
            labelScore.AutoSize = true;
            labelScore.Location = new Point(65, 20);
            labelScore.Margin = new Padding(2, 0, 2, 0);
            labelScore.Name = "labelScore";
            labelScore.Size = new Size(78, 17);
            labelScore.TabIndex = 17;
            labelScore.Text = "1234567890";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(5, 20);
            label3.Margin = new Padding(2, 0, 2, 0);
            label3.Name = "label3";
            label3.Size = new Size(44, 17);
            label3.TabIndex = 16;
            label3.Text = "得分：";
            // 
            // labelBomb
            // 
            labelBomb.AutoSize = true;
            labelBomb.Font = new Font("Segoe UI Symbol", 9F, FontStyle.Regular, GraphicsUnit.Point);
            labelBomb.Location = new Point(65, 54);
            labelBomb.Margin = new Padding(2, 0, 2, 0);
            labelBomb.Name = "labelBomb";
            labelBomb.Size = new Size(13, 15);
            labelBomb.TabIndex = 15;
            labelBomb.Text = "3";
            // 
            // labelLife
            // 
            labelLife.AutoSize = true;
            labelLife.Location = new Point(65, 37);
            labelLife.Margin = new Padding(2, 0, 2, 0);
            labelLife.Name = "labelLife";
            labelLife.Size = new Size(15, 17);
            labelLife.TabIndex = 14;
            labelLife.Text = "4";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(5, 37);
            label4.Margin = new Padding(2, 0, 2, 0);
            label4.Name = "label4";
            label4.Size = new Size(44, 17);
            label4.TabIndex = 12;
            label4.Text = "残机：";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(5, 54);
            label5.Margin = new Padding(2, 0, 2, 0);
            label5.Name = "label5";
            label5.Size = new Size(44, 17);
            label5.TabIndex = 13;
            label5.Text = "符卡：";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(5, 65);
            label2.Margin = new Padding(2, 0, 2, 0);
            label2.Name = "label2";
            label2.Size = new Size(92, 17);
            label2.TabIndex = 10;
            label2.Text = "残机符卡显示：";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(5, 37);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(68, 17);
            label1.TabIndex = 9;
            label1.Text = "得分显示：";
            // 
            // checkBoxShowEmpty
            // 
            checkBoxShowEmpty.AutoSize = true;
            checkBoxShowEmpty.Enabled = false;
            checkBoxShowEmpty.Location = new Point(7, 92);
            checkBoxShowEmpty.Margin = new Padding(2, 3, 2, 3);
            checkBoxShowEmpty.Name = "checkBoxShowEmpty";
            checkBoxShowEmpty.Size = new Size(166, 21);
            checkBoxShowEmpty.TabIndex = 8;
            checkBoxShowEmpty.Text = "数量小于8时显示空心符号";
            checkBoxShowEmpty.UseVisualStyleBackColor = true;
            checkBoxShowEmpty.CheckedChanged += checkBoxShowEmpty_CheckedChanged;
            // 
            // comboBoxLifeStyle
            // 
            comboBoxLifeStyle.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxLifeStyle.FormattingEnabled = true;
            comboBoxLifeStyle.Location = new Point(147, 63);
            comboBoxLifeStyle.Margin = new Padding(2, 3, 2, 3);
            comboBoxLifeStyle.Name = "comboBoxLifeStyle";
            comboBoxLifeStyle.Size = new Size(163, 25);
            comboBoxLifeStyle.TabIndex = 7;
            comboBoxLifeStyle.SelectedIndexChanged += comboBoxLifeStyle_SelectedIndexChanged;
            // 
            // comboBoxScoreStyle
            // 
            comboBoxScoreStyle.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxScoreStyle.FormattingEnabled = true;
            comboBoxScoreStyle.Location = new Point(147, 34);
            comboBoxScoreStyle.Margin = new Padding(2, 3, 2, 3);
            comboBoxScoreStyle.Name = "comboBoxScoreStyle";
            comboBoxScoreStyle.Size = new Size(163, 25);
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
            tabPage2.Margin = new Padding(2, 3, 2, 3);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(2, 3, 2, 3);
            tabPage2.Size = new Size(318, 213);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "程序";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // comboBoxOperAfterDelete
            // 
            comboBoxOperAfterDelete.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxOperAfterDelete.FormattingEnabled = true;
            comboBoxOperAfterDelete.Location = new Point(132, 83);
            comboBoxOperAfterDelete.Margin = new Padding(2, 3, 2, 3);
            comboBoxOperAfterDelete.Name = "comboBoxOperAfterDelete";
            comboBoxOperAfterDelete.Size = new Size(118, 25);
            comboBoxOperAfterDelete.TabIndex = 10;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(5, 86);
            label8.Margin = new Padding(2, 0, 2, 0);
            label8.Name = "label8";
            label8.Size = new Size(80, 17);
            label8.TabIndex = 9;
            label8.Text = "删除文件后：";
            // 
            // comboBoxOperAfterCopy
            // 
            comboBoxOperAfterCopy.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxOperAfterCopy.FormattingEnabled = true;
            comboBoxOperAfterCopy.Location = new Point(132, 54);
            comboBoxOperAfterCopy.Margin = new Padding(2, 3, 2, 3);
            comboBoxOperAfterCopy.Name = "comboBoxOperAfterCopy";
            comboBoxOperAfterCopy.Size = new Size(118, 25);
            comboBoxOperAfterCopy.TabIndex = 8;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(5, 57);
            label7.Margin = new Padding(2, 0, 2, 0);
            label7.Name = "label7";
            label7.Size = new Size(80, 17);
            label7.TabIndex = 7;
            label7.Text = "复制文件后：";
            // 
            // comboBoxOperAfterMove
            // 
            comboBoxOperAfterMove.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxOperAfterMove.FormattingEnabled = true;
            comboBoxOperAfterMove.Location = new Point(132, 26);
            comboBoxOperAfterMove.Margin = new Padding(2, 3, 2, 3);
            comboBoxOperAfterMove.Name = "comboBoxOperAfterMove";
            comboBoxOperAfterMove.Size = new Size(118, 25);
            comboBoxOperAfterMove.TabIndex = 6;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(5, 28);
            label6.Margin = new Padding(2, 0, 2, 0);
            label6.Name = "label6";
            label6.Size = new Size(80, 17);
            label6.TabIndex = 5;
            label6.Text = "移动文件后：";
            // 
            // checkBoxRegisterAll
            // 
            checkBoxRegisterAll.AutoSize = true;
            checkBoxRegisterAll.Location = new Point(5, 138);
            checkBoxRegisterAll.Margin = new Padding(2, 3, 2, 3);
            checkBoxRegisterAll.Name = "checkBoxRegisterAll";
            checkBoxRegisterAll.Size = new Size(277, 21);
            checkBoxRegisterAll.TabIndex = 4;
            checkBoxRegisterAll.Text = "关联.rpy文件（所有用户）（需要管理员权限）";
            checkBoxRegisterAll.UseVisualStyleBackColor = true;
            // 
            // checkBoxRegisterCurrent
            // 
            checkBoxRegisterCurrent.AutoSize = true;
            checkBoxRegisterCurrent.Location = new Point(5, 112);
            checkBoxRegisterCurrent.Margin = new Padding(2, 3, 2, 3);
            checkBoxRegisterCurrent.Name = "checkBoxRegisterCurrent";
            checkBoxRegisterCurrent.Size = new Size(169, 21);
            checkBoxRegisterCurrent.TabIndex = 3;
            checkBoxRegisterCurrent.Text = "关联.rpy文件（当前用户）";
            checkBoxRegisterCurrent.UseVisualStyleBackColor = true;
            // 
            // checkBoxOnTop
            // 
            checkBoxOnTop.AutoSize = true;
            checkBoxOnTop.Location = new Point(5, 5);
            checkBoxOnTop.Margin = new Padding(2, 3, 2, 3);
            checkBoxOnTop.Name = "checkBoxOnTop";
            checkBoxOnTop.Size = new Size(75, 21);
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
            tabPage3.Margin = new Padding(2, 3, 2, 3);
            tabPage3.Name = "tabPage3";
            tabPage3.Size = new Size(318, 213);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "编码切换";
            tabPage3.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(checkBoxEncode4);
            groupBox2.Controls.Add(checkBoxEncode3);
            groupBox2.Controls.Add(checkBoxEncode2);
            groupBox2.Controls.Add(checkBoxEncode1);
            groupBox2.Controls.Add(comboBoxEncode4);
            groupBox2.Controls.Add(comboBoxEncode3);
            groupBox2.Controls.Add(comboBoxEncode2);
            groupBox2.Controls.Add(comboBoxEncode1);
            groupBox2.Location = new Point(5, 56);
            groupBox2.Margin = new Padding(2, 3, 2, 3);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new Padding(2, 3, 2, 3);
            groupBox2.Size = new Size(315, 147);
            groupBox2.TabIndex = 3;
            groupBox2.TabStop = false;
            groupBox2.Text = "常用编码";
            // 
            // checkBoxEncode4
            // 
            checkBoxEncode4.AutoSize = true;
            checkBoxEncode4.Location = new Point(5, 109);
            checkBoxEncode4.Margin = new Padding(2, 3, 2, 3);
            checkBoxEncode4.Name = "checkBoxEncode4";
            checkBoxEncode4.Size = new Size(124, 21);
            checkBoxEncode4.TabIndex = 8;
            checkBoxEncode4.Text = "启用快捷键（F4）";
            checkBoxEncode4.UseVisualStyleBackColor = true;
            // 
            // checkBoxEncode3
            // 
            checkBoxEncode3.AutoSize = true;
            checkBoxEncode3.Location = new Point(5, 80);
            checkBoxEncode3.Margin = new Padding(2, 3, 2, 3);
            checkBoxEncode3.Name = "checkBoxEncode3";
            checkBoxEncode3.Size = new Size(124, 21);
            checkBoxEncode3.TabIndex = 7;
            checkBoxEncode3.Text = "启用快捷键（F3）";
            checkBoxEncode3.UseVisualStyleBackColor = true;
            // 
            // checkBoxEncode2
            // 
            checkBoxEncode2.AutoSize = true;
            checkBoxEncode2.Location = new Point(5, 51);
            checkBoxEncode2.Margin = new Padding(2, 3, 2, 3);
            checkBoxEncode2.Name = "checkBoxEncode2";
            checkBoxEncode2.Size = new Size(124, 21);
            checkBoxEncode2.TabIndex = 6;
            checkBoxEncode2.Text = "启用快捷键（F2）";
            checkBoxEncode2.UseVisualStyleBackColor = true;
            // 
            // checkBoxEncode1
            // 
            checkBoxEncode1.AutoSize = true;
            checkBoxEncode1.Location = new Point(5, 22);
            checkBoxEncode1.Margin = new Padding(2, 3, 2, 3);
            checkBoxEncode1.Name = "checkBoxEncode1";
            checkBoxEncode1.Size = new Size(124, 21);
            checkBoxEncode1.TabIndex = 5;
            checkBoxEncode1.Text = "启用快捷键（F1）";
            checkBoxEncode1.UseVisualStyleBackColor = true;
            // 
            // comboBoxEncode4
            // 
            comboBoxEncode4.DisplayMember = "Name";
            comboBoxEncode4.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxEncode4.FormattingEnabled = true;
            comboBoxEncode4.Location = new Point(157, 107);
            comboBoxEncode4.Margin = new Padding(2, 3, 2, 3);
            comboBoxEncode4.Name = "comboBoxEncode4";
            comboBoxEncode4.Size = new Size(156, 25);
            comboBoxEncode4.TabIndex = 3;
            comboBoxEncode4.ValueMember = "CodePage";
            // 
            // comboBoxEncode3
            // 
            comboBoxEncode3.DisplayMember = "Name";
            comboBoxEncode3.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxEncode3.FormattingEnabled = true;
            comboBoxEncode3.Location = new Point(157, 78);
            comboBoxEncode3.Margin = new Padding(2, 3, 2, 3);
            comboBoxEncode3.Name = "comboBoxEncode3";
            comboBoxEncode3.Size = new Size(156, 25);
            comboBoxEncode3.TabIndex = 2;
            comboBoxEncode3.ValueMember = "CodePage";
            // 
            // comboBoxEncode2
            // 
            comboBoxEncode2.DisplayMember = "Name";
            comboBoxEncode2.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxEncode2.FormattingEnabled = true;
            comboBoxEncode2.Location = new Point(157, 49);
            comboBoxEncode2.Margin = new Padding(2, 3, 2, 3);
            comboBoxEncode2.Name = "comboBoxEncode2";
            comboBoxEncode2.Size = new Size(156, 25);
            comboBoxEncode2.TabIndex = 1;
            comboBoxEncode2.ValueMember = "CodePage";
            // 
            // comboBoxEncode1
            // 
            comboBoxEncode1.DisplayMember = "Name";
            comboBoxEncode1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxEncode1.FormattingEnabled = true;
            comboBoxEncode1.Location = new Point(157, 20);
            comboBoxEncode1.Margin = new Padding(2, 3, 2, 3);
            comboBoxEncode1.Name = "comboBoxEncode1";
            comboBoxEncode1.Size = new Size(156, 25);
            comboBoxEncode1.TabIndex = 0;
            comboBoxEncode1.ValueMember = "CodePage";
            // 
            // radioButtonCommonEncoding
            // 
            radioButtonCommonEncoding.AutoSize = true;
            radioButtonCommonEncoding.Location = new Point(5, 31);
            radioButtonCommonEncoding.Margin = new Padding(2, 3, 2, 3);
            radioButtonCommonEncoding.Name = "radioButtonCommonEncoding";
            radioButtonCommonEncoding.Size = new Size(146, 21);
            radioButtonCommonEncoding.TabIndex = 2;
            radioButtonCommonEncoding.Text = "主界面只显示常用编码";
            radioButtonCommonEncoding.UseVisualStyleBackColor = true;
            // 
            // radioButtonAllEncoding
            // 
            radioButtonAllEncoding.AutoSize = true;
            radioButtonAllEncoding.Checked = true;
            radioButtonAllEncoding.Location = new Point(5, 5);
            radioButtonAllEncoding.Margin = new Padding(2, 3, 2, 3);
            radioButtonAllEncoding.Name = "radioButtonAllEncoding";
            radioButtonAllEncoding.Size = new Size(134, 21);
            radioButtonAllEncoding.TabIndex = 1;
            radioButtonAllEncoding.TabStop = true;
            radioButtonAllEncoding.Text = "主界面显示全部编码";
            radioButtonAllEncoding.UseVisualStyleBackColor = true;
            // 
            // listBoxTabs
            // 
            listBoxTabs.FormattingEnabled = true;
            listBoxTabs.IntegralHeight = false;
            listBoxTabs.ItemHeight = 17;
            listBoxTabs.Location = new Point(9, 10);
            listBoxTabs.Margin = new Padding(2, 3, 2, 3);
            listBoxTabs.Name = "listBoxTabs";
            listBoxTabs.Size = new Size(118, 237);
            listBoxTabs.TabIndex = 8;
            listBoxTabs.SelectedIndexChanged += listBoxTabs_SelectedIndexChanged;
            // 
            // buttonOK
            // 
            buttonOK.Location = new Point(226, 253);
            buttonOK.Margin = new Padding(2, 3, 2, 3);
            buttonOK.Name = "buttonOK";
            buttonOK.Size = new Size(73, 25);
            buttonOK.TabIndex = 9;
            buttonOK.Text = "确定";
            buttonOK.UseVisualStyleBackColor = true;
            buttonOK.Click += buttonOK_Click;
            // 
            // buttonCancel
            // 
            buttonCancel.Location = new Point(303, 253);
            buttonCancel.Margin = new Padding(2, 3, 2, 3);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(73, 25);
            buttonCancel.TabIndex = 10;
            buttonCancel.Text = "取消";
            buttonCancel.UseVisualStyleBackColor = true;
            buttonCancel.Click += buttonCancel_Click;
            // 
            // buttonApply
            // 
            buttonApply.Enabled = false;
            buttonApply.Location = new Point(380, 253);
            buttonApply.Margin = new Padding(2, 3, 2, 3);
            buttonApply.Name = "buttonApply";
            buttonApply.Size = new Size(73, 25);
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
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(463, 284);
            Controls.Add(buttonApply);
            Controls.Add(buttonCancel);
            Controls.Add(buttonOK);
            Controls.Add(listBoxTabs);
            Controls.Add(tabControlMain);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(2, 3, 2, 3);
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
        private CheckBox checkBoxEncode4;
        private CheckBox checkBoxEncode3;
        private CheckBox checkBoxEncode2;
        private CheckBox checkBoxEncode1;
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
        private ComboBox comboBoxScoreType;
        private Label label9;
    }
}