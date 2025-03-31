using System.Reflection;
using System.Text;
using YamlDotNet.Serialization;

namespace thhylR.Helper
{
    public static class VersionManager
    {
        private static VersionInfo versionInfo = new VersionInfo();

        public static bool Manage()
        {
            var currentVersion = Assembly.GetExecutingAssembly().GetName().Version;
            var deserializer = new DeserializerBuilder().Build();
            var result = true;
            bool requireUpdateFile = false;
            using (var input = new StreamReader(@"version.yaml", Encoding.UTF8))
            {
                try
                {
                    versionInfo = deserializer.Deserialize<VersionInfo>(input);
                }
                catch
                {
                    requireUpdateFile = true;
                    versionInfo.Version = currentVersion.ToString();
                    versionInfo.OutdatedFiles = new List<string>();
                }
            }

            if (!Version.TryParse(versionInfo.Version, out Version version))
            {
                requireUpdateFile = true;
                version = currentVersion;
            }

            if (version > currentVersion)
            {
                result = false;
            }

            var newFileList = new List<string>();
            if (versionInfo.OutdatedFiles != null)
            {
                var currentPath = Environment.CurrentDirectory;
                if (!currentPath.EndsWith('\\'))
                {
                    currentPath += "\\";
                }
                foreach (var file in versionInfo.OutdatedFiles)
                {
                    var currentFile = Path.GetFullPath(file.Replace("/", "\\"));
                    if (currentFile.StartsWith(currentPath))
                    {
                        if (File.Exists(currentFile))
                        {
                            try
                            {
                                File.Delete(currentFile);
                            }
                            catch
                            {
                                newFileList.Add(currentFile);
                            }
                        }
                    }
                }
            }
            if (versionInfo.OutdatedFiles.Count != newFileList.Count || !versionInfo.OutdatedFiles.All(newFileList.Contains))
            {
                requireUpdateFile = true;
                versionInfo.OutdatedFiles = newFileList;
            }

            if (requireUpdateFile)
            {
                using var output = new StreamWriter("version.yaml", false, Encoding.UTF8);
                try
                {
                    var serializer = new SerializerBuilder().Build();
                    serializer.Serialize(output, versionInfo);
                }
                catch
                {

                }
            }
            return result;
        }
    }

    public class VersionInfo
    {
        public string Version { get; set; }
        public List<string> OutdatedFiles { get; set; }
    }
}
