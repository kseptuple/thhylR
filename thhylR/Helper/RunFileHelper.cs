using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
