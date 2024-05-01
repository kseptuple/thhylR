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
            buttonClose = new Button();
            buttonExport = new Button();
            tabControlKeys = new TabControl();
            tabPage1 = new TabPage();
            listBoxStages = new ListBox();
            label1 = new Label();
            labelKeyDescription = new Label();
            dataGridViewKeys = new DataGridView();
            tabPage2 = new TabPage();
            tabControlKeys.SuspendLayout();
            tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewKeys).BeginInit();
            SuspendLayout();
            // 
            // buttonClose
            // 
            buttonClose.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonClose.Location = new Point(892, 541);
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
            buttonExport.Location = new Point(792, 541);
            buttonExport.Name = "buttonExport";
            buttonExport.Size = new Size(94, 29);
            buttonExport.TabIndex = 5;
            buttonExport.Text = "button1";
            buttonExport.UseVisualStyleBackColor = true;
            // 
            // tabControlKeys
            // 
            tabControlKeys.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tabControlKeys.Controls.Add(tabPage1);
            tabControlKeys.Controls.Add(tabPage2);
            tabControlKeys.Location = new Point(0, 0);
            tabControlKeys.Name = "tabControlKeys";
            tabControlKeys.SelectedIndex = 0;
            tabControlKeys.Size = new Size(998, 535);
            tabControlKeys.TabIndex = 7;
            // 
            // tabPage1
            // 
            tabPage1.BackColor = SystemColors.Control;
            tabPage1.Controls.Add(listBoxStages);
            tabPage1.Controls.Add(label1);
            tabPage1.Controls.Add(labelKeyDescription);
            tabPage1.Controls.Add(dataGridViewKeys);
            tabPage1.Location = new Point(4, 29);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(990, 502);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "tabPage1";
            // 
            // listBoxStages
            // 
            listBoxStages.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            listBoxStages.FormattingEnabled = true;
            listBoxStages.IntegralHeight = false;
            listBoxStages.ItemHeight = 20;
            listBoxStages.Location = new Point(3, 23);
            listBoxStages.Name = "listBoxStages";
            listBoxStages.Size = new Size(153, 473);
            listBoxStages.TabIndex = 2;
            listBoxStages.SelectedIndexChanged += listBoxStages_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(3, 0);
            label1.Name = "label1";
            label1.Size = new Size(53, 20);
            label1.TabIndex = 9;
            label1.Text = "label1";
            // 
            // labelKeyDescription
            // 
            labelKeyDescription.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            labelKeyDescription.Location = new Point(760, 3);
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
            dataGridViewKeys.Location = new Point(159, 3);
            dataGridViewKeys.MultiSelect = false;
            dataGridViewKeys.Name = "dataGridViewKeys";
            dataGridViewKeys.ReadOnly = true;
            dataGridViewKeys.RowHeadersVisible = false;
            dataGridViewKeys.RowHeadersWidth = 51;
            dataGridViewKeys.RowTemplate.Height = 29;
            dataGridViewKeys.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewKeys.ShowCellToolTips = false;
            dataGridViewKeys.Size = new Size(595, 493);
            dataGridViewKeys.TabIndex = 7;
            dataGridViewKeys.VirtualMode = true;
            dataGridViewKeys.CellValueNeeded += dataGridViewKeys_CellValueNeeded;
            // 
            // tabPage2
            // 
            tabPage2.BackColor = SystemColors.Control;
            tabPage2.Location = new Point(4, 29);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(990, 502);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "tabPage2";
            // 
            // FormKeyViewer
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(998, 582);
            Controls.Add(tabControlKeys);
            Controls.Add(buttonExport);
            Controls.Add(buttonClose);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormKeyViewer";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "FormKeyViewer";
            tabControlKeys.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewKeys).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Button buttonClose;
        private Button buttonExport;
        private TabControl tabControlKeys;
        private TabPage tabPage1;
        private ListBox listBoxStages;
        private Label label1;
        private Label labelKeyDescription;
        private DataGridView dataGridViewKeys;
        private TabPage tabPage2;
        private TabPage tabPageKeyViewer;
    }
}