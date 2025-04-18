﻿using System.Data;
using System.Text;
using thhylR.Common;

namespace thhylR.Games
{
    public class TouhouReplay
    {
        public GameOffsets GameData { get; set; }

        public string FilePath { get; set; }

        public byte[] Header { get; set; }
        public byte[] RawData { get; set; }
        public byte[] InfoBlockRawData { get; set; }

        public List<StageData> Stages { get; set; }

        public List<InfoBlock> InfoBlocks { get; set; }

        public int InfoBlockStart { get; set; } = -1;

        public int TotalFrameCount { get; set; }
        public double CalculatedTotalSlowRate { get; set; }

        public List<GameCustomInfoItem> GameRelatedData { get; set; }
        public GameDataSource GameCustomDataHeader { get; set; }
        public GameDataSource GameCustomDataBody { get; set; }

        public DataTable DisplayData { get; set; }
        public List<DataRow> DisplayDataList { get; set; } = new List<DataRow>();

        public ReplayProblemEnum ReplayProblem { get; set; }

        public TouhouReplay()
        {
            DisplayData = new DataTable();
            DisplayData.Columns.Add("Name");
            DisplayData.Columns.Add("DisplayValue");
            DisplayData.Columns.Add(new DataColumn("Value", typeof(object)));
            DisplayData.Columns.Add(new DataColumn("RawValue", typeof(object)));
            DisplayData.Columns.Add("Id");
            DisplayData.Columns.Add("Modifier");
            DisplayData.Columns.Add("Formatter");
            DisplayData.Columns.Add("Visible");
            DisplayData.Columns.Add("EnumList");
            DisplayData.Columns.Add(new DataColumn("Stage", typeof(int)));
            DisplayData.Columns.Add(new DataColumn("IsSymbol", typeof(bool)));
            DisplayData.Columns.Add("ExtraData");
            DisplayData.AcceptChanges();
        }
    }

    [Flags]
    public enum ReplayProblemEnum
    {
        None = 0,
        FileNotExist = 0x1,
        ChnVerReplay = 0x2,
        StageLengthError = 0x4,
    }

    public class DataOffsetAndLength
    {
        public int Offset { get; set; }
        public int Length { get; set; }
    }

    public class GameDataSource
    {
        public byte[] Data { get; set; }
        //public List<GameCustomInfoItem> DataInfoList { get; set; }
        public int BeginOffset { get; set; }

