namespace thhylR
{
    partial class FormAbout
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
            richTextBoxAbout = new RichTextBox();
            SuspendLayout();
            // 
            // richTextBoxAbout
            // 
            richTextBoxAbout.Dock = DockStyle.Fill;
            richTextBoxAbout.Location = new Point(0, 0);
            richTextBoxAbout.Name = "richTextBoxAbout";
            richTextBoxAbout.ReadOnly = true;
            richTextBoxAbout.Size = new Size(471, 326);
            richTextBoxAbout.TabIndex = 0;
            richTextBoxAbout.Text = "";
            richTextBoxAbout.LinkClicked += richTextBoxAbout_LinkClicked;
            // 
            // FormAbout
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(471, 326);
            Controls.Add(richTextBoxAbout);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormAbout";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "FormAbout";
            ResumeLayout(false);
        }

        #endregion

        private RichTextBox richTextBoxAbout;
    }
}