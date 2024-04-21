using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using thhylR.Helper;
using YamlDotNet.Serialization;

namespace thhylR.Common
{
    public class EnumItem
    {
        public string Name { get; set; }
        public string Value { get; set; }
        public static implicit operator EnumItem(string str)
        {
            return new EnumItem() { Value = str };
        }
    }

    public class EnumItemList
    {
        public string Name { get; set; }
        public List<EnumItem> EnumValues { get; set; }
        public bool UseEnumName
        {
            get
            {
                if (EnumValues == null || EnumValues.Count == 0) return false;
                return EnumValues[0] != null && !string.IsNullOrEmpty(EnumValues[0].Name);
            }
        }
    }

    public static class EnumData
    {
        public static List<EnumItemList> EnumDataList { get; set; }
        public static void Init()
        {
            EnumDataList = new List<EnumItemList>();
            var deserializer = new DeserializerBuilder().IgnoreUnmatchedProperties().Build();
            string[] yamlFiles = Directory.GetFiles("EnumData\\", "*.yaml");
            foreach (var yamlFile in yamlFiles)
            {
                using var input = new StreamReader(yamlFile, Encoding.UTF8);
                try
                {
                    List<EnumItemList> tmpGameData = deserializer.Deserialize<List<EnumItemList>>(input);
                    EnumDataList.AddRange(tmpGameData);
                }
                catch
                {

                }
            }
        }
    }
}
