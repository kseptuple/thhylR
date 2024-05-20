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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
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
            OpenShanghaiAliceToolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem4 = new ToolStripSeparator();
            ExitToolStripMenuItem = new ToolStripMenuItem();
            EditToolStripMenuItem = new ToolStripMenuItem();
            SaveReplayInfoToolStripMenuItem = new ToolStripMenuItem();
            CopyInfoToolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem5 = new ToolStripSeparator();
            EncodingToolStripMenuItem = new ToolStripMenuItem();
            Encoding1ToolStripMenuItem = new ToolStripMenuItem();
            Encoding2ToolStripMenuItem = new ToolStripMenuItem();
            Encoding3ToolStripMenuItem = new ToolStripMenuItem();
            Encoding4ToolStripMenuItem = new ToolStripMenuItem();
            EditCommentToolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem3 = new ToolStripSeparator();
            ViewKeysToolStripMenuItem = new ToolStripMenuItem();
            ExportToolStripMenuItem = new ToolStripMenuItem();
            ExportAllToolStripMenuItem = new ToolStripMenuItem();
            ExportCustomToolStripMenuItem = new ToolStripMenuItem();
            ToolToolStripMenuItem = new ToolStripMenuItem();
            OptionToolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem6 = new ToolStripSeparator();
            AboutToolStripMenuItem = new ToolStripMenuItem();
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
            toolStripSeparator3 = new ToolStripSeparator();
            toolStripButtonEditComment = new ToolStripButton();
            toolStripSeparator5 = new ToolStripSeparator();
            toolStripButtonViewKeys = new ToolStripButton();
            toolStripButtonExportAll = new ToolStripButton();
            toolStripButtonExportCustom = new ToolStripButton();
            toolStripSeparator4 = new ToolStripSeparator();
            toolStripButtonOption = new ToolStripButton();
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
            statusStripMain = new StatusStrip();
            toolStripStatusLabelInfo = new ToolStripStatusLabel();
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
            statusStripMain.SuspendLayout();
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
            menuStripMain.Padding = new Padding(3, 2, 0, 2);
            menuStripMain.Size = new Size(935, 25);
            menuStripMain.TabIndex = 6;
            menuStripMain.Text = "menuStrip1";
            // 
            // FileToolStripMenuItem
            // 
            FileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { OpenToolStripMenuItem, toolStripMenuItem1, CutToolStripMenuItem, CopyToolStripMenuItem, MoveToToolStripMenuItem, CopyToToolStripMenuItem, RenameToolStripMenuItem, DeleteToolStripMenuItem, SplitToolStripMenuItem, FirstReplayToolStripMenuItem, PreviousReplayToolStripMenuItem, NextReplayToolStripMenuItem, LastReplayToolStripMenuItem, toolStripMenuItem2, OpenShanghaiAliceToolStripMenuItem, toolStripMenuItem4, ExitToolStripMenuItem });
            FileToolStripMenuItem.Name = "FileToolStripMenuItem";
            FileToolStripMenuItem.Size = new Size(58, 21);
            FileToolStripMenuItem.Text = "文件(&F)";
            // 
            // OpenToolStripMenuItem
            // 
            OpenToolStripMenuItem.Image = Properties.Resources.OpenFile;
            OpenToolStripMenuItem.Name = "OpenToolStripMenuItem";
            OpenToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.O;
            OpenToolStripMenuItem.Size = new Size(239, 22);
            OpenToolStripMenuItem.Text = "打开(&O)";
            OpenToolStripMenuItem.Click += OpenToolStripMenuItem_Click;
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new Size(236, 6);
            // 
            // CutToolStripMenuItem
            // 
            CutToolStripMenuItem.Image = Properties.Resources.Cut;
            CutToolStripMenuItem.Name = "CutToolStripMenuItem";
            CutToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.X;
            CutToolStripMenuItem.Size = new Size(239, 22);
            CutToolStripMenuItem.Text = "剪切(&T)";
            CutToolStripMenuItem.Click += CutToolStripMenuItem_Click;
            // 
            // CopyToolStripMenuItem
            // 
            CopyToolStripMenuItem.Image = Properties.Resources.Copy;
            CopyToolStripMenuItem.Name = "CopyToolStripMenuItem";
            CopyToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.C;
            CopyToolStripMenuItem.Size = new Size(239, 22);
            CopyToolStripMenuItem.Text = "复制(&C)";
            CopyToolStripMenuItem.Click += CopyToolStripMenuItem_Click;
            // 
            // MoveToToolStripMenuItem
            // 
            MoveToToolStripMenuItem.Image = Properties.Resources.MoveTo;
            MoveToToolStripMenuItem.Name = "MoveToToolStripMenuItem";
            MoveToToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.Shift | Keys.X;
            MoveToToolStripMenuItem.Size = new Size(239, 22);
            MoveToToolStripMenuItem.Text = "移动到(&M)...";
            MoveToToolStripMenuItem.Click += MoveToToolStripMenuItem_Click;
            // 
            // CopyToToolStripMenuItem
            // 
            CopyToToolStripMenuItem.Image = Properties.Resources.CopyTo;
            CopyToToolStripMenuItem.Name = "CopyToToolStripMenuItem";
            CopyToToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.Shift | Keys.C;
            CopyToToolStripMenuItem.Size = new Size(239, 22);
            CopyToToolStripMenuItem.Text = "复制到(&P)...";
            CopyToToolStripMenuItem.Click += CopyToToolStripMenuItem_Click;
            // 
            // RenameToolStripMenuItem
            // 
            RenameToolStripMenuItem.Image = Properties.Resources.Rename;
            RenameToolStripMenuItem.Name = "RenameToolStripMenuItem";
            RenameToolStripMenuItem.ShortcutKeys = Keys.F2;
            RenameToolStripMenuItem.Size = new Size(239, 22);
            RenameToolStripMenuItem.Text = "重命名(&R)";
            RenameToolStripMenuItem.Click += RenameToolStripMenuItem_Click;
            // 
            // DeleteToolStripMenuItem
            // 
            DeleteToolStripMenuItem.Image = Properties.Resources.Delete;
            DeleteToolStripMenuItem.Name = "DeleteToolStripMenuItem";
            DeleteToolStripMenuItem.ShortcutKeys = Keys.Delete;
            DeleteToolStripMenuItem.Size = new Size(239, 22);
            DeleteToolStripMenuItem.Text = "删除(&D)";
            DeleteToolStripMenuItem.Click += DeleteToolStripMenuItem_Click;
            // 
            // SplitToolStripMenuItem
            // 
            SplitToolStripMenuItem.Name = "SplitToolStripMenuItem";
            SplitToolStripMenuItem.Size = new Size(236, 6);
            // 
            // FirstReplayToolStripMenuItem
            // 
            FirstReplayToolStripMenuItem.Image = Properties.Resources.First;
            FirstReplayToolStripMenuItem.Name = "FirstReplayToolStripMenuItem";
            FirstReplayToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+Home";
            FirstReplayToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.Home;
            FirstReplayToolStripMenuItem.Size = new Size(239, 22);
            FirstReplayToolStripMenuItem.Text = "第一个录像";
            FirstReplayToolStripMenuItem.Click += FirstReplayToolStripMenuItem_Click;
            // 
            // PreviousReplayToolStripMenuItem
            // 
            PreviousReplayToolStripMenuItem.Image = Properties.Resources.Previous;
            PreviousReplayToolStripMenuItem.Name = "PreviousReplayToolStripMenuItem";
            PreviousReplayToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.PageUp;
            PreviousReplayToolStripMenuItem.Size = new Size(239, 22);
            PreviousReplayToolStripMenuItem.Text = "上一个录像";
            PreviousReplayToolStripMenuItem.Click += PreviousReplayToolStripMenuItem_Click;
            // 
            // NextReplayToolStripMenuItem
            // 
            NextReplayToolStripMenuItem.Image = Properties.Resources.Next;
            NextReplayToolStripMenuItem.Name = "NextReplayToolStripMenuItem";
            NextReplayToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.Next;
            NextReplayToolStripMenuItem.Size = new Size(239, 22);
            NextReplayToolStripMenuItem.Text = "下一个录像";
            NextReplayToolStripMenuItem.Click += NextReplayToolStripMenuItem_Click;
            // 
            // LastReplayToolStripMenuItem
            // 
            LastReplayToolStripMenuItem.Image = Properties.Resources.Last;
            LastReplayToolStripMenuItem.Name = "LastReplayToolStripMenuItem";
            LastReplayToolStripMenuItem.ShortcutKeyDisplayString = "";
            LastReplayToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.End;
            LastReplayToolStripMenuItem.Size = new Size(239, 22);
            LastReplayToolStripMenuItem.Text = "最后一个录像";
            LastReplayToolStripMenuItem.Click += LastReplayToolStripMenuItem_Click;
            // 
            // toolStripMenuItem2
            // 
            toolStripMenuItem2.Name = "toolStripMenuItem2";
            toolStripMenuItem2.Size = new Size(236, 6);
            // 
            // OpenShanghaiAliceToolStripMenuItem
            // 
            OpenShanghaiAliceToolStripMenuItem.Name = "OpenShanghaiAliceToolStripMenuItem";
            OpenShanghaiAliceToolStripMenuItem.Size = new Size(239, 22);
            OpenShanghaiAliceToolStripMenuItem.Text = "打开ShanghaiAlice文件夹";
            OpenShanghaiAliceToolStripMenuItem.Click += OpenShanghaiAliceToolStripMenuItem_Click;
            // 
            // toolStripMenuItem4
            // 
            toolStripMenuItem4.Name = "toolStripMenuItem4";
            toolStripMenuItem4.Size = new Size(236, 6);
            // 
            // ExitToolStripMenuItem
            // 
            ExitToolStripMenuItem.Name = "ExitToolStripMenuItem";
            ExitToolStripMenuItem.ShortcutKeys = Keys.Alt | Keys.F4;
            ExitToolStripMenuItem.Size = new Size(239, 22);
            ExitToolStripMenuItem.Text = "退出(&X)";
            ExitToolStripMenuItem.Click += ExitToolStripMenuItem_Click;
            // 
            // EditToolStripMenuItem
            // 
            EditToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { SaveReplayInfoToolStripMenuItem, CopyInfoToolStripMenuItem, toolStripMenuItem5, EncodingToolStripMenuItem, EditCommentToolStripMenuItem, toolStripMenuItem3, ViewKeysToolStripMenuItem, ExportToolStripMenuItem });
            EditToolStripMenuItem.Name = "EditToolStripMenuItem";
            EditToolStripMenuItem.Size = new Size(59, 21);
            EditToolStripMenuItem.Text = "编辑(&E)";
            // 
            // SaveReplayInfoToolStripMenuItem
            // 
            SaveReplayInfoToolStripMenuItem.Name = "SaveReplayInfoToolStripMenuItem";
            SaveReplayInfoToolStripMenuItem.Size = new Size(172, 22);
            SaveReplayInfoToolStripMenuItem.Text = "保存录像信息";
            SaveReplayInfoToolStripMenuItem.Click += SaveReplayInfoToolStripMenuItem_Click;
            // 
            // CopyInfoToolStripMenuItem
            // 
            CopyInfoToolStripMenuItem.Name = "CopyInfoToolStripMenuItem";
            CopyInfoToolStripMenuItem.Size = new Size(172, 22);
            CopyInfoToolStripMenuItem.Text = "复制信息到剪贴板";
            CopyInfoToolStripMenuItem.Click += CopyInfoToolStripMenuItem_Click;
            // 
            // toolStripMenuItem5
            // 
            toolStripMenuItem5.Name = "toolStripMenuItem5";
            toolStripMenuItem5.Size = new Size(169, 6);
            // 
            // EncodingToolStripMenuItem
            // 
            EncodingToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { Encoding1ToolStripMenuItem, Encoding2ToolStripMenuItem, Encoding3ToolStripMenuItem, Encoding4ToolStripMenuItem });
            EncodingToolStripMenuItem.Name = "EncodingToolStripMenuItem";
            EncodingToolStripMenuItem.Size = new Size(172, 22);
            EncodingToolStripMenuItem.Text = "编码(&N)";
            // 
            // Encoding1ToolStripMenuItem
            // 
            Encoding1ToolStripMenuItem.Name = "Encoding1ToolStripMenuItem";
            Encoding1ToolStripMenuItem.Size = new Size(83, 22);
            Encoding1ToolStripMenuItem.Text = "1";
            Encoding1ToolStripMenuItem.Click += Encoding1ToolStripMenuItem_Click;
            // 
            // Encoding2ToolStripMenuItem
            // 
            Encoding2ToolStripMenuItem.Name = "Encoding2ToolStripMenuItem";
            Encoding2ToolStripMenuItem.Size = new Size(83, 22);
            Encoding2ToolStripMenuItem.Text = "2";
            Encoding2ToolStripMenuItem.Click += Encoding2ToolStripMenuItem_Click;
            // 
            // Encoding3ToolStripMenuItem
            // 
            Encoding3ToolStripMenuItem.Name = "Encoding3ToolStripMenuItem";
            Encoding3ToolStripMenuItem.Size = new Size(83, 22);
            Encoding3ToolStripMenuItem.Text = "3";
            Encoding3ToolStripMenuItem.Click += Encoding3ToolStripMenuItem_Click;
            // 
            // Encoding4ToolStripMenuItem
            // 
            Encoding4ToolStripMenuItem.Name = "Encoding4ToolStripMenuItem";
            Encoding4ToolStripMenuItem.Size = new Size(83, 22);
            Encoding4ToolStripMenuItem.Text = "4";
            Encoding4ToolStripMenuItem.Click += Encoding4ToolStripMenuItem_Click;
            // 
            // EditCommentToolStripMenuItem
            // 
            EditCommentToolStripMenuItem.Image = Properties.Resources.EditComment;
            EditCommentToolStripMenuItem.Name = "EditCommentToolStripMenuItem";
            EditCommentToolStripMenuItem.Size = new Size(172, 22);
            EditCommentToolStripMenuItem.Text = "编辑注释(&M)...";
            EditCommentToolStripMenuItem.Click += EditCommentToolStripMenuItem_Click;
            // 
            // toolStripMenuItem3
            // 
            toolStripMenuItem3.Name = "toolStripMenuItem3";
            toolStripMenuItem3.Size = new Size(169, 6);
            // 
            // ViewKeysToolStripMenuItem
            // 
            ViewKeysToolStripMenuItem.Image = Properties.Resources.Keyboard;
            ViewKeysToolStripMenuItem.Name = "ViewKeysToolStripMenuItem";
            ViewKeysToolStripMenuItem.Size = new Size(172, 22);
            ViewKeysToolStripMenuItem.Text = "查看按键(&K)...";
            ViewKeysToolStripMenuItem.Click += ViewKeysToolStripMenuItem_Click;
            // 
            // ExportToolStripMenuItem
            // 
            ExportToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { ExportAllToolStripMenuItem, ExportCustomToolStripMenuItem });
            ExportToolStripMenuItem.Image = Properties.Resources.Export;
            ExportToolStripMenuItem.Name = "ExportToolStripMenuItem";
            ExportToolStripMenuItem.Size = new Size(172, 22);
            ExportToolStripMenuItem.Text = "导出原始数据(&P)";
            // 
            // ExportAllToolStripMenuItem
            // 
            ExportAllToolStripMenuItem.Image = Properties.Resources.ExportFile;
            ExportAllToolStripMenuItem.Name = "ExportAllToolStripMenuItem";
            ExportAllToolStripMenuItem.Size = new Size(137, 22);
            ExportAllToolStripMenuItem.Text = "全部(&A)";
            ExportAllToolStripMenuItem.Click += ExportAllToolStripMenuItem_Click;
            // 
            // ExportCustomToolStripMenuItem
            // 
            ExportCustomToolStripMenuItem.Image = Properties.Resources.ExportFilter;
            ExportCustomToolStripMenuItem.Name = "ExportCustomToolStripMenuItem";
            ExportCustomToolStripMenuItem.Size = new Size(137, 22);
            ExportCustomToolStripMenuItem.Text = "自定义(&C)...";
            ExportCustomToolStripMenuItem.Click += ExportCustomToolStripMenuItem_Click;
            // 
            // ToolToolStripMenuItem
            // 
            ToolToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { OptionToolStripMenuItem, toolStripMenuItem6, AboutToolStripMenuItem });
            ToolToolStripMenuItem.Name = "ToolToolStripMenuItem";
            ToolToolStripMenuItem.Size = new Size(59, 21);
            ToolToolStripMenuItem.Text = "工具(&T)";
            // 
            // OptionToolStripMenuItem
            // 
            OptionToolStripMenuItem.Image = Properties.Resources.Settings;
            OptionToolStripMenuItem.Name = "OptionToolStripMenuItem";
            OptionToolStripMenuItem.Size = new Size(127, 22);
            OptionToolStripMenuItem.Text = "选项(&O)...";
            OptionToolStripMenuItem.Click += OptionToolStripMenuItem_Click;
            // 
            // toolStripMenuItem6
            // 
            toolStripMenuItem6.Name = "toolStripMenuItem6";
            toolStripMenuItem6.Size = new Size(124, 6);
            // 
            // AboutToolStripMenuItem
            // 
            AboutToolStripMenuItem.Name = "AboutToolStripMenuItem";
            AboutToolStripMenuItem.Size = new Size(127, 22);
            AboutToolStripMenuItem.Text = "关于(&A)...";
            AboutToolStripMenuItem.Click += AboutToolStripMenuItem_Click;
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
            toolStripMain.Items.AddRange(new ToolStripItem[] { toolStripButtonOpen, toolStripSeparator1, toolStripButtonCut, toolStripButtonCopy, toolStripButtonMoveTo, toolStripButtonCopyTo, toolStripButtonRename, toolStripButtonDelete, toolStripSeparator2, toolStripButtonFirst, toolStripButtonPrevious, toolStripButtonNext, toolStripButtonLast, toolStripSeparator3, toolStripButtonEditComment, toolStripSeparator5, toolStripButtonViewKeys, toolStripButtonExportAll, toolStripButtonExportCustom, toolStripSeparator4, toolStripButtonOption });
            toolStripMain.Location = new Point(0, 25);
            toolStripMain.Name = "toolStripMain";
            toolStripMain.Size = new Size(935, 27);
            toolStripMain.TabIndex = 10;
            toolStripMain.Text = "toolStrip1";
            // 
            // toolStripButtonOpen
            // 
            toolStripButtonOpen.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButtonOpen.Image = Properties.Resources.OpenFile;
            toolStripButtonOpen.ImageTransparentColor = Color.Magenta;
            toolStripButtonOpen.Name = "toolStripButtonOpen";
            toolStripButtonOpen.Size = new Size(24, 24);
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
            toolStripButtonCut.Size = new Size(24, 24);
            toolStripButtonCut.Text = "toolStripButton1";
            toolStripButtonCut.Click += toolStripButtonCut_Click;
            // 
            // toolStripButtonCopy
            // 
            toolStripButtonCopy.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButtonCopy.Image = Properties.Resources.Copy;
            toolStripButtonCopy.ImageTransparentColor = Color.Magenta;
            toolStripButtonCopy.Name = "toolStripButtonCopy";
            toolStripButtonCopy.Size = new Size(24, 24);
            toolStripButtonCopy.Text = "toolStripButton1";
            toolStripButtonCopy.Click += toolStripButtonCopy_Click;
            // 
            // toolStripButtonMoveTo
            // 
            toolStripButtonMoveTo.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButtonMoveTo.Image = Properties.Resources.MoveTo;
            toolStripButtonMoveTo.ImageTransparentColor = Color.Magenta;
            toolStripButtonMoveTo.Name = "toolStripButtonMoveTo";
            toolStripButtonMoveTo.Size = new Size(24, 24);
            toolStripButtonMoveTo.Text = "toolStripButton1";
            toolStripButtonMoveTo.Click += toolStripButtonMoveTo_Click;
            // 
            // toolStripButtonCopyTo
            // 
            toolStripButtonCopyTo.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButtonCopyTo.Image = Properties.Resources.CopyTo;
            toolStripButtonCopyTo.ImageTransparentColor = Color.Magenta;
            toolStripButtonCopyTo.Name = "toolStripButtonCopyTo";
            toolStripButtonCopyTo.Size = new Size(24, 24);
            toolStripButtonCopyTo.Text = "toolStripButton1";
            toolStripButtonCopyTo.Click += toolStripButtonCopyTo_Click;
            // 
            // toolStripButtonRename
            // 
            toolStripButtonRename.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButtonRename.Image = Properties.Resources.Rename;
            toolStripButtonRename.ImageTransparentColor = Color.Magenta;
            toolStripButtonRename.Name = "toolStripButtonRename";
            toolStripButtonRename.Size = new Size(24, 24);
            toolStripButtonRename.Text = "toolStripButton1";
            toolStripButtonRename.Click += toolStripButtonRename_Click;
            // 
            // toolStripButtonDelete
            // 
            toolStripButtonDelete.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButtonDelete.Image = Properties.Resources.Delete;
            toolStripButtonDelete.ImageTransparentColor = Color.Magenta;
            toolStripButtonDelete.Name = "toolStripButtonDelete";
            toolStripButtonDelete.Size = new Size(24, 24);
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
            toolStripButtonFirst.Size = new Size(24, 24);
            toolStripButtonFirst.Text = "toolStripButton1";
            toolStripButtonFirst.Click += toolStripButtonFirst_Click;
            // 
            // toolStripButtonPrevious
            // 
            toolStripButtonPrevious.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButtonPrevious.Image = Properties.Resources.Previous;
            toolStripButtonPrevious.ImageTransparentColor = Color.Magenta;
            toolStripButtonPrevious.Name = "toolStripButtonPrevious";
            toolStripButtonPrevious.Size = new Size(24, 24);
            toolStripButtonPrevious.Text = "toolStripButton1";
            toolStripButtonPrevious.Click += toolStripButtonPrevious_Click;
            // 
            // toolStripButtonNext
            // 
            toolStripButtonNext.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButtonNext.Image = Properties.Resources.Next;
            toolStripButtonNext.ImageTransparentColor = Color.Magenta;
            toolStripButtonNext.Name = "toolStripButtonNext";
            toolStripButtonNext.Size = new Size(24, 24);
            toolStripButtonNext.Text = "toolStripButton1";
            toolStripButtonNext.Click += toolStripButtonNext_Click;
            // 
            // toolStripButtonLast
            // 
            toolStripButtonLast.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButtonLast.Image = Properties.Resources.Last;
            toolStripButtonLast.ImageTransparentColor = Color.Magenta;
            toolStripButtonLast.Name = "toolStripButtonLast";
            toolStripButtonLast.Size = new Size(24, 24);
            toolStripButtonLast.Text = "toolStripButton1";
            toolStripButtonLast.Click += toolStripButtonLast_Click;
            // 
            // toolStripSeparator3
            // 
            toolStripSeparator3.Name = "toolStripSeparator3";
            toolStripSeparator3.Size = new Size(6, 27);
            // 
            // toolStripButtonEditComment
            // 
            toolStripButtonEditComment.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButtonEditComment.Image = Properties.Resources.EditComment;
            toolStripButtonEditComment.ImageTransparentColor = Color.Magenta;
            toolStripButtonEditComment.Name = "toolStripButtonEditComment";
            toolStripButtonEditComment.Size = new Size(24, 24);
            toolStripButtonEditComment.Text = "toolStripButton1";
            toolStripButtonEditComment.Click += toolStripButtonEditComment_Click;
            // 
            // toolStripSeparator5
            // 
            toolStripSeparator5.Name = "toolStripSeparator5";
            toolStripSeparator5.Size = new Size(6, 27);
            // 
            // toolStripButtonViewKeys
            // 
            toolStripButtonViewKeys.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButtonViewKeys.Image = Properties.Resources.Keyboard;
            toolStripButtonViewKeys.ImageTransparentColor = Color.Magenta;
            toolStripButtonViewKeys.Name = "toolStripButtonViewKeys";
            toolStripButtonViewKeys.Size = new Size(24, 24);
            toolStripButtonViewKeys.Text = "toolStripButton1";
            toolStripButtonViewKeys.Click += toolStripButtonViewKeys_Click;
            // 
            // toolStripButtonExportAll
            // 
            toolStripButtonExportAll.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButtonExportAll.Image = Properties.Resources.ExportFile;
            toolStripButtonExportAll.ImageTransparentColor = Color.Magenta;
            toolStripButtonExportAll.Name = "toolStripButtonExportAll";
            toolStripButtonExportAll.Size = new Size(24, 24);
            toolStripButtonExportAll.Text = "toolStripButton2";
            toolStripButtonExportAll.Click += toolStripButtonExportAll_Click;
            // 
            // toolStripButtonExportCustom
            // 
            toolStripButtonExportCustom.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButtonExportCustom.Image = Properties.Resources.ExportFilter;
            toolStripButtonExportCustom.ImageTransparentColor = Color.Magenta;
            toolStripButtonExportCustom.Name = "toolStripButtonExportCustom";
            toolStripButtonExportCustom.Size = new Size(24, 24);
            toolStripButtonExportCustom.Text = "toolStripButton1";
            toolStripButtonExportCustom.Click += toolStripButtonExportCustom_Click;
            // 
            // toolStripSeparator4
            // 
            toolStripSeparator4.Name = "toolStripSeparator4";
            toolStripSeparator4.Size = new Size(6, 27);
            // 
            // toolStripButtonOption
            // 
            toolStripButtonOption.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButtonOption.Image = Properties.Resources.Settings;
            toolStripButtonOption.ImageTransparentColor = Color.Magenta;
            toolStripButtonOption.Name = "toolStripButtonOption";
            toolStripButtonOption.Size = new Size(24, 24);
            toolStripButtonOption.Text = "toolStripButton1";
            toolStripButtonOption.Click += toolStripButtonOption_Click;
            // 
            // splitContainerMain
            // 
            splitContainerMain.Dock = DockStyle.Fill;
            splitContainerMain.Location = new Point(0, 52);
            splitContainerMain.Margin = new Padding(2, 3, 2, 3);
            splitContainerMain.Name = "splitContainerMain";
            // 
            // splitContainerMain.Panel1
            // 
            splitContainerMain.Panel1.Controls.Add(treeViewFiles);
            splitContainerMain.Panel1MinSize = 200;
            // 
            // splitContainerMain.Panel2
            // 
            splitContainerMain.Panel2.Controls.Add(splitContainerInfo);
            splitContainerMain.Panel2MinSize = 660;
            splitContainerMain.Size = new Size(935, 434);
            splitContainerMain.SplitterDistance = 207;
            splitContainerMain.SplitterWidth = 2;
            splitContainerMain.TabIndex = 12;
            // 
            // treeViewFiles
            // 
            treeViewFiles.Dock = DockStyle.Fill;
            treeViewFiles.DrawMode = TreeViewDrawMode.OwnerDrawText;
            treeViewFiles.HideSelection = false;
            treeViewFiles.Location = new Point(0, 0);
            treeViewFiles.Margin = new Padding(2, 3, 2, 3);
            treeViewFiles.Name = "treeViewFiles";
            treeViewFiles.Size = new Size(207, 434);
            treeViewFiles.TabIndex = 9;
            treeViewFiles.DrawNode += treeViewFiles_DrawNode;
            treeViewFiles.AfterSelect += treeViewFiles_AfterSelect;
            // 
            // splitContainerInfo
            // 
            splitContainerInfo.Dock = DockStyle.Fill;
            splitContainerInfo.Location = new Point(0, 0);
            splitContainerInfo.Margin = new Padding(2, 3, 2, 3);
            splitContainerInfo.Name = "splitContainerInfo";
            // 
            // splitContainerInfo.Panel1
            // 
            splitContainerInfo.Panel1.Controls.Add(label1);
            splitContainerInfo.Panel1.Controls.Add(textBoxPath);
            splitContainerInfo.Panel1.Controls.Add(dataGridInfo);
            splitContainerInfo.Panel1MinSize = 400;
            // 
            // splitContainerInfo.Panel2
            // 
            splitContainerInfo.Panel2.Controls.Add(label2);
            splitContainerInfo.Panel2.Controls.Add(comboBoxEncoding);
            splitContainerInfo.Panel2.Controls.Add(textBoxInfo);
            splitContainerInfo.Panel2MinSize = 250;
            splitContainerInfo.Size = new Size(726, 434);
            splitContainerInfo.SplitterDistance = 462;
            splitContainerInfo.SplitterWidth = 2;
            splitContainerInfo.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(2, 3);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(43, 17);
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
            textBoxPath.Location = new Point(49, 1);
            textBoxPath.Margin = new Padding(2, 3, 2, 3);
            textBoxPath.Name = "textBoxPath";
            textBoxPath.Size = new Size(415, 23);
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
            dataGridInfo.Location = new Point(0, 23);
            dataGridInfo.Margin = new Padding(2, 3, 2, 3);
            dataGridInfo.MultiSelect = false;
            dataGridInfo.Name = "dataGridInfo";
            dataGridInfo.ReadOnly = true;
            dataGridInfo.RowHeadersVisible = false;
            dataGridInfo.RowHeadersWidth = 51;
            dataGridInfo.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridInfo.RowTemplate.Height = 29;
            dataGridInfo.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridInfo.ShowCellToolTips = false;
            dataGridInfo.Size = new Size(464, 411);
            dataGridInfo.TabIndex = 13;
            dataGridInfo.SelectionChanged += dataGridInfo_SelectionChanged;
            // 
            // dataGridColumnName
            // 
            dataGridColumnName.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridColumnName.DataPropertyName = "Name";
            dataGridColumnName.FillWeight = 30F;
            dataGridColumnName.HeaderText = "Name";
            dataGridColumnName.MinimumWidth = 6;
            dataGridColumnName.Name = "dataGridColumnName";
            dataGridColumnName.ReadOnly = true;
            // 
            // dataGridColumnValue
            // 
            dataGridColumnValue.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridColumnValue.DataPropertyName = "DisplayValue";
            dataGridColumnValue.FillWeight = 70F;
            dataGridColumnValue.HeaderText = "DisplayValue";
            dataGridColumnValue.MinimumWidth = 6;
            dataGridColumnValue.Name = "dataGridColumnValue";
            dataGridColumnValue.ReadOnly = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(2, 3);
            label2.Margin = new Padding(2, 0, 2, 0);
            label2.Name = "label2";
            label2.Size = new Size(43, 17);
            label2.TabIndex = 8;
            label2.Text = "label2";
            // 
            // comboBoxEncoding
            // 
            comboBoxEncoding.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            comboBoxEncoding.DisplayMember = "Name";
            comboBoxEncoding.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxEncoding.FormattingEnabled = true;
            comboBoxEncoding.Location = new Point(49, 0);
            comboBoxEncoding.Margin = new Padding(2, 3, 2, 3);
            comboBoxEncoding.Name = "comboBoxEncoding";
            comboBoxEncoding.Size = new Size(239, 25);
            comboBoxEncoding.TabIndex = 7;
            comboBoxEncoding.ValueMember = "CodePage";
            comboBoxEncoding.SelectedIndexChanged += comboBoxEncoding_SelectedIndexChanged;
            // 
            // textBoxInfo
            // 
            textBoxInfo.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            textBoxInfo.Location = new Point(0, 23);
            textBoxInfo.Margin = new Padding(2, 3, 2, 3);
            textBoxInfo.Multiline = true;
            textBoxInfo.Name = "textBoxInfo";
            textBoxInfo.ReadOnly = true;
            textBoxInfo.ScrollBars = ScrollBars.Vertical;
            textBoxInfo.Size = new Size(288, 411);
            textBoxInfo.TabIndex = 6;
            // 
            // statusStripMain
            // 
            statusStripMain.ImageScalingSize = new Size(20, 20);
            statusStripMain.Items.AddRange(new ToolStripItem[] { toolStripStatusLabelInfo });
            statusStripMain.Location = new Point(0, 486);
            statusStripMain.Name = "statusStripMain";
            statusStripMain.Padding = new Padding(1, 0, 7, 0);
            statusStripMain.Size = new Size(935, 25);
            statusStripMain.TabIndex = 13;
            statusStripMain.Text = "statusStrip1";
            // 
            // toolStripStatusLabelInfo
            // 
            toolStripStatusLabelInfo.Image = Properties.Resources.StatusWarning;
            toolStripStatusLabelInfo.IsLink = true;
            toolStripStatusLabelInfo.Name = "toolStripStatusLabelInfo";
            toolStripStatusLabelInfo.Size = new Size(151, 20);
            toolStripStatusLabelInfo.Text = "toolStripStatusLabel1";
            toolStripStatusLabelInfo.Click += toolStripStatusLabelInfo_Click;
            // 
            // FormMain
            // 
            AllowDrop = true;
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(935, 511);
            Controls.Add(splitContainerMain);
            Controls.Add(statusStripMain);
            Controls.Add(toolStripMain);
            Controls.Add(menuStripMain);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = menuStripMain;
            Margin = new Padding(2, 3, 2, 3);
            MinimumSize = new Size(885, 550);
            Name = "FormMain";
            StartPosition = FormStartPosition.Manual;
            Text = "Form1";
            FormClosing += FormMain_FormClosing;
            Shown += FormMain_Shown;
            DpiChanged += FormMain_DpiChanged;
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
            statusStripMain.ResumeLayout(false);
            statusStripMain.PerformLayout();
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
        private ToolStripMenuItem EditCommentToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator3;
        private ToolStripButton toolStripButtonEditComment;
        private ToolStripButton toolStripButtonOption;
        private ToolStripSeparator toolStripSeparator4;
        private ToolStripSeparator toolStripSeparator5;
        private ToolStripButton toolStripButtonExportAll;
        private ToolStripButton toolStripButtonExportCustom;
        private DataGridViewTextBoxColumn dataGridColumnName;
        private DataGridViewTextBoxColumn dataGridColumnValue;
        private StatusStrip statusStripMain;
        private ToolStripStatusLabel toolStripStatusLabelInfo;
        private ToolStripMenuItem ViewKeysToolStripMenuItem;
        private ToolStripButton toolStripButtonViewKeys;
        private ToolStripMenuItem OpenShanghaiAliceToolStripMenuItem;
        private ToolStripSeparator toolStripMenuItem4;
        private ToolStripMenuItem SaveReplayInfoToolStripMenuItem;
        private ToolStripMenuItem CopyInfoToolStripMenuItem;
        private ToolStripSeparator toolStripMenuItem5;
        private ToolStripMenuItem AboutToolStripMenuItem;
        private ToolStripSeparator toolStripMenuItem6;
    }
}
