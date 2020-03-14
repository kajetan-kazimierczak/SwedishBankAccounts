using System;
using System.Globalization;

namespace KajetanKazimierczak.SwedishBankAccounts.Checksum
{
    internal static class Modulus11
    {
        public static string GetChecksum(string number)
        {
            var sum = 0;
            for (int i = number.Length - 2, multiplier = 2; i >= 0; i--)
            {
                sum += (number[i] -'0') * multiplier;
                if (multiplier++ > 9) multiplier = 1;
            }
            var reminder = (sum % 11);
            if (reminder == 0 || reminder == 1) return "0";
            return (11 - reminder).ToString(new CultureInfo("sv-SE"));
        }

        public static bool ValidateChecksum(string number)
        {
            var actual = number[number.Length - 1].ToString();
            var expected = GetChecksum(number);

            return actual == expected;
        }
    }
}