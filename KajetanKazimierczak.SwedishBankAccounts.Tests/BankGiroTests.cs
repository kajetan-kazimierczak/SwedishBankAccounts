using System;
using System.Collections.Generic;
using System.Text;
using KajetanKazimierczak.SwedishBankAccounts.Enums;
using NUnit.Framework;

namespace KajetanKazimierczak.SwedishBankAccounts.Tests
{
    public class BankGiroTests
    {

        [TestCase("yyy",false,ValidationResult.InvalidFormat)]
        [TestCase("1234-5678", false, ValidationResult.InvalidChecksum)]
        [TestCase("123-5678", false, ValidationResult.InvalidChecksum)]
        [TestCase("5858-2628", true, ValidationResult.ChecksumValidated)]
        [TestCase("160-9908", true, ValidationResult.ChecksumValidated)]
        [TestCase("158-5694", true, ValidationResult.ChecksumValidated)]
        [TestCase("354-7247", true, ValidationResult.ChecksumValidated)]
        [TestCase("354-724-7", false, ValidationResult.InvalidFormat)]
        [TestCase("3547247", true, ValidationResult.ChecksumValidated)]
        [TestCase("354-7", false, ValidationResult.InvalidFormat)]
        [TestCase("3547", false, ValidationResult.InvalidAccountNumberLength)]
        [TestCase(null, false, ValidationResult.InvalidAccountNumberLength)]
        [TestCase("", false, ValidationResult.InvalidAccountNumberLength)]
        public void ShouldValidateBankGiroAccount(string account, 
            bool valid, 
            ValidationResult validationResult)
        {
            var sut = new BankGiro(account);

            Assert.AreEqual(valid, sut.IsValid);
            Assert.AreEqual(validationResult, sut.ValidationResult);
        }

        [TestCase("354-7247", "0003547247")]
        public void ShouldFormat10(string account, string expected)
        {
            var sut = new BankGiro(account);
            Assert.AreEqual(expected, sut.FormatBgc10);
        }
        [TestCase("354-7247", "0000000003547247")]
        public void ShouldFormat16(string account, string expected)
        {
            var sut = new BankGiro(account);
            Assert.AreEqual(expected, sut.FormatBgc16);
        }
    }
}
