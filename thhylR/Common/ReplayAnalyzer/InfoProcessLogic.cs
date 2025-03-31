using System.Collections;
using System.Data;
using System.Text;
using System.Text.RegularExpressions;
using thhylR.Games;
using thhylR.Helper;

namespace thhylR.Common
{
    public static partial class ReplayAnalyzer
    {
        private static readonly Regex modifierReplacer = new Regex(@"\{[^\{\}]*?\}", RegexOptions.Compiled);
        private static readonly Regex formatterReplacer = new Regex(@"(\{[^\{\}]*?\})|(\{[^\{\}:]*?:[^\{\}:]*?\})", RegexOptions.Compiled);

        private static void ProcessDisplayData(List<DataRow> data)
        {
            ModifyData(data);
            SetVisible(data);
            SetEnumData(data);
            FormatData(data);
        }

        public static void ModifyData(List<DataRow> data)
        {
            //Modifier
            foreach (DataRow dr in data)
            {
                var currentValue = dr["RawValue"];
                if (dr["Modifier"] == null || dr["Modifier"].ToString() == string.Empty)
                {
                    dr["Value"] = dr["RawValue"];
                    continue;
                }

                string modifier = dr["Modifier"].ToString();

                if (currentValue != null && currentValue is IList)
                {
                    List<object> resultList = new List<object>();
                    var currentValueList = (IList)currentValue;
                    for (int i = 0; i < currentValueList.Count; i++)
                    {
                        var item = currentValueList[i];
                        resultList.Add(CalculateItem(data, item, i, modifier, (int)dr["Stage"], dr["ExtraData"].ToString()));
                    }
                    dr["Value"] = resultList;
                }
                else
                {
                    dr["Value"] = CalculateItem(data, currentValue, 0, modifier, (int)dr["Stage"], dr["ExtraData"].ToString());
                }
            }
        }

        public static object CalculateItem(List<DataRow> data, object item, int index, string modifier, int stage, string extraData)
        {
            if (item == null)
            {
                item = string.Empty;
            }
            MatchEvaluator modifierEvaluator = m =>
            {
                object itemToCalc = null;
                var value = m.Value[1..^1];
                if (value == ".")
                {
                    return "(" + item.ToString() + ")";
                }
                else
                {
                    var predicate = (DataRow d) =>
                        d["Id"].ToString() == value
                        && ((int)d["Stage"] == stage || (int)d["Stage"] == -1)
                        && (d["ExtraData"].ToString() == extraData || d["ExtraData"].ToString() == string.Empty);

                    var dataRow = data.FirstOrDefault(predicate);
                    if (dataRow == null)
                    {
                        return "(" + value + ")";
                    }
                    else
                    {
                        itemToCalc = dataRow["RawValue"] ?? string.Empty;
                        object actualItemToCalc = null;
                        if (itemToCalc is IList)
                        {
                            var itemToCalcList = (IList)itemToCalc;
                            if (itemToCalcList.Count <= index)
                            {
                                actualItemToCalc = string.Empty;
                            }
                            else
                            {
                                actualItemToCalc = itemToCalcList[index];
                            }
                            itemToCalc = actualItemToCalc;
                        }
                        return "(" + itemToCalc.ToString() + ")";
                    }
                }
            };

            modifier = modifier.Replace("{{", "\uFDD0");
            modifier = modifierReplacer.Replace(modifier, modifierEvaluator);
            modifier = modifier.Replace("\uFDD0", "{");
            try
            {
                return ExpressionAnalyzer.getValue(modifier);
            }
            catch
            {
                return "ERROR";
            }
        }

