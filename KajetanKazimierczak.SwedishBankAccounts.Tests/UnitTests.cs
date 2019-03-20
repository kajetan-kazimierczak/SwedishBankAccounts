using KajetanKazimierczak.SwedishBankAccounts.Checksum;
using KajetanKazimierczak.SwedishBankAccounts.Enums;
using KajetanKazimierczak.SwedishBankAccounts.Extensions;
using NUnit.Framework;

namespace KajetanKazimierczak.SwedishBankAccounts.Tests
{
    public class UnitTests
    {
        [TestCase("241350", "0")]
        [TestCase("324558", "8")]
        [TestCase("8601089976", "6")]
        [TestCase("2444609298", "8")]
        public void TestModulus11(string value, string expected)
        {
            var sut = Modulus11.GetChecksum(value);

            Assert.AreEqual(expected, sut);
        }

        [TestCase("1212121212", "2")]
        [TestCase("7210020579", "9")]
        public void TestModulus10(string value, string expected)
        {
            var sut = Modulus10.GetChecksum(value);

            Assert.AreEqual(expected, sut);
        }

        [TestCase("1860 10 89976", "18601089976")]
        [TestCase("3244 46 09298", "32444609298")]
        [TestCase("3244-46.092.98", "32444609298")]
        public void TestStringToDigits(string value, string expected)
        {
            var sut = value.ToDigits();
            Assert.AreEqual(expected, sut);
        }

        [TestCase(9150, "Skandiabanken", 9150, 9169)]
        public void TestGetConfigForClearingNumber(int number, string bankName, int clearingStart, int clearingEnd)
        {
            var sut = Configuration.Configuration.GetConfigForClearingNumber(number);

            Assert.AreEqual(bankName, sut.BankName);
            Assert.AreEqual(clearingStart, sut.ClearingNumberStart);
            Assert.AreEqual(clearingEnd, sut.ClearingNumberEnd);

        }
    }
}