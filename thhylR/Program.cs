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

            FormMain formMain = null;
#if !DEBUG
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            ThreadExceptionEventHandler threadExceptionHandler = null;
            threadExceptionHandler = (sender, e) =>
            {
                try
                {
                    exceptionHandler(formMain, e.Exception);
                }
                catch (Exception ex) 
                {
                    MessageBox.Show(ex.Message, string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                Application.Exit();
            };
            Application.ThreadException += threadExceptionHandler;

            UnhandledExceptionEventHandler unhandledExceptionHandler = null;
            unhandledExceptionHandler = (sender, e) =>
            {
                try
                {
                    if (e.ExceptionObject is Exception ex)
                    {
                        exceptionHandler(formMain, ex);
                    }
                    else
                    {
                        exceptionHandler(formMain, new ExternalException(e.ExceptionObject.ToString()));
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                if (e.IsTerminating)
                {
                    Application.Exit();
                }
            };
            AppDomain.CurrentDomain.UnhandledException += unhandledExceptionHandler;
#endif
            formMain = new FormMain();
            Application.Run(formMain);
        }

        private static void exceptionHandler(FormMain formMain, Exception ex)
        {
            string replayFile = null;
            if (formMain != null && formMain.CurrentReplay != null)
            {
                replayFile = formMain.CurrentReplay.FilePath;
            }
            string path = CrashHandler.DoCrashLog(ex, replayFile);
            MessageBox.Show(ex.Message, string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Error);
            RunFileHelper.Run(path);
        }
    }

    public class ExternalException(string message) : Exception(message)
    {
    }
}