        public static void SetVisible(List<DataRow> data)
        {
            //Visible
            foreach (DataRow dr in data)
            {
                MatchEvaluator visibleEvaluator = m =>
                {
                    var value = m.Value[1..^1];
                    if (value == ".")
                    {
                        return "(" + dr["Value"].ToString() + ")";
                    }
                    else
                    {
                        var predicate = (DataRow d) =>
                            d["Id"].ToString() == value
                            && ((int)d["Stage"] == (int)dr["Stage"] || (int)d["Stage"] == -1)
                            && (d["ExtraData"].ToString() == dr["ExtraData"].ToString() || d["ExtraData"].ToString() == string.Empty);

                        var dataRow = data.FirstOrDefault(predicate);
                        if (dataRow != null)
                        {
                            return "(" + dataRow["Value"].ToString() + ")";
                        }
                        else
                        {
                            return "(" + value + ")";
                        }
                    }
                };

                if (dr["Visible"] != null && dr["Visible"].ToString() != string.Empty)
                {
                    string visible = dr["Visible"].ToString();
                    if (visible == "true")
                    {
                        dr["Visible"] = "1";
                    }
                    else if (visible == "false")
                    {
                        dr["Visible"] = "0";
                    }
                    else
                    {
                        visible = visible.Replace("{{", "\uFDD0");
                        visible = modifierReplacer.Replace(visible, visibleEvaluator);
                        visible = visible.Replace("\uFDD0", "{");
                        try
                        {
                            var value = ExpressionAnalyzer.getValue(visible);
                            dr["Visible"] = value;
                        }
                        catch
                        {
                            dr["Visible"] = "1";
                        }
                    }
                }
                else
                {
                    dr["Visible"] = "1";
                }
            }
        }

        public static void SetEnumData(List<DataRow> data)
        {
            //Enum
            foreach (DataRow dr in data)
            {
                dr["RawValue"] = dr["Value"];
                var currentValue = dr["RawValue"];
                if (dr["EnumList"] == null || dr["EnumList"].ToString() == string.Empty)
                {
                    continue;
                }

                string enumName = dr["EnumList"].ToString();

                if (currentValue != null && currentValue is IList)
                {
                    List<string> resultList = new List<string>();
                    var currentValueList = (IList)currentValue;
                    for (int i = 0; i < currentValueList.Count; i++)
                    {
                        var item = currentValueList[i];
                        resultList.Add(getEnumValue(item.ToString(), enumName));
                    }
                    dr["RawValue"] = resultList;
                }
                else
                {
                    dr["RawValue"] = getEnumValue(currentValue.ToString(), enumName);
                }
            }

            string getEnumValue(string item, string enumName)
            {
                if (string.IsNullOrEmpty(item)) return string.Empty;

                EnumItemList enumItemList = EnumData.EnumDataList.FirstOrDefault(e => e.Name == enumName);
                if (enumItemList != null)
                {
                    if (enumItemList.UseEnumName)
                    {
                        EnumItem enumResult = enumItemList.EnumValues.FirstOrDefault(e => e.Name == item);
                        if (enumResult != null)
                        {
                            return enumResult.Value;
                        }
                        else
                        {
                            return item;
                        }
                    }
                    else
                    {
                        if (int.TryParse(item, out int enumIndex) && enumIndex >= 0 && enumIndex < enumItemList.EnumValues.Count)
                        {
                            return enumItemList.EnumValues[enumIndex].Value;
                        }
                        else
                        {
                            return item;
                        }
                    }
                }
                return item;
            }
        }

