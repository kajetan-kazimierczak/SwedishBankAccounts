using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace KajetanKazimierczak.SwedishBankAccounts.Extensions
{
    public static class BankAccountExtensions
    {
        public static string FormatP27(this BankAccount bankAccount)
        {
            /* From SEB's documentation:
             *
             * Danske Bank
             * If clearing number atarts with 12,13, or 24, enter clearing number and account number (11 digits)
             * if clearing number starts with 9180-9189, enter only account number (10 digits)
             *
             * Nordea Bank
             * Enter personal number without space (10 digits) or account number (11 digits)
             *
             * Sparbanken Syd
             * Enter account number (10 digits)
             *
             * Svenska Handelsbanken
             * Enter the account number without clearing number please just add (9 digits)
             *
             * Swedbank
             * If clearing number starts with 7, enter clearing number and account number (11 digits)
             * If clearing number starts with 8, enter the clearing number (5 digits) and then the account number with total 13-15 digits
             * If total number is less than 15 digits, add zeros between clearing number and account number
             *
             * Others
             * All other banks, enter clearing number and account number (11 digits)
             */

            if (bankAccount.BankName == "Danske Bank" && (bankAccount.ClearingNumber.StartsWith("12") ||
                                                          bankAccount.ClearingNumber.StartsWith("13") ||
                                                          bankAccount.ClearingNumber.StartsWith("24")))
            {
                return $"{bankAccount.ClearingNumber}{bankAccount.AccountNumber}";
            }

            if (bankAccount.BankName == "Danske Bank" && bankAccount.ClearingNumber.StartsWith("918"))
            {
                return $"{bankAccount.AccountNumber}";
            }

            if (bankAccount.BankName.Contains("Nordea") && (bankAccount.ClearingNumber == "3300" ||
                                                            bankAccount.ClearingNumber == "3782"))
            {
                return $"{bankAccount.AccountNumber}";
            }

            if (bankAccount.BankName == "Sparbanken Syd")
            {
                return $"{bankAccount.AccountNumber}".PadLeft(10,'0');
            }

            if (bankAccount.BankName.Contains("Handelsbanken"))
            {
                return $"{bankAccount.AccountNumber}".PadLeft(9,'0');
            }

            if (bankAccount.BankName == "Swedbank" && bankAccount.ClearingNumber.StartsWith("7"))
            {
                return $"{bankAccount.ClearingNumber}{bankAccount.AccountNumber}";
            }

            if (bankAccount.BankName.Contains("Swedbank") && bankAccount.ClearingNumber.StartsWith("8")) 
            {
                return $"{bankAccount.ClearingNumber}" + $"{bankAccount.AccountNumber}".PadLeft(10,'0');
            }

            return $"{bankAccount.ClearingNumber}{bankAccount.AccountNumber}";

        }
    }
}
