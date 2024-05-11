using System.Text;
using thhylR.Common;
using thhylR.Helper;

namespace thhylR
{
    public partial class FormCommentEditor : Form
    {
        public string FileName { get; set; }
        private List<InfoBlock> infoBlocks;

        private int userBlockAddress = 0;

        private int currentCodePage = 0;
        Encoding currentEncoding = null;
        private List<EncodingInfo> encodingList = new List<EncodingInfo>();

        private string formText = string.Empty;
        private bool isModified = false;

        private bool neverSaved = true;
        private double dpiScale = 0d;

        public FormCommentEditor()
        {
            InitializeComponent();
            splitContainerMain.Panel1.Name = "CommentPanel1";
            splitContainerMain.Panel2.Name = "CommentPanel2";
            ResourceLoader.SetFormText(this);
            dpiScale = DeviceDpi / 96.0;
            TopMost = SettingProvider.Settings.OnTop;

            formText = Text;

            Width = (int)(SettingProvider.Settings.CommentFormWidth * dpiScale);
            Height = (int)(SettingProvider.Settings.CommentFormHeight * dpiScale);

            textBoxComment.Anchor = AnchorStyles.None;
            textBoxPreview.Anchor = AnchorStyles.None;

            textBoxComment.Width = splitContainerMain.Panel1.Width;
            textBoxComment.Height = splitContainerMain.Panel1.Height - textBoxComment.Top;
            textBoxPreview.Width = splitContainerMain.Panel2.Width;
            textBoxPreview.Height = splitContainerMain.Panel2.Height - textBoxPreview.Top;

            textBoxComment.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom;
            textBoxPreview.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom;

            encodingList = EncodingHelper.EncodingList;
            loadEncodingList();
            saveFileDialogComment.Filter = ResourceLoader.GetText("ReplayFileFilter");
        }

        public FormCommentEditor(string fileName, List<InfoBlock> infoBlocks, int codePage, int userBlockAddress) : this()
        {
            FileName = fileName;
            this.infoBlocks = infoBlocks;
            currentCodePage = codePage;
            comboBoxEncoding.SetSelectedValue(currentEncoding);

            InfoBlock commentBlock = infoBlocks.FirstOrDefault(b => b.BlockType == InfoBlock.UserBlockType.Comment);
            this.userBlockAddress = userBlockAddress;

            if (commentBlock != null)
            {
                string comment = UserInfo.GetStringFromByteArray(currentCodePage, commentBlock.Data);
                textBoxComment.Text = comment;
            }

            Text = formText;
            isModified = false;
        }

        private void loadEncodingList()
        {
            var encodings = SettingProvider.Settings.Encodings;
            var nullItem = new { Name = ResourceLoader.GetText("EncodingNone"), CodePage = -1 };
            var defaultItem = new { Name = ResourceLoader.GetText("EncodingDefault"), CodePage = 0 };
            var codePage = -1;

            List<int> tmpEncodings = new List<int>();

            bool showAllEncodings = SettingProvider.Settings.ShowAllEncodings;

            if (showAllEncodings)
            {
                comboBoxEncoding.Items.Add(defaultItem);

                foreach (var encodingInfo in encodingList)
                {
                    comboBoxEncoding.Items.Add(encodingInfo);
                }
            }
            else
            {
                for (int i = 0; i < encodings.Count; i++)
                {
                    var encodingItem = encodings[i];
                    if (encodingItem.EncodingId == -1)
                    {

                    }
                    else if (encodingItem.EncodingId == 0)
                    {
                        if (!showAllEncodings && !tmpEncodings.Contains(encodingItem.EncodingId))
                        {
                            comboBoxEncoding.Items.Add(defaultItem);
                        }

                        if (codePage == -1)
                        {
                            codePage = 0;
                        }
                    }
                    else
                    {
                        var encodingInfoItem = encodingList.FirstOrDefault(e => e.CodePage == encodingItem.EncodingId);
                        if (encodingInfoItem != null)
                        {
                            if (!showAllEncodings && !tmpEncodings.Contains(encodingItem.EncodingId))
                            {
                                comboBoxEncoding.Items.Add(encodingInfoItem);
                            }

                            if (codePage == -1)
                            {
                                codePage = encodingItem.EncodingId;
                            }
                        }
                    }

                    tmpEncodings.Add(encodingItem.EncodingId);
                }
            }

            if (comboBoxEncoding.Items.Count == 0)
            {
                comboBoxEncoding.Items.Add(Encoding.GetEncoding(932));
                currentCodePage = 932;
            }
            else
            {
                currentCodePage = codePage;
            }
            comboBoxEncoding.SelectedIndex = 0;
        }

