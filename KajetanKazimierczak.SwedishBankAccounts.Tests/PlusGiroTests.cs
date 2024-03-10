using System;
using System.Collections.Generic;
using System.Text;
using KajetanKazimierczak.SwedishBankAccounts.Enums;
using NUnit.Framework;

namespace KajetanKazimierczak.SwedishBankAccounts.Tests
{
    public class PlusGiroTests
    {
        [TestCase("354-7", false, ValidationResult.InvalidChecksum)]
        [TestCase("1160499-8", true, ValidationResult.ChecksumValidated)]
        [TestCase("116 04 99-8", true, ValidationResult.ChecksumValidated)]
        [TestCase("11604998", true, ValidationResult.ChecksumValidated)]
        [TestCase(null, false, ValidationResult.InvalidAccountNumberLength)]
        [TestCase("", false, ValidationResult.InvalidAccountNumberLength)]
        public void ShouldValidatePlusGiroAccount(string account, 
            bool valid, 
            ValidationResult validationResult)
        {
            var sut = new PlusGiro(account);

            Assert.That(sut.IsValid, Is.EqualTo(valid));
            Assert.That(sut.ValidationResult, Is.EqualTo(validationResult));
        }

        [TestCase("1160499-8", "0011604998")]
        public void ShouldFormat10(string account, string expected)
        {
            var sut = new BankGiro(account);
            Assert.That(sut.FormatBgc10, Is.EqualTo(expected));
        }
        [TestCase("1160499-8", "0000000011604998")]
        public void ShouldFormat16(string account, string expected)
        {
            var sut = new BankGiro(account);
            Assert.That(sut.FormatBgc16, Is.EqualTo(expected));
        }
    }
}
