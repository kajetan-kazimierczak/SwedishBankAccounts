using System;

namespace KajetanKazimierczak.SwedishBankAccounts.Enums
{
    public enum ValidationResult
    {
        /// <summary>
        /// Account number checksum is correct
        /// </summary>
        ChecksumValidated = 0,

        /// <summary>
        /// Account number invalid. Checksum digit is incorrect.
        /// </summary>
        InvalidChecksum = 1,

        /// <summary>
        /// Invalid account number length.
        /// </summary>
        InvalidAccountNumberLength = 2,

        /// <summary>
        /// Invalid clearing number length.
        /// </summary>
        InvalidClearingNumberLength = 3,

        /// <summary>
        /// Unknown clearing number. 
        /// </summary>
        UnknownClearingNumber = 4,

        /// <summary>
        /// In rare cases some account numbers can not be validated with checksum.
        /// </summary>
         [Obsolete("Not used", false)]
        PossiblyCannotBeValidatedWithChecksum = 5,

        /// <summary>
        /// Invalid clearing number. Checksum of 5 digit clearing number is not valid.
        /// </summary>
        InvalidClearingNumber = 6,

        /// <summary>
        /// Invalid format. Make sure the '-' is at correct place.
        /// </summary>
        InvalidFormat = 7,

        /// <summary>
        /// Unknown validation error.
        /// </summary>
        Unknown = 9999,
        
    }
}