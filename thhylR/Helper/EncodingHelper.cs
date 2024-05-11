using System.Text;

namespace thhylR.Helper
{
    public static class EncodingHelper
    {
        public static List<EncodingInfo> EncodingList { get; set; }
        public static void Init()
        {
            EncodingList = Encoding.GetEncodings().ToList();
            EncodingList = EncodingList.OrderBy(e => e.Name.ToLower()).ToList();
        }
    }
}
