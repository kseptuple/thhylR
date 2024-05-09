namespace thhylR
{
    partial class FormFileExist
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
            buttonOverwrite = new Button();
            buttonRename = new Button();
            buttonCancel = new Button();
            pictureBoxIcon = new PictureBox();
            labelText = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBoxIcon).BeginInit();
            SuspendLayout();
            // 
            // buttonOverwrite
            // 
            buttonOverwrite.Location = new Point(100, 79);
            buttonOverwrite.Margin = new Padding(2, 3, 2, 3);
            buttonOverwrite.Name = "buttonOverwrite";
            buttonOverwrite.Size = new Size(73, 25);
            buttonOverwrite.TabIndex = 1;
            buttonOverwrite.Text = "button1";
            buttonOverwrite.UseVisualStyleBackColor = true;
            buttonOverwrite.Click += buttonOverwrite_Click;
            // 
            // buttonRename
            // 
            buttonRename.Location = new Point(177, 79);
            buttonRename.Margin = new Padding(2, 3, 2, 3);
            buttonRename.Name = "buttonRename";
            buttonRename.Size = new Size(73, 25);
            buttonRename.TabIndex = 2;
            buttonRename.Text = "button2";
            buttonRename.UseVisualStyleBackColor = true;
            buttonRename.Click += buttonRename_Click;
            // 
            // buttonCancel
            // 
            buttonCancel.Location = new Point(255, 79);
            buttonCancel.Margin = new Padding(2, 3, 2, 3);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(73, 25);
            buttonCancel.TabIndex = 3;
            buttonCancel.Text = "button3";
            buttonCancel.UseVisualStyleBackColor = true;
            buttonCancel.Click += buttonCancel_Click;
            // 
            // pictureBoxIcon
            // 
            pictureBoxIcon.BackColor = Color.Transparent;
            pictureBoxIcon.Location = new Point(19, 20);
            pictureBoxIcon.Margin = new Padding(2, 3, 2, 3);
            pictureBoxIcon.Name = "pictureBoxIcon";
            pictureBoxIcon.Size = new Size(31, 34);
            pictureBoxIcon.TabIndex = 4;
            pictureBoxIcon.TabStop = false;
            pictureBoxIcon.Paint += pictureBoxIcon_Paint;
            // 
            // labelText
            // 
            labelText.AutoSize = true;
            labelText.Location = new Point(68, 29);
            labelText.Margin = new Padding(2, 0, 2, 0);
            labelText.Name = "labelText";
            labelText.Size = new Size(152, 17);
            labelText.TabIndex = 5;
            labelText.Text = "目标文件已存在，是否要：";
            labelText.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // FormFileExist
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = buttonCancel;
            ClientSize = new Size(338, 114);
            Controls.Add(labelText);
            Controls.Add(pictureBoxIcon);
            Controls.Add(buttonCancel);
            Controls.Add(buttonRename);
            Controls.Add(buttonOverwrite);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(2, 3, 2, 3);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormFileExist";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "FormFileExist";
            Load += FormFileExist_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBoxIcon).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button buttonOverwrite;
        private Button buttonRename;
        private Button buttonCancel;
        private PictureBox pictureBoxIcon;
        private Label labelText;
    }
}