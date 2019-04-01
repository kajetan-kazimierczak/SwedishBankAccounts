using System;
using KajetanKazimierczak.SwedishBankAccounts.Checksum;
using KajetanKazimierczak.SwedishBankAccounts.Configuration;
using KajetanKazimierczak.SwedishBankAccounts.Enums;
using KajetanKazimierczak.SwedishBankAccounts.Extensions;

namespace KajetanKazimierczak.SwedishBankAccounts
{
    public class BankAccount
    {
        private readonly string _clearingNumber;
        private readonly string _clearingCheckDigit;
        private readonly string _accountNumber;
        private string _bank;
        private bool _isValid;
        private ValidationResult _validationResult = ValidationResult.Unknown;
        private AccountConfiguration _accountConfiguration;

        /// <summary>
        /// Construct BankAccount object
        /// </summary>
        /// <param name="fullAccountNumber">Account Number (clearing number included)</param>
        public BankAccount(string fullAccountNumber)
        {
            var accountNumber = fullAccountNumber?.ToDigits() ?? string.Empty;

            if (!string.IsNullOrEmpty(accountNumber) && accountNumber.Length > 15)
            {
                _isValid = false;
                _validationResult = ValidationResult.InvalidAccountNumberLength;
                return;
            }
            
            if(string.IsNullOrEmpty(accountNumber) || accountNumber.Length < 5)
            {
                _isValid = false;
                _validationResult = ValidationResult.InvalidClearingNumberLength;
                return;
            }

            var clearingNumberLength = 4;
            //if (accountNumber.StartsWith("8")
            //    && accountNumber.Substring(0, 4) != "8351")
            //{
            //    // Swedbank Sparbankerna
            //    // https://sv.wikipedia.org/wiki/Lista_%C3%B6ver_clearingnummer_till_svenska_banker
            //    clearingNumberLength = 5;
            //}

            _clearingNumber = accountNumber.Substring(0, clearingNumberLength);
            _accountNumber = accountNumber.Substring(clearingNumberLength);

            Validate();
        }

        /// <summary>
        /// Construct BankAccount object
        /// </summary>
        /// <param name="clearingNumber">Account Clearing Number (4-5 digits)</param>
        /// <param name="accountNumber">Account Number</param>
        public BankAccount(string clearingNumber, string accountNumber)
        {
            _clearingNumber = clearingNumber?.ToDigits() ?? string.Empty;
            _accountNumber = accountNumber?.ToDigits() ?? string.Empty;

            if (_clearingNumber.Length == 5 && _clearingNumber.StartsWith("8"))
            {
                _clearingCheckDigit = _clearingNumber[4].ToString();
                _clearingNumber = _clearingNumber.Substring(0, 4);
            }

            if (_clearingNumber.Length != 4)
            {
                _isValid = false;
                _validationResult = ValidationResult.InvalidClearingNumberLength;
                return;
            }

            Validate();
        }

        /// <summary>
        /// Name of the Bank
        /// </summary>
        public string BankName => _bank;

        /// <summary>
        /// Cleaned up Clearing Number (first 4 digits of the account)
        /// </summary>
        public string ClearingNumber => _clearingNumber;

        /// <summary>
        /// Cleaned up Account number (without the Clearing Number)
        /// </summary>
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
        public string FormatBgc16 =>
                _clearingNumber + _accountNumber.PadLeft(12, '0');
            
        

        private void Validate()
        { 
            _accountConfiguration = Configuration
                .Configuration.GetConfigForClearingNumber(_clearingNumber);
            if (_accountConfiguration == null)
            {
                _validationResult = ValidationResult.UnknownClearingNumber;
                _isValid = false;
                return;
            }

            _bank = _accountConfiguration.BankName;

            if (_accountConfiguration.BankAccountType == BankAccountType.Type1)
            {
                if (_clearingNumber.Length != 4)
                {
                    _validationResult = ValidationResult.InvalidClearingNumberLength;
                    _isValid = false;
                    return;
                }

                if (_accountNumber.Length != 7)
                {
                    _validationResult = ValidationResult.InvalidAccountNumberLength;
                    _isValid = false;
                    return;
                }

                if (_accountConfiguration.BankAccountTypeComment == BankAccountTypeComment.Type1)
                {
                    var number = _clearingNumber.Substring(1) + _accountNumber;
                    _isValid = Modulus11.ValidateChecksum(number);
                    _validationResult =
                        _isValid ? ValidationResult.ChecksumValidated : ValidationResult.InvalidChecksum;
                    return;
                }
                if (_accountConfiguration.BankAccountTypeComment == BankAccountTypeComment.Type2)
                {
                    var number = _clearingNumber + _accountNumber;
                    _isValid = Modulus11.ValidateChecksum(number);
                    _validationResult =
                        _isValid ? ValidationResult.ChecksumValidated : ValidationResult.InvalidChecksum;
                    return;
                }
            }

            if (_accountConfiguration.BankAccountType == BankAccountType.Type2)
            {
                if (_accountConfiguration.BankAccountTypeComment == BankAccountTypeComment.Type1)
                {
                    if (_accountNumber.Length != 10)
                    {
                        _isValid = false;
                        _validationResult = ValidationResult.InvalidAccountNumberLength;
                    }

                    var number = _accountNumber;
                    _isValid = Modulus10.ValidateChecksum(number);
                    _validationResult =
                        _isValid ? ValidationResult.ChecksumValidated : ValidationResult.InvalidChecksum;
                    return;
                }

                if (_accountConfiguration.BankAccountTypeComment == BankAccountTypeComment.Type2)
                {
                    if (_accountNumber.Length != 9)
                    {
                        _isValid = false;
                        _validationResult = ValidationResult.InvalidAccountNumberLength;
                    }

                    var number = _accountNumber;
                    _isValid = Modulus11.ValidateChecksum(number);
                    _validationResult =
                        _isValid ? ValidationResult.ChecksumValidated : ValidationResult.InvalidChecksum;
                    return;
                }

                // Swedbank & Sparbankerna
                if (_accountConfiguration.BankAccountTypeComment == BankAccountTypeComment.Type3 
                    && _clearingNumber.StartsWith("8"))
                {
                    if (!string.IsNullOrEmpty(_clearingCheckDigit))
                    {
                        _isValid = Modulus10.ValidateChecksum(_clearingNumber + _clearingCheckDigit);

                        if (!_isValid)
                        {
                            _validationResult = ValidationResult.InvalidClearingNumber;
                            return;
                        }
                    }

                    if (_accountNumber.Length < 1 || _accountNumber.Length > 10)
                    {
                        _isValid = false;
                        _validationResult = ValidationResult.InvalidAccountNumberLength;
                        return;
                    }
                    
                    var number = _accountNumber;
                    _isValid = Modulus10.ValidateChecksum(number);
                    _validationResult =
                        _isValid ? ValidationResult.ChecksumValidated : ValidationResult.InvalidChecksum;

                }

                if (_accountConfiguration.BankAccountTypeComment == BankAccountTypeComment.Type3
                    && !_clearingNumber.StartsWith("8"))
                {
                    if (_accountNumber.Length < 1 || _accountNumber.Length > 10)
                    {
                        _isValid = false;
                        _validationResult = ValidationResult.InvalidAccountNumberLength;
                    }


                    var number = _accountNumber;
                    _isValid = Modulus10.ValidateChecksum(number);
                    _validationResult =
                        _isValid ? ValidationResult.ChecksumValidated : ValidationResult.InvalidChecksum;

                    return;
                }
            }
        }
    }
}
