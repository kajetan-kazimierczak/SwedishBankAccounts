using System;
using KajetanKazimierczak.SwedishBankAccounts;

namespace BankAccountDemoConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var accountNumber = string.Join(" ", args);

            var account = new BankAccount(accountNumber);

            if (!account.isValid)
            {
                Console.WriteLine("Account number invalid");
                Console.WriteLine($"Reason: {account.ValidationResult.ToString()}");
                Console.WriteLine($"Bank: {account.BankName}");
                Console.WriteLine($"Clearing number: {account.ClearingNumber}");
                Console.WriteLine($"Account number:  {account.AccountNumber}");
                return;
            }

            Console.WriteLine("Account number valid");
            Console.WriteLine($"Validation result: {account.ValidationResult.ToString()}");
            Console.WriteLine($"Bank: {account.BankName}");
            Console.WriteLine($"Clearing number: {account.ClearingNumber}");
            Console.WriteLine($"Account number:  {account.AccountNumber}");

            
        }
    }
}
