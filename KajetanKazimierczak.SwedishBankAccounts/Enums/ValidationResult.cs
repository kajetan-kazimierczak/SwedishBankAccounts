namespace KajetanKazimierczak.SwedishBankAccounts.Enums
{
    public enum ValidationResult
    {
        ChecksumValidated = 0,
        ChecksumInvalid = 1,
        AccountNumberLengthInvalid = 2,
        ClearingNumberLengthInvalid = 3,
        UnknownClearingNumber = 4,
        PossiblyCannotBeValidatedWithChecksum = 5,
        ClearingNumberInvalid = 6,
        Unknown = 9999
    }
}