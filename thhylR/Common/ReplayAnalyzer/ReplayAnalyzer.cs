using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;
using thhylR.Games;
using thhylR.Helper;

namespace thhylR.Common
{
    public static partial class ReplayAnalyzer
    {
        public static int defaultCodePage = 932;
        public static int defaultCHNCodePage = 936;

        public static bool IsSpecialCHNVersion(string gameId, byte[] afterDecompressData)
        {
            string version = null;
            uint value1 = 0, value2 = 0;
            int offset = 0;
            switch (gameId)
            {
                case "Th07":
                    offset = 0x8c;
                    value1 = 0x0009EE00;
                    value2 = 0xAEC5445C;
                    version = "0100b";
                    break;
                case "Th08":
                    offset = 0xc4;
                    value1 = 0x000CD400;
                    value2 = 0xA26861B9;
                    version = "0100d";
                    break;
                case "Th09":
                    offset = 0x11c;
                    value1 = 0x000A7400;
                    value2 = 0xABEE4C8F;
                    version = "0150a";
                    break;
                default:
                    return false;
            }
            if (Encoding.ASCII.GetString(afterDecompressData[offset..(offset + 5)]) != version)
            {
                return false;
            }
            if (BitConverter.ToUInt32(afterDecompressData, offset - 8) == value1 && BitConverter.ToUInt32(afterDecompressData, offset - 4) == value2)
            {
                return false;
            }
            return true;
        }

        public static TouhouReplay Analyze(byte[] replayData, int codePage)
        {
            TouhouReplay result = null;
            var identifier = Encoding.ASCII.GetString(replayData[0..4]);
            foreach (var gameData in GameData.GameDataList)
            {
                if (gameData.Identifier == identifier)
                {
                    bool isMatching = true;
                    if (gameData.MatchingGameVersion != null && gameData.MatchingGameVersion.Count != 0 && gameData.GameVersion != -1)
                    {
                        short currentGameVersion = BitConverter.ToInt16(replayData, gameData.GameVersion);
                        if (gameData.MatchingGameVersion.IndexOf(currentGameVersion) == -1)
                        {
                            isMatching = false;
                        }
                    }
                    if (isMatching && gameData.MatchingReplayVersion != null && gameData.MatchingReplayVersion.Count != 0 && gameData.ReplayVersion != -1)
                    {
                        short currentReplayVersion = BitConverter.ToInt16(replayData, gameData.ReplayVersion);
                        if (gameData.MatchingReplayVersion.IndexOf(currentReplayVersion) == -1)
                        {
                            isMatching = false;
                        }
                    }
                    if (isMatching)
                    {
                        result = AnalyzeWithOffsets(replayData, gameData, codePage);
                        if (result != null)
                            break;
                    }
                }
            }

            return result;
        }

