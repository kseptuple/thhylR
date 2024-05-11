using thhylR.Helper;

namespace thhylR
{
    public partial class FormRename : Form
    {
        public string FileName { get; private set; }

        public FormRename()
        {
            InitializeComponent();
            ResourceLoader.SetFormText(this);
            TopMost = SettingProvider.Settings.OnTop;
        }

        public FormRename(string fileName) : this()
        {
            FileName = Path.GetFileNameWithoutExtension(fileName);
            textBoxFileName.Text = FileName;
        }

        private void textBoxFileName_TextChanged(object sender, EventArgs e)
        {
            FileName = textBoxFileName.Text;
        }

        private void textBoxFileName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                DialogResult = DialogResult.Cancel;
                e.Handled = true;
                e.SuppressKeyPress = true;
                Close();
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
