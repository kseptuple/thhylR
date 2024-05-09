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
            comboBoxEncoding.Location = new Point(92, 10);
            comboBoxEncoding.Margin = new Padding(2, 3, 2, 3);
            comboBoxEncoding.Name = "comboBoxEncoding";
            comboBoxEncoding.Size = new Size(335, 25);
            comboBoxEncoding.TabIndex = 1;
            comboBoxEncoding.ValueMember = "CodePage";
            comboBoxEncoding.SelectedIndexChanged += comboBoxEncoding_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(9, 13);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(43, 17);
            label1.TabIndex = 2;
            label1.Text = "label1";
            // 
            // buttonSave
            // 
            buttonSave.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonSave.Location = new Point(198, 302);
            buttonSave.Margin = new Padding(2, 3, 2, 3);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(73, 25);
            buttonSave.TabIndex = 3;
            buttonSave.Text = "button1";
            buttonSave.UseVisualStyleBackColor = true;
            buttonSave.Click += buttonSave_Click;
            // 
            // buttonSaveAs
            // 
            buttonSaveAs.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonSaveAs.Location = new Point(275, 302);
            buttonSaveAs.Margin = new Padding(2, 3, 2, 3);
            buttonSaveAs.Name = "buttonSaveAs";
            buttonSaveAs.Size = new Size(73, 25);
            buttonSaveAs.TabIndex = 4;
            buttonSaveAs.Text = "button1";
            buttonSaveAs.UseVisualStyleBackColor = true;
            buttonSaveAs.Click += buttonSaveAs_Click;
            // 
            // buttonClose
            // 
            buttonClose.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonClose.Location = new Point(353, 302);
            buttonClose.Margin = new Padding(2, 3, 2, 3);
            buttonClose.Name = "buttonClose";
            buttonClose.Size = new Size(73, 25);
            buttonClose.TabIndex = 5;
            buttonClose.Text = "button1";
            buttonClose.UseVisualStyleBackColor = true;
            buttonClose.Click += buttonClose_Click;
            // 
            // splitContainerMain
            // 
            splitContainerMain.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            splitContainerMain.IsSplitterFixed = true;
            splitContainerMain.Location = new Point(9, 39);
            splitContainerMain.Margin = new Padding(2, 3, 2, 3);
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
            splitContainerMain.Size = new Size(417, 258);
            splitContainerMain.SplitterDistance = 208;
            splitContainerMain.SplitterWidth = 1;
            splitContainerMain.TabIndex = 6;
            // 
            // textBoxComment
            // 
            textBoxComment.AcceptsReturn = true;
            textBoxComment.AcceptsTab = true;
            textBoxComment.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            textBoxComment.Location = new Point(0, 22);
            textBoxComment.Margin = new Padding(2, 3, 2, 3);
            textBoxComment.Multiline = true;
            textBoxComment.Name = "textBoxComment";
            textBoxComment.ScrollBars = ScrollBars.Vertical;
            textBoxComment.Size = new Size(204, 236);
            textBoxComment.TabIndex = 1;
            textBoxComment.TextChanged += textBoxComment_TextChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(2, 3);
            label2.Margin = new Padding(2, 0, 2, 0);
            label2.Name = "label2";
            label2.Size = new Size(43, 17);
            label2.TabIndex = 3;
            label2.Text = "label2";
            // 
            // textBoxPreview
            // 
            textBoxPreview.AcceptsReturn = true;
            textBoxPreview.AcceptsTab = true;
            textBoxPreview.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            textBoxPreview.Location = new Point(0, 22);
            textBoxPreview.Margin = new Padding(2, 3, 2, 3);
            textBoxPreview.Multiline = true;
            textBoxPreview.Name = "textBoxPreview";
            textBoxPreview.ReadOnly = true;
            textBoxPreview.ScrollBars = ScrollBars.Vertical;
            textBoxPreview.Size = new Size(207, 236);
            textBoxPreview.TabIndex = 2;
            // 
            // FormCommentEditor
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(436, 337);
            Controls.Add(splitContainerMain);
            Controls.Add(buttonClose);
            Controls.Add(buttonSaveAs);
            Controls.Add(buttonSave);
            Controls.Add(label1);
            Controls.Add(comboBoxEncoding);
            Margin = new Padding(2, 3, 2, 3);
            MaximizeBox = false;
            MinimizeBox = false;
            MinimumSize = new Size(450, 370);
            Name = "FormCommentEditor";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "CommentEditor";
            FormClosing += FormCommentEditor_FormClosing;
            DpiChanged += FormCommentEditor_DpiChanged;
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