        private static TouhouReplay AnalyzeWithOffsets(byte[] replayData, GameOffsets gameData, int codePage)
        {
            if (gameData == null) return null;
            TouhouReplay result = new TouhouReplay();
            result.GameData = gameData;
            insertIntoDisplayTable(ResourceLoader.getTextResource("GameName"), gameData.GameDisplayName, gameData.GameDisplayName, "GameDisplayName", -1);
            var decodeSetting = gameData.DecodeSetting;
            List<InfoBlock> infoBlocks = null;
            byte[] infoBlockData = null;
            if (gameData.InfoBlock != -1)
            {
                int infoBlockStartData = BitConverter.ToInt32(replayData, gameData.InfoBlock);
                result.InfoBlockStart = infoBlockStartData;
                infoBlockData = replayData[infoBlockStartData..];
                infoBlocks = UserInfo.GetReplayInfoBlocks(replayData, infoBlockStartData);
            }
            result.InfoBlockRawData = infoBlockData;
            result.InfoBlocks = infoBlocks;

            byte[] beforeDecompressData = null;
            byte[] header = null;
            if (decodeSetting.DecodeVersion == 1)
            {
                byte decodeBase = replayData[decodeSetting.DecodeBaseParam];
                int decodeEnd = 0;
                if (gameData.InfoBlock == -1)
                {
                    decodeEnd = replayData.Length;
                }
                else
                {
                    decodeEnd = BitConverter.ToInt32(replayData, gameData.InfoBlock);
                }
                ReplayDecrypt.DecodeV1(replayData, decodeSetting.DecodeStartData, decodeEnd, decodeBase, decodeSetting.DecodeAdderData);
                var decompressStart = decodeSetting.DecompressStartData;
                beforeDecompressData = replayData[decompressStart..];
                header = replayData[0..decompressStart];
            }
            else if (decodeSetting.DecodeVersion == 2)
            {
                var decodeStart = decodeSetting.DecodeStartData;
                beforeDecompressData = replayData[decodeStart..];
                header = replayData[0..decodeStart];
                var decodeLength = BitConverter.ToInt32(replayData, decodeSetting.DecompressLength);
                ReplayDecrypt.DecodeV2(beforeDecompressData, decodeLength, decodeSetting.BlockSizeDataV2[0], decodeSetting.DecodeBaseParamDataV2[0], decodeSetting.DecodeAdderDataV2[0]);
                ReplayDecrypt.DecodeV2(beforeDecompressData, decodeLength, decodeSetting.BlockSizeDataV2[1], decodeSetting.DecodeBaseParamDataV2[1], decodeSetting.DecodeAdderDataV2[1]);
            }
            else
            {
                throw new NotSupportedException();
            }

            byte[] afterDecompressData = null;
            if (decodeSetting.DecompressVersion == 0)
            {
                afterDecompressData = beforeDecompressData;
            }
            else if (decodeSetting.DecompressVersion == 1)
            {
                var decompressedLength = BitConverter.ToInt32(replayData, decodeSetting.AfterDecompressLength);
                int decompressLength = 0;
                if (decodeSetting.CalculateDecompressLength)
                {
                    decompressLength = BitConverter.ToInt32(replayData, gameData.InfoBlock) - decodeSetting.DecompressStartData;
                }
                else
                {
                    decompressLength = BitConverter.ToInt32(replayData, decodeSetting.DecompressLength);
                }
                afterDecompressData = ReplayDecrypt.Decompress(beforeDecompressData, decompressedLength, decompressLength);
            }

            result.Header = header;
            result.RawData = afterDecompressData;
            result.GameRelatedData = gameData.CustomReplayInfo;

            result.GameCustomDataHeader = new GameDataSource(result.Header);
            result.GameCustomDataBody = new GameDataSource(result.RawData);

            int infoCodePage = defaultCodePage;
            if (IsSpecialCHNVersion(gameData.GameName, afterDecompressData))
            {
                result.ReplayProblem |= ReplayProblemEnum.ChnVerReplay;
                if (gameData.GameName == "Th08")
                {
                    infoCodePage = defaultCHNCodePage;
                }
            }

            if (infoBlocks != null)
            {
                var userBlock = infoBlocks.FirstOrDefault(b => b.BlockType == InfoBlock.UserBlockType.UserInfo);
                if (userBlock != null)
                {
                    string replaySummary = UserInfo.GetStringFromByteArray(infoCodePage, userBlock.Data);
                    insertIntoDisplayTable(ResourceLoader.getTextResource("ReplaySummary"), replaySummary, replaySummary, "ReplaySummary", -1);
                }
                var commentBlock = infoBlocks.FirstOrDefault(b => b.BlockType == InfoBlock.UserBlockType.Comment);
                if (commentBlock != null)
                {
                    string comment = UserInfo.GetStringFromByteArray(codePage, commentBlock.Data);
                    insertIntoDisplayTable(ResourceLoader.getTextResource("ReplayComment"), comment, comment, "Comment", -1);
                }
            }
            insertEmptyLine();

            GameDataSource defaultData = result.GameCustomDataBody;
            GameDataSource alternativeData = result.GameCustomDataHeader;

            addDisplayData(gameData.CustomReplayInfo, defaultData, alternativeData, -1);

            var stageSetting = gameData.StageSetting;
            List<DataOffsetAndLength> stages = null;
            if (gameData.ReplayStructVersion == 1)
            {
                stages = GetStagePointersV1(header, stageSetting.FirstStage, stageSetting.TotalStageCountData, afterDecompressData.Length);
            }
            else if (gameData.ReplayStructVersion == 2)
            {
                bool isCorrupted = false;
                stages = GetStagePointersV2(afterDecompressData, gameData.StageSetting, out isCorrupted);
                if (isCorrupted)
                {
                    result.ReplayProblem |= ReplayProblemEnum.StageLengthError;
                }
            }
            if (stages == null)
            {
                return null;
            }
            bool hasFPSData = true;
            if (stageSetting.FPSStartData == -1 && gameData.ReplayStructVersion == 1)
            {
                hasFPSData = false;
            }
            int stageCount = hasFPSData ? stages.Count / 2 : stages.Count;
            result.Stages = new List<StageData>();
            int FPSPosStart = stageSetting.FPSStartData == -1 ? stageCount : stageSetting.FPSStartData;
            int currentFPSPos = FPSPosStart;
            for (int i = 0; i < stageCount; i++)
            {
                if (stages[i] != null)
                {
                    var stageData = new StageData();
                    stageData.HeaderData = new DataOffsetAndLength();
                    stageData.HeaderData.Offset = stages[i].Offset;
                    stageData.HeaderData.Length = stageSetting.StageHeaderSizeData;
                    stageData.KeyData = new DataOffsetAndLength();
                    stageData.KeyData.Offset = stages[i].Offset + stageSetting.StageHeaderSizeData;
                    stageData.KeyData.Length = stages[i].Length - stageSetting.StageHeaderSizeData;
                    if (hasFPSData)
                    {
                        stageData.FPSData = new FPSData();
                        stageData.FPSData.Data = stages[currentFPSPos];
                    }

                    stageData.StageId = i;
                    stageData.GameRelatedData = stageSetting.CustomStageInfo;

                    stageData.GameCustomData = new GameDataSource(result.RawData, stageData.HeaderData.Offset);

                    result.Stages.Add(stageData);
                }
                if (hasFPSData)
                {
                    currentFPSPos++;
                    if (currentFPSPos >= stages.Count)
                    {
                        currentFPSPos = FPSPosStart;
                    }
                }
            }

            var stageEnumDataList = EnumData.EnumDataList.FirstOrDefault(e => e.Name == "StageEnum");
            string stageFormatter = "Stage";
            if (stageEnumDataList != null)
            {
                var stageEnumData = stageEnumDataList.EnumValues.FirstOrDefault(e => e.Name == gameData.GameName);
                if (stageEnumData != null)
                {
                    stageFormatter = stageEnumData.Value;
                }
            }
            if (stageSetting.IsVSGame)
            {
                int actualStageCount = result.Stages.Count / 2;
                for (var i = 0; i < actualStageCount; i++)
                {
                    var p1Data = result.Stages[i];
                    var p2Data = result.Stages[i + actualStageCount];
                    var stageId = p1Data.StageId;
                    if (gameData.NeedStage)
                    {
                        insertEmptyLine();
                        insertIntoDisplayTable(ResourceLoader.getTextResource("GameStage"), null, stageId, "Stage", stageId, 
                            string.Empty, string.Empty, "true", stageFormatter);
                    }
                    else
                    {
                        stageId = -1;
                    }
                    addVSGameStageDisplayData(stageSetting.CustomStageInfo, p1Data.GameCustomData, p2Data.GameCustomData, stageId);
                }
            }
            else
            {
                for (var i = 0; i < result.Stages.Count; i++)
                {
                    var stageData = result.Stages[i];
                    var stageId = stageData.StageId;
                    if (gameData.NeedStage)
                    {
                        insertEmptyLine();
                        insertIntoDisplayTable(ResourceLoader.getTextResource("GameStage"), null, stageId, "Stage", stageId, 
                            string.Empty, string.Empty, "true", stageFormatter);
                    }
                    else
                    {
                        stageId = -1;
                    }
                    addDisplayData(stageData.GameRelatedData, stageData.GameCustomData, stageData.GameCustomData, stageId);
                }
            }

            ProcessDisplayData(result.DisplayData);

            result.DisplayData.AcceptChanges();

            return result;

            void addDisplayData(List<GameCustomInfoItem> customInfoItem, GameDataSource defaultData, GameDataSource alternativeData, int stage, int padBefore = 0)
            {
                string pad = new string(' ', padBefore);
                if (customInfoItem == null) return;
                if (defaultData == null && alternativeData == null) return;

                foreach (var gameCustomInfo in customInfoItem)
                {
                    if (gameCustomInfo.Ignore) continue;
                    object rawValue = null;
                    string displayName = null;
                    List<GameCustomInfoItem> subCustomInfoItem = null;
                    if (!gameCustomInfo.UseAlternativeSource)
                    {
                        if (defaultData == null) continue;
                        rawValue = defaultData.GetItem(gameCustomInfo.Name, customInfoItem, out displayName, out subCustomInfoItem);
                    }
                    else
                    {
                        if (alternativeData == null) continue;
                        rawValue = alternativeData.GetItem(gameCustomInfo.Name, customInfoItem, out displayName, out subCustomInfoItem);
                    }
                    displayName = displayName ?? string.Empty;
                    string name = pad + displayName;

                    if (rawValue is GameDataSource || rawValue is List<GameDataSource>)
                    {
                        if (rawValue is GameDataSource)
                        {
                            insertIntoDisplayTable(name, string.Empty, string.Empty, gameCustomInfo.Name, stage);
                            var newData = rawValue as GameDataSource;
                            addDisplayData(subCustomInfoItem, newData, newData, stage, padBefore);
                        }
                        else if (rawValue is List<GameDataSource>)
                        {
                            var newDataList = rawValue as List<GameDataSource>;
                            for (int i = 0; i < newDataList.Count; i++)
                            {
                                insertIntoDisplayTable(name + " " + i, string.Empty, string.Empty, gameCustomInfo.Name, stage);
                                var newData = newDataList[i];
                                addDisplayData(subCustomInfoItem, newData, newData, stage, padBefore + 2);
                            }
                        }
                    }
                    else
                    {
                        if (string.IsNullOrEmpty(gameCustomInfo.FixedValue))
                        {
                            insertIntoDisplayTable(name, null, rawValue, gameCustomInfo.Name, stage, gameCustomInfo.Modifier,
                                gameCustomInfo.Formatter, gameCustomInfo.IsVisible, gameCustomInfo.EnumList);
                        }
                        else
                        {
                            insertIntoDisplayTable(name, null, gameCustomInfo.FixedValue, gameCustomInfo.Name, stage,
                                string.Empty, string.Empty, gameCustomInfo.IsVisible);
                        }
                    }
                }
            }

            void addVSGameStageDisplayData(List<GameCustomInfoItem> customInfoItem, GameDataSource p1Data, GameDataSource p2Data, int stage, int padBefore = 0)
            {
                string pad = new string(' ', padBefore);
                if (customInfoItem == null) return;
                if (p1Data == null && p2Data == null) return;

                foreach (var gameCustomInfo in customInfoItem)
                {
                    for (int j = 0; j < 2; j++)
                    {
                        string displayName = null;
                        string id = null;
                        string displayNamePrefix = string.Empty;
                        List<GameCustomInfoItem> subCustomInfoItem = null;
                        GameDataSource currentData = null;
                        if (j == 0)
                        {
                            if (gameCustomInfo.SpecificPlayer == "Player2") continue;
                            id = gameCustomInfo.Name + "P1";
                            currentData = p1Data;
                            if (gameCustomInfo.SpecificPlayer != "Player1")
                                displayNamePrefix = "1P";
                        }
                        else
                        {
                            if (gameCustomInfo.SpecificPlayer == "Player1") continue;
                            id = gameCustomInfo.Name + "P2";
                            currentData = p2Data;
                            if (gameCustomInfo.SpecificPlayer != "Player2")
                                displayNamePrefix = "2P";
                        }

                        if (currentData == null) continue;
                        object rawValue = currentData.GetItem(gameCustomInfo.Name, customInfoItem, out displayName, out subCustomInfoItem);

                        displayName = displayNamePrefix + (displayName ?? string.Empty);
                        string name = pad + displayName;

                        if (rawValue is GameDataSource || rawValue is List<GameDataSource>)
                        {
                            if (rawValue is GameDataSource)
                            {
                                insertIntoDisplayTable(name, string.Empty, string.Empty, id, stage);
                                var newData = rawValue as GameDataSource;
                                addDisplayData(subCustomInfoItem, newData, newData, stage, padBefore);
                            }
                            else if (rawValue is List<GameDataSource>)
                            {
                                var newDataList = rawValue as List<GameDataSource>;
                                for (int i = 0; i < newDataList.Count; i++)
                                {
                                    insertIntoDisplayTable(name + " " + i, string.Empty, string.Empty, id, stage);
                                    var newData = newDataList[i];
                                    addDisplayData(subCustomInfoItem, newData, newData, stage, padBefore + 2);
                                }
                            }
                        }
                        else
                        {
                            if (string.IsNullOrEmpty(gameCustomInfo.FixedValue))
                            {
                                insertIntoDisplayTable(name, null, rawValue, id, stage, gameCustomInfo.Modifier,
                                    gameCustomInfo.Formatter, gameCustomInfo.IsVisible, gameCustomInfo.EnumList);
                            }
                            else
                            {
                                insertIntoDisplayTable(name, null, gameCustomInfo.FixedValue, id, stage,
                                    string.Empty, string.Empty, gameCustomInfo.IsVisible);
                            }
                        }
                    }
                }
            }

            void insertIntoDisplayTable(string name, object value, object rawValue, string id, int stage,
                string modifier = "", string formatter = "", string isVisible = "", string enumList = "")
            {
                DataRow dr = result.DisplayData.NewRow();
                dr["Name"] = name;
                dr["Value"] = value;
                dr["RawValue"] = rawValue;
                dr["Id"] = id;
                dr["Modifier"] = modifier;
                dr["Formatter"] = formatter;
                dr["Visible"] = isVisible;
                dr["EnumList"] = enumList;
                dr["Stage"] = stage;
                //dr["IsSymbol"] = false;
                result.DisplayData.Rows.Add(dr);
            }

            void insertEmptyLine()
            {
                insertIntoDisplayTable(string.Empty, null, null, string.Empty, -1);
            }
        }

