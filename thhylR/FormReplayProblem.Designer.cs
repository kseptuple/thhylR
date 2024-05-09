namespace thhylR
{
    partial class FormReplayProblem
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
            textBoxReplayProblem = new TextBox();
            SuspendLayout();
            // 
            // textBoxReplayProblem
            // 
            textBoxReplayProblem.Dock = DockStyle.Fill;
            textBoxReplayProblem.Location = new Point(0, 0);
            textBoxReplayProblem.Margin = new Padding(2, 3, 2, 3);
            textBoxReplayProblem.Multiline = true;
            textBoxReplayProblem.Name = "textBoxReplayProblem";
            textBoxReplayProblem.ReadOnly = true;
            textBoxReplayProblem.ScrollBars = ScrollBars.Vertical;
            textBoxReplayProblem.Size = new Size(491, 332);
            textBoxReplayProblem.TabIndex = 0;
            // 
            // FormReplayProblem
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(491, 332);
            Controls.Add(textBoxReplayProblem);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(2, 3, 2, 3);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormReplayProblem";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "FormReplayProblem";
            Load += FormReplayProblem_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBoxReplayProblem;
    }
}