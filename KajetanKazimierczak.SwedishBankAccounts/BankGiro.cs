using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using KajetanKazimierczak.SwedishBankAccounts.Checksum;
using KajetanKazimierczak.SwedishBankAccounts.Enums;
using KajetanKazimierczak.SwedishBankAccounts.Extensions;

namespace KajetanKazimierczak.SwedishBankAccounts
{
    /// <summary>
    /// Swedish Bankgiro
    /// </summary>
    public class BankGiro
    {
        private bool _isValid;
        private string _accountNumber;
        private ValidationResult _validationResult;


        public BankGiro(string bankGiroNumber)
        {
            _accountNumber = bankGiroNumber;

            if (string.IsNullOrEmpty(bankGiroNumber))
            {
                _isValid = false;
                _validationResult = ValidationResult.InvalidAccountNumberLength;
                return;
            }

            var parts = bankGiroNumber.Split('-');
            if (parts.Length != 2
                || !(parts[0].Length == 3 || parts[0].Length == 4)
                || parts[1].Length != 4)
            {
                _isValid = false;
                _validationResult = ValidationResult.InvalidFormat;
                return;
            }
            
            var accountNumber = bankGiroNumber.ToDigits();
            if (accountNumber.Length < 7 || accountNumber.Length > 8)
            {
                _isValid = false;
                _validationResult = ValidationResult.InvalidAccountNumberLength;
                return;
            }

            _isValid = Modulus10.ValidateChecksum(accountNumber);
            _validationResult = _isValid
                ? ValidationResult.ChecksumValidated
                : ValidationResult.InvalidChecksum;
  
        }

    

        public string AccountNumber => _accountNumber;
        public bool IsValid => _isValid;

        public ValidationResult ValidationResult => _validationResult;

        public string FormatBgc10 => _accountNumber.ToDigits().PadLeft(10, '0');

        public string FormatBgc16 => _accountNumber.ToDigits().PadLeft(16, '0');

    }
}
