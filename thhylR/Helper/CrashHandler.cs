using Microsoft.VisualBasic.Devices;
using System.Globalization;
using System.IO.Compression;
using System.Text;

namespace thhylR.Helper
{
    public static class CrashHandler
    {
        public static string GetInfo()
        {
            StringBuilder result = new StringBuilder();
            ComputerInfo computerInfo = new ComputerInfo();
            result.AppendLine($"操作系统：{Environment.OSVersion.VersionString}");
            result.AppendLine($"是否64位系统：{(Environment.Is64BitOperatingSystem ? "是" : "否")}");
            result.AppendLine($"系统语言：{CultureInfo.CurrentCulture.DisplayName}");
            result.AppendLine($"逻辑处理器数量：{Environment.ProcessorCount}");
            result.AppendLine($"物理内存（可用/全部）：{GetSizeDisplay(computerInfo.AvailablePhysicalMemory)}/{GetSizeDisplay(computerInfo.TotalPhysicalMemory)}");
            result.AppendLine($"虚拟内存（可用/全部）：{GetSizeDisplay(computerInfo.AvailableVirtualMemory)}/{GetSizeDisplay(computerInfo.TotalVirtualMemory)}");
            result.AppendLine($"为本程序分配的内存：{GetSizeDisplay((ulong)Environment.WorkingSet)}");
            result.AppendLine($"GC托管内存：{GetSizeDisplay((ulong)GC.GetTotalMemory(false))}");
            result.AppendLine($"当前时间：{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}");
            result.AppendLine($"时区：{TimeZoneInfo.Local.DisplayName}");
            return result.ToString();
        }

        private static readonly string[] sizeUnits = { "B", "KB", "MB", "GB", "TB", "PB", "EB" };
        public static string GetSizeDisplay(ulong byteSize)
        {
            decimal resultNum = byteSize;
            int i = 0;
            while (resultNum >= 2048m && i < 7)
            {
                resultNum /= 1024m;
                i++;
            }
            return resultNum.ToString("0.00") + sizeUnits[i];
        }

        public static string GetFullException(Exception ex)
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine(ex.Message);
            result.AppendLine(ex.StackTrace);
            ex = ex.InnerException;
            while (ex != null)
            {
                result.AppendLine();
                result.AppendLine("root cause:");
                result.AppendLine(ex.StackTrace);
                ex = ex.InnerException;
            }
            return result.ToString();
        }

        public static string DoCrashLog(Exception ex, string replayPath)
        {
            string tmpPath = Path.GetTempPath();
            string date = DateTime.Now.ToString("yyyy-MM-dd");
            string filename = "thhylR crash log " + date;
            string logPath = autoRename(tmpPath, filename, ".log");

            StringBuilder alltext = new StringBuilder();
            alltext.Append(GetInfo());
            if (replayPath != null)
            {
                alltext.AppendLine($"录像文件：{replayPath}");
            }
            alltext.AppendLine();
            alltext.Append(GetFullException(ex));
            File.WriteAllText(logPath, alltext.ToString());

            string exePath = Path.GetDirectoryName(Application.ExecutablePath);
            string crashReportPath = Path.Combine(exePath, "CrashReports");
            if (!Directory.Exists(crashReportPath))
            {
                Directory.CreateDirectory(crashReportPath);
            }
            string zipName = "CrashReport " + date;
            string zipPath = autoRename(crashReportPath, zipName, ".zip");

            using (FileStream fs = File.Open(zipPath, FileMode.Create))
            {
                using (var archive = new ZipArchive(fs, ZipArchiveMode.Create))
                {
                    try
                    {
                        archive.CreateEntryFromFile(logPath, filename + ".log");
                    }
                    catch
                    {

                    }

                    try
                    {
                        if (replayPath != null)
                        {
                            archive.CreateEntryFromFile(replayPath, Path.GetFileName(replayPath));
                        }
                    }
                    catch
                    {

                    }
                }
            }

            try
            {
                File.Delete(logPath);
            }
            catch
            {

            }
            return crashReportPath;
        }

        private static string autoRename(string path, string filename, string extesion)
        {
            string acutalFilename = filename;
            int suffix = 1;
            while (File.Exists(Path.Combine(path, acutalFilename + extesion)))
            {
                suffix++;
                acutalFilename = filename + $" ({suffix})";
            }
            return Path.Combine(path, acutalFilename + extesion);
        }
    }
}