        public static void changeEncoding(TouhouReplay replay, int codePage)
        {
            if (replay.InfoBlocks == null) return;
            DataTable data = replay.DisplayData;
            var infoBlocks = replay.InfoBlocks;

            var commentBlock = infoBlocks.FirstOrDefault(b => b.BlockType == InfoBlock.UserBlockType.Comment);
            if (commentBlock != null)
            {
                string comment = UserInfo.GetStringFromByteArray(codePage, commentBlock.Data);
                DataRow dr = data.Select("Id = 'Comment'").FirstOrDefault();
                if (dr != null)
                {
                    dr["DisplayValue"] = comment;
                    dr["Value"] = comment;
                    dr["RawValue"] = comment;
                }
            }

            data.AcceptChanges();
        }

        public static List<DataOffsetAndLength> GetStagePointersV1(byte[] header, int firstOffset, int stageCount, int totalSize)
        {
            int offset = firstOffset;
            int headerSize = header.Length;
            List<DataOffsetAndLength> result = new List<DataOffsetAndLength>();
            var lastValidStage = -1;
            for (int i = 0; i < stageCount; i++)
            {
                DataOffsetAndLength item = new DataOffsetAndLength();
                int stageOffset = BitConverter.ToInt32(header, offset) - headerSize;
                if (stageOffset >= 0 && stageOffset < totalSize)
                {
                    item.Offset = stageOffset;
                    if (lastValidStage != -1)
                    {
                        var lastLength = stageOffset - result[lastValidStage].Offset;
                        if (lastLength > 0)
                        {
                            result[lastValidStage].Length = lastLength;
                        }
                        else
                        {
                            item = null;
                        }
                    }
                    result.Add(item);
                    if (item != null)
                    {
                        lastValidStage = i;
                    }
                }
                else
                {
                    result.Add(null);
                }
                offset += 4;
            }
            result[lastValidStage].Length = totalSize - result[lastValidStage].Offset;
            return result;
        }

