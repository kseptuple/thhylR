namespace thhylR
{
    partial class FormRename
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
            textBoxFileName = new TextBox();
            label1 = new Label();
            buttonOK = new Button();
            buttonCancel = new Button();
            SuspendLayout();
            // 
            // textBoxFileName
            // 
            textBoxFileName.Location = new Point(9, 10);
            textBoxFileName.Margin = new Padding(2, 3, 2, 3);
            textBoxFileName.Name = "textBoxFileName";
            textBoxFileName.Size = new Size(191, 23);
            textBoxFileName.TabIndex = 0;
            textBoxFileName.TextChanged += textBoxFileName_TextChanged;
            textBoxFileName.KeyDown += textBoxFileName_KeyDown;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(205, 13);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(30, 17);
            label1.TabIndex = 1;
            label1.Text = ".rpy";
            // 
            // buttonOK
            // 
            buttonOK.Location = new Point(79, 38);
            buttonOK.Margin = new Padding(2, 3, 2, 3);
            buttonOK.Name = "buttonOK";
            buttonOK.Size = new Size(73, 25);
            buttonOK.TabIndex = 2;
            buttonOK.Text = "button1";
            buttonOK.UseVisualStyleBackColor = true;
            buttonOK.Click += buttonOK_Click;
            // 
            // buttonCancel
            // 
            buttonCancel.Location = new Point(156, 38);
            buttonCancel.Margin = new Padding(2, 3, 2, 3);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(73, 25);
            buttonCancel.TabIndex = 3;
            buttonCancel.Text = "button2";
            buttonCancel.UseVisualStyleBackColor = true;
            buttonCancel.Click += buttonCancel_Click;
            // 
            // FormRename
            // 
            AcceptButton = buttonOK;
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = buttonCancel;
            ClientSize = new Size(239, 71);
            Controls.Add(buttonCancel);
            Controls.Add(buttonOK);
            Controls.Add(label1);
            Controls.Add(textBoxFileName);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(2, 3, 2, 3);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormRename";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "RenameForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBoxFileName;
        private Label label1;
        private Button buttonOK;
        private Button buttonCancel;
    }
}