using KajetanKazimierczak.SwedishBankAccounts.Checksum;
using KajetanKazimierczak.SwedishBankAccounts.Enums;
using KajetanKazimierczak.SwedishBankAccounts.Extensions;

namespace KajetanKazimierczak.SwedishBankAccounts
{
    /// <summary>
    /// Swedish Plusgiro
    /// </summary>
    public class PlusGiro
    {
        private bool _isValid;
        private string _accountNumber;
        private ValidationResult _validationResult;

        /// <summary>
        /// Construct PlusGiro object
        /// </summary>
        /// <param name="plusGiro">PlusGiro account number. Hyphen optional.</param>
        public PlusGiro(string plusGiro)
        {
            _accountNumber = plusGiro;

            if (string.IsNullOrWhiteSpace(plusGiro))
            {
                _isValid = false;
                _validationResult = ValidationResult.InvalidAccountNumberLength;
                return;
            }

            if (plusGiro.ToDigits() != plusGiro)
            {
                var parts = plusGiro.Split('-');
                if (parts.Length != 2
                    || (parts[0].ToDigits().Length < 1 || parts[0].ToDigits().Length > 7)
                    || parts[1].ToDigits().Length != 1)
                {
                    _isValid = false;
                    _validationResult = ValidationResult.InvalidFormat;
                    return;
                }
            }

            var accountNumber = plusGiro.ToDigits();
            if (accountNumber.Length < 2 || accountNumber.Length > 8)
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

    
        /// <summary>
        /// Gets the account number.
        /// </summary>
        public string AccountNumber => _accountNumber;

        /// <summary>
        /// Shows if account is valid or not. Check ValidationResult for more info.
        /// </summary>
        public bool IsValid => _isValid;

        /// <summary>
        /// Result of the validation.
        /// </summary>
        public ValidationResult ValidationResult => _validationResult;

    }
}
