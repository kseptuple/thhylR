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
            FirstReplayToolStripMenuItem = new ToolStripMenuItem();
            PreviousReplayToolStripMenuItem = new ToolStripMenuItem();
            NextReplayToolStripMenuItem = new ToolStripMenuItem();
            LastReplayToolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem2 = new ToolStripSeparator();
            ExitToolStripMenuItem = new ToolStripMenuItem();
            EditToolStripMenuItem = new ToolStripMenuItem();
            EncodingToolStripMenuItem = new ToolStripMenuItem();
            Encoding1ToolStripMenuItem = new ToolStripMenuItem();
            Encoding2ToolStripMenuItem = new ToolStripMenuItem();
            Encoding3ToolStripMenuItem = new ToolStripMenuItem();
            Encoding4ToolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem3 = new ToolStripSeparator();
            ExportToolStripMenuItem = new ToolStripMenuItem();
            ExportAllToolStripMenuItem = new ToolStripMenuItem();
            ExportCustomToolStripMenuItem = new ToolStripMenuItem();
            ToolToolStripMenuItem = new ToolStripMenuItem();
            OptionToolStripMenuItem = new ToolStripMenuItem();
            saveFileDialog = new SaveFileDialog();
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
            toolStripSeparator2 = new ToolStripSeparator();
            toolStripButtonFirst = new ToolStripButton();
            toolStripButtonPrevious = new ToolStripButton();
            toolStripButtonNext = new ToolStripButton();
            toolStripButtonLast = new ToolStripButton();
            folderBrowserDialogMoveCopy = new FolderBrowserDialog();
            splitContainerMain = new SplitContainer();
            treeViewFiles = new TreeView();
            splitContainerInfo = new SplitContainer();
            label1 = new Label();
            textBoxPath = new TextBox();
            dataGridInfo = new DataGridView();
            dataGridColumnName = new DataGridViewTextBoxColumn();
            dataGridColumnValue = new DataGridViewTextBoxColumn();
            label2 = new Label();
            comboBoxEncoding = new ComboBox();
            textBoxInfo = new TextBox();
            menuStripMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)fileSystemWatcherFolder).BeginInit();
            toolStripMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainerMain).BeginInit();
            splitContainerMain.Panel1.SuspendLayout();
            splitContainerMain.Panel2.SuspendLayout();
            splitContainerMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainerInfo).BeginInit();
            splitContainerInfo.Panel1.SuspendLayout();
            splitContainerInfo.Panel2.SuspendLayout();
            splitContainerInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridInfo).BeginInit();
            SuspendLayout();
            // 
            // openReplayDialog
            // 
            openReplayDialog.Filter = "录像文件|*.rpy";
            // 
            // menuStripMain
            // 
            menuStripMain.ImageScalingSize = new Size(20, 20);
            menuStripMain.Items.AddRange(new ToolStripItem[] { FileToolStripMenuItem, EditToolStripMenuItem, ToolToolStripMenuItem });
            menuStripMain.Location = new Point(0, 0);
            menuStripMain.Name = "menuStripMain";
            menuStripMain.Size = new Size(1330, 28);
            menuStripMain.TabIndex = 6;
            menuStripMain.Text = "menuStrip1";
            // 
            // FileToolStripMenuItem
            // 
            FileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { OpenToolStripMenuItem, toolStripMenuItem1, CutToolStripMenuItem, CopyToolStripMenuItem, MoveToToolStripMenuItem, CopyToToolStripMenuItem, RenameToolStripMenuItem, DeleteToolStripMenuItem, SplitToolStripMenuItem, FirstReplayToolStripMenuItem, PreviousReplayToolStripMenuItem, NextReplayToolStripMenuItem, LastReplayToolStripMenuItem, toolStripMenuItem2, ExitToolStripMenuItem });
            FileToolStripMenuItem.Name = "FileToolStripMenuItem";
            FileToolStripMenuItem.Size = new Size(71, 24);
            FileToolStripMenuItem.Text = "文件(&F)";
            // 
            // OpenToolStripMenuItem
            // 
            OpenToolStripMenuItem.Image = Properties.Resources.OpenFile;
            OpenToolStripMenuItem.Name = "OpenToolStripMenuItem";
            OpenToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.O;
            OpenToolStripMenuItem.Size = new Size(295, 26);
            OpenToolStripMenuItem.Text = "打开(&O)";
            OpenToolStripMenuItem.Click += OpenToolStripMenuItem_Click;
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new Size(292, 6);
            // 
            // CutToolStripMenuItem
            // 
            CutToolStripMenuItem.Image = Properties.Resources.Cut;
            CutToolStripMenuItem.Name = "CutToolStripMenuItem";
            CutToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.X;
            CutToolStripMenuItem.Size = new Size(295, 26);
            CutToolStripMenuItem.Text = "剪切(&T)";
            CutToolStripMenuItem.Click += CutToolStripMenuItem_Click;
            // 
            // CopyToolStripMenuItem
            // 
            CopyToolStripMenuItem.Image = Properties.Resources.Copy;
            CopyToolStripMenuItem.Name = "CopyToolStripMenuItem";
            CopyToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.C;
            CopyToolStripMenuItem.Size = new Size(295, 26);
            CopyToolStripMenuItem.Text = "复制(&C)";
            CopyToolStripMenuItem.Click += CopyToolStripMenuItem_Click;
            // 
            // MoveToToolStripMenuItem
            // 
            MoveToToolStripMenuItem.Image = Properties.Resources.MoveTo;
            MoveToToolStripMenuItem.Name = "MoveToToolStripMenuItem";
            MoveToToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.Shift | Keys.X;
            MoveToToolStripMenuItem.Size = new Size(295, 26);
            MoveToToolStripMenuItem.Text = "移动到(&M)...";
            MoveToToolStripMenuItem.Click += MoveToToolStripMenuItem_Click;
            // 
            // CopyToToolStripMenuItem
            // 
            CopyToToolStripMenuItem.Image = Properties.Resources.CopyTo;
            CopyToToolStripMenuItem.Name = "CopyToToolStripMenuItem";
            CopyToToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.Shift | Keys.C;
            CopyToToolStripMenuItem.Size = new Size(295, 26);
            CopyToToolStripMenuItem.Text = "复制到(&P)...";
            CopyToToolStripMenuItem.Click += CopyToToolStripMenuItem_Click;
            // 
            // RenameToolStripMenuItem
            // 
            RenameToolStripMenuItem.Image = Properties.Resources.Rename;
            RenameToolStripMenuItem.Name = "RenameToolStripMenuItem";
            RenameToolStripMenuItem.Size = new Size(295, 26);
            RenameToolStripMenuItem.Text = "重命名(&R)";
            RenameToolStripMenuItem.Click += RenameToolStripMenuItem_Click;
            // 
            // DeleteToolStripMenuItem
            // 
            DeleteToolStripMenuItem.Image = Properties.Resources.Delete;
            DeleteToolStripMenuItem.Name = "DeleteToolStripMenuItem";
            DeleteToolStripMenuItem.ShortcutKeys = Keys.Delete;
            DeleteToolStripMenuItem.Size = new Size(295, 26);
            DeleteToolStripMenuItem.Text = "删除(&D)";
            DeleteToolStripMenuItem.Click += DeleteToolStripMenuItem_Click;
            // 
            // SplitToolStripMenuItem
            // 
            SplitToolStripMenuItem.Name = "SplitToolStripMenuItem";
            SplitToolStripMenuItem.Size = new Size(292, 6);
            // 
            // FirstReplayToolStripMenuItem
            // 
            FirstReplayToolStripMenuItem.Image = Properties.Resources.First;
            FirstReplayToolStripMenuItem.Name = "FirstReplayToolStripMenuItem";
            FirstReplayToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+Home";
            FirstReplayToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.Home;
            FirstReplayToolStripMenuItem.Size = new Size(295, 26);
            FirstReplayToolStripMenuItem.Text = "第一个录像";
            FirstReplayToolStripMenuItem.Click += FirstReplayToolStripMenuItem_Click;
            // 
            // PreviousReplayToolStripMenuItem
            // 
            PreviousReplayToolStripMenuItem.Image = Properties.Resources.Previous;
            PreviousReplayToolStripMenuItem.Name = "PreviousReplayToolStripMenuItem";
            PreviousReplayToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.PageUp;
            PreviousReplayToolStripMenuItem.Size = new Size(295, 26);
            PreviousReplayToolStripMenuItem.Text = "上一个录像";
            PreviousReplayToolStripMenuItem.Click += PreviousReplayToolStripMenuItem_Click;
            // 
            // NextReplayToolStripMenuItem
            // 
            NextReplayToolStripMenuItem.Image = Properties.Resources.Next;
            NextReplayToolStripMenuItem.Name = "NextReplayToolStripMenuItem";
            NextReplayToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.Next;
            NextReplayToolStripMenuItem.Size = new Size(295, 26);
            NextReplayToolStripMenuItem.Text = "下一个录像";
            NextReplayToolStripMenuItem.Click += NextReplayToolStripMenuItem_Click;
            // 
            // LastReplayToolStripMenuItem
            // 
            LastReplayToolStripMenuItem.Image = Properties.Resources.Last;
            LastReplayToolStripMenuItem.Name = "LastReplayToolStripMenuItem";
            LastReplayToolStripMenuItem.ShortcutKeyDisplayString = "";
            LastReplayToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.End;
            LastReplayToolStripMenuItem.Size = new Size(295, 26);
            LastReplayToolStripMenuItem.Text = "最后一个录像";
            LastReplayToolStripMenuItem.Click += LastReplayToolStripMenuItem_Click;
            // 
            // toolStripMenuItem2
            // 
            toolStripMenuItem2.Name = "toolStripMenuItem2";
            toolStripMenuItem2.Size = new Size(292, 6);
            // 
            // ExitToolStripMenuItem
            // 
            ExitToolStripMenuItem.Name = "ExitToolStripMenuItem";
            ExitToolStripMenuItem.ShortcutKeys = Keys.Alt | Keys.F4;
            ExitToolStripMenuItem.Size = new Size(295, 26);
            ExitToolStripMenuItem.Text = "退出(&X)";
            ExitToolStripMenuItem.Click += ExitToolStripMenuItem_Click;
            // 
            // EditToolStripMenuItem
            // 
            EditToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { EncodingToolStripMenuItem, toolStripMenuItem3, ExportToolStripMenuItem });
            EditToolStripMenuItem.Name = "EditToolStripMenuItem";
            EditToolStripMenuItem.Size = new Size(71, 24);
            EditToolStripMenuItem.Text = "编辑(&E)";
            // 
            // EncodingToolStripMenuItem
            // 
            EncodingToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { Encoding1ToolStripMenuItem, Encoding2ToolStripMenuItem, Encoding3ToolStripMenuItem, Encoding4ToolStripMenuItem });
            EncodingToolStripMenuItem.Name = "EncodingToolStripMenuItem";
            EncodingToolStripMenuItem.Size = new Size(224, 26);
            EncodingToolStripMenuItem.Text = "编码(&N)";
            // 
            // Encoding1ToolStripMenuItem
            // 
            Encoding1ToolStripMenuItem.Name = "Encoding1ToolStripMenuItem";
            Encoding1ToolStripMenuItem.Size = new Size(224, 26);
            Encoding1ToolStripMenuItem.Text = "1";
            Encoding1ToolStripMenuItem.Click += Encoding1ToolStripMenuItem_Click;
            // 
            // Encoding2ToolStripMenuItem
            // 
            Encoding2ToolStripMenuItem.Name = "Encoding2ToolStripMenuItem";
            Encoding2ToolStripMenuItem.Size = new Size(224, 26);
            Encoding2ToolStripMenuItem.Text = "2";
            Encoding2ToolStripMenuItem.Click += Encoding2ToolStripMenuItem_Click;
            // 
            // Encoding3ToolStripMenuItem
            // 
            Encoding3ToolStripMenuItem.Name = "Encoding3ToolStripMenuItem";
            Encoding3ToolStripMenuItem.Size = new Size(224, 26);
            Encoding3ToolStripMenuItem.Text = "3";
            Encoding3ToolStripMenuItem.Click += Encoding3ToolStripMenuItem_Click;
            // 
            // Encoding4ToolStripMenuItem
            // 
            Encoding4ToolStripMenuItem.Name = "Encoding4ToolStripMenuItem";
            Encoding4ToolStripMenuItem.Size = new Size(224, 26);
            Encoding4ToolStripMenuItem.Text = "4";
            Encoding4ToolStripMenuItem.Click += Encoding4ToolStripMenuItem_Click;
            // 
            // toolStripMenuItem3
            // 
            toolStripMenuItem3.Name = "toolStripMenuItem3";
            toolStripMenuItem3.Size = new Size(221, 6);
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
            toolStripMain.Items.AddRange(new ToolStripItem[] { toolStripButtonOpen, toolStripSeparator1, toolStripButtonCut, toolStripButtonCopy, toolStripButtonMoveTo, toolStripButtonCopyTo, toolStripButtonRename, toolStripButtonDelete, toolStripSeparator2, toolStripButtonFirst, toolStripButtonPrevious, toolStripButtonNext, toolStripButtonLast });
            toolStripMain.Location = new Point(0, 28);
            toolStripMain.Name = "toolStripMain";
            toolStripMain.Size = new Size(1330, 27);
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
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(6, 27);
            // 
            // toolStripButtonFirst
            // 
            toolStripButtonFirst.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButtonFirst.Image = Properties.Resources.First;
            toolStripButtonFirst.ImageTransparentColor = Color.Magenta;
            toolStripButtonFirst.Name = "toolStripButtonFirst";
            toolStripButtonFirst.Size = new Size(29, 24);
            toolStripButtonFirst.Text = "toolStripButton1";
            toolStripButtonFirst.Click += toolStripButtonFirst_Click;
            // 
            // toolStripButtonPrevious
            // 
            toolStripButtonPrevious.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButtonPrevious.Image = Properties.Resources.Previous;
            toolStripButtonPrevious.ImageTransparentColor = Color.Magenta;
            toolStripButtonPrevious.Name = "toolStripButtonPrevious";
            toolStripButtonPrevious.Size = new Size(29, 24);
            toolStripButtonPrevious.Text = "toolStripButton1";
            toolStripButtonPrevious.Click += toolStripButtonPrevious_Click;
            // 
            // toolStripButtonNext
            // 
            toolStripButtonNext.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButtonNext.Image = Properties.Resources.Next;
            toolStripButtonNext.ImageTransparentColor = Color.Magenta;
            toolStripButtonNext.Name = "toolStripButtonNext";
            toolStripButtonNext.Size = new Size(29, 24);
            toolStripButtonNext.Text = "toolStripButton1";
            toolStripButtonNext.Click += toolStripButtonNext_Click;
            // 
            // toolStripButtonLast
            // 
            toolStripButtonLast.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButtonLast.Image = Properties.Resources.Last;
            toolStripButtonLast.ImageTransparentColor = Color.Magenta;
            toolStripButtonLast.Name = "toolStripButtonLast";
            toolStripButtonLast.Size = new Size(29, 24);
            toolStripButtonLast.Text = "toolStripButton1";
            toolStripButtonLast.Click += toolStripButtonLast_Click;
            // 
            // splitContainerMain
            // 
            splitContainerMain.Dock = DockStyle.Fill;
            splitContainerMain.Location = new Point(0, 55);
            splitContainerMain.Name = "splitContainerMain";
            // 
            // splitContainerMain.Panel1
            // 
            splitContainerMain.Panel1.Controls.Add(treeViewFiles);
            // 
            // splitContainerMain.Panel2
            // 
            splitContainerMain.Panel2.Controls.Add(splitContainerInfo);
            splitContainerMain.Size = new Size(1330, 553);
            splitContainerMain.SplitterDistance = 246;
            splitContainerMain.TabIndex = 12;
            // 
            // treeViewFiles
            // 
            treeViewFiles.Dock = DockStyle.Fill;
            treeViewFiles.DrawMode = TreeViewDrawMode.OwnerDrawText;
            treeViewFiles.HideSelection = false;
            treeViewFiles.Location = new Point(0, 0);
            treeViewFiles.Name = "treeViewFiles";
            treeViewFiles.Size = new Size(246, 553);
            treeViewFiles.TabIndex = 9;
            treeViewFiles.DrawNode += treeViewFiles_DrawNode;
            treeViewFiles.AfterSelect += treeViewFiles_AfterSelect;
            // 
            // splitContainerInfo
            // 
            splitContainerInfo.Dock = DockStyle.Fill;
            splitContainerInfo.Location = new Point(0, 0);
            splitContainerInfo.Name = "splitContainerInfo";
            // 
            // splitContainerInfo.Panel1
            // 
            splitContainerInfo.Panel1.Controls.Add(label1);
            splitContainerInfo.Panel1.Controls.Add(textBoxPath);
            splitContainerInfo.Panel1.Controls.Add(dataGridInfo);
            // 
            // splitContainerInfo.Panel2
            // 
            splitContainerInfo.Panel2.Controls.Add(label2);
            splitContainerInfo.Panel2.Controls.Add(comboBoxEncoding);
            splitContainerInfo.Panel2.Controls.Add(textBoxInfo);
            splitContainerInfo.Size = new Size(1080, 553);
            splitContainerInfo.SplitterDistance = 769;
            splitContainerInfo.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(3, 3);
            label1.Name = "label1";
            label1.Size = new Size(53, 20);
            label1.TabIndex = 15;
            label1.Text = "label1";
            // 
            // textBoxPath
            // 
            textBoxPath.AcceptsReturn = true;
            textBoxPath.AcceptsTab = true;
            textBoxPath.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBoxPath.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            textBoxPath.AutoCompleteSource = AutoCompleteSource.FileSystem;
            textBoxPath.Location = new Point(62, 1);
            textBoxPath.Name = "textBoxPath";
            textBoxPath.Size = new Size(707, 27);
            textBoxPath.TabIndex = 14;
            textBoxPath.KeyDown += textBoxPath_KeyDown;
            textBoxPath.PreviewKeyDown += textBoxPath_PreviewKeyDown;
            // 
            // dataGridInfo
            // 
            dataGridInfo.AllowUserToAddRows = false;
            dataGridInfo.AllowUserToDeleteRows = false;
            dataGridInfo.AllowUserToResizeRows = false;
            dataGridInfo.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
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
            dataGridInfo.Location = new Point(0, 33);
            dataGridInfo.MultiSelect = false;
            dataGridInfo.Name = "dataGridInfo";
            dataGridInfo.ReadOnly = true;
            dataGridInfo.RowHeadersVisible = false;
            dataGridInfo.RowHeadersWidth = 51;
            dataGridInfo.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridInfo.RowTemplate.Height = 29;
            dataGridInfo.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridInfo.ShowCellToolTips = false;
            dataGridInfo.Size = new Size(769, 520);
            dataGridInfo.TabIndex = 13;
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
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(3, 3);
            label2.Name = "label2";
            label2.Size = new Size(53, 20);
            label2.TabIndex = 8;
            label2.Text = "label2";
            // 
            // comboBoxEncoding
            // 
            comboBoxEncoding.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            comboBoxEncoding.DisplayMember = "Name";
            comboBoxEncoding.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxEncoding.FormattingEnabled = true;
            comboBoxEncoding.Location = new Point(62, 0);
            comboBoxEncoding.Name = "comboBoxEncoding";
            comboBoxEncoding.Size = new Size(245, 28);
            comboBoxEncoding.TabIndex = 7;
            comboBoxEncoding.ValueMember = "CodePage";
            comboBoxEncoding.SelectedIndexChanged += comboBoxEncoding_SelectedIndexChanged;
            // 
            // textBoxInfo
            // 
            textBoxInfo.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            textBoxInfo.Location = new Point(0, 33);
            textBoxInfo.Multiline = true;
            textBoxInfo.Name = "textBoxInfo";
            textBoxInfo.ReadOnly = true;
            textBoxInfo.ScrollBars = ScrollBars.Vertical;
            textBoxInfo.Size = new Size(307, 520);
            textBoxInfo.TabIndex = 6;
            // 
            // FormMain
            // 
            AllowDrop = true;
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1330, 608);
            Controls.Add(splitContainerMain);
            Controls.Add(toolStripMain);
            Controls.Add(menuStripMain);
            MainMenuStrip = menuStripMain;
            Name = "FormMain";
            Text = "Form1";
            DragDrop += FormMain_DragDrop;
            DragEnter += FormMain_DragEnter;
            menuStripMain.ResumeLayout(false);
            menuStripMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)fileSystemWatcherFolder).EndInit();
            toolStripMain.ResumeLayout(false);
            toolStripMain.PerformLayout();
            splitContainerMain.Panel1.ResumeLayout(false);
            splitContainerMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainerMain).EndInit();
            splitContainerMain.ResumeLayout(false);
            splitContainerInfo.Panel1.ResumeLayout(false);
            splitContainerInfo.Panel1.PerformLayout();
            splitContainerInfo.Panel2.ResumeLayout(false);
            splitContainerInfo.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainerInfo).EndInit();
            splitContainerInfo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridInfo).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private OpenFileDialog openReplayDialog;
        private MenuStrip menuStripMain;
        private ToolStripMenuItem FileToolStripMenuItem;
        private ToolStripSeparator SplitToolStripMenuItem;
        private ToolStripMenuItem EditToolStripMenuItem;
        private ToolStripMenuItem ExitToolStripMenuItem;
        private ToolStripMenuItem ExportToolStripMenuItem;
        private ToolStripMenuItem ExportAllToolStripMenuItem;
        private ToolStripMenuItem ExportCustomToolStripMenuItem;
        private SaveFileDialog saveFileDialog;
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
        private SplitContainer splitContainerMain;
        private SplitContainer splitContainerInfo;
        private TreeView treeViewFiles;
        private TextBox textBoxPath;
        private DataGridView dataGridInfo;
        private DataGridViewTextBoxColumn dataGridColumnName;
        private DataGridViewTextBoxColumn dataGridColumnValue;
        private TextBox textBoxInfo;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripButton toolStripButtonFirst;
        private ToolStripButton toolStripButtonPrevious;
        private ToolStripButton toolStripButtonNext;
        private ToolStripButton toolStripButtonLast;
        private ToolStripSeparator toolStripMenuItem2;
        private ToolStripMenuItem PreviousReplayToolStripMenuItem;
        private ToolStripMenuItem FirstReplayToolStripMenuItem;
        private ToolStripMenuItem NextReplayToolStripMenuItem;
        private ToolStripMenuItem LastReplayToolStripMenuItem;
        private ToolStripMenuItem EncodingToolStripMenuItem;
        private ToolStripSeparator toolStripMenuItem3;
        private ComboBox comboBoxEncoding;
        private Label label1;
        private Label label2;
        private ToolStripMenuItem Encoding1ToolStripMenuItem;
        private ToolStripMenuItem Encoding2ToolStripMenuItem;
        private ToolStripMenuItem Encoding3ToolStripMenuItem;
        private ToolStripMenuItem Encoding4ToolStripMenuItem;
    }
}
