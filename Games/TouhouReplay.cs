using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;
using thhylR.Common;
using thhylR.Helper;

namespace thhylR.Games
{
    public class TouhouReplay
    {
        //public bool IsTrial { get; set; }
        public GameOffsets GameData { get; set; }
        public short ReplayVersion { get; set; }
        //public int GameVersion { get; set; }

        public byte[] Header { get; set; }
        public byte[] RawData { get; set; }
        public byte[] InfoBlockRawData { get; set; }

        public List<StageData> Stages { get; set; }

        public List<InfoBlock> InfoBlocks { get; set; }

        public double CalculatedTotalSlowRate { get; set; }

        public List<GameCustomInfoItem> GameRelatedData { get; set; }
        public GameDataSource GameCustomDataHeader { get; set; }
        public GameDataSource GameCustomDataBody { get; set; }

        public DataTable DisplayData { get; set; }

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
            DisplayData.AcceptChanges();
        }
    }

    [Flags]
    public enum ReplayProblemEnum
    {
        ChnVerReplay = 0x1,
        StageLengthError = 0x2,
    }

    public class InfoBlock
    {
        public string Marker { get; set; }
        public int Length { get; set; }
        public int Id { get; set; }
        public byte[] Data { get; set; }

        public enum UserBlockType
        {
            UserInfo = 0,
            Comment = 1
        }

        public UserBlockType BlockType
        {
            get
            {
                return (UserBlockType)(Id & 0xFF);
            }
        }

        public bool IsUserBlock
        {
            get
            {
                return Marker == "USER";
            }
        }
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

        public object GetItem(string name, List<GameCustomInfoItem> dataInfoList, out string displayName, out List<GameCustomInfoItem> subDataInfoList, bool isGetMark = false, int extraOffset = 0)
        {
            displayName = null;
            subDataInfoList = null;
            var customInfoItem = dataInfoList.FirstOrDefault(i => i.Name == name);
            if (customInfoItem == null) return null;
            displayName = customInfoItem.DisplayName;
            object result = null;
            int offset = BeginOffset + extraOffset + customInfoItem.Offset;
            if (customInfoItem.Type == null) return null;
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
                //case "display":
                //    itemGetter = o => null;
                //    break;
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
                        var capAt = GetItem(customInfoItem.CapAt, dataInfoList, out _, out _, true);
                        if (capAt != null && (capAt is int || capAt is decimal))
                        {
                            cap = (int)capAt;
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
                            var isEndObj = GetItem(customInfoItem.EndMark, dataInfoList, out _, out _, true, currentOffset);
                            if (isEndObj != null && isEndObj is decimal)
                            {
                                bool isEnd = (decimal)isEndObj != 0M;
                                if (isEnd) break;
                            }
                        }
                        if (hasSkipMark)
                        {
                            var isSkipObj = GetItem(customInfoItem.SkipMark, dataInfoList, out _, out _, true, currentOffset);
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
            if (isGetMark)
            {
                if (!string.IsNullOrEmpty(customInfoItem.Modifier))
                {
                    string expression = customInfoItem.Modifier.Replace("{.}", "(" + result.ToString() + ")");
                    var expressionVal = ExpressionAnalyzer.getValue(expression);
                    result = expressionVal;
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
        public FPSData FPSData { get; set; }

        public List<GameCustomInfoItem> GameRelatedData { get; set; }

        public GameDataSource GameCustomData { get; set; }
    }

    public class FPSData
    {
        public DataOffsetAndLength Data { get; set; }
        public double CalculatedSlowRate { get; set; }
    }

}
