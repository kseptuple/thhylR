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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title2 = new System.Windows.Forms.DataVisualization.Charting.Title();
            buttonClose = new Button();
            tabControlKeys = new TabControl();
            tabPage1 = new TabPage();
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
            buttonExport = new Button();
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
            buttonClose.Location = new Point(1076, 555);
            buttonClose.Name = "buttonClose";
            buttonClose.Size = new Size(94, 29);
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
            tabControlKeys.Location = new Point(171, 0);
            tabControlKeys.Name = "tabControlKeys";
            tabControlKeys.SelectedIndex = 0;
            tabControlKeys.Size = new Size(1011, 549);
            tabControlKeys.TabIndex = 7;
            tabControlKeys.SelectedIndexChanged += tabControlKeys_SelectedIndexChanged;
            // 
            // tabPage1
            // 
            tabPage1.BackColor = SystemColors.Control;
            tabPage1.Controls.Add(buttonExport);
            tabPage1.Controls.Add(labelKeyDescription);
            tabPage1.Controls.Add(dataGridViewKeys);
            tabPage1.Location = new Point(4, 29);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(1003, 516);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "tabPage1";
            // 
            // labelKeyDescription
            // 
            labelKeyDescription.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            labelKeyDescription.Location = new Point(768, 3);
            labelKeyDescription.Name = "labelKeyDescription";
            labelKeyDescription.Size = new Size(227, 172);
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
            dataGridViewKeys.Location = new Point(6, 3);
            dataGridViewKeys.MultiSelect = false;
            dataGridViewKeys.Name = "dataGridViewKeys";
            dataGridViewKeys.ReadOnly = true;
            dataGridViewKeys.RowHeadersVisible = false;
            dataGridViewKeys.RowHeadersWidth = 51;
            dataGridViewKeys.RowTemplate.Height = 29;
            dataGridViewKeys.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewKeys.ShowCellToolTips = false;
            dataGridViewKeys.Size = new Size(756, 507);
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
            tabPage2.Location = new Point(4, 29);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(1003, 516);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "tabPage2";
            // 
            // labelDetail
            // 
            labelDetail.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            labelDetail.Location = new Point(6, 33);
            labelDetail.Name = "labelDetail";
            labelDetail.Size = new Size(989, 47);
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
            dataGridViewStats.Location = new Point(6, 391);
            dataGridViewStats.MultiSelect = false;
            dataGridViewStats.Name = "dataGridViewStats";
            dataGridViewStats.ReadOnly = true;
            dataGridViewStats.RowHeadersVisible = false;
            dataGridViewStats.RowHeadersWidth = 51;
            dataGridViewStats.RowTemplate.Height = 29;
            dataGridViewStats.Size = new Size(991, 119);
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
            radioButtonKey.Location = new Point(138, 6);
            radioButtonKey.Name = "radioButtonKey";
            radioButtonKey.Size = new Size(126, 24);
            radioButtonKey.TabIndex = 2;
            radioButtonKey.TabStop = true;
            radioButtonKey.Text = "radioButton2";
            radioButtonKey.UseVisualStyleBackColor = true;
            radioButtonKey.CheckedChanged += radioButtonKey_CheckedChanged;
            // 
            // radioButtonController
            // 
            radioButtonController.AutoSize = true;
            radioButtonController.Location = new Point(6, 6);
            radioButtonController.Name = "radioButtonController";
            radioButtonController.Size = new Size(126, 24);
            radioButtonController.TabIndex = 1;
            radioButtonController.TabStop = true;
            radioButtonController.Text = "radioButton1";
            radioButtonController.UseVisualStyleBackColor = true;
            radioButtonController.CheckedChanged += radioButtonController_CheckedChanged;
            // 
            // chartKeys
            // 
            chartKeys.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            chartArea2.AxisX.IntervalAutoMode = System.Windows.Forms.DataVisualization.Charting.IntervalAutoMode.VariableCount;
            chartArea2.AxisX.MajorGrid.Enabled = false;
            chartArea2.AxisY.MajorGrid.LineColor = Color.FromArgb(224, 224, 224);
            chartArea2.AxisY.MajorTickMark.Enabled = false;
            chartArea2.AxisY2.MajorGrid.Enabled = false;
            chartArea2.Name = "ChartArea1";
            chartArea2.Position.Auto = false;
            chartArea2.Position.Height = 90F;
            chartArea2.Position.Width = 98F;
            chartArea2.Position.Y = 1F;
            chartKeys.ChartAreas.Add(chartArea2);
            chartKeys.Location = new Point(6, 83);
            chartKeys.Name = "chartKeys";
            chartKeys.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.None;
            chartKeys.PaletteCustomColors = new Color[]
    {
    Color.Red
    };
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
            series2.IsXValueIndexed = true;
            series2.Name = "Series1";
            series2.YValuesPerPoint = 6;
            chartKeys.Series.Add(series2);
            chartKeys.Size = new Size(991, 302);
            chartKeys.TabIndex = 0;
            chartKeys.Text = "chart1";
            title2.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Bottom;
            title2.Name = "Title1";
            chartKeys.Titles.Add(title2);
            // 
            // listBoxStages
            // 
            listBoxStages.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            listBoxStages.FormattingEnabled = true;
            listBoxStages.IntegralHeight = false;
            listBoxStages.ItemHeight = 20;
            listBoxStages.Location = new Point(12, 29);
            listBoxStages.Name = "listBoxStages";
            listBoxStages.Size = new Size(153, 516);
            listBoxStages.TabIndex = 2;
            listBoxStages.SelectedIndexChanged += listBoxStages_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 6);
            label1.Name = "label1";
            label1.Size = new Size(53, 20);
            label1.TabIndex = 9;
            label1.Text = "label1";
            // 
            // buttonExport
            // 
            buttonExport.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonExport.Location = new Point(901, 481);
            buttonExport.Name = "buttonExport";
            buttonExport.Size = new Size(94, 29);
            buttonExport.TabIndex = 9;
            buttonExport.Text = "button1";
            buttonExport.UseVisualStyleBackColor = true;
            buttonExport.Click += buttonExport_Click;
            // 
            // FormKeyViewer
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1182, 596);
            Controls.Add(label1);
            Controls.Add(listBoxStages);
            Controls.Add(tabControlKeys);
            Controls.Add(buttonClose);
            MaximizeBox = false;
            MinimizeBox = false;
            MinimumSize = new Size(1200, 600);
            Name = "FormKeyViewer";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "FormKeyViewer";
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