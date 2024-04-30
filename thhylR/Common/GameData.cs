using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YamlDotNet.Serialization;
using System.Threading.Tasks;
using thhylR.Games;
using thhylR.Helper;

namespace thhylR.Common
{
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

    public class GameOffsets : GameDataCloneableClass
    {
        public string GameName { get; set; }
        public string GameDisplayName { get; set; }
        public string Identifier { get; set; }
        public int InfoBlock { get; set; } = -1;
        public int GameVersion { get; set; } = -1;
        public int ReplayVersion { get; set; } = -1;

        public List<short> MatchingGameVersion { get; set; }
        public List<short> MatchingReplayVersion { get; set; }

        public int ReplayHeaderVersion { get; set; } = -1;
        public int ReplayStructVersion { get; set; } = -1;

        public DecodeOffsets DecodeSetting { get; set; }
        public StageOffsets StageSetting { get; set; }
        //public int HeaderSize { get; set; } = -1;
        //public int DataSize { get; set; } = -1;

        public string Alias { get; set; }
        public bool NeedStage { get; set; } = true;
        public List<GameCustomInfoItem> CustomReplayInfo { get; set; }
    }

    public class DecodeOffsets : GameDataCloneableClass
    {
        public int DecodeVersion { get; set; } = -1;
        public int DecompressVersion { get; set; } = -1;

        public int DecodeStartData { get; set; }

        public int DecodeBaseParam { get; set; }

        public byte DecodeAdderData { get; set; }

        public int DecodeHeaderBlockLength { get; set; }

        public List<int> BlockSizeDataV2 { get; set; }
        public List<byte> DecodeBaseParamDataV2 { get; set; }
        public List<byte> DecodeAdderDataV2 { get; set; }

        public int DecompressStartData { get; set; }
        public int DecompressLength { get; set; }
        public int AfterDecompressLength { get; set; }
        public bool CalculateDecompressLength { get; set; } = false;

        //public int RawLength { get; set; }
    }

    public class StageOffsets : GameDataCloneableClass
    {
        public int FirstStage { get; set; }
        public int FirstStageData { get; set; }
        public int FPSStartData { get; set; } = -1;
        public int TotalStageCountData { get; set; }
        public int TotalStageCount { get; set; } = -1;
        public int StageHeaderSizeData { get; set; }
        public bool IsStageEndScore { get; set; } = false;
        public int KeySizeData { get; set; }
        public int StageNumOfStage { get; set; }
        public int KeyCountOfStage { get; set; }
        public int TotalSizeOrFpsSizeOfStage { get; set; }
        public bool UseFpsSize { get; set; } = false;
        public bool UseKeyDataSize { get; set; } = false;
        public bool IsVSGame { get; set; } = false;
        public List<GameCustomInfoItem> CustomStageInfo { get; set; }
        public KeyDataSetting KeyData { get; set; }
    }

    public class KeyDataSetting : GameDataCloneableClass
    {
        public bool FirstFrameIsNullFrame { get; set; } = false;
        public bool HasTerminateMark { get; set; } = true;
        public List<string> KeyNames { get; set; }
        public int KeySize { get; set; }
        public int KeyDataVersion { get; set; }
    }

    public class GameCustomInfoItem
    {
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public int Offset { get; set; }
        public int Size { get; set; }
        public int Count { get; set; }
        public string Type { get; set; }
        public bool UseAlternativeSource { get; set; } = false;
        public string EnumList { get; set; }
        public List<GameCustomInfoItem> SubItems { get; set; }
        public string Modifier { get; set; }
        public string IsVisible { get; set; } = "true";
        public string Formatter { get; set; }
        public string SpecificPlayer { get; set; }
        public string EndMark { get; set; }
        public string SkipMark { get; set; }
        public bool Ignore { get; set; } = false;
        public string FixedValue { get; set; }
        public string CapAt { get; set; }
        public object AfterCapValue { get; set; }
    }

    public abstract class GameDataCloneableClass
    {
        public List<string> OverrideFields { get; set; }
    }
}
