using KajetanKazimierczak.SwedishBankAccounts.Enums;

namespace KajetanKazimierczak.SwedishBankAccounts.Configuration
{
    internal class AccountConfiguration
    {
        public int ClearingNumberStart { get; set; }
        public int ClearingNumberEnd { get; set; }
        public string BankName { get; set; }

        public BankAccountType BankAccountType { get; set; }
        public BankAccountTypeComment BankAccountTypeComment { get; set; }

    }
}