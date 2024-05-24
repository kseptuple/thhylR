using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using thhylR.Helper;

namespace thhylR
{
    public partial class FormAbout : Form
    {
        public FormAbout()
        {
            InitializeComponent();
            ResourceLoader.SetFormText(this);
            TopMost = SettingProvider.Settings.OnTop;
            var ms = new MemoryStream();
            var richTextBytes = Encoding.UTF8.GetBytes(Properties.Resources.About);
            ms.Write(richTextBytes, 0, richTextBytes.Length);
            ms.Seek(0, SeekOrigin.Begin);
            richTextBoxAbout.LoadFile(ms, RichTextBoxStreamType.RichText);
        }

        private void richTextBoxAbout_LinkClicked(object sender, LinkClickedEventArgs e)
        {
            RunFileHelper.Run(e.LinkText);
        }
    }
}
