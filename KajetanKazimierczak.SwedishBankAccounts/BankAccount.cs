using KajetanKazimierczak.SwedishBankAccounts.Checksum;
using KajetanKazimierczak.SwedishBankAccounts.Configuration;
using KajetanKazimierczak.SwedishBankAccounts.Enums;
using KajetanKazimierczak.SwedishBankAccounts.Extensions;

namespace KajetanKazimierczak.SwedishBankAccounts
{
    public class BankAccount
    {
        private readonly string _clearingNumber;
        private readonly string _accountNumber;
        private string _bank;
        private bool _isValid;
        private ValidationResult _validationResult = ValidationResult.Unknown;
        private AccountConfiguration _accountConfiguration;
        public BankAccount(string fullAccountNumber)
        {
            var accountNumber = fullAccountNumber?.ToDigits();
            if (accountNumber?.Length < 4)
            {
                _isValid = false;
                _validationResult = ValidationResult.ClearingNumberLengthInvalid;
                return;
            }

            _clearingNumber = accountNumber?.Substring(0, 4);
            _accountNumber = accountNumber?.Substring(4);

            Validate();
        }

        public BankAccount(string clearingNumber, string accountNumber)
        {
            _clearingNumber = clearingNumber?.ToDigits();
            _accountNumber = accountNumber?.ToDigits();

            Validate();
        }

        /// <summary>
        /// Name of the Bank
        /// </summary>
        public string BankName => _bank;

        /// <summary>
        /// Cleaned up Clearing Number (usually first 4 digits of the account)
        /// </summary>
        public string ClearingNumber => _clearingNumber;

        /// <summary>
        /// Cleaned up Account number (without the Clearing Number)
        /// </summary>
        public string AccountNumber => _accountNumber;
        /// <summary>
        /// Shows if account is valid or not. Check ValidationResult for more info
        /// </summary>
        public bool isValid => _isValid;

        /// <summary>
        /// Result of the validation
        /// </summary>
        public ValidationResult ValidationResult => _validationResult;

        private void Validate()
        {
            _accountConfiguration = Configuration.Configuration.GetConfigForClearingNumber(_clearingNumber);
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
                    _validationResult = ValidationResult.ClearingNumberLengthInvalid;
                    _isValid = false;
                    return;
                }

                if (_accountNumber.Length != 7)
                {
                    _validationResult = ValidationResult.AccountNumberLengthInvalid;
                    _isValid = false;
                    return;
                }

                if (_accountConfiguration.BankAccountTypeComment == BankAccountTypeComment.Type1)
                {
                    var number = _clearingNumber.Substring(1) + _accountNumber;
                    _isValid = Modulus11.ValidateChecksum(number);
                    _validationResult =
                        _isValid ? ValidationResult.ChecksumValidated : ValidationResult.ChecksumInvalid;
                    return;
                }
                if (_accountConfiguration.BankAccountTypeComment == BankAccountTypeComment.Type2)
                {
                    var number = _clearingNumber + _accountNumber;
                    _isValid = Modulus11.ValidateChecksum(number);
                    _validationResult =
                        _isValid ? ValidationResult.ChecksumValidated : ValidationResult.ChecksumInvalid;
                    return;
                }
            }

            if (_accountConfiguration.BankAccountType == BankAccountType.Type2)
            {
                if (_accountConfiguration.BankAccountTypeComment == BankAccountTypeComment.Type1)
                {
                    var number = _accountNumber;
                    _isValid = Modulus10.ValidateChecksum(number);
                    _validationResult =
                        _isValid ? ValidationResult.ChecksumValidated : ValidationResult.ChecksumInvalid;
                    return;
                }

                if (_accountConfiguration.BankAccountTypeComment == BankAccountTypeComment.Type2)
                {
                    var number = _accountNumber;
                    _isValid = Modulus11.ValidateChecksum(number);
                    _validationResult =
                        _isValid ? ValidationResult.ChecksumValidated : ValidationResult.ChecksumInvalid;
                    return;
                }

                if (_accountConfiguration.BankAccountTypeComment == BankAccountTypeComment.Type3)
                {
                    if (_clearingNumber.StartsWith("8") && _clearingNumber.Length == 5)
                    {
                        // Here be dragons... possibly Swedbank account that can not be validated.
                        _isValid = true;
                        _validationResult = ValidationResult.ProbablyCannotBeValidatedWithChecksum;
                        return;
                    }

                    var number = _accountNumber;
                    _isValid = Modulus10.ValidateChecksum(number);
                    _validationResult =
                        _isValid ? ValidationResult.ChecksumValidated : ValidationResult.ChecksumInvalid;
                  
                }
            }


        }

    }
}
