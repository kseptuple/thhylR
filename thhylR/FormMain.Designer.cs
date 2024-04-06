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
            dataGridInfo = new DataGridView();
            dataGridColumnName = new DataGridViewTextBoxColumn();
            dataGridColumnValue = new DataGridViewTextBoxColumn();
            textBoxInfo = new TextBox();
            menuStripMain = new MenuStrip();
            FileToolStripMenuItem = new ToolStripMenuItem();
            OpenToolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem1 = new ToolStripSeparator();
            CutToolStripMenuItem = new ToolStripMenuItem();
            CopyToolStripMenuItem = new ToolStripMenuItem();
            MoveToToolStripMenuItem = new ToolStripMenuItem();
            CopyToToolStripMenuItem = new ToolStripMenuItem();
            RenameToolStripMenuItem = new ToolStripMenuItem();
            DeleteToolStripMenuItem = new ToolStripMenuItem();
            SplitToolStripMenuItem = new ToolStripSeparator();
            ExitToolStripMenuItem = new ToolStripMenuItem();
            EditToolStripMenuItem = new ToolStripMenuItem();
            ExportToolStripMenuItem = new ToolStripMenuItem();
            ExportAllToolStripMenuItem = new ToolStripMenuItem();
            ExportCustomToolStripMenuItem = new ToolStripMenuItem();
            ToolToolStripMenuItem = new ToolStripMenuItem();
            OptionToolStripMenuItem = new ToolStripMenuItem();
            saveFileDialog = new SaveFileDialog();
            textBoxPath = new TextBox();
            treeViewFiles = new TreeView();
            fileSystemWatcherFolder = new FileSystemWatcher();
            toolStripMain = new ToolStrip();
            toolStripButtonOpen = new ToolStripButton();
            toolStripSeparator1 = new ToolStripSeparator();
            toolStripButtonCut = new ToolStripButton();
            toolStripButtonCopy = new ToolStripButton();
            toolStripButtonMoveTo = new ToolStripButton();
            toolStripButtonCopyTo = new ToolStripButton();
            toolStripButtonRename = new ToolStripButton();
            toolStripButtonDelete = new ToolStripButton();
            folderBrowserDialogMoveCopy = new FolderBrowserDialog();
            ((System.ComponentModel.ISupportInitialize)dataGridInfo).BeginInit();
            menuStripMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)fileSystemWatcherFolder).BeginInit();
            toolStripMain.SuspendLayout();
            SuspendLayout();
            // 
            // openReplayDialog
            // 
            openReplayDialog.Filter = "录像文件|*.rpy";
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
            FileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { OpenToolStripMenuItem, toolStripMenuItem1, CutToolStripMenuItem, CopyToolStripMenuItem, MoveToToolStripMenuItem, CopyToToolStripMenuItem, RenameToolStripMenuItem, DeleteToolStripMenuItem, SplitToolStripMenuItem, ExitToolStripMenuItem });
            FileToolStripMenuItem.Name = "FileToolStripMenuItem";
            FileToolStripMenuItem.Size = new Size(71, 24);
            FileToolStripMenuItem.Text = "文件(&F)";
            // 
            // OpenToolStripMenuItem
            // 
            OpenToolStripMenuItem.Image = Properties.Resources.OpenFile;
            OpenToolStripMenuItem.Name = "OpenToolStripMenuItem";
            OpenToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.O;
            OpenToolStripMenuItem.Size = new Size(274, 26);
            OpenToolStripMenuItem.Text = "打开(&O)";
            OpenToolStripMenuItem.Click += OpenToolStripMenuItem_Click;
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new Size(271, 6);
            // 
            // CutToolStripMenuItem
            // 
            CutToolStripMenuItem.Image = Properties.Resources.Cut;
            CutToolStripMenuItem.Name = "CutToolStripMenuItem";
            CutToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.X;
            CutToolStripMenuItem.Size = new Size(274, 26);
            CutToolStripMenuItem.Text = "剪切(&T)";
            CutToolStripMenuItem.Click += CutToolStripMenuItem_Click;
            // 
            // CopyToolStripMenuItem
            // 
            CopyToolStripMenuItem.Image = Properties.Resources.Copy;
            CopyToolStripMenuItem.Name = "CopyToolStripMenuItem";
            CopyToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.C;
            CopyToolStripMenuItem.Size = new Size(274, 26);
            CopyToolStripMenuItem.Text = "复制(&C)";
            CopyToolStripMenuItem.Click += CopyToolStripMenuItem_Click;
            // 
            // MoveToToolStripMenuItem
            // 
            MoveToToolStripMenuItem.Image = Properties.Resources.MoveTo;
            MoveToToolStripMenuItem.Name = "MoveToToolStripMenuItem";
            MoveToToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.Shift | Keys.X;
            MoveToToolStripMenuItem.Size = new Size(274, 26);
            MoveToToolStripMenuItem.Text = "移动到(&M)...";
            MoveToToolStripMenuItem.Click += MoveToToolStripMenuItem_Click;
            // 
            // CopyToToolStripMenuItem
            // 
            CopyToToolStripMenuItem.Image = Properties.Resources.CopyTo;
            CopyToToolStripMenuItem.Name = "CopyToToolStripMenuItem";
            CopyToToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.Shift | Keys.C;
            CopyToToolStripMenuItem.Size = new Size(274, 26);
            CopyToToolStripMenuItem.Text = "复制到(&P)...";
            CopyToToolStripMenuItem.Click += CopyToToolStripMenuItem_Click;
            // 
            // RenameToolStripMenuItem
            // 
            RenameToolStripMenuItem.Image = Properties.Resources.Rename;
            RenameToolStripMenuItem.Name = "RenameToolStripMenuItem";
            RenameToolStripMenuItem.Size = new Size(274, 26);
            RenameToolStripMenuItem.Text = "重命名(&R)";
            RenameToolStripMenuItem.Click += RenameToolStripMenuItem_Click;
            // 
            // DeleteToolStripMenuItem
            // 
            DeleteToolStripMenuItem.Image = Properties.Resources.Delete;
            DeleteToolStripMenuItem.Name = "DeleteToolStripMenuItem";
            DeleteToolStripMenuItem.ShortcutKeys = Keys.Delete;
            DeleteToolStripMenuItem.Size = new Size(274, 26);
            DeleteToolStripMenuItem.Text = "删除(&D)";
            DeleteToolStripMenuItem.Click += DeleteToolStripMenuItem_Click;
            // 
            // SplitToolStripMenuItem
            // 
            SplitToolStripMenuItem.Name = "SplitToolStripMenuItem";
            SplitToolStripMenuItem.Size = new Size(271, 6);
            // 
            // ExitToolStripMenuItem
            // 
            ExitToolStripMenuItem.Name = "ExitToolStripMenuItem";
            ExitToolStripMenuItem.ShortcutKeys = Keys.Alt | Keys.F4;
            ExitToolStripMenuItem.Size = new Size(274, 26);
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
            ExportToolStripMenuItem.Size = new Size(201, 26);
            ExportToolStripMenuItem.Text = "导出原始数据(&P)";
            // 
            // ExportAllToolStripMenuItem
            // 
            ExportAllToolStripMenuItem.Name = "ExportAllToolStripMenuItem";
            ExportAllToolStripMenuItem.Size = new Size(169, 26);
            ExportAllToolStripMenuItem.Text = "全部(&A)";
            ExportAllToolStripMenuItem.Click += ExportAllToolStripMenuItem_Click;
            // 
            // ExportCustomToolStripMenuItem
            // 
            ExportCustomToolStripMenuItem.Name = "ExportCustomToolStripMenuItem";
            ExportCustomToolStripMenuItem.Size = new Size(169, 26);
            ExportCustomToolStripMenuItem.Text = "自定义(&C)...";
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
            OptionToolStripMenuItem.Image = Properties.Resources.Settings;
            OptionToolStripMenuItem.Name = "OptionToolStripMenuItem";
            OptionToolStripMenuItem.Size = new Size(156, 26);
            OptionToolStripMenuItem.Text = "选项(&O)...";
            OptionToolStripMenuItem.Click += OptionToolStripMenuItem_Click;
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
            // toolStripMain
            // 
            toolStripMain.ImageScalingSize = new Size(20, 20);
            toolStripMain.Items.AddRange(new ToolStripItem[] { toolStripButtonOpen, toolStripSeparator1, toolStripButtonCut, toolStripButtonCopy, toolStripButtonMoveTo, toolStripButtonCopyTo, toolStripButtonRename, toolStripButtonDelete });
            toolStripMain.Location = new Point(0, 28);
            toolStripMain.Name = "toolStripMain";
            toolStripMain.Size = new Size(1307, 27);
            toolStripMain.TabIndex = 10;
            toolStripMain.Text = "toolStrip1";
            // 
            // toolStripButtonOpen
            // 
            toolStripButtonOpen.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButtonOpen.Image = Properties.Resources.OpenFile;
            toolStripButtonOpen.ImageTransparentColor = Color.Magenta;
            toolStripButtonOpen.Name = "toolStripButtonOpen";
            toolStripButtonOpen.Size = new Size(29, 24);
            toolStripButtonOpen.Text = "toolStripButton1";
            toolStripButtonOpen.Click += toolStripButtonOpen_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(6, 27);
            // 
            // toolStripButtonCut
            // 
            toolStripButtonCut.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButtonCut.Image = Properties.Resources.Cut;
            toolStripButtonCut.ImageTransparentColor = Color.Magenta;
            toolStripButtonCut.Name = "toolStripButtonCut";
            toolStripButtonCut.Size = new Size(29, 24);
            toolStripButtonCut.Text = "toolStripButton1";
            toolStripButtonCut.Click += toolStripButtonCut_Click;
            // 
            // toolStripButtonCopy
            // 
            toolStripButtonCopy.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButtonCopy.Image = Properties.Resources.Copy;
            toolStripButtonCopy.ImageTransparentColor = Color.Magenta;
            toolStripButtonCopy.Name = "toolStripButtonCopy";
            toolStripButtonCopy.Size = new Size(29, 24);
            toolStripButtonCopy.Text = "toolStripButton1";
            toolStripButtonCopy.Click += toolStripButtonCopy_Click;
            // 
            // toolStripButtonMoveTo
            // 
            toolStripButtonMoveTo.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButtonMoveTo.Image = Properties.Resources.MoveTo;
            toolStripButtonMoveTo.ImageTransparentColor = Color.Magenta;
            toolStripButtonMoveTo.Name = "toolStripButtonMoveTo";
            toolStripButtonMoveTo.Size = new Size(29, 24);
            toolStripButtonMoveTo.Text = "toolStripButton1";
            toolStripButtonMoveTo.Click += toolStripButtonMoveTo_Click;
            // 
            // toolStripButtonCopyTo
            // 
            toolStripButtonCopyTo.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButtonCopyTo.Image = Properties.Resources.CopyTo;
            toolStripButtonCopyTo.ImageTransparentColor = Color.Magenta;
            toolStripButtonCopyTo.Name = "toolStripButtonCopyTo";
            toolStripButtonCopyTo.Size = new Size(29, 24);
            toolStripButtonCopyTo.Text = "toolStripButton1";
            toolStripButtonCopyTo.Click += toolStripButtonCopyTo_Click;
            // 
            // toolStripButtonRename
            // 
            toolStripButtonRename.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButtonRename.Image = Properties.Resources.Rename;
            toolStripButtonRename.ImageTransparentColor = Color.Magenta;
            toolStripButtonRename.Name = "toolStripButtonRename";
            toolStripButtonRename.Size = new Size(29, 24);
            toolStripButtonRename.Text = "toolStripButton1";
            toolStripButtonRename.Click += toolStripButtonRename_Click;
            // 
            // toolStripButtonDelete
            // 
            toolStripButtonDelete.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButtonDelete.Image = Properties.Resources.Delete;
            toolStripButtonDelete.ImageTransparentColor = Color.Magenta;
            toolStripButtonDelete.Name = "toolStripButtonDelete";
            toolStripButtonDelete.Size = new Size(29, 24);
            toolStripButtonDelete.Text = "toolStripButton1";
            toolStripButtonDelete.Click += toolStripButtonDelete_Click;
            // 
            // FormMain
            // 
            AllowDrop = true;
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1307, 695);
            Controls.Add(toolStripMain);
            Controls.Add(treeViewFiles);
            Controls.Add(textBoxPath);
            Controls.Add(textBoxInfo);
            Controls.Add(dataGridInfo);
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
            toolStripMain.ResumeLayout(false);
            toolStripMain.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private OpenFileDialog openReplayDialog;
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
        private ToolStripMenuItem ToolToolStripMenuItem;
        private ToolStripMenuItem OptionToolStripMenuItem;
        private ToolStrip toolStripMain;
        private ToolStripButton toolStripButtonOpen;
        private ToolStripMenuItem OpenToolStripMenuItem;
        private ToolStripButton toolStripButtonCut;
        private ToolStripButton toolStripButtonCopy;
        private ToolStripButton toolStripButtonMoveTo;
        private ToolStripButton toolStripButtonCopyTo;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripButton toolStripButtonRename;
        private ToolStripButton toolStripButtonDelete;
        private ToolStripMenuItem CutToolStripMenuItem;
        private ToolStripMenuItem CopyToolStripMenuItem;
        private ToolStripSeparator toolStripMenuItem1;
        private ToolStripMenuItem MoveToToolStripMenuItem;
        private ToolStripMenuItem CopyToToolStripMenuItem;
        private ToolStripMenuItem DeleteToolStripMenuItem;
        private ToolStripMenuItem RenameToolStripMenuItem;
        private FolderBrowserDialog folderBrowserDialogMoveCopy;
    }
}
