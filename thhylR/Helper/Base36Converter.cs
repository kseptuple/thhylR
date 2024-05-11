using System.Text;

namespace thhylR.Helper
{
    public static class Base36Converter
    {
        public static uint ToDecimal(string str)
        {
            uint result = 0;
            str = str.ToLower();
            checked
            {
                for (int i = 0; i < str.Length; i++)
                {
                    result *= 36;
                    char currentChar = str[i];
                    if (currentChar >= '0' && currentChar <= '9')
                    {
                        result += (uint)(currentChar - '0');
                    }
                    else if (currentChar >= 'a' && currentChar <= 'z')
                    {
                        result += (uint)(currentChar - 'a') + 10;
                    }
                    else
                    {
                        throw new FormatException(str);
                    }
                }
            }
            return result;
        }

        private static readonly string base36Str = "0123456789abcdefghijklmnopqrstuvwxyz";

        public static string ToBase36(uint num)
        {
            if (num == 0) return "0";
            int mod = 0;
            StringBuilder result = new StringBuilder();
            while (num != 0)
            {
                mod = (int)(num % 36);
                result.Insert(0, base36Str[mod]);
                num /= 36;
            }
            return result.ToString();
        }
    }
}
