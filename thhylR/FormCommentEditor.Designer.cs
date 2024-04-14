namespace thhylR
{
    partial class FormCommentEditor
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
            comboBoxEncoding = new ComboBox();
            label1 = new Label();
            buttonSave = new Button();
            buttonSaveAs = new Button();
            buttonClose = new Button();
            saveFileDialogComment = new SaveFileDialog();
            splitContainerMain = new SplitContainer();
            textBoxComment = new TextBox();
            label2 = new Label();
            textBoxPreview = new TextBox();
            ((System.ComponentModel.ISupportInitialize)splitContainerMain).BeginInit();
            splitContainerMain.Panel1.SuspendLayout();
            splitContainerMain.Panel2.SuspendLayout();
            splitContainerMain.SuspendLayout();
            SuspendLayout();
            // 
            // comboBoxEncoding
            // 
            comboBoxEncoding.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            comboBoxEncoding.DisplayMember = "Name";
            comboBoxEncoding.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxEncoding.FormattingEnabled = true;
            comboBoxEncoding.Location = new Point(118, 12);
            comboBoxEncoding.Name = "comboBoxEncoding";
            comboBoxEncoding.Size = new Size(430, 28);
            comboBoxEncoding.TabIndex = 1;
            comboBoxEncoding.ValueMember = "CodePage";
            comboBoxEncoding.SelectedIndexChanged += comboBoxEncoding_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 15);
            label1.Name = "label1";
            label1.Size = new Size(53, 20);
            label1.TabIndex = 2;
            label1.Text = "label1";
            // 
            // buttonSave
            // 
            buttonSave.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonSave.Location = new Point(254, 348);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(94, 29);
            buttonSave.TabIndex = 3;
            buttonSave.Text = "button1";
            buttonSave.UseVisualStyleBackColor = true;
            buttonSave.Click += buttonSave_Click;
            // 
            // buttonSaveAs
            // 
            buttonSaveAs.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonSaveAs.Location = new Point(354, 348);
            buttonSaveAs.Name = "buttonSaveAs";
            buttonSaveAs.Size = new Size(94, 29);
            buttonSaveAs.TabIndex = 4;
            buttonSaveAs.Text = "button1";
            buttonSaveAs.UseVisualStyleBackColor = true;
            buttonSaveAs.Click += buttonSaveAs_Click;
            // 
            // buttonClose
            // 
            buttonClose.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonClose.Location = new Point(454, 348);
            buttonClose.Name = "buttonClose";
            buttonClose.Size = new Size(94, 29);
            buttonClose.TabIndex = 5;
            buttonClose.Text = "button1";
            buttonClose.UseVisualStyleBackColor = true;
            buttonClose.Click += buttonClose_Click;
            // 
            // splitContainerMain
            // 
            splitContainerMain.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            splitContainerMain.IsSplitterFixed = true;
            splitContainerMain.Location = new Point(12, 46);
            splitContainerMain.Name = "splitContainerMain";
            // 
            // splitContainerMain.Panel1
            // 
            splitContainerMain.Panel1.Controls.Add(textBoxComment);
            // 
            // splitContainerMain.Panel2
            // 
            splitContainerMain.Panel2.Controls.Add(label2);
            splitContainerMain.Panel2.Controls.Add(textBoxPreview);
            splitContainerMain.Size = new Size(536, 296);
            splitContainerMain.SplitterDistance = 266;
            splitContainerMain.TabIndex = 6;
            // 
            // textBoxComment
            // 
            textBoxComment.AcceptsReturn = true;
            textBoxComment.AcceptsTab = true;
            textBoxComment.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            textBoxComment.Location = new Point(0, 26);
            textBoxComment.Multiline = true;
            textBoxComment.Name = "textBoxComment";
            textBoxComment.ScrollBars = ScrollBars.Vertical;
            textBoxComment.Size = new Size(264, 270);
            textBoxComment.TabIndex = 1;
            textBoxComment.TextChanged += textBoxComment_TextChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(3, 3);
            label2.Name = "label2";
            label2.Size = new Size(53, 20);
            label2.TabIndex = 3;
            label2.Text = "label2";
            // 
            // textBoxPreview
            // 
            textBoxPreview.AcceptsReturn = true;
            textBoxPreview.AcceptsTab = true;
            textBoxPreview.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            textBoxPreview.Location = new Point(3, 26);
            textBoxPreview.Multiline = true;
            textBoxPreview.Name = "textBoxPreview";
            textBoxPreview.ReadOnly = true;
            textBoxPreview.ScrollBars = ScrollBars.Vertical;
            textBoxPreview.Size = new Size(260, 270);
            textBoxPreview.TabIndex = 2;
            // 
            // FormCommentEditor
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(560, 396);
            Controls.Add(splitContainerMain);
            Controls.Add(buttonClose);
            Controls.Add(buttonSaveAs);
            Controls.Add(buttonSave);
            Controls.Add(label1);
            Controls.Add(comboBoxEncoding);
            MaximizeBox = false;
            MinimizeBox = false;
            MinimumSize = new Size(550, 420);
            Name = "FormCommentEditor";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "CommentEditor";
            FormClosing += FormCommentEditor_FormClosing;
            splitContainerMain.Panel1.ResumeLayout(false);
            splitContainerMain.Panel1.PerformLayout();
            splitContainerMain.Panel2.ResumeLayout(false);
            splitContainerMain.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainerMain).EndInit();
            splitContainerMain.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private ComboBox comboBoxEncoding;
        private Label label1;
        private Button buttonSave;
        private Button buttonSaveAs;
        private Button buttonClose;
        private SaveFileDialog saveFileDialogComment;
        private SplitContainer splitContainerMain;
        private TextBox textBoxComment;
        private TextBox textBoxPreview;
        private Label label2;
    }
}