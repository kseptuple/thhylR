﻿using Microsoft.Win32;
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
                    new() { EncodingId = 936, UseEncoding = true },
                    new() { EncodingId = 0, UseEncoding = true },
                    new() { EncodingId = -1, UseEncoding = false }
                };

                Settings.NormalFont = new Font(SystemFonts.DefaultFont.Name, 12F, FontStyle.Regular);
                Settings.SymbolFont = new Font("Segoe UI Symbol", 12F, FontStyle.Regular);

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
            Settings.NormalFontInfo.Name = Settings.NormalFont.Name;
            Settings.NormalFontInfo.Size = Settings.NormalFont.Size;
            Settings.NormalFontInfo.Style = Settings.NormalFont.Style;
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
}
