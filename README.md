# SwedishBankAccounts
![.NET Core Tests](https://github.com/kajetan-kazimierczak/SwedishBankAccounts/workflows/.NET%20Core%20Tests/badge.svg)
[![NuGet Badge](https://buildstats.info/nuget/KajetanKazimierczak.SwedishBankAccounts)](https://www.nuget.org/packages/KajetanKazimierczak.SwedishBankAccounts/)
## Info 

Validate Swedish Bank Account numbers, PlusGiro and BankGiro. The account numbers are validated with checksum calculations.

## Based on 
  [bankernaskontonummeruppbyggnad_anvandarmanual_sv.pdf](https://www.bankgirot.se/globalassets/dokument/anvandarmanualer/bankernaskontonummeruppbyggnad_anvandarmanual_sv.pdf) (2020-04-15)
  
  [11-modul.pdf](https://www.bankgirot.se/globalassets/dokument/anvandarmanualer/11-modul.pdf)
  
  [10-modul.pdf](https://www.bankgirot.se/globalassets/dokument/anvandarmanualer/10-modul.pdf)

## Usage
Instantiate the BankAccount, PlusGiro or BankGiro class and check the IsValid property of the object. If the account is not valid, check the ValidationResult property for details.

### Examples

#### Bank account

```csharp
var account = new BankAccount(clearigNumber, accountNumber);

if (!account.IsValid)
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

The BankAccount class can be instantiated with full account number (clearing number and account number combined), but the parsing could be wrong for Swedbank accounts starting with an 8 if the clearing number has 5 digits. If possible, use the above constructor.

```csharp
var account = new BankAccount(fullAccountNumber);
```

#### PlusGiro

```csharp
var account = new PlusGiro(accountNumber);

if (!account.IsValid)
{
    Console.WriteLine("Account number invalid");
    Console.WriteLine($"Reason: {account.ValidationResult.ToString()}");
    return;
}

Console.WriteLine("Account number valid");
Console.WriteLine($"Validation result: {account.ValidationResult.ToString()}");
```

#### BankGiro

```csharp
var account = new BankGiro(accountNumber);

if (!account.IsValid)
{
    Console.WriteLine("Account number invalid");
    Console.WriteLine($"Reason: {account.ValidationResult.ToString()}");
    return;
}

Console.WriteLine("Account number valid");
Console.WriteLine($"Validation result: {account.ValidationResult.ToString()}");
```


## Known issues
In rare occasions some of Swedbank’s accounts with clearing number beginning with '8' cannot be validated by a checksum calculation. These accounts will be flagged as invalid.
