namespace KajetanKazimierczak.SwedishBankAccounts.Enums
{
    public enum ValidationResult
    {
        ChecksumValidated = 0,
        InvalidChecksum = 1,
        InvalidAccountNumberLength = 2,
        InvalidClearingNumberLength = 3,
        UnknownClearingNumber = 4,
        PossiblyCannotBeValidatedWithChecksum = 5,
        InvalidClearingNumber = 6,
        InvalidFormat = 7,
        Unknown = 9999,
        
    }
}