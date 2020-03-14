using System.Globalization;

namespace KajetanKazimierczak.SwedishBankAccounts.Checksum
{
    internal static class Modulus10
    {
        public static string GetChecksum(string number)
        {
            var sum = 0;
            for (int i = number.Length - 2, multiplier = 2; i >= 0; i--)
            {
                var num = (number[i] - '0') * multiplier;
                sum += ((num / 10) + (num % 10));
                multiplier = 3 - multiplier;
            }

            var reminder = (sum % 10);

            return ((10 - reminder) % 10).ToString(new CultureInfo("sv-SE"));
        }

        public static bool ValidateChecksum(string number)
        {
            var actual = number[number.Length - 1].ToString();
            var expected = GetChecksum(number);

            return actual == expected;
        }

    }
}