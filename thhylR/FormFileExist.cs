using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using thhylR.Helper;

namespace thhylR
{
    public partial class FormFileExist : Form
    {
        public FormFileExist()
        {
            InitializeComponent();
            ResourceLoader.SetFormText(this);
            TopMost = SettingProvider.Settings.OnTop;
        }

        public FileExistResult Result = FileExistResult.Cancel;

        private void FormFileExist_Load(object sender, EventArgs e)
        {
            System.Media.SystemSounds.Asterisk.Play();
        }

        private void pictureBoxIcon_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawIcon(SystemIcons.Warning, 0, 0);
        }

        private void buttonOverwrite_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Result = FileExistResult.Overwrite;
            Close();
        }

        private void buttonRename_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Result = FileExistResult.Rename;
            Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }

    public enum FileExistResult
    {
        Overwrite,
        Rename,
        Cancel
    }
}
