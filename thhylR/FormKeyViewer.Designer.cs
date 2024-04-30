namespace thhylR
{
    partial class FormKeyViewer
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
            dataGridViewKeys = new DataGridView();
            labelKeyDescription = new Label();
            label1 = new Label();
            buttonClose = new Button();
            buttonExport = new Button();
            panelStages = new Panel();
            listBoxStages = new ListBox();
            groupBoxStat = new GroupBox();
            textBoxAverage = new TextBox();
            label6 = new Label();
            label5 = new Label();
            textBox3Frame = new TextBox();
            textBox2Frame = new TextBox();
            label4 = new Label();
            label3 = new Label();
            textBox1Frame = new TextBox();
            textBoxFrame = new TextBox();
            label2 = new Label();
            labelExplain = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridViewKeys).BeginInit();
            panelStages.SuspendLayout();
            groupBoxStat.SuspendLayout();
            SuspendLayout();
            // 
            // dataGridViewKeys
            // 
            dataGridViewKeys.AllowUserToAddRows = false;
            dataGridViewKeys.AllowUserToDeleteRows = false;
            dataGridViewKeys.AllowUserToResizeRows = false;
            dataGridViewKeys.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridViewKeys.BackgroundColor = SystemColors.Control;
            dataGridViewKeys.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewKeys.EditMode = DataGridViewEditMode.EditProgrammatically;
            dataGridViewKeys.Location = new Point(168, 9);
            dataGridViewKeys.MultiSelect = false;
            dataGridViewKeys.Name = "dataGridViewKeys";
            dataGridViewKeys.ReadOnly = true;
            dataGridViewKeys.RowHeadersVisible = false;
            dataGridViewKeys.RowHeadersWidth = 51;
            dataGridViewKeys.RowTemplate.Height = 29;
            dataGridViewKeys.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewKeys.ShowCellToolTips = false;
            dataGridViewKeys.Size = new Size(542, 517);
            dataGridViewKeys.TabIndex = 0;
            dataGridViewKeys.VirtualMode = true;
            dataGridViewKeys.CellValueNeeded += dataGridViewKeys_CellValueNeeded;
            // 
            // labelKeyDescription
            // 
            labelKeyDescription.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            labelKeyDescription.Location = new Point(716, 12);
            labelKeyDescription.Name = "labelKeyDescription";
            labelKeyDescription.Size = new Size(269, 172);
            labelKeyDescription.TabIndex = 2;
            labelKeyDescription.Text = "label1";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(53, 20);
            label1.TabIndex = 3;
            label1.Text = "label1";
            // 
            // buttonClose
            // 
            buttonClose.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonClose.Location = new Point(891, 532);
            buttonClose.Name = "buttonClose";
            buttonClose.Size = new Size(94, 29);
            buttonClose.TabIndex = 4;
            buttonClose.Text = "button1";
            buttonClose.UseVisualStyleBackColor = true;
            buttonClose.Click += buttonClose_Click;
            // 
            // buttonExport
            // 
            buttonExport.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonExport.Location = new Point(791, 532);
            buttonExport.Name = "buttonExport";
            buttonExport.Size = new Size(94, 29);
            buttonExport.TabIndex = 5;
            buttonExport.Text = "button1";
            buttonExport.UseVisualStyleBackColor = true;
            // 
            // panelStages
            // 
            panelStages.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            panelStages.Controls.Add(listBoxStages);
            panelStages.Location = new Point(12, 32);
            panelStages.Name = "panelStages";
            panelStages.Size = new Size(150, 494);
            panelStages.TabIndex = 6;
            // 
            // listBoxStages
            // 
            listBoxStages.Dock = DockStyle.Fill;
            listBoxStages.FormattingEnabled = true;
            listBoxStages.ItemHeight = 20;
            listBoxStages.Location = new Point(0, 0);
            listBoxStages.Name = "listBoxStages";
            listBoxStages.Size = new Size(150, 494);
            listBoxStages.TabIndex = 2;
            listBoxStages.SelectedIndexChanged += listBoxStages_SelectedIndexChanged;
            // 
            // groupBoxStat
            // 
            groupBoxStat.Controls.Add(labelExplain);
            groupBoxStat.Controls.Add(textBoxAverage);
            groupBoxStat.Controls.Add(label6);
            groupBoxStat.Controls.Add(label5);
            groupBoxStat.Controls.Add(textBox3Frame);
            groupBoxStat.Controls.Add(textBox2Frame);
            groupBoxStat.Controls.Add(label4);
            groupBoxStat.Controls.Add(label3);
            groupBoxStat.Controls.Add(textBox1Frame);
            groupBoxStat.Controls.Add(textBoxFrame);
            groupBoxStat.Controls.Add(label2);
            groupBoxStat.Location = new Point(716, 259);
            groupBoxStat.Name = "groupBoxStat";
            groupBoxStat.Size = new Size(269, 267);
            groupBoxStat.TabIndex = 9;
            groupBoxStat.TabStop = false;
            groupBoxStat.Text = "groupBox1";
            // 
            // textBoxAverage
            // 
            textBoxAverage.Location = new Point(159, 158);
            textBoxAverage.Name = "textBoxAverage";
            textBoxAverage.ReadOnly = true;
            textBoxAverage.Size = new Size(104, 27);
            textBoxAverage.TabIndex = 27;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(6, 161);
            label6.Name = "label6";
            label6.Size = new Size(97, 20);
            label6.TabIndex = 26;
            label6.Text = "Avg. Length";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(6, 128);
            label5.Name = "label5";
            label5.Size = new Size(53, 20);
            label5.TabIndex = 25;
            label5.Text = "label5";
            // 
            // textBox3Frame
            // 
            textBox3Frame.Location = new Point(159, 125);
            textBox3Frame.Name = "textBox3Frame";
            textBox3Frame.ReadOnly = true;
            textBox3Frame.Size = new Size(104, 27);
            textBox3Frame.TabIndex = 24;
            // 
            // textBox2Frame
            // 
            textBox2Frame.Location = new Point(159, 92);
            textBox2Frame.Name = "textBox2Frame";
            textBox2Frame.ReadOnly = true;
            textBox2Frame.Size = new Size(104, 27);
            textBox2Frame.TabIndex = 23;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(6, 95);
            label4.Name = "label4";
            label4.Size = new Size(53, 20);
            label4.TabIndex = 22;
            label4.Text = "label4";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(6, 62);
            label3.Name = "label3";
            label3.Size = new Size(53, 20);
            label3.TabIndex = 21;
            label3.Text = "label3";
            // 
            // textBox1Frame
            // 
            textBox1Frame.Location = new Point(159, 59);
            textBox1Frame.Name = "textBox1Frame";
            textBox1Frame.ReadOnly = true;
            textBox1Frame.Size = new Size(104, 27);
            textBox1Frame.TabIndex = 20;
            // 
            // textBoxFrame
            // 
            textBoxFrame.Location = new Point(159, 26);
            textBoxFrame.Name = "textBoxFrame";
            textBoxFrame.ReadOnly = true;
            textBoxFrame.Size = new Size(104, 27);
            textBoxFrame.TabIndex = 19;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(6, 29);
            label2.Name = "label2";
            label2.Size = new Size(53, 20);
            label2.TabIndex = 18;
            label2.Text = "label2";
            // 
            // labelExplain
            // 
            labelExplain.Location = new Point(6, 194);
            labelExplain.Name = "labelExplain";
            labelExplain.Size = new Size(257, 70);
            labelExplain.TabIndex = 28;
            labelExplain.Text = "label7";
            // 
            // FormKeyViewer
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(997, 573);
            Controls.Add(groupBoxStat);
            Controls.Add(panelStages);
            Controls.Add(buttonExport);
            Controls.Add(buttonClose);
            Controls.Add(label1);
            Controls.Add(labelKeyDescription);
            Controls.Add(dataGridViewKeys);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormKeyViewer";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "FormKeyViewer";
            ((System.ComponentModel.ISupportInitialize)dataGridViewKeys).EndInit();
            panelStages.ResumeLayout(false);
            groupBoxStat.ResumeLayout(false);
            groupBoxStat.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridViewKeys;
        private Label labelKeyDescription;
        private Label label1;
        private Button buttonClose;
        private Button buttonExport;
        private Panel panelStages;
        private ListBox listBoxStages;
        private GroupBox groupBoxStat;
        private TextBox textBoxAverage;
        private Label label6;
        private Label label5;
        private TextBox textBox3Frame;
        private TextBox textBox2Frame;
        private Label label4;
        private Label label3;
        private TextBox textBox1Frame;
        private TextBox textBoxFrame;
        private Label label2;
        private Label labelExplain;
    }
}