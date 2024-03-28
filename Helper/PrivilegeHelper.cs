using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace thhylR.Helper
{
    public static class PrivilegeHelper
    {
        public static bool Promote()
        {
            var proc = new ProcessStartInfo();
            proc.UseShellExecute = true;
            proc.WorkingDirectory = Environment.CurrentDirectory;
            proc.FileName = Application.ExecutablePath;
            proc.Arguments = string.Join(' ', Environment.GetCommandLineArgs());
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
            return true;
        }
    }
}
