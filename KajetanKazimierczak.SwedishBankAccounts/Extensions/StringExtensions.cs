namespace KajetanKazimierczak.SwedishBankAccounts.Extensions
{
    internal static class StringExtensions
    {
        public static string ToDigits(this string str)
        {
            var res = string.Empty;
            if (string.IsNullOrEmpty(str)) return string.Empty;

            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] - '0' >= 0 && str[i] - '0' <= 9) res += str[i];
            }

            return res;
        }
    }
}