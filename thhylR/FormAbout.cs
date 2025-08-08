using System.Text;
using thhylR.Helper;

namespace thhylR
{
    public partial class FormAbout : Form
    {
        private int clickCount = 0;
        private int countToTrigger = 10;
        private object locker = new object();
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
            if (clickCount < 10)
                clickCount--;
            RunFileHelper.Run(e.LinkText);
        }

        private void FormAbout_Load(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now;
            //2月8日 / 6月11日 / 9月19日
            if ((now.Month == 2 && now.Day == 8) ||
                (now.Month == 6 && now.Day == 11) ||
                (now.Month == 9 && now.Day == 19))
            {
                countToTrigger = 3;
            }
        }

        private void richTextBoxAbout_Click(object sender, EventArgs e)
        {
            clickCount++;
            lock (locker)
            {
                if (clickCount >= countToTrigger)
                {
                    showEasterEgg();
                }
            }
        }

        private void richTextBoxAbout_DoubleClick(object sender, EventArgs e)
        {
            clickCount++;
            lock (locker)
            {
                if (clickCount >= countToTrigger)
                {
                    showEasterEgg();
                }
            }
        }

        private async void showEasterEgg()
        {
            richTextBoxAbout.Click -= richTextBoxAbout_Click;
            richTextBoxAbout.DoubleClick -= richTextBoxAbout_DoubleClick;

            pictureBoxEaster.Image = Properties.Resources.EasterImage;
            pictureBoxEaster.Top = richTextBoxAbout.Height - pictureBoxEaster.Height;
            pictureBoxEaster.Left = (richTextBoxAbout.Width - pictureBoxEaster.Width) / 2;

            Graphics g = richTextBoxAbout.CreateGraphics();
            Bitmap richtextArea = new Bitmap(richTextBoxAbout.Width, richTextBoxAbout.Height);
            richTextBoxAbout.DrawToBitmap(richtextArea, new Rectangle(0, 0, richTextBoxAbout.Width, richTextBoxAbout.Height));
            Rectangle cropArea = new Rectangle(pictureBoxEaster.Left, pictureBoxEaster.Top, pictureBoxEaster.Width, pictureBoxEaster.Height);
            Bitmap background = richtextArea.Clone(cropArea, richtextArea.PixelFormat);
            pictureBoxEaster.BackgroundImage = background;
            richtextArea.Dispose();

            pictureBoxEaster.Visible = true;

            await Task.Run(() =>
            {
                Thread.Sleep(3700);
                try
                {
                    Invoke(() =>
                    {
                        pictureBoxEaster.Visible = false;
                        pictureBoxEaster.Image = null;
                        pictureBoxEaster.BackgroundImage = null;
                        background.Dispose();
                    });
                }
                catch (InvalidOperationException)
                {

                }
            });
        }

    }
}
