namespace thhylR
{
    partial class FormExport
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
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            dataGridViewExport = new DataGridView();
            IsChecked = new DataGridViewCheckBoxColumn();
            Id = new DataGridViewTextBoxColumn();
            FileName = new DataGridViewTextBoxColumn();
            BlockType = new DataGridViewTextBoxColumn();
            Stage = new DataGridViewTextBoxColumn();
            Offset = new DataGridViewTextBoxColumn();
            Length = new DataGridViewTextBoxColumn();
            ExportResult = new DataGridViewTextBoxColumn();
            buttonSelectFolder = new Button();
            buttonClose = new Button();
            folderBrowserDialogSaveTo = new FolderBrowserDialog();
            ((System.ComponentModel.ISupportInitialize)dataGridViewExport).BeginInit();
            SuspendLayout();
            // 
            // dataGridViewExport
            // 
            dataGridViewExport.AllowUserToAddRows = false;
            dataGridViewExport.AllowUserToDeleteRows = false;
            dataGridViewExport.AllowUserToResizeRows = false;
            dataGridViewExport.BackgroundColor = SystemColors.Control;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Control;
            dataGridViewCellStyle2.Font = new Font("Microsoft YaHei UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Control;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.WindowText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dataGridViewExport.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dataGridViewExport.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewExport.Columns.AddRange(new DataGridViewColumn[] { IsChecked, Id, FileName, BlockType, Stage, Offset, Length, ExportResult });
            dataGridViewExport.EditMode = DataGridViewEditMode.EditOnEnter;
            dataGridViewExport.Location = new Point(9, 10);
            dataGridViewExport.Margin = new Padding(2, 3, 2, 3);
            dataGridViewExport.MultiSelect = false;
            dataGridViewExport.Name = "dataGridViewExport";
            dataGridViewExport.RowHeadersVisible = false;
            dataGridViewExport.RowHeadersWidth = 51;
            dataGridViewExport.RowTemplate.Height = 29;
            dataGridViewExport.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewExport.ShowCellToolTips = false;
            dataGridViewExport.ShowEditingIcon = false;
            dataGridViewExport.Size = new Size(683, 355);
            dataGridViewExport.TabIndex = 0;
            dataGridViewExport.CurrentCellDirtyStateChanged += dataGridViewExport_CurrentCellDirtyStateChanged;
            // 
            // IsChecked
            // 
            IsChecked.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            IsChecked.Frozen = true;
            IsChecked.HeaderText = "";
            IsChecked.MinimumWidth = 6;
            IsChecked.Name = "IsChecked";
            IsChecked.Resizable = DataGridViewTriState.False;
            IsChecked.Width = 30;
            // 
            // Id
            // 
            Id.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            Id.HeaderText = "序号";
            Id.MinimumWidth = 6;
            Id.Name = "Id";
            Id.ReadOnly = true;
            Id.Width = 57;
            // 
            // FileName
            // 
            FileName.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            FileName.HeaderText = "文件名";
            FileName.MinimumWidth = 6;
            FileName.Name = "FileName";
            FileName.Width = 69;
            // 
            // BlockType
            // 
            BlockType.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            BlockType.HeaderText = "类型";
            BlockType.MinimumWidth = 6;
            BlockType.Name = "BlockType";
            BlockType.ReadOnly = true;
            BlockType.Width = 57;
            // 
            // Stage
            // 
            Stage.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            Stage.HeaderText = "关卡";
            Stage.MinimumWidth = 6;
            Stage.Name = "Stage";
            Stage.ReadOnly = true;
            Stage.Width = 57;
            // 
            // Offset
            // 
            Offset.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            Offset.HeaderText = "起始地址";
            Offset.MinimumWidth = 6;
            Offset.Name = "Offset";
            Offset.ReadOnly = true;
            Offset.Width = 81;
            // 
            // Length
            // 
            Length.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            Length.HeaderText = "长度";
            Length.MinimumWidth = 6;
            Length.Name = "Length";
            Length.ReadOnly = true;
            Length.Width = 57;
            // 
            // ExportResult
            // 
            ExportResult.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            ExportResult.HeaderText = "Column1";
            ExportResult.MinimumWidth = 6;
            ExportResult.Name = "ExportResult";
            ExportResult.ReadOnly = true;
            ExportResult.Width = 84;
            // 
            // buttonSelectFolder
            // 
            buttonSelectFolder.Location = new Point(484, 371);
            buttonSelectFolder.Margin = new Padding(2, 3, 2, 3);
            buttonSelectFolder.Name = "buttonSelectFolder";
            buttonSelectFolder.Size = new Size(133, 25);
            buttonSelectFolder.TabIndex = 1;
            buttonSelectFolder.Text = "保存到文件夹...";
            buttonSelectFolder.UseVisualStyleBackColor = true;
            buttonSelectFolder.Click += buttonSelectFolder_Click;
            // 
            // buttonClose
            // 
            buttonClose.Location = new Point(621, 371);
            buttonClose.Margin = new Padding(2, 3, 2, 3);
            buttonClose.Name = "buttonClose";
            buttonClose.Size = new Size(73, 25);
            buttonClose.TabIndex = 2;
            buttonClose.Text = "关闭";
            buttonClose.UseVisualStyleBackColor = true;
            buttonClose.Click += buttonClose_Click;
            // 
            // FormExport
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(703, 406);
            Controls.Add(buttonClose);
            Controls.Add(buttonSelectFolder);
            Controls.Add(dataGridViewExport);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(2, 3, 2, 3);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormExport";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "FormExport";
            Load += FormExport_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewExport).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridViewExport;
        private Button buttonSelectFolder;
        private Button buttonClose;
        private FolderBrowserDialog folderBrowserDialogSaveTo;
        private DataGridViewCheckBoxColumn IsChecked;
        private DataGridViewTextBoxColumn Id;
        private DataGridViewTextBoxColumn FileName;
        private DataGridViewTextBoxColumn BlockType;
        private DataGridViewTextBoxColumn Stage;
        private DataGridViewTextBoxColumn Offset;
        private DataGridViewTextBoxColumn Length;
        private DataGridViewTextBoxColumn ExportResult;
    }
}