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

        public PlusGiro(string plusGiro)
        {
            _accountNumber = plusGiro;

            if (string.IsNullOrEmpty(plusGiro))
            {
                _isValid = false;
                _validationResult = ValidationResult.InvalidAccountNumberLength;
                return;
            }

            var parts = plusGiro.Split('-');
            if (parts.Length != 2
                || (parts[0].ToDigits().Length < 1 || parts[0].ToDigits().Length > 7)
                || parts[1].ToDigits().Length != 1)
            {
                _isValid = false;
                _validationResult = ValidationResult.InvalidFormat;
                return;
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

    

        public string AccountNumber => _accountNumber;

        /// <summary>
        /// Shows if account is valid or not. Check ValidationResult for more info
        /// </summary>
        public bool IsValid => _isValid;

        /// <summary>
        /// Get account number formatted for use in BGC files.
        /// </summary>
        public ValidationResult ValidationResult => _validationResult;

    }
}
