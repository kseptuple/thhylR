namespace SettingTabs
{
    partial class SettingTabControl
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

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            listBoxTabs = new ListBox();
            tableLayoutPanelMain = new TableLayoutPanel();
            tableLayoutPanelMain.SuspendLayout();
            SuspendLayout();
            // 
            // listBoxTabs
            // 
            listBoxTabs.Dock = DockStyle.Fill;
            listBoxTabs.FormattingEnabled = true;
            listBoxTabs.ItemHeight = 20;
            listBoxTabs.Location = new Point(15, 15);
            listBoxTabs.Margin = new Padding(15);
            listBoxTabs.Name = "listBoxTabs";
            listBoxTabs.Size = new Size(377, 420);
            listBoxTabs.TabIndex = 0;
            listBoxTabs.SelectedIndexChanged += listBoxTabs_SelectedIndexChanged;
            // 
            // tableLayoutPanelMain
            // 
            tableLayoutPanelMain.ColumnCount = 2;
            tableLayoutPanelMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50.875F));
            tableLayoutPanelMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 49.125F));
            tableLayoutPanelMain.Controls.Add(listBoxTabs, 0, 0);
            tableLayoutPanelMain.Dock = DockStyle.Fill;
            tableLayoutPanelMain.Location = new Point(0, 0);
            tableLayoutPanelMain.Name = "tableLayoutPanelMain";
            tableLayoutPanelMain.RowCount = 1;
            tableLayoutPanelMain.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanelMain.Size = new Size(800, 450);
            tableLayoutPanelMain.TabIndex = 1;
            // 
            // SettingTabControl
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tableLayoutPanelMain);
            Name = "SettingTabControl";
            Size = new Size(800, 450);
            tableLayoutPanelMain.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private ListBox listBoxTabs;
        private TableLayoutPanel tableLayoutPanelMain;
    }
}
