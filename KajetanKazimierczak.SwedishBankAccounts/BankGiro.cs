﻿using KajetanKazimierczak.SwedishBankAccounts.Checksum;
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

        /// <summary>
        /// Construct BankGiro object
        /// </summary>
        /// <param name="bankGiroNumber">BankGiro account number</param>
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
                || !(parts[0].ToDigits().Length == 3 || parts[0].ToDigits().Length == 4)
                || parts[1].ToDigits().Length != 4)
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

        /// <summary>
        /// Shows if account is valid or not. Check ValidationResult for more info
        /// </summary>
        public bool IsValid => _isValid;

        /// <summary>
        /// Result of the validation
        /// </summary>
        public ValidationResult ValidationResult => _validationResult;

        /// <summary>
        /// Get account number formatted for use in BGC files.
        /// </summary>
        public string FormatBgc10 => _accountNumber.ToDigits().PadLeft(10, '0');

        /// <summary>
        /// Get account number formatted for use in BGC files.
        /// </summary>
        public string FormatBgc16 => _accountNumber.ToDigits().PadLeft(16, '0');

    }
}
