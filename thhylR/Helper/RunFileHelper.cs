using System.Diagnostics;

namespace thhylR.Helper
{
    public static class RunFileHelper
    {
        public static void Run(string file)
        {
            var psi = new ProcessStartInfo
            {
                UseShellExecute = true,
                FileName = file
            };
            Process.Start(psi);
        }
    }
}
