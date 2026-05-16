namespace thhylR.Helper
{
    public static class FileDeleteHelper
    {
        public static bool DeleteFile(string filePath, bool throwException = false)
        {
            try
            {
                if (File.Exists(filePath))
                {
                    File.SetAttributes(filePath, FileAttributes.Normal);
                    File.Delete(filePath);
                    return true;
                }
                return false;
            }
            catch
            {
                if (throwException)
                {
                    throw;
                }
                return false;
            }
        }


        public static bool DeleteDirectory(string directoryPath, bool throwException = false)
        {
            try
            {
                if (Directory.Exists(directoryPath))
                {
                    DirectoryInfo dirInfo = new DirectoryInfo(directoryPath);
                    foreach (FileInfo file in dirInfo.GetFiles())
                    {
                        file.Attributes = FileAttributes.Normal;
                        file.Delete();
                    }
                    foreach (DirectoryInfo dir in dirInfo.GetDirectories())
                    {
                        DeleteDirectory(dir.FullName);
                    }
                    Directory.Delete(directoryPath);
                    return true;
                }
                return false;
            }
            catch
            {
                if (throwException)
                {
                    throw;
                }
                return false;
            }
        }
    }
}
