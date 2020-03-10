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

        [TestCase("82149", "9234726124", true, ValidationResult.ChecksumValidated)]
        [TestCase("8214", "9234726124", true, ValidationResult.ChecksumValidated)]
        [TestCase("82148", "9234726124", false, ValidationResult.InvalidClearingNumber)]
        [TestCase("82149", "9234726125", false, ValidationResult.InvalidChecksum)]
        [TestCase("3300", "121212-1212", true, ValidationResult.ChecksumValidated)]
        [TestCase("33000", "121212-1212", false, ValidationResult.InvalidClearingNumberLength)]
        [TestCase("3300", "121232-1218", false, ValidationResult.InvalidFormat)]
        [TestCase(null, null, false, ValidationResult.InvalidClearingNumberLength)]
        public void ShouldEvaluateAccountAndClearingNumbers(string clearingNumber, 
            string accountNumber, 
            bool expected,
            ValidationResult validationResult)
        {
            var sut = new BankAccount(clearingNumber, accountNumber);

            Assert.AreEqual(expected, sut.IsValid);
            Assert.AreEqual(validationResult, sut.ValidationResult);
        }

        [TestCase("82149", "9234726124", "8214009234726124")]
        [TestCase("3300", "1212121212", "3300001212121212")]
        public void ShouldFormatBgc16(string clearingNumber, string accountNumber, string expected)
        {
            var sut = new BankAccount(clearingNumber, accountNumber);
            
            Assert.AreEqual(expected, sut.FormatBgc16);
        }

        [TestCase("1212121212", true)]
        [TestCase("1213121212", false)]
        [TestCase("121", false)]
        [TestCase("1212721212", true)]
        [TestCase("1212321212", false)]

        public void ShouldDetectInvalidPersonNummerSamordingsnummer(string accountNumber, bool expected)
        {
            var sut = accountNumber.IsValidPersonnummerSamordningsnummer();

            Assert.AreEqual(expected, sut);
        }
    }
}