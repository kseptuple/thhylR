using System.Diagnostics;
using thhylR.Helper;

namespace thhylR
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
#if DEBUG
            Application.Run(new FormMain());
#else
            FormMain formMain = null;
            try
            {
                formMain = new FormMain();
                Application.Run(formMain);
            }
            catch (Exception ex) 
            {
                string replayFile = null;
                if (formMain != null && formMain.CurrentReplay != null)
                {
                    replayFile = formMain.CurrentReplay.FilePath;
                }
                string path = CrashHandler.DoCrashLog(ex, replayFile);
                MessageBox.Show(ex.Message, string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Error);
                var psi = new ProcessStartInfo
                {
                    UseShellExecute = true,
                    FileName = path
                };
                Process.Start(psi);
            }
#endif
        }
    }
}