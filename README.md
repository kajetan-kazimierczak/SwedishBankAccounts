# SwedishBankAccounts
Validate Swedish Bank Accounts

## Based on 
  [bankernaskontonummeruppbyggnad_anvandarmanual_sv.pdf](https://www.bankgirot.se/globalassets/dokument/anvandarmanualer/bankernaskontonummeruppbyggnad_anvandarmanual_sv.pdf)
  
  [11-modul.pdf](https://www.bankgirot.se/globalassets/dokument/anvandarmanualer/11-modul.pdf)
  
  [10-modul.pdf](https://www.bankgirot.se/globalassets/dokument/anvandarmanualer/10-modul.pdf)

## Usage

```csharp
var account = new BankAccount(clearigNumber, accountNumber);

if (!account.isValid)
{
    Console.WriteLine("Account number invalid");
    Console.WriteLine($"Reason: {account.ValidationResult.ToString()}");
    return;
}

Console.WriteLine("Account number valid");
Console.WriteLine($"Validation result: {account.ValidationResult.ToString()}");
Console.WriteLine($"Bank: {account.BankName}");
Console.WriteLine($"Clearing number: {account.ClearingNumber}");
Console.WriteLine($"Account number:  {account.AccountNumber}");
```

## Known issues
Can not validate some Swedbank accounts with 5 digit clearing number.
