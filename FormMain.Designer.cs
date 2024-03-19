namespace thhylR
{
    partial class FormMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            openReplayDialog = new OpenFileDialog();
            button1 = new Button();
            dataGridInfo = new DataGridView();
            dataGridColumnName = new DataGridViewTextBoxColumn();
            dataGridColumnValue = new DataGridViewTextBoxColumn();
            textBoxInfo = new TextBox();
            menuStripMain = new MenuStrip();
            FileToolStripMenuItem = new ToolStripMenuItem();
            SplitToolStripMenuItem = new ToolStripSeparator();
            ExitToolStripMenuItem = new ToolStripMenuItem();
            EditToolStripMenuItem = new ToolStripMenuItem();
            ExportToolStripMenuItem = new ToolStripMenuItem();
            ExportAllToolStripMenuItem = new ToolStripMenuItem();
            ExportCustomToolStripMenuItem = new ToolStripMenuItem();
            saveFileDialog = new SaveFileDialog();
            textBoxPath = new TextBox();
            treeViewFiles = new TreeView();
            fileSystemWatcherFolder = new FileSystemWatcher();
            button2 = new Button();
            ToolToolStripMenuItem = new ToolStripMenuItem();
            OptionToolStripMenuItem = new ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)dataGridInfo).BeginInit();
            menuStripMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)fileSystemWatcherFolder).BeginInit();
            SuspendLayout();
            // 
            // openReplayDialog
            // 
            openReplayDialog.Filter = "录像文件|*.rpy";
            // 
            // button1
            // 
            button1.Location = new Point(1010, 59);
            button1.Name = "button1";
            button1.Size = new Size(94, 29);
            button1.TabIndex = 2;
            button1.Text = "buttonOpen";
            button1.UseVisualStyleBackColor = true;
            button1.Click += buttonOpen_Click;
            // 
            // dataGridInfo
            // 
            dataGridInfo.AllowUserToAddRows = false;
            dataGridInfo.AllowUserToDeleteRows = false;
            dataGridInfo.AllowUserToResizeRows = false;
            dataGridInfo.BackgroundColor = SystemColors.Control;
            dataGridInfo.ColumnHeadersHeight = 29;
            dataGridInfo.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridInfo.ColumnHeadersVisible = false;
            dataGridInfo.Columns.AddRange(new DataGridViewColumn[] { dataGridColumnName, dataGridColumnValue });
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Window;
            dataGridViewCellStyle1.Font = new Font("Microsoft YaHei UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.False;
            dataGridInfo.DefaultCellStyle = dataGridViewCellStyle1;
            dataGridInfo.Location = new Point(224, 178);
            dataGridInfo.MultiSelect = false;
            dataGridInfo.Name = "dataGridInfo";
            dataGridInfo.ReadOnly = true;
            dataGridInfo.RowHeadersVisible = false;
            dataGridInfo.RowHeadersWidth = 51;
            dataGridInfo.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridInfo.RowTemplate.Height = 29;
            dataGridInfo.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridInfo.ShowCellToolTips = false;
            dataGridInfo.Size = new Size(621, 444);
            dataGridInfo.TabIndex = 3;
            dataGridInfo.SelectionChanged += dataGridInfo_SelectionChanged;
            // 
            // dataGridColumnName
            // 
            dataGridColumnName.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridColumnName.DataPropertyName = "Name";
            dataGridColumnName.FillWeight = 25F;
            dataGridColumnName.HeaderText = "Name";
            dataGridColumnName.MinimumWidth = 6;
            dataGridColumnName.Name = "dataGridColumnName";
            dataGridColumnName.ReadOnly = true;
            // 
            // dataGridColumnValue
            // 
            dataGridColumnValue.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridColumnValue.DataPropertyName = "DisplayValue";
            dataGridColumnValue.FillWeight = 75F;
            dataGridColumnValue.HeaderText = "DisplayValue";
            dataGridColumnValue.MinimumWidth = 6;
            dataGridColumnValue.Name = "dataGridColumnValue";
            dataGridColumnValue.ReadOnly = true;
            // 
            // textBoxInfo
            // 
            textBoxInfo.Location = new Point(851, 178);
            textBoxInfo.Multiline = true;
            textBoxInfo.Name = "textBoxInfo";
            textBoxInfo.ReadOnly = true;
            textBoxInfo.ScrollBars = ScrollBars.Vertical;
            textBoxInfo.Size = new Size(382, 444);
            textBoxInfo.TabIndex = 5;
            // 
            // menuStripMain
            // 
            menuStripMain.ImageScalingSize = new Size(20, 20);
            menuStripMain.Items.AddRange(new ToolStripItem[] { FileToolStripMenuItem, EditToolStripMenuItem, ToolToolStripMenuItem });
            menuStripMain.Location = new Point(0, 0);
            menuStripMain.Name = "menuStripMain";
            menuStripMain.Size = new Size(1307, 28);
            menuStripMain.TabIndex = 6;
            menuStripMain.Text = "menuStrip1";
            // 
            // FileToolStripMenuItem
            // 
            FileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { SplitToolStripMenuItem, ExitToolStripMenuItem });
            FileToolStripMenuItem.Name = "FileToolStripMenuItem";
            FileToolStripMenuItem.Size = new Size(71, 24);
            FileToolStripMenuItem.Text = "文件(&F)";
            // 
            // SplitToolStripMenuItem
            // 
            SplitToolStripMenuItem.Name = "SplitToolStripMenuItem";
            SplitToolStripMenuItem.Size = new Size(221, 6);
            // 
            // ExitToolStripMenuItem
            // 
            ExitToolStripMenuItem.Name = "ExitToolStripMenuItem";
            ExitToolStripMenuItem.ShortcutKeys = Keys.Alt | Keys.F4;
            ExitToolStripMenuItem.Size = new Size(224, 26);
            ExitToolStripMenuItem.Text = "退出(&X)";
            ExitToolStripMenuItem.Click += ExitToolStripMenuItem_Click;
            // 
            // EditToolStripMenuItem
            // 
            EditToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { ExportToolStripMenuItem });
            EditToolStripMenuItem.Name = "EditToolStripMenuItem";
            EditToolStripMenuItem.Size = new Size(71, 24);
            EditToolStripMenuItem.Text = "编辑(&E)";
            // 
            // ExportToolStripMenuItem
            // 
            ExportToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { ExportAllToolStripMenuItem, ExportCustomToolStripMenuItem });
            ExportToolStripMenuItem.Name = "ExportToolStripMenuItem";
            ExportToolStripMenuItem.Size = new Size(224, 26);
            ExportToolStripMenuItem.Text = "导出原始数据(&P)";
            // 
            // ExportAllToolStripMenuItem
            // 
            ExportAllToolStripMenuItem.Name = "ExportAllToolStripMenuItem";
            ExportAllToolStripMenuItem.Size = new Size(224, 26);
            ExportAllToolStripMenuItem.Text = "全部(&A)";
            ExportAllToolStripMenuItem.Click += ExportAllToolStripMenuItem_Click;
            // 
            // ExportCustomToolStripMenuItem
            // 
            ExportCustomToolStripMenuItem.Name = "ExportCustomToolStripMenuItem";
            ExportCustomToolStripMenuItem.Size = new Size(224, 26);
            ExportCustomToolStripMenuItem.Text = "自定义(&C)...";
            // 
            // textBoxPath
            // 
            textBoxPath.Location = new Point(253, 85);
            textBoxPath.Name = "textBoxPath";
            textBoxPath.Size = new Size(582, 27);
            textBoxPath.TabIndex = 7;
            // 
            // treeViewFiles
            // 
            treeViewFiles.DrawMode = TreeViewDrawMode.OwnerDrawText;
            treeViewFiles.HideSelection = false;
            treeViewFiles.Location = new Point(32, 178);
            treeViewFiles.Name = "treeViewFiles";
            treeViewFiles.Size = new Size(166, 444);
            treeViewFiles.TabIndex = 8;
            treeViewFiles.DrawNode += treeViewFiles_DrawNode;
            treeViewFiles.AfterSelect += treeViewFiles_AfterSelect;
            // 
            // fileSystemWatcherFolder
            // 
            fileSystemWatcherFolder.EnableRaisingEvents = true;
            fileSystemWatcherFolder.Filter = "*.rpy";
            fileSystemWatcherFolder.NotifyFilter = NotifyFilters.FileName | NotifyFilters.DirectoryName;
            fileSystemWatcherFolder.SynchronizingObject = this;
            fileSystemWatcherFolder.Created += fileSystemWatcherFolder_Events;
            fileSystemWatcherFolder.Deleted += fileSystemWatcherFolder_Events;
            fileSystemWatcherFolder.Renamed += fileSystemWatcherFolder_Renamed;
            // 
            // button2
            // 
            button2.Location = new Point(19, 115);
            button2.Name = "button2";
            button2.Size = new Size(263, 22);
            button2.TabIndex = 9;
            button2.Text = "button2";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // ToolToolStripMenuItem
            // 
            ToolToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { OptionToolStripMenuItem });
            ToolToolStripMenuItem.Name = "ToolToolStripMenuItem";
            ToolToolStripMenuItem.Size = new Size(72, 24);
            ToolToolStripMenuItem.Text = "工具(&T)";
            // 
            // OptionToolStripMenuItem
            // 
            OptionToolStripMenuItem.Name = "OptionToolStripMenuItem";
            OptionToolStripMenuItem.Size = new Size(224, 26);
            OptionToolStripMenuItem.Text = "选项(&O)...";
            OptionToolStripMenuItem.Click += OptionToolStripMenuItem_Click;
            // 
            // FormMain
            // 
            AllowDrop = true;
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1307, 695);
            Controls.Add(button2);
            Controls.Add(treeViewFiles);
            Controls.Add(textBoxPath);
            Controls.Add(textBoxInfo);
            Controls.Add(dataGridInfo);
            Controls.Add(button1);
            Controls.Add(menuStripMain);
            MainMenuStrip = menuStripMain;
            Name = "FormMain";
            Text = "Form1";
            DragDrop += FormMain_DragDrop;
            DragEnter += FormMain_DragEnter;
            ((System.ComponentModel.ISupportInitialize)dataGridInfo).EndInit();
            menuStripMain.ResumeLayout(false);
            menuStripMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)fileSystemWatcherFolder).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private OpenFileDialog openReplayDialog;
        private Button button1;
        private DataGridView dataGridInfo;
        private DataGridViewTextBoxColumn dataGridColumnName;
        private DataGridViewTextBoxColumn dataGridColumnValue;
        private TextBox textBoxInfo;
        private MenuStrip menuStripMain;
        private ToolStripMenuItem FileToolStripMenuItem;
        private ToolStripSeparator SplitToolStripMenuItem;
        private ToolStripMenuItem EditToolStripMenuItem;
        private ToolStripMenuItem ExitToolStripMenuItem;
        private ToolStripMenuItem ExportToolStripMenuItem;
        private ToolStripMenuItem ExportAllToolStripMenuItem;
        private ToolStripMenuItem ExportCustomToolStripMenuItem;
        private SaveFileDialog saveFileDialog;
        private TextBox textBoxPath;
        private TreeView treeViewFiles;
        private FileSystemWatcher fileSystemWatcherFolder;
        private Button button2;
        private ToolStripMenuItem ToolToolStripMenuItem;
        private ToolStripMenuItem OptionToolStripMenuItem;
    }
}
