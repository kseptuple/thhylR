using System.Reflection;
using System.Text;
using thhylR.Helper;
using YamlDotNet.Serialization;

namespace thhylR.Common
{
    [Obfuscation(Exclude = false)]
    public static class GameData
    {
        public static void Init()
        {
            GameDataList = new List<GameOffsets>();
            var deserializer = new DeserializerBuilder().IgnoreUnmatchedProperties().Build();
            string[] yamlFiles = Directory.GetFiles("GameSettings\\", "*.yaml");
            foreach (var yamlFile in yamlFiles)
            {
                using var input = new StreamReader(yamlFile, Encoding.UTF8);
                try
                {
                    List<GameOffsets> tmpGameData = deserializer.Deserialize<List<GameOffsets>>(input);
                    GameDataList.AddRange(tmpGameData);
                }
                catch
                {

                }
            }

            for (int i = 0; i < GameDataList.Count; i++)
            {
                var gameData = GameDataList[i];
                if (!string.IsNullOrEmpty(gameData.Alias))
                {
                    GameOffsets aliasGameData = GameDataList.FirstOrDefault(d => d.GameName == gameData.Alias);
                    if (aliasGameData != null && aliasGameData != gameData)
                    {
                        GameDataCloner.CloneTo(aliasGameData, ref gameData);
                        GameDataList[i] = gameData;
                    }
                }
            }
        }

        public static List<GameOffsets> GameDataList { get; private set; }
    }

    [Obfuscation(Exclude = false)]
    public class GameOffsets : GameDataCloneableClass
    {
        [YamlMember(Alias = "GameName")]
        public string GameName { get; set; }
        [YamlMember(Alias = "GameDisplayName")]
        public string GameDisplayName { get; set; }
        [YamlMember(Alias = "Identifier")]
        public string Identifier { get; set; }
        [YamlMember(Alias = "InfoBlock")]
        public int InfoBlock { get; set; } = -1;
        [YamlMember(Alias = "GameVersion")]
        public int GameVersion { get; set; } = -1;
        [YamlMember(Alias = "ReplayVersion")]
        public int ReplayVersion { get; set; } = -1;

        [YamlMember(Alias = "MatchingGameVersion")]
        public List<short> MatchingGameVersion { get; set; }
        [YamlMember(Alias = "MatchingReplayVersion")]
        public List<short> MatchingReplayVersion { get; set; }

        [YamlMember(Alias = "ReplayHeaderVersion")]
        public int ReplayHeaderVersion { get; set; } = -1;
        [YamlMember(Alias = "ReplayStructVersion")]
        public int ReplayStructVersion { get; set; } = -1;

        [YamlMember(Alias = "DecodeSetting")]
        public DecodeOffsets DecodeSetting { get; set; }
        [YamlMember(Alias = "StageSetting")]
        public StageOffsets StageSetting { get; set; }
        //public int HeaderSize { get; set; } = -1;
        //public int DataSize { get; set; } = -1;

        [YamlMember(Alias = "Alias")]
        public string Alias { get; set; }
        [YamlMember(Alias = "NeedStage")]
        public bool NeedStage { get; set; } = true;
        [YamlMember(Alias = "CustomReplayInfo")]
        public List<GameCustomInfoItem> CustomReplayInfo { get; set; }
    }

    [Obfuscation(Exclude = false)]
    public class DecodeOffsets : GameDataCloneableClass
    {
        [YamlMember(Alias = "DecodeVersion")]
        public int DecodeVersion { get; set; } = -1;
        [YamlMember(Alias = "DecompressVersion")]
        public int DecompressVersion { get; set; } = -1;

        [YamlMember(Alias = "DecodeStartData")]
        public int DecodeStartData { get; set; }

        [YamlMember(Alias = "DecodeBaseParam")]
        public int DecodeBaseParam { get; set; }

        [YamlMember(Alias = "DecodeAdderData")]
        public byte DecodeAdderData { get; set; }

        [YamlMember(Alias = "DecodeHeaderBlockLength")]
        public int DecodeHeaderBlockLength { get; set; }

        [YamlMember(Alias = "BlockSizeDataV2")]
        public List<int> BlockSizeDataV2 { get; set; }
        [YamlMember(Alias = "DecodeBaseParamDataV2")]
        public List<byte> DecodeBaseParamDataV2 { get; set; }
        [YamlMember(Alias = "DecodeAdderDataV2")]
        public List<byte> DecodeAdderDataV2 { get; set; }

        [YamlMember(Alias = "DecompressStartData")]
        public int DecompressStartData { get; set; }
        [YamlMember(Alias = "DecompressLength")]
        public int DecompressLength { get; set; }
        [YamlMember(Alias = "AfterDecompressLength")]
        public int AfterDecompressLength { get; set; }
        [YamlMember(Alias = "CalculateDecompressLength")]
        public bool CalculateDecompressLength { get; set; } = false;

