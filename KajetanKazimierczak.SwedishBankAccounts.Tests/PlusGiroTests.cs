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
        public void ShouldValidatePlusGiroAccount(string account, 
            bool valid, 
            ValidationResult validationResult)
        {
            var sut = new PlusGiro(account);

            Assert.AreEqual(valid, sut.IsValid);
            Assert.AreEqual(validationResult, sut.ValidationResult);
        }

    }
}
