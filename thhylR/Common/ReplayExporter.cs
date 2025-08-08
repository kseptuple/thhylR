using System.Reflection;
using thhylR.Games;

namespace thhylR.Common
{
    [Obfuscation(Exclude = false)]
    public static class ReplayExporter
    {
        private static EnumItemList stageEnumDataList = EnumData.EnumDataList.FirstOrDefault(e => e.Name == "StageEnum");

        public static byte[] GetAllData(TouhouReplay replay)
        {
            int resultLength = replay.Header.Length + replay.RawData.Length;
            if (replay.InfoBlockRawData != null)
            {
                resultLength += replay.InfoBlockRawData.Length;
            }
            byte[] result = new byte[resultLength];
            Array.Copy(replay.Header, 0, result, 0, replay.Header.Length);
            Array.Copy(replay.RawData, 0, result, replay.Header.Length, replay.RawData.Length);
            if (replay.InfoBlockRawData != null)
            {
                Array.Copy(replay.InfoBlockRawData, 0,
                    result, replay.Header.Length + replay.RawData.Length, replay.InfoBlockRawData.Length);
            }
            return result;
        }

        public static List<ReplayBlock> GetBlocks(TouhouReplay replay)
        {
            int firstStageAddress = int.MaxValue;
            var result = new List<ReplayBlock>();
            var gameOffset = replay.GameData;
            var headerLength = replay.Header.Length;
            var rawDataLength = replay.RawData.Length;

            var stageCount = replay.Stages.Count;
            if (gameOffset.StageSetting.IsVSGame)
            {
                stageCount /= 2;
            }
            for (int i = 0; i < stageCount; i++)
            {
                var stage = replay.Stages[i];
                if (firstStageAddress > stage.HeaderData.Offset)
                {
                    firstStageAddress = stage.HeaderData.Offset;
                }

                int stageId = stage.StageId;
                string vsGameSuffix = string.Empty;

                if (gameOffset.StageSetting.IsVSGame)
                {
                    vsGameSuffix = "_1p";
                }
                string stageName = stage.StageName;
                result.Add(new ReplayBlock()
                {
                    Name = $"{stageName}{vsGameSuffix}_header",
                    Stage = stageName,
                    StageId = stageId,
                    Length = stage.HeaderData.Length,
                    Offset = stage.HeaderData.Offset + headerLength,
                    Type = ReplayBlockType.StageHeader
                });
                result.Add(new ReplayBlock()
                {
                    Name = $"{stageName}{vsGameSuffix}_keydata",
                    Stage = stageName,
                    StageId = stageId,
                    Length = stage.KeyData.Length,
                    Offset = stage.KeyData.Offset + headerLength,
                    Type = ReplayBlockType.KeyData
                });

                if (gameOffset.StageSetting.IsVSGame)
                {
                    var stage2 = replay.Stages[i + replay.Stages.Count / 2];
                    result.Add(new ReplayBlock()
                    {
                        Name = $"{stageName}_2p_header",
                        Stage = stageName,
                        StageId = stage2.StageId,
                        Length = stage2.HeaderData.Length,
                        Offset = stage2.HeaderData.Offset + headerLength,
                        Type = ReplayBlockType.StageHeader
                    });
                    result.Add(new ReplayBlock()
                    {
                        Name = $"{stageName}_2p_keydata",
                        Stage = stageName,
                        StageId = stage2.StageId,
                        Length = stage2.KeyData.Length,
                        Offset = stage2.KeyData.Offset + headerLength,
                        Type = ReplayBlockType.KeyData
                    });
                }

                if (stage.FPSData != null)
                {
                    result.Add(new ReplayBlock()
                    {
                        Name = $"{stageName}_fpsdata",
                        Stage = stageName,
                        StageId = stageId,
                        Length = stage.FPSData.Length,
                        Offset = stage.FPSData.Offset + headerLength,
                        Type = ReplayBlockType.FPSData
                    });
                }
            }

            result.Insert(0, new ReplayBlock()
            {
                Name = $"header",
                Length = firstStageAddress + replay.Header.Length,
                Offset = 0,
                Type = ReplayBlockType.Header
            });

            if (gameOffset.InfoBlock != -1)
            {
                result.Add(new ReplayBlock()
                {
                    Name = $"userblock",
                    Length = replay.InfoBlockRawData.Length,
                    Offset = replay.InfoBlockStart + headerLength + rawDataLength,
                    Type = ReplayBlockType.InfoBlock
                });
            }
            return result;
        }

        public static byte[] GetBlockData(ReplayBlock replayBlock, TouhouReplay replay)
        {
            switch (replayBlock.Type)
            {
                case ReplayBlockType.InfoBlock:
                    return replay.InfoBlockRawData;
                case ReplayBlockType.Header:
                    {
                        var result = new byte[replayBlock.Length];
                        replay.Header.CopyTo(result, 0);
                        int remainLength = replayBlock.Length - replay.Header.Length;
                        replay.RawData[0..remainLength].CopyTo(result, replay.Header.Length);
                        return result;
                    }
                case ReplayBlockType.StageHeader:
                case ReplayBlockType.KeyData:
                case ReplayBlockType.FPSData:
                    {
                        int stageId = replayBlock.StageId;
                        var stageData = replay.Stages.FirstOrDefault(s => s.StageId == stageId);
                        if (stageData != null)
                        {
                            DataOffsetAndLength dataOffsetAndLength = null;
                            if (replayBlock.Type == ReplayBlockType.StageHeader)
                            {
                                dataOffsetAndLength = stageData.HeaderData;
                            }
                            else if (replayBlock.Type == ReplayBlockType.KeyData)
                            {
                                dataOffsetAndLength = stageData.KeyData;
                            }
                            else
                            {
                                dataOffsetAndLength = stageData.FPSData;
                            }
                            return replay.RawData[dataOffsetAndLength.Offset..(dataOffsetAndLength.Offset + dataOffsetAndLength.Length)];
                        }
                        else
                        {
                            return null;
                        }
                    }
                default:
                    return null;
            }
        }
    }

    public class ReplayBlock
    {
        public string Name { get; set; }
        public string Stage { get; set; }
        public int StageId { get; set; } = -1;
        public int Offset { get; set; }
        public int Length { get; set; }
        public ReplayBlockType Type { get; set; }
    }

    public enum ReplayBlockType
    {
        Header,
        StageHeader,
        KeyData,
        FPSData,
        InfoBlock
    }
}
