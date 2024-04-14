using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
