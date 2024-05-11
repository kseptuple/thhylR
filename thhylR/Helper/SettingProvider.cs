using System.Text;
using YamlDotNet.Serialization;

namespace thhylR.Helper
{
    public class ProgramSettings
    {
        public int Version { get; set; }
        public ScoreFormat ScoreType { get; set; }
        public LifeBombFormat LifeBombType { get; set; }
        public bool ShowEmptyIcon { get; set; }
        public bool OnTop { get; set; }

        public FileOperate OperAfterMove { get; set; }
        public FileOperate OperAfterCopy { get; set; }
        public FileOperate OperAfterDelete { get; set; }

        [YamlIgnore]
        private bool registerReplayUser = RegistryHelper.isCurrentUserAssociated();
        [YamlIgnore]
        public bool RegisterReplayUser
        {
            get
            {
                return registerReplayUser;
            }
            set
            {
                if (value && !registerReplayUser)
                {
                    RegistryHelper.setCurrentUserAssociate();
                    registerReplayUser = value;
                }
                else if (!value && registerReplayUser)
                {
                    RegistryHelper.removeCurrentUserAssociate();
                    registerReplayUser = value;
                }
            }
        }
        [YamlIgnore]
        private bool registerReplaySystem = RegistryHelper.isAllUserAssociated();
        [YamlIgnore]
        public bool RegisterReplaySystem
        {
            get
            {
                return registerReplaySystem;
            }
            set
            {
                if (value && !registerReplaySystem)
                {
                    RegistryHelper.setAllUserAssociate();
                    registerReplaySystem = value;
                }
                else if (!value && registerReplaySystem)
                {
                    RegistryHelper.removeAllUserAssociate();
                    registerReplaySystem = value;
                }
            }
        }
        public bool ShowAllEncodings { get; set; }
        public List<CommonEncoding> Encodings { get; set; }
        [YamlIgnore]
        public Font NormalFont { get; set; }
        [YamlIgnore]
        public Font SymbolFont { get; set; }
        public FontInfo NormalFontInfo { get; set; }
        public FontInfo SymbolFontInfo { get; set; }
        public ShownScoreType ShownScore { get; set; }

        public int CurrentCodePage { get; set; }

        public int MainFormTop { get; set; }
        public int MainFormLeft { get; set; }
        public int MainFormWidth { get; set; }
        public int MainFormHeight { get; set; }
        public int MainFormSplitter1Pos { get; set; }
        public int MainFormSplitter2Pos { get; set; }

        public int CommentFormWidth { get; set; }
        public int CommentFormHeight { get; set; }

        public int KeyViewerFormWidth { get; set; }
        public int KeyViewerFormHeight { get; set; }

        public class CommonEncoding
        {
            public int EncodingId { get; set; }
            public bool UseEncoding { get; set; }
        }
    }

    public static class SettingProvider
    {
        public const int currentVersion = 1;
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
                Settings.Version = currentVersion;
                Settings.ScoreType = ScoreFormat.Comma;
                Settings.LifeBombType = LifeBombFormat.Heart;
                Settings.ShowEmptyIcon = false;
                Settings.OnTop = false;
                Settings.OperAfterMove = FileOperate.Next;
                Settings.OperAfterCopy = FileOperate.KeepOrClose;
                Settings.OperAfterDelete = FileOperate.Next;
                Settings.ShowAllEncodings = false;
                Settings.Encodings = new List<ProgramSettings.CommonEncoding>
                {
                    new() { EncodingId = 932, UseEncoding = true },
                    new() { EncodingId = 65001, UseEncoding = true },
                    new() { EncodingId = 0, UseEncoding = true },
                    new() { EncodingId = -1, UseEncoding = false }
                };

                Settings.NormalFont = new Font(SystemFonts.DefaultFont.Name, 12F, FontStyle.Regular);
                Settings.SymbolFont = new Font("Segoe UI Symbol", 12F, FontStyle.Regular);
                Settings.ShownScore = ShownScoreType.StageEnd;

                Settings.CurrentCodePage = 932;

                Settings.MainFormLeft = -1;
                Settings.MainFormTop = -1;
                Settings.MainFormWidth = 1200;
                Settings.MainFormHeight = 700;
                Settings.MainFormSplitter1Pos = 250;
                Settings.MainFormSplitter2Pos = 600;

                Settings.CommentFormWidth = 750;
                Settings.CommentFormHeight = 500;

                Settings.KeyViewerFormWidth = 1100;
                Settings.KeyViewerFormHeight = 650;

                SaveSettings();
            }
            else
            {
                while (Settings.Encodings.Count < 4)
                {
                    Settings.Encodings.Add(new() { EncodingId = -1, UseEncoding = false });
                }

                Settings.NormalFont = new Font(Settings.NormalFontInfo.Name, Settings.NormalFontInfo.Size, Settings.NormalFontInfo.Style);
                Settings.SymbolFont = new Font(Settings.SymbolFontInfo.Name, Settings.SymbolFontInfo.Size, Settings.SymbolFontInfo.Style);
            }
        }

        public static void SaveSettings()
        {
            if (Settings.NormalFontInfo == null) Settings.NormalFontInfo = new FontInfo();
            Settings.NormalFontInfo.Name = Settings.NormalFont.Name;
            Settings.NormalFontInfo.Size = Settings.NormalFont.Size;
            Settings.NormalFontInfo.Style = Settings.NormalFont.Style;

            if (Settings.SymbolFontInfo == null) Settings.SymbolFontInfo = new FontInfo();
            Settings.SymbolFontInfo.Name = Settings.SymbolFont.Name;
            Settings.SymbolFontInfo.Size = Settings.SymbolFont.Size;
            Settings.SymbolFontInfo.Style = Settings.SymbolFont.Style;

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

    public enum LifeBombFormat
    {
        Number = 0,
        Heart = 1,
        Star = 2
    }

    public enum ScoreFormat
    {
        Plain = 0,
        Comma = 1,
        Character = 2
    }

    public enum FileOperate
    {
        KeepOrClose = 0,
        Next = 1,
        New = 2
    }

    public class FontInfo
    {
        public string Name { get; set; }
        public float Size { get; set; }
        public FontStyle Style { get; set; }
    }

    public enum ShownScoreType
    {
        Default = 0,
        StageEnd = 1,
        StageStart = 2
    }
}