        private static readonly DateTime win32FileTimeEpoch = new DateTime(1601, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
        //private static readonly Regex modifierReplacer = new Regex(@"\{[^\{\}]*?\}", RegexOptions.Compiled);

        public GameDataSource(byte[] data)
        {
            Data = data;
            //DataInfoList = datainfo;
            BeginOffset = 0;
        }

        public GameDataSource(byte[] data, int beginOffset) : this(data)
        {
            BeginOffset = beginOffset;
        }

        public object GetItem(List<DataRow> allData, int stage, string extraData, string name, List<GameCustomInfoItem> dataInfoList,
            out string displayName, out List<GameCustomInfoItem> subDataInfoList, bool isGetMark = false, int extraOffset = 0)
        {
            displayName = null;
            subDataInfoList = null;
            var customInfoItem = dataInfoList.FirstOrDefault(i => i.Name == name);
            if (customInfoItem == null) return null;
            return GetItem(allData, stage, extraData, customInfoItem, dataInfoList, out displayName, out subDataInfoList, isGetMark, extraOffset);
        }

        public object GetItem(List<DataRow> allData, int stage, string extraData, GameCustomInfoItem customInfoItem,
            List<GameCustomInfoItem> dataInfoList, out string displayName, out List<GameCustomInfoItem> subDataInfoList,
            bool isGetMark = false, int extraOffset = 0)
        {
            displayName = customInfoItem.DisplayName;
            subDataInfoList = null;
            object result = null;
            int offset = BeginOffset + extraOffset + customInfoItem.Offset;
            if (customInfoItem.Type != null)
            {
                string type = customInfoItem.Type.ToLower();
                bool isList = false;
                if (type.EndsWith("[]"))
                {
                    isList = true;
                    type = type[..^2];
                }
                Func<int, object> itemGetter = null;
                int size = 0;
                switch (type)
                {
                    case "byte":
                        itemGetter = o => Data[o];
                        size = 1;
                        break;
                    case "sbyte":
                        itemGetter = o => (sbyte)Data[o];
                        size = 1;
                        break;
                    case "short":
                        itemGetter = o => BitConverter.ToInt16(Data, o);
                        size = 2;
                        break;
                    case "ushort":
                        itemGetter = o => BitConverter.ToUInt16(Data, o);
                        size = 2;
                        break;
                    case "int":
                        itemGetter = o => BitConverter.ToInt32(Data, o);
                        size = 4;
                        break;
                    case "uint":
                        itemGetter = o => BitConverter.ToUInt32(Data, o);
                        size = 4;
                        break;
                    case "long":
                        itemGetter = o => BitConverter.ToInt64(Data, o);
                        size = 8;
                        break;
                    case "ulong":
                        itemGetter = o => BitConverter.ToUInt64(Data, o);
                        size = 8;
                        break;
                    case "utcdateint":
                        itemGetter = o => DateTimeOffset.FromUnixTimeSeconds(BitConverter.ToInt32(Data, o)).LocalDateTime;
                        size = 4;
                        break;
                    case "utcdatelong":
                        itemGetter = o => DateTimeOffset.FromUnixTimeSeconds(BitConverter.ToInt64(Data, o)).LocalDateTime;
                        size = 8;
                        break;
                    case "win32date":
                        itemGetter = o => win32FileTimeEpoch.AddTicks(BitConverter.ToInt64(Data, o)).ToLocalTime();
                        size = 8;
                        break;
                    case "float":
                        itemGetter = o => BitConverter.ToSingle(Data, o);
                        size = 4;
                        break;
                    case "double":
                        itemGetter = o => BitConverter.ToDouble(Data, o);
                        size = 8;
                        break;
                    case "string":
                        size = customInfoItem.Size;
                        if (customInfoItem.Size <= 0)
                        {
                            size = 0;
                            itemGetter = o => string.Empty;
                        }
                        else
                        {
                            itemGetter = o =>
                            {
                                string str = Encoding.ASCII.GetString(Data[o..(o + size)]);
                                int endPos = str.IndexOf('\0');
                                if (endPos == 0)
                                {
                                    str = string.Empty;
                                }
                                else if (endPos != -1)
                                {
                                    str = str[..endPos];
                                }
                                return str;
                            };
                        }
                        break;
                    case "sctime11":
                        itemGetter = o =>
                        {
                            int rawInt = BitConverter.ToInt32(Data, o);
                            if (rawInt == 0) return 99999M;
                            int decimalPart = rawInt % 100 - 33;
                            if (decimalPart < 0)
                            {
                                decimalPart += 100;
                            }
                            int integerPart = rawInt / 100 % 1000 - 66;
                            if (integerPart < 0)
                            {
                                integerPart += 1000;
                            }
                            int checksum = rawInt / 100000;

                            if (decimalPart + integerPart + 22 != checksum)
                            {
                                if (rawInt < 0)    //why?
                                {
                                    decimalPart = rawInt % 100 + 67;
                                    if (decimalPart < 0)
                                    {
                                        decimalPart += 100;
                                    }
                                }

                                int tmpVal = (rawInt - decimalPart) / 100 - 22066 - 1000 * decimalPart;
                                int test = tmpVal % 1001;
                                integerPart = tmpVal / 1001;
                                if (test == 0 && integerPart <= 999)
                                {
                                    return integerPart + decimalPart / 100M;
                                }

                                return 99999M;
                            }
                            return integerPart + decimalPart / 100M;
                        };
                        size = 4;
                        break;
                    case "sctime":
                        itemGetter = o =>
                        {
                            int rawInt = BitConverter.ToInt32(Data, o);
                            if (rawInt == 0) return 99999M;
                            int decimalPart = rawInt % 100 - 33;
                            if (decimalPart < 0)
                            {
                                decimalPart += 100;
                            }
                            int integerPart = rawInt / 100 % 1000 - 66;
                            if (integerPart < 0)
                            {
                                integerPart += 1000;
                            }
                            int checksum = rawInt / 100000;

                            if (decimalPart + integerPart + 22 != checksum)
                            {
                                if (rawInt < 0)    //why?
                                {
                                    decimalPart = rawInt % 100 + 67;
                                    if (decimalPart < 0)
                                    {
                                        decimalPart += 100;
                                    }
                                }
                                int tmpVar = (rawInt - decimalPart) / 100 - 22000 - 1000 * decimalPart;
                                integerPart = tmpVar / 1000;
                                if (tmpVar > -66000)
                                {
                                    integerPart--;
                                }
                                if (integerPart < 0 && (integerPart * 1000 + (integerPart + 66) % 1000 == tmpVar))
                                {
                                    return integerPart + decimalPart / 100M;
                                }
                                return 99999M;
                            }
                            return integerPart + decimalPart / 100M;
                        };
                        size = 4;
                        break;
                    case "object":
                        size = customInfoItem.Size;
                        if (customInfoItem.Size <= 0 || customInfoItem.SubItems == null)
                        {
                            size = 0;
                            itemGetter = o => null;
                        }
                        else
                        {
                            subDataInfoList = customInfoItem.SubItems;
                            itemGetter = o => new GameDataSource(Data, o);
                        }
                        break;
                    default:
                        break;
                }
                if (itemGetter == null)
                {
                    return null;
                }

                if (!isList)
                {
                    result = itemGetter(offset);
                }
                else
                {
                    List<object> _result = new List<object>();
                    if (customInfoItem.Count >= 0)
                    {
                        bool hasEndMark = !string.IsNullOrEmpty(customInfoItem.EndMark);
                        bool hasSkipMark = !string.IsNullOrEmpty(customInfoItem.SkipMark);
                        bool hasCap = !string.IsNullOrEmpty(customInfoItem.CapAt);
                        int cap = -1;
                        bool continueAfterCap = false;
                        if (hasCap)
                        {
                            var capAt = GetItem(allData, stage, extraData, customInfoItem.CapAt, dataInfoList, out _, out _, true);
                            if (capAt != null && (capAt is int || capAt is decimal))
                            {
                                if (capAt is int _i)
                                {
                                    cap = _i;
                                }
                                else if (capAt is decimal _d)
                                {
                                    cap = decimal.ToInt32(_d);
                                }
                                if (customInfoItem.AfterCapValue != null)
                                {
                                    continueAfterCap = true;
                                }
                            }
                            else
                            {
                                hasCap = false;
                            }
                        }
                        for (int i = 0; i < customInfoItem.Count; i++)
                        {
                            if (hasCap && i >= cap)
                            {
                                if (continueAfterCap)
                                {
                                    _result.Add(customInfoItem.AfterCapValue);
                                    continue;
                                }
                                else
                                {
                                    break;
                                }
                            }
                            int currentOffset = offset + i * size;
                            if (hasEndMark)
                            {
                                var isEndObj = GetItem(allData, stage, extraData, customInfoItem.EndMark, dataInfoList, out _, out _,
                                    true, currentOffset - BeginOffset);
                                if (isEndObj != null && isEndObj is decimal)
                                {
                                    bool isEnd = (decimal)isEndObj != 0M;
                                    if (isEnd) break;
                                }
                            }
                            if (hasSkipMark)
                            {
                                var isSkipObj = GetItem(allData, stage, extraData, customInfoItem.SkipMark, dataInfoList, out _, out _,
                                    true, currentOffset - BeginOffset);
                                if (isSkipObj != null && isSkipObj is decimal)
                                {
                                    bool isSkip = (decimal)isSkipObj != 0M;
                                    if (isSkip) continue;
                                }
                            }
                            _result.Add(itemGetter(currentOffset));
                        }
                    }
                    result = _result;
                }
            }
            if (isGetMark)
            {
                if (!string.IsNullOrEmpty(customInfoItem.Modifier))
                {
                    result = ReplayAnalyzer.CalculateItem(allData, result, 0, customInfoItem.Modifier, stage, extraData);
                }
            }

            return result;
        }
    }

    public class StageData
    {
        public string StageName { get; set; }
        public int StageId { get; set; }
        public DataOffsetAndLength HeaderData { get; set; }
        public DataOffsetAndLength KeyData { get; set; }
        public DataOffsetAndLength FPSData { get; set; }

        public List<GameCustomInfoItem> GameRelatedData { get; set; }

        public GameDataSource GameCustomData { get; set; }

        public int FrameCount { get; set; }
        public double CalculatedSlowRate { get; set; }

        public List<string[]> KeyList { get; set; }
        public List<int> FPSList { get; set; }
        public List<byte> ArrowKeyList { get; set; }
        public bool HasConflictKeys { get; set; }
    }
}