        public static List<DataOffsetAndLength> GetStagePointersV2(byte[] decompressedData, StageOffsets stageData, out bool isLengthCorrupted)
        {
            isLengthCorrupted = false;
            List<DataOffsetAndLength> result = new List<DataOffsetAndLength>();
            for (int i = 0; i < stageData.TotalStageCountData * 2; i++)
            {
                result.Add(null);
            }

            int stageCount = 0;
            if (stageData.TotalStageCount == -1)
            {
                stageCount = 1;
            }
            else
            {
                stageCount = BitConverter.ToInt32(decompressedData, stageData.TotalStageCount);
            }
            if (stageCount == 0)
            {
                return null;
            }
            int currentStageStart = stageData.FirstStageData;
            for (int i = 0; i < stageCount; i++)
            {
                if (currentStageStart >= decompressedData.Length || currentStageStart < 0)
                {
                    return null;
                }
                int dataSize = BitConverter.ToInt32(decompressedData, currentStageStart + stageData.TotalSizeOrFpsSizeOfStage);
                int keyCount = BitConverter.ToInt32(decompressedData, currentStageStart + stageData.KeyCountOfStage);
                if (dataSize < 0 || keyCount < 0)
                {
                    return null;
                }

                DataOffsetAndLength item = new DataOffsetAndLength();
                DataOffsetAndLength fpsItem = new DataOffsetAndLength();
                item.Offset = currentStageStart;
                int rawStageLength = keyCount * stageData.KeySizeData;
                if (stageData.UseKeyDataSize)
                {
                    rawStageLength = keyCount;
                }

                if (stageData.UseFpsSize)
                {
                    fpsItem.Length = dataSize;
                }
                else
                {
                    if (dataSize < rawStageLength)
                    {
                        isLengthCorrupted = true;
                        keyCount = (int)Math.Floor(dataSize / (stageData.KeySizeData + 1.0 / 30));
                        rawStageLength = keyCount * stageData.KeySizeData;
                        Debug.Assert(keyCount / 30 + 1 + rawStageLength == dataSize);
                    }
                    fpsItem.Length = dataSize - rawStageLength;
                }

                item.Length = rawStageLength + stageData.StageHeaderSizeData;
                fpsItem.Offset = item.Length + currentStageStart;

                if (item.Offset + item.Length > decompressedData.Length || fpsItem.Offset + fpsItem.Length > decompressedData.Length)
                {
                    return null;
                }
                if (stageData.TotalStageCount == -1)
                {
                    result[0] = item;
                    result[1] = fpsItem;
                }
                else
                {
                    short stageNum = BitConverter.ToInt16(decompressedData, currentStageStart + stageData.StageNumOfStage);
                    if (stageNum > stageData.TotalStageCountData)
                    {
                        return null;
                    }
                    result[stageNum - 1] = item;
                    result[stageData.TotalStageCountData + stageNum - 1] = fpsItem;
                }

                currentStageStart += item.Length + fpsItem.Length;
            }

            return result;
        }
    }
}