        public static void FormatData(List<DataRow> data)
        {
            //Formatter
            var argumentTypes = new Type[] { typeof(string) };

            foreach (DataRow dr in data)
            {
                bool isSymbol = false;
                bool _tmpIsSymbol = false;
                var currentValue = dr["RawValue"];

                string formatter = null;
                if (dr["Formatter"] != null && dr["Formatter"].ToString() != string.Empty)
                {
                    formatter = dr["Formatter"].ToString();
                }
                if (currentValue != null && currentValue is IList)
                {
                    StringBuilder resultBuilder = new StringBuilder();
                    var currentValueList = (IList)currentValue;
                    for (int i = 0; i < currentValueList.Count; i++)
                    {
                        var item = currentValueList[i];
                        resultBuilder.Append(formatItem(item, i, formatter, (int)dr["Stage"], dr["ExtraData"].ToString(), out _tmpIsSymbol));
                        if (_tmpIsSymbol && !isSymbol)
                        {
                            isSymbol = true;
                        }
                        if (i < currentValueList.Count - 1)
                        {
                            resultBuilder.Append(", ");
                        }
                    }
                    dr["Value"] = resultBuilder.ToString();
                }
                else
                {
                    dr["Value"] = formatItem(currentValue, 0, formatter, (int)dr["Stage"], dr["ExtraData"].ToString(), out isSymbol);
                }

                dr["DisplayValue"] = dr["Value"].ToString().Replace('\t', ' ').Replace("\r\n", " ");
                if (isSymbol)
                {
                    dr["IsSymbol"] = true;
                }
                else
                {
                    dr["IsSymbol"] = false;
                }
            }

            string formatItem(object item, int index, string formatter, int stage, string extraData, out bool isSymbol)
            {
                isSymbol = false;
                if (!string.IsNullOrEmpty(formatter))
                {
                    string result = formatter.Replace("{{", "\uFDD0");
                    if (result.Contains('{'))
                    {
                        bool _isSymbol = false;
                        MatchEvaluator formatterEvaluator = m =>
                        {
                            var value = m.Value[1..^1];
                            var formatItems = value.Split(':');
                            object itemToFormat = null;
                            if (formatItems[0] == ".")
                            {
                                itemToFormat = item ?? string.Empty;
                            }
                            else
                            {
                                var predicate = (DataRow d) =>
                                    d["Id"].ToString() == formatItems[0]
                                    && ((int)d["Stage"] == stage || (int)d["Stage"] == -1)
                                    && (d["ExtraData"].ToString() == extraData || d["ExtraData"].ToString() == string.Empty);

                                var dataRow = data.FirstOrDefault(predicate);
                                if (dataRow == null)
                                {
                                    return formatItems[0];
                                }
                                else
                                {
                                    itemToFormat = dataRow["RawValue"] ?? string.Empty;
                                    object actualItemToFormat = null;
                                    if (itemToFormat is IList)
                                    {
                                        var itemToFormatList = (IList)itemToFormat;
                                        if (itemToFormatList.Count <= index)
                                        {
                                            actualItemToFormat = string.Empty;
                                        }
                                        else
                                        {
                                            actualItemToFormat = itemToFormatList[index];
                                        }
                                        itemToFormat = actualItemToFormat;
                                    }
                                }
                            }

                            if (formatItems.Length == 1)
                            {
                                return itemToFormat.ToString();
                            }
                            else
                            {
                                string result = string.Join(':', formatItems[1..]);
                                return callToString(itemToFormat, result, out _isSymbol);
                            }

                        };

                        result = formatterReplacer.Replace(result, formatterEvaluator);
                        isSymbol = _isSymbol;
                    }
                    else
                    {
                        result = callToString(item, result, out isSymbol);
                    }

                    result = result.Replace("\uFDD0", "{");
                    return result;
                }
                else
                {
                    return item.ToString();
                }
            }

            string callToString(object item, string formatter, out bool isSymbol)
            {
                isSymbol = false;
                if (item == null)
                {
                    return string.Empty;
                }
                if (formatter == "life")
                {
                    switch (SettingProvider.Settings.LifeBombType)
                    {
                        case LifeBombFormat.Number:
                            return item.ToString();
                        case LifeBombFormat.Heart:
                            isSymbol = true;
                            return getSymbolString(item, "\u2665\ufe0e", "\u2661\ufe0e");
                        case LifeBombFormat.Star:
                            isSymbol = true;
                            return getSymbolString(item, "\u2605\ufe0e", "\u2606\ufe0e");
                    }
                }
                else if (formatter == "bomb")
                {
                    switch (SettingProvider.Settings.LifeBombType)
                    {
                        case LifeBombFormat.Number:
                            return item.ToString();
                        case LifeBombFormat.Heart:
                        case LifeBombFormat.Star:
                            isSymbol = true;
                            return getSymbolString(item, "\u2605\ufe0e", "\u2606\ufe0e");
                    }
                }
                else if (formatter == "score")
                {
                    string itemStr = item.ToString();
                    bool isMinus = itemStr.StartsWith('-');
                    string result = null;
                    if (isMinus)
                    {
                        itemStr = itemStr.Substring(1);
                    }
                    switch (SettingProvider.Settings.ScoreType)
                    {
                        case ScoreFormat.Plain:
                            return item.ToString();
                        case ScoreFormat.Comma:
                            StringBuilder itemBuilder = new StringBuilder();
                            for (int i = itemStr.Length; i >= 0; i -= 3)
                            {
                                if (i >= 3)
                                {
                                    itemBuilder.Insert(0, itemStr[(i - 3)..i]);
                                    if (i != 3)
                                    {
                                        itemBuilder.Insert(0, ",");
                                    }
                                }
                                else
                                {
                                    itemBuilder.Insert(0, itemStr[0..i]);
                                }
                            }
                            result = itemBuilder.ToString();
                            break;
                        case ScoreFormat.Character:
                            string chara = ResourceLoader.GetText("ScoreChara");
                            StringBuilder itemBuilderChara = new StringBuilder();
                            int currentChara = 0;
                            for (int i = itemStr.Length; i >= 0; i -= 4)
                            {
                                if (i >= 4 && currentChara < chara.Length)
                                {
                                    itemBuilderChara.Insert(0, itemStr[(i - 4)..i]);
                                    if (i != 4)
                                    {
                                        itemBuilderChara.Insert(0, chara[currentChara]);
                                    }
                                }
                                else
                                {
                                    itemBuilderChara.Insert(0, itemStr[0..i]);
                                    break;
                                }
                                currentChara++;
                            }
                            result = itemBuilderChara.ToString();
                            break;
                    }
                    if (isMinus)
                    {
                        result = "-" + result;
                    }
                    return result;
                }
                var toStringMethod = item.GetType().GetMethod("ToString", argumentTypes);
                if (toStringMethod == null)
                {
                    return item.ToString();
                }
                else
                {
                    return (string)toStringMethod.Invoke(item, new object[] { formatter });
                }

                string getSymbolString(object item, string symbol, string emptySymbol)
                {
                    decimal decItem = 0;
                    if (tryConvertToDecimal(item, out decItem))
                    {
                        StringBuilder stringBuilder = new StringBuilder();
                        for (decimal i = 0; i < decItem; i++)
                        {
                            stringBuilder.Append(symbol);
                        }
                        if (decItem == 0 && !SettingProvider.Settings.ShowEmptyIcon)
                        {
                            stringBuilder.Append('-');
                        }
                        if (SettingProvider.Settings.ShowEmptyIcon && decItem < 8)
                        {
                            if (decItem < 8)
                            {
                                decimal remain = 8 - decItem;
                                for (decimal i = 0; i < remain; i++)
                                {
                                    stringBuilder.Append(emptySymbol);
                                }
                            }
                        }
                        return stringBuilder.ToString();
                    }
                    else
                    {
                        return item.ToString();
                    }
                }
            }

            bool tryConvertToDecimal(object value, out decimal result)
            {
                try
                {
                    result = Convert.ToDecimal(value);
                    return true;
                }
                catch
                {
                    result = 0M;
                    return false;
                }
            }
        }

