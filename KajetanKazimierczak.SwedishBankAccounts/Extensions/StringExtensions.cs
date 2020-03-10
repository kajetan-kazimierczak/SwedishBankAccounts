using System;

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

        public static bool IsValidPersonnummerSamordningsnummer(this string str)
        {
            // not 100% valid date checking because we don't know the year

            if (str.Length < 6) return false;

            var year = str.Substring(0, 2);
            var month = str.Substring(2, 2);
            var day = str.Substring(4, 2);

            if (year.ToDigits() != year) return false;
            if (month.ToDigits() != month) return false;
            if (day.ToDigits() != day) return false;

            if (int.Parse(month) > 12) return false;

            var intDay = int.Parse(day);
            if (intDay > 31) intDay -= 60;
            if (intDay < 0 || intDay > 31) return false;


            return true;
        }
    }
}