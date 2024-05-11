using System.Text;
using thhylR.Games;
using thhylR.Helper;

namespace thhylR
{
    public partial class FormReplayProblem : Form
    {
        public FormReplayProblem()
        {
            InitializeComponent();
            ResourceLoader.SetFormText(this);
            TopMost = SettingProvider.Settings.OnTop;
            textBoxReplayProblem.Text = "* " + ResourceLoader.GetText("ProblemNotOpenDisplay");
        }

        public FormReplayProblem(ReplayProblemEnum replayProblem) : this()
        {
            if (replayProblem == ReplayProblemEnum.None)
            {
                textBoxReplayProblem.Text = "* " + ResourceLoader.GetText("ReplayOKDisplay");
                return;
            }
            else
            {
                StringBuilder sb = new StringBuilder();
                if (replayProblem.HasFlag(ReplayProblemEnum.FileNotExist))
                {
                    sb.Append("* ");
                    sb.AppendLine(ResourceLoader.GetText("ProblemFileNotExits"));
                }
                if (replayProblem.HasFlag(ReplayProblemEnum.ChnVerReplay))
                {
                    sb.Append("* ");
                    sb.AppendLine(ResourceLoader.GetText("ProblemCHSVersion"));
                }
                if (replayProblem.HasFlag(ReplayProblemEnum.StageLengthError))
                {
                    sb.Append("* ");
                    sb.AppendLine(ResourceLoader.GetText("ProblemLengthError"));
                }
                textBoxReplayProblem.Text = sb.ToString();
            }
        }

        private void FormReplayProblem_Load(object sender, EventArgs e)
        {
            textBoxReplayProblem.SelectionStart = textBoxReplayProblem.Text.Length;
            textBoxReplayProblem.SelectionLength = 0;
        }
    }
}