        public static void ShiftScore(TouhouReplay replay)
        {
            var scoreType = SettingProvider.Settings.ShownScore;

            if (scoreType != ShownScoreType.Default)
            {
                List<DataRow> dataList = replay.DisplayDataList;
                List<string> suffix = new List<string>();
                if (replay.GameData.StageSetting.IsVSGame)
                {
                    suffix.Add("P1");
                    suffix.Add("P2");
                }
                else
                {
                    suffix.Add("");
                }

                if (scoreType == ShownScoreType.StageEnd && !replay.GameData.StageSetting.IsStageEndScore)
                {
                    foreach (var suffixItem in suffix)
                    {
                        DataRow totalScoreRow = dataList.FirstOrDefault(d => d["Id"].ToString() == "Score" + suffixItem);
                        if (totalScoreRow != null)
                        {
                            var allStageScore = dataList.Where(d => d["Id"].ToString() == "StageScore" + suffixItem).ToList();
                            //allStageScore.Sort((d1, d2) => (int)d1["Stage"] - (int)d2["Stage"]);
                            for (int i = 0; i < allStageScore.Count; i++)
                            {
                                DataRow dr = allStageScore[i];
                                if (i != allStageScore.Count - 1)
                                {
                                    copyFrom(ref dr, allStageScore[i + 1]);
                                }
                                else
                                {
                                    copyFrom(ref dr, totalScoreRow);
                                }
                                allStageScore[i] = dr;
                            }
                        }
                    }
                }
                else if (scoreType == ShownScoreType.StageStart && replay.GameData.StageSetting.IsStageEndScore)
                {
                    foreach (var suffixItem in suffix)
                    {
                        var allStageScore = dataList.Where(d => d["Id"].ToString() == "StageScore" + suffixItem).ToList();
                        //allStageScore.Sort((d1, d2) => (int)d1["Stage"] - (int)d2["Stage"]);
                        for (int i = allStageScore.Count - 1; i >= 0; i--)
                        {
                            DataRow dr = allStageScore[i];
                            if (i != 0)
                            {
                                copyFrom(ref dr, allStageScore[i - 1]);
                            }
                            else
                            {
                                dr["DisplayValue"] = 0;
                                dr["Value"] = 0;
                            }
                            allStageScore[i] = dr;
                        }
                    }
                }
            }

            void copyFrom(ref DataRow source, DataRow dest)
            {
                source["DisplayValue"] = dest["DisplayValue"];
                source["Value"] = dest["Value"];
            }
        }
    }
}

