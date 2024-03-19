using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using thhylR.Common;
using YamlDotNet.Serialization;

namespace thhylR.Helper
{
    public class ProgramSettings
    {
        public int ScoreType { get; set; }
        public int LifeBombType { get; set; }
        public bool ShowEmptyIcon { get; set; }
        public bool OnTop { get; set; }
        public bool ConfirmOnDelete { get; set; }
        public bool NextFileOnDelete { get; set; }
        public bool ShowAllEncodings { get; set; }
        public List<CommonEncoding> Encodings { get; set; }

        public class CommonEncoding
        {
            public int EncodingId { get; set; }
            public bool UseEncoding { get; set; }
        }
    }

    public static class SettingProvider
    {
        public static ProgramSettings Settings { get; set; }

        public static void Init()
        {
            if (File.Exists("Settings.yaml"))
            {
                using var input = new StreamReader("Settings.yaml", Encoding.UTF8);
                try
                {
                    var deserializer = new DeserializerBuilder().IgnoreUnmatchedProperties().Build();
                    Settings = deserializer.Deserialize<ProgramSettings>(input);
                }
                catch
                {

                }
            }

            if (Settings == null)
            {
                Settings = new ProgramSettings();
                Settings.ScoreType = 1;
                Settings.LifeBombType = 1;
                Settings.ShowEmptyIcon = false;
                Settings.OnTop = false;
                Settings.ConfirmOnDelete = true;
                Settings.NextFileOnDelete = true;
                Settings.ShowAllEncodings = false;
                Settings.Encodings = new List<ProgramSettings.CommonEncoding>
                {
                    new() { EncodingId = 932, UseEncoding = true },
                    new() { EncodingId = 936, UseEncoding = true },
                    new() { EncodingId = 0, UseEncoding = true },
                    new() { EncodingId = -1, UseEncoding = false }
                };
                SaveSettings();
            }
        }

        public static void SaveSettings()
        {
            using var output = new StreamWriter("Settings.yaml", false, Encoding.UTF8);
            try
            {
                var serializer = new SerializerBuilder().Build();
                serializer.Serialize(output, Settings);
            }
            catch
            {

            }
        }
    }
}
