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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            buttonClose = new Button();
            tabControlKeys = new TabControl();
            tabPage1 = new TabPage();
            buttonExport = new Button();
            labelKeyDescription = new Label();
            dataGridViewKeys = new DataGridView();
            tabPage2 = new TabPage();
            labelDetail = new Label();
            dataGridViewStats = new DataGridView();
            Column1 = new DataGridViewTextBoxColumn();
            Column2 = new DataGridViewTextBoxColumn();
            Column3 = new DataGridViewTextBoxColumn();
            Column4 = new DataGridViewTextBoxColumn();
            radioButtonKey = new RadioButton();
            radioButtonController = new RadioButton();
            chartKeys = new System.Windows.Forms.DataVisualization.Charting.Chart();
            listBoxStages = new ListBox();
            label1 = new Label();
            saveFileDialogExport = new SaveFileDialog();
            tabControlKeys.SuspendLayout();
            tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewKeys).BeginInit();
            tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewStats).BeginInit();
            ((System.ComponentModel.ISupportInitialize)chartKeys).BeginInit();
            SuspendLayout();
            // 
            // buttonClose
            // 
            buttonClose.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonClose.Location = new Point(840, 472);
            buttonClose.Margin = new Padding(2, 3, 2, 3);
            buttonClose.Name = "buttonClose";
            buttonClose.Size = new Size(73, 25);
            buttonClose.TabIndex = 4;
            buttonClose.Text = "button1";
            buttonClose.UseVisualStyleBackColor = true;
            buttonClose.Click += buttonClose_Click;
            // 
            // tabControlKeys
            // 
            tabControlKeys.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tabControlKeys.Controls.Add(tabPage1);
            tabControlKeys.Controls.Add(tabPage2);
            tabControlKeys.Location = new Point(133, 0);
            tabControlKeys.Margin = new Padding(2, 3, 2, 3);
            tabControlKeys.Name = "tabControlKeys";
            tabControlKeys.SelectedIndex = 0;
            tabControlKeys.Size = new Size(789, 467);
            tabControlKeys.TabIndex = 7;
            tabControlKeys.SelectedIndexChanged += tabControlKeys_SelectedIndexChanged;
            // 
            // tabPage1
            // 
            tabPage1.BackColor = SystemColors.Control;
            tabPage1.Controls.Add(buttonExport);
            tabPage1.Controls.Add(labelKeyDescription);
            tabPage1.Controls.Add(dataGridViewKeys);
            tabPage1.Location = new Point(4, 26);
            tabPage1.Margin = new Padding(2, 3, 2, 3);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(2, 3, 2, 3);
            tabPage1.Size = new Size(781, 437);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "tabPage1";
            // 
            // buttonExport
            // 
            buttonExport.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonExport.Location = new Point(703, 409);
            buttonExport.Margin = new Padding(2, 3, 2, 3);
            buttonExport.Name = "buttonExport";
            buttonExport.Size = new Size(73, 25);
            buttonExport.TabIndex = 9;
            buttonExport.Text = "button1";
            buttonExport.UseVisualStyleBackColor = true;
            buttonExport.Click += buttonExport_Click;
            // 
            // labelKeyDescription
            // 
            labelKeyDescription.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            labelKeyDescription.Location = new Point(600, 3);
            labelKeyDescription.Margin = new Padding(2, 0, 2, 0);
            labelKeyDescription.Name = "labelKeyDescription";
            labelKeyDescription.Size = new Size(177, 146);
            labelKeyDescription.TabIndex = 8;
            labelKeyDescription.Text = "label1";
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
            dataGridViewKeys.Location = new Point(5, 3);
            dataGridViewKeys.Margin = new Padding(2, 3, 2, 3);
            dataGridViewKeys.MultiSelect = false;
            dataGridViewKeys.Name = "dataGridViewKeys";
            dataGridViewKeys.ReadOnly = true;
            dataGridViewKeys.RowHeadersVisible = false;
            dataGridViewKeys.RowHeadersWidth = 51;
            dataGridViewKeys.RowTemplate.Height = 29;
            dataGridViewKeys.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewKeys.ShowCellToolTips = false;
            dataGridViewKeys.Size = new Size(591, 431);
            dataGridViewKeys.TabIndex = 7;
            dataGridViewKeys.VirtualMode = true;
            dataGridViewKeys.CellValueNeeded += dataGridViewKeys_CellValueNeeded;
            // 
            // tabPage2
            // 
            tabPage2.BackColor = SystemColors.Control;
            tabPage2.Controls.Add(labelDetail);
            tabPage2.Controls.Add(dataGridViewStats);
            tabPage2.Controls.Add(radioButtonKey);
            tabPage2.Controls.Add(radioButtonController);
            tabPage2.Controls.Add(chartKeys);
            tabPage2.Location = new Point(4, 26);
            tabPage2.Margin = new Padding(2, 3, 2, 3);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(2, 3, 2, 3);
            tabPage2.Size = new Size(781, 437);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "tabPage2";
            // 
            // labelDetail
            // 
            labelDetail.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            labelDetail.Location = new Point(5, 28);
            labelDetail.Margin = new Padding(2, 0, 2, 0);
            labelDetail.Name = "labelDetail";
            labelDetail.Size = new Size(769, 40);
            labelDetail.TabIndex = 4;
            labelDetail.Text = "labelDetail";
            // 
            // dataGridViewStats
            // 
            dataGridViewStats.AllowUserToAddRows = false;
            dataGridViewStats.AllowUserToDeleteRows = false;
            dataGridViewStats.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridViewStats.BackgroundColor = SystemColors.Control;
            dataGridViewStats.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewStats.ColumnHeadersVisible = false;
            dataGridViewStats.Columns.AddRange(new DataGridViewColumn[] { Column1, Column2, Column3, Column4 });
            dataGridViewStats.Location = new Point(5, 332);
            dataGridViewStats.Margin = new Padding(2, 3, 2, 3);
            dataGridViewStats.MultiSelect = false;
            dataGridViewStats.Name = "dataGridViewStats";
            dataGridViewStats.ReadOnly = true;
            dataGridViewStats.RowHeadersVisible = false;
            dataGridViewStats.RowHeadersWidth = 51;
            dataGridViewStats.RowTemplate.Height = 29;
            dataGridViewStats.Size = new Size(771, 101);
            dataGridViewStats.TabIndex = 3;
            // 
            // Column1
            // 
            Column1.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Column1.HeaderText = "Column1";
            Column1.MinimumWidth = 6;
            Column1.Name = "Column1";
            Column1.ReadOnly = true;
            // 
            // Column2
            // 
            Column2.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Column2.HeaderText = "Column2";
            Column2.MinimumWidth = 6;
            Column2.Name = "Column2";
            Column2.ReadOnly = true;
            // 
            // Column3
            // 
            Column3.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Column3.HeaderText = "Column3";
            Column3.MinimumWidth = 6;
            Column3.Name = "Column3";
            Column3.ReadOnly = true;
            // 
            // Column4
            // 
            Column4.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Column4.HeaderText = "Column4";
            Column4.MinimumWidth = 6;
            Column4.Name = "Column4";
            Column4.ReadOnly = true;
            // 
            // radioButtonKey
            // 
            radioButtonKey.AutoSize = true;
            radioButtonKey.Location = new Point(107, 5);
            radioButtonKey.Margin = new Padding(2, 3, 2, 3);
            radioButtonKey.Name = "radioButtonKey";
            radioButtonKey.Size = new Size(102, 21);
            radioButtonKey.TabIndex = 2;
            radioButtonKey.TabStop = true;
            radioButtonKey.Text = "radioButton2";
            radioButtonKey.UseVisualStyleBackColor = true;
            radioButtonKey.CheckedChanged += radioButtonKey_CheckedChanged;
            // 
            // radioButtonController
            // 
            radioButtonController.AutoSize = true;
            radioButtonController.Location = new Point(5, 5);
            radioButtonController.Margin = new Padding(2, 3, 2, 3);
            radioButtonController.Name = "radioButtonController";
            radioButtonController.Size = new Size(102, 21);
            radioButtonController.TabIndex = 1;
            radioButtonController.TabStop = true;
            radioButtonController.Text = "radioButton1";
            radioButtonController.UseVisualStyleBackColor = true;
            radioButtonController.CheckedChanged += radioButtonController_CheckedChanged;
            // 
            // chartKeys
            // 
            chartKeys.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            chartArea1.AxisX.IntervalAutoMode = System.Windows.Forms.DataVisualization.Charting.IntervalAutoMode.VariableCount;
            chartArea1.AxisX.MajorGrid.Enabled = false;
            chartArea1.AxisY.MajorGrid.LineColor = Color.FromArgb(224, 224, 224);
            chartArea1.AxisY.MajorTickMark.Enabled = false;
            chartArea1.AxisY2.MajorGrid.Enabled = false;
            chartArea1.Name = "ChartArea1";
            chartArea1.Position.Auto = false;
            chartArea1.Position.Height = 90F;
            chartArea1.Position.Width = 98F;
            chartArea1.Position.Y = 1F;
            chartKeys.ChartAreas.Add(chartArea1);
            chartKeys.Location = new Point(5, 71);
            chartKeys.Margin = new Padding(2, 3, 2, 3);
            chartKeys.Name = "chartKeys";
            chartKeys.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.None;
            chartKeys.PaletteCustomColors = new Color[]
    {
    Color.Red
    };
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
            series1.IsXValueIndexed = true;
            series1.Name = "Series1";
            series1.YValuesPerPoint = 6;
            chartKeys.Series.Add(series1);
            chartKeys.Size = new Size(771, 257);
            chartKeys.TabIndex = 0;
            chartKeys.Text = "chart1";
            title1.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Bottom;
            title1.Name = "Title1";
            chartKeys.Titles.Add(title1);
            // 
            // listBoxStages
            // 
            listBoxStages.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            listBoxStages.FormattingEnabled = true;
            listBoxStages.IntegralHeight = false;
            listBoxStages.ItemHeight = 17;
            listBoxStages.Location = new Point(9, 25);
            listBoxStages.Margin = new Padding(2, 3, 2, 3);
            listBoxStages.Name = "listBoxStages";
            listBoxStages.Size = new Size(120, 439);
            listBoxStages.TabIndex = 2;
            listBoxStages.SelectedIndexChanged += listBoxStages_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(9, 5);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(43, 17);
            label1.TabIndex = 9;
            label1.Text = "label1";
            // 
            // FormKeyViewer
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(924, 507);
            Controls.Add(label1);
            Controls.Add(listBoxStages);
            Controls.Add(tabControlKeys);
            Controls.Add(buttonClose);
            Margin = new Padding(2, 3, 2, 3);
            MaximizeBox = false;
            MinimizeBox = false;
            MinimumSize = new Size(940, 520);
            Name = "FormKeyViewer";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "FormKeyViewer";
            FormClosing += FormKeyViewer_FormClosing;
            DpiChanged += FormKeyViewer_DpiChanged;
            tabControlKeys.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridViewKeys).EndInit();
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewStats).EndInit();
            ((System.ComponentModel.ISupportInitialize)chartKeys).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button buttonClose;
        private TabControl tabControlKeys;
        private TabPage tabPage1;
        private ListBox listBoxStages;
        private Label label1;
        private Label labelKeyDescription;
        private DataGridView dataGridViewKeys;
        private TabPage tabPage2;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartKeys;
        private RadioButton radioButtonKey;
        private RadioButton radioButtonController;
        private DataGridView dataGridViewStats;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn Column2;
        private DataGridViewTextBoxColumn Column3;
        private DataGridViewTextBoxColumn Column4;
        private Label labelDetail;
        private SaveFileDialog saveFileDialogExport;
        private Button buttonExport;
    }
}