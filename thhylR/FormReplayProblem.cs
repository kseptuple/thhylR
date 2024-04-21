using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
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
            textBoxReplayProblem.Text = "* " + ResourceLoader.getTextResource("ProblemNotOpenDisplay");
        }

        public FormReplayProblem(ReplayProblemEnum replayProblem) : this()
        {
            if (replayProblem == ReplayProblemEnum.None)
            {
                textBoxReplayProblem.Text = "* " + ResourceLoader.getTextResource("ReplayOKDisplay");
                return;
            }
            else
            {
                StringBuilder sb = new StringBuilder();
                if (replayProblem.HasFlag(ReplayProblemEnum.FileNotExist))
                {
                    sb.Append("* ");
                    sb.AppendLine(ResourceLoader.getTextResource("ProblemFileNotExits"));
                }
                if (replayProblem.HasFlag(ReplayProblemEnum.ChnVerReplay))
                {
                    sb.Append("* ");
                    sb.AppendLine(ResourceLoader.getTextResource("ProblemCHSVersion"));
                }
                if (replayProblem.HasFlag(ReplayProblemEnum.StageLengthError))
                {
                    sb.Append("* ");
                    sb.AppendLine(ResourceLoader.getTextResource("ProblemLengthError"));
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
