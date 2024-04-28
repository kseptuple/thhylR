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
            ((System.ComponentModel.ISupportInitialize)dataGridViewKeys).BeginInit();
            panelStages.SuspendLayout();
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
            dataGridViewKeys.Size = new Size(529, 517);
            dataGridViewKeys.TabIndex = 0;
            dataGridViewKeys.VirtualMode = true;
            // 
            // labelKeyDescription
            // 
            labelKeyDescription.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            labelKeyDescription.Location = new Point(703, 12);
            labelKeyDescription.Name = "labelKeyDescription";
            labelKeyDescription.Size = new Size(217, 239);
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
            buttonClose.Location = new Point(826, 532);
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
            buttonExport.Location = new Point(726, 532);
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
            // 
            // FormKeyViewer
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(932, 573);
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
            Text = "FormKeyViewer";
            ((System.ComponentModel.ISupportInitialize)dataGridViewKeys).EndInit();
            panelStages.ResumeLayout(false);
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
    }
}