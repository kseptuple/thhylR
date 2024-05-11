using System.Diagnostics;
using System.Security.Principal;

namespace thhylR.Helper
{
    public static class PrivilegeHelper
    {
        public static bool Promote()
        {
            var args = Environment.GetCommandLineArgs();
            if (args.Length > 1)
            {
                var arguments = new string[args.Length - 1];
                for (int i = 1; i < args.Length; i++)
                {
                    var arg = args[i];
                    if (arg.Contains(" "))
                    {
                        arguments[i - 1] = "\"" + arg + "\"";
                    }
                    else
                    {
                        arguments[i - 1] = arg;
                    }
                }

                return Promote(arguments);
            }
            else
            {
                return Promote(null);
            }
        }

        public static bool Promote(string[] arguments)
        {
            var proc = new ProcessStartInfo();
            proc.UseShellExecute = true;
            proc.WorkingDirectory = Environment.CurrentDirectory;
            proc.FileName = Application.ExecutablePath;
            if (arguments != null)
            {
                proc.Arguments = string.Join(' ', arguments);
            }

            proc.Verb = "runas";

            try
            {
                Process.Start(proc);
            }
            catch (Exception)
            {
                return false;
            }
            Application.Exit();
            //Environment.Exit(0);
            return true;
        }

        public static bool IsAdministrator()
        {
            using WindowsIdentity identity = WindowsIdentity.GetCurrent();
            WindowsPrincipal principal = new WindowsPrincipal(identity);
            return principal.IsInRole(WindowsBuiltInRole.Administrator);
        }
    }
}