        //public int RawLength { get; set; }
    }

    [Obfuscation(Exclude = false)]
    public class StageOffsets : GameDataCloneableClass
    {
        [YamlMember(Alias = "FirstStage")]
        public int FirstStage { get; set; }
        [YamlMember(Alias = "FirstStageData")]
        public int FirstStageData { get; set; }
        [YamlMember(Alias = "FPSStartData")]
        public int FPSStartData { get; set; } = -1;
        [YamlMember(Alias = "TotalStageCountData")]
        public int TotalStageCountData { get; set; }
        [YamlMember(Alias = "TotalStageCount")]
        public int TotalStageCount { get; set; } = -1;
        [YamlMember(Alias = "StageHeaderSizeData")]
        public int StageHeaderSizeData { get; set; }
        [YamlMember(Alias = "IsStageEndScore")]
        public bool IsStageEndScore { get; set; } = false;
        [YamlMember(Alias = "KeySizeData")]
        public int KeySizeData { get; set; }
        [YamlMember(Alias = "StageNumOfStage")]
        public int StageNumOfStage { get; set; }
        [YamlMember(Alias = "KeyCountOfStage")]
        public int KeyCountOfStage { get; set; }
        [YamlMember(Alias = "TotalSizeOrFpsSizeOfStage")]
        public int TotalSizeOrFpsSizeOfStage { get; set; }
        [YamlMember(Alias = "UseFpsSize")]
        public bool UseFpsSize { get; set; } = false;
        [YamlMember(Alias = "UseKeyDataSize")]
        public bool UseKeyDataSize { get; set; } = false;
        [YamlMember(Alias = "IsVSGame")]
        public bool IsVSGame { get; set; } = false;
        [YamlMember(Alias = "CustomStageInfo")]
        public List<GameCustomInfoItem> CustomStageInfo { get; set; }
        [YamlMember(Alias = "KeyData")]
        public KeyDataSetting KeyData { get; set; }
    }

    [Obfuscation(Exclude = false)]
    public class KeyDataSetting : GameDataCloneableClass
    {
        [YamlMember(Alias = "FirstFrameIsNullFrame")]
        public bool FirstFrameIsNullFrame { get; set; } = false;
        [YamlMember(Alias = "HasTerminateMark")]
        public bool HasTerminateMark { get; set; } = true;
        [YamlMember(Alias = "KeyNames")]
        public List<string> KeyNames { get; set; }
        [YamlMember(Alias = "KeySize")]
        public int KeySize { get; set; }
        [YamlMember(Alias = "KeyDataVersion")]
        public int KeyDataVersion { get; set; }
        [YamlMember(Alias = "FirstFPSFrameIsNullFrame")]
        public bool FirstFPSFrameIsNullFrame { get; set; } = false;
        [YamlMember(Alias = "FPSSize")]
        public int FPSSize { get; set; } = 1;
    }

    [Obfuscation(Exclude = false)]
    public class GameCustomInfoItem
    {
        [YamlMember(Alias = "Name")]
        public string Name { get; set; }
        [YamlMember(Alias = "DisplayName")]
        public string DisplayName { get; set; }
        [YamlMember(Alias = "Offset")]
        public int Offset { get; set; }
        [YamlMember(Alias = "Size")]
        public int Size { get; set; }
        [YamlMember(Alias = "Count")]
        public int Count { get; set; }
        [YamlMember(Alias = "Type")]
        public string Type { get; set; }
        [YamlMember(Alias = "UseAlternativeSource")]
        public bool UseAlternativeSource { get; set; } = false;
        [YamlMember(Alias = "EnumList")]
        public string EnumList { get; set; }
        [YamlMember(Alias = "SubItems")]
        public List<GameCustomInfoItem> SubItems { get; set; }
        [YamlMember(Alias = "Modifier")]
        public string Modifier { get; set; }
        [YamlMember(Alias = "IsVisible")]
        public string IsVisible { get; set; } = "true";
        [YamlMember(Alias = "Formatter")]
        public string Formatter { get; set; }
        [YamlMember(Alias = "SpecificPlayer")]
        public string SpecificPlayer { get; set; }
        [YamlMember(Alias = "EndMark")]
        public string EndMark { get; set; }
        [YamlMember(Alias = "SkipMark")]
        public string SkipMark { get; set; }
        [YamlMember(Alias = "Ignore")]
        public bool Ignore { get; set; } = false;
        [YamlMember(Alias = "FixedValue")]
        public string FixedValue { get; set; }
        [YamlMember(Alias = "CapAt")]
        public string CapAt { get; set; }
        [YamlMember(Alias = "AfterCapValue")]
        public object AfterCapValue { get; set; }
        [YamlMember(Alias = "MultilineList")]
        public bool MultilineList { get; set; } = false;
    }

    public abstract class GameDataCloneableClass
    {
        public List<string> OverrideFields { get; set; }
    }
}
