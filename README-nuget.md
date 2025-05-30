# SwedishBankAccounts

## Features
- Validate Swedish Bank Account numbers, PlusGiro, and BankGiro
- Checksum validation based on official Swedish banking documentation
- Provides detailed validation results and error reasons
- Identifies bank name, clearing number, and account number for bank accounts

## Supported Banks and Account Types
- All major Swedish banks (e.g., Swedbank, SEB, Nordea, Handelsbanken, Danske Bank, Länsförsäkringar, ICA Banken, SkandiaBanken, Sparbanken Syd, Ålandsbanken, Forex Bank, etc.)
- PlusGiro accounts
- BankGiro accounts


## Based on 
  [bankernaskontonummeruppbyggnad_anvandarmanual_sv.pdf](https://www.bankgirot.se/globalassets/dokument/anvandarmanualer/bankernaskontonummeruppbyggnad_anvandarmanual_sv.pdf) (2024-02-22)
  
  [11-modul.pdf](https://www.bankgirot.se/globalassets/dokument/anvandarmanualer/11-modul.pdf)
  
  [10-modul.pdf](https://www.bankgirot.se/globalassets/dokument/anvandarmanualer/10-modul.pdf)

## Usage
Instantiate the `BankAccount`, `PlusGiro`, or `BankGiro` class and check the `IsValid` property. If the account is not valid, check the `ValidationResult` property for details.

### Examples

#### Bank account

```csharp
var account = new BankAccount(clearingNumber, accountNumber);

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

The `BankAccount` class can also be instantiated with a full account number (clearing number and account number combined), but parsing may be incorrect for Swedbank accounts starting with 8 if the clearing number has 5 digits. Prefer the constructor above when possible.

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

## ValidationResult
The `ValidationResult` property provides detailed information about why an account number is invalid, including error codes and messages (e.g., invalid length, checksum failure, etc.).

## Contributing
Contributions are welcome! Please open issues or submit pull requests for improvements or bug fixes.

## License
This project is licensed under the MIT License. See the LICENSE file for details.