        private void FormCommentEditor_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult = DialogResult.OK;

            if (!isModified && neverSaved)
            {
                DialogResult = DialogResult.Cancel;
            }
            else if (isModified)
            {
                var msgBoxResult = MessageBox.Show(ResourceLoader.GetText("CommentCloseWarning"), formText, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (msgBoxResult == DialogResult.Yes)
                {
                    if (!saveComment())
                    {
                        DialogResult = DialogResult.None;
                        e.Cancel = true;
                        return;
                    }
                }
                else
                {
                    if (neverSaved)
                    {
                        DialogResult = DialogResult.Cancel;
                    }
                }
            }

            SettingProvider.Settings.CommentFormWidth = (int)(Width / dpiScale);
            SettingProvider.Settings.CommentFormHeight = (int)(Height / dpiScale);
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void comboBoxEncoding_SelectedIndexChanged(object sender, EventArgs e)
        {
            currentCodePage = (int)comboBoxEncoding.GetSelectedValue();
            currentEncoding = Encoding.GetEncoding(currentCodePage);

            setPreviewText();
        }

        private void setPreviewText()
        {
            textBoxPreview.Text = currentEncoding.GetString(currentEncoding.GetBytes(textBoxComment.Text));
            Text = formText + " *";
            isModified = true;
        }

        private bool saveComment()
        {
            if (currentCodePage != 932)
            {
                var msgBoxResult = MessageBox.Show(ResourceLoader.GetText("NonShiftJISWarning"), formText, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (msgBoxResult == DialogResult.No)
                {
                    return false;
                }
            }
            int commentBlockIndex = infoBlocks.FindIndex(b => b.BlockType == InfoBlock.UserBlockType.Comment);
            byte[] blockData = currentEncoding.GetBytes(textBoxComment.Text);
            blockData = blockData.Append((byte)0).ToArray();
            if (commentBlockIndex != -1)
            {
                var commentBlock = infoBlocks[commentBlockIndex];
                commentBlock.Data = blockData;
                commentBlock.Length = blockData.Length + 12;
            }
            else
            {
                var commentBlock = new InfoBlock(InfoBlock.UserBlockType.Comment, blockData);
                infoBlocks.Add(commentBlock);
                commentBlockIndex = infoBlocks.Count - 1;
            }

            int userBlockStart = userBlockAddress;

            for (int i = 0; i < commentBlockIndex; i++)
            {
                userBlockStart += infoBlocks[i].Length;
            }

            using (FileStream fs = File.OpenWrite(FileName))
            {
                using (StreamWriter sw = new StreamWriter(fs))
                {
                    fs.Seek(userBlockStart, SeekOrigin.Begin);

                    for (int i = commentBlockIndex; i < infoBlocks.Count; i++)
                    {
                        fs.Write(UserInfo.GetByteArray(infoBlocks[i]));
                    }
                    fs.SetLength(fs.Position);
                    fs.Flush();
                }
            }

            Text = formText;
            isModified = false;
            neverSaved = false;
            return true;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            saveComment();
        }

        private void textBoxComment_TextChanged(object sender, EventArgs e)
        {
            setPreviewText();
        }

        private void buttonSaveAs_Click(object sender, EventArgs e)
        {
            saveFileDialogComment.InitialDirectory = Path.GetDirectoryName(FileName);
            var dialogResult = saveFileDialogComment.ShowDialog(this);
            if (dialogResult == DialogResult.OK)
            {
                var targetName = saveFileDialogComment.FileName;
                if (FileName != targetName)
                {
                    File.Copy(FileName, targetName, true);
                    FileName = targetName;
                }
                saveComment();
            }
        }

        private void FormCommentEditor_DpiChanged(object sender, DpiChangedEventArgs e)
        {
            dpiScale = DeviceDpi / 96.0;
            MinimumSize = new Size((int)(450 * dpiScale), (int)(370 * dpiScale));
        }
    }
}
