using System.Collections.Generic;
using System.Linq;
using KajetanKazimierczak.SwedishBankAccounts.Enums;
using KajetanKazimierczak.SwedishBankAccounts.Extensions;

namespace KajetanKazimierczak.SwedishBankAccounts.Configuration
{
    internal static class Configuration
    {
        // https://www.bankgirot.se/globalassets/dokument/anvandarmanualer/bankernaskontonummeruppbyggnad_anvandarmanual_sv.pdf
        // version 2019-10-22

        private static readonly List<AccountConfiguration> AccountConfigurations = new List<AccountConfiguration>
        {
            new AccountConfiguration
            {
                BankName = "Svea Bank AB",
                ClearingNumberStart = 9660,
                ClearingNumberEnd = 9669,
                BankAccountType = BankAccountType.Type1,
                BankAccountTypeComment = BankAccountTypeComment.Type2
            },
            new AccountConfiguration
            {
                BankName = "Avanza Bank AB",
                ClearingNumberStart = 9550,
                ClearingNumberEnd = 9569,
                BankAccountType = BankAccountType.Type1,
                BankAccountTypeComment = BankAccountTypeComment.Type2
            },
            new AccountConfiguration
            {
                BankName = "BlueStep Finans AB",
                ClearingNumberStart = 9680,
                ClearingNumberEnd = 9689,
                BankAccountType = BankAccountType.Type1,
                BankAccountTypeComment = BankAccountTypeComment.Type1
            },
            new AccountConfiguration
            {
                BankName = "BNP Paribas SA., Sverige filial",
                ClearingNumberStart = 9470,
                ClearingNumberEnd = 9479,
                BankAccountType = BankAccountType.Type1,
                BankAccountTypeComment = BankAccountTypeComment.Type2
            },
            new AccountConfiguration
            {
                BankName = "Citibank",
                ClearingNumberStart = 9040,
                ClearingNumberEnd = 9049,
                BankAccountType = BankAccountType.Type1,
                BankAccountTypeComment = BankAccountTypeComment.Type2
            },
            new AccountConfiguration
            {
                BankName = "Danske Bank",
                ClearingNumberStart = 1200,
                ClearingNumberEnd = 1399,
                BankAccountType = BankAccountType.Type1,
                BankAccountTypeComment = BankAccountTypeComment.Type1
            },
            new AccountConfiguration
            {
                BankName = "Danske Bank",
                ClearingNumberStart = 2400,
                ClearingNumberEnd = 2499,
                BankAccountType = BankAccountType.Type1,
                BankAccountTypeComment = BankAccountTypeComment.Type1
            },
            new AccountConfiguration
            {
                BankName = "DNB Bank",
                ClearingNumberStart = 9190,
                ClearingNumberEnd = 9199,
                BankAccountType = BankAccountType.Type1,
                BankAccountTypeComment = BankAccountTypeComment.Type2
            },
            new AccountConfiguration
            {
                BankName = "DNB Bank",
                ClearingNumberStart = 9260,
                ClearingNumberEnd = 9269,
                BankAccountType = BankAccountType.Type1,
                BankAccountTypeComment = BankAccountTypeComment.Type2
            },
            new AccountConfiguration
            {
                BankName = "Ekobanken",
                ClearingNumberStart = 9700,
                ClearingNumberEnd = 9709,
                BankAccountType = BankAccountType.Type1,
                BankAccountTypeComment = BankAccountTypeComment.Type2
            },
            new AccountConfiguration
            {
                BankName = "Erik Penser AB",
                ClearingNumberStart = 9590,
                ClearingNumberEnd = 9599,
                BankAccountType = BankAccountType.Type1,
                BankAccountTypeComment = BankAccountTypeComment.Type2
            },
            new AccountConfiguration
            {
                BankName = "Forex Bank",
                ClearingNumberStart = 9400,
                ClearingNumberEnd = 9449,
                BankAccountType = BankAccountType.Type1,
                BankAccountTypeComment = BankAccountTypeComment.Type1
            },
            new AccountConfiguration
            {
                BankName = "ICA Banken AB",
                ClearingNumberStart = 9270,
                ClearingNumberEnd = 9279,
                BankAccountType = BankAccountType.Type1,
                BankAccountTypeComment = BankAccountTypeComment.Type1
            },
            new AccountConfiguration
            {
                BankName = "IKANO Bank",
                ClearingNumberStart = 9170,
                ClearingNumberEnd = 9179,
                BankAccountType = BankAccountType.Type1,
                BankAccountTypeComment = BankAccountTypeComment.Type1
            },
            new AccountConfiguration
            {
                BankName = "JAK Medlemsbank",
                ClearingNumberStart = 9670,
                ClearingNumberEnd = 9679,
                BankAccountType = BankAccountType.Type1,
                BankAccountTypeComment = BankAccountTypeComment.Type2
            },
            new AccountConfiguration
            {
                BankName = "Klarna Bank",
                ClearingNumberStart = 9780,
                ClearingNumberEnd = 9789,
                BankAccountType = BankAccountType.Type1,
                BankAccountTypeComment = BankAccountTypeComment.Type2
            },
            new AccountConfiguration
            {
                BankName = "Landshypotek AB",
                ClearingNumberStart = 9390,
                ClearingNumberEnd = 9399,
                BankAccountType = BankAccountType.Type1,
                BankAccountTypeComment = BankAccountTypeComment.Type2
            },
            new AccountConfiguration
            {
                BankName = "Lån & Spar Bank Sverige",
                ClearingNumberStart = 9630,
                ClearingNumberEnd = 9639,
                BankAccountType = BankAccountType.Type1,
                BankAccountTypeComment = BankAccountTypeComment.Type1
            },
            new AccountConfiguration
            {
                BankName = "Länsförsäkringar Bank",
                ClearingNumberStart = 3400,
                ClearingNumberEnd = 3409,
                BankAccountType = BankAccountType.Type1,
                BankAccountTypeComment = BankAccountTypeComment.Type1
            },
            new AccountConfiguration
            {
                BankName = "Länsförsäkringar Bank",
                ClearingNumberStart = 9020,
                ClearingNumberEnd = 9029,
                BankAccountType = BankAccountType.Type1,
                BankAccountTypeComment = BankAccountTypeComment.Type2
            },
            new AccountConfiguration
            {
                BankName = "Länsförsäkringar Bank",
                ClearingNumberStart = 9060,
                ClearingNumberEnd = 9069,
                BankAccountType = BankAccountType.Type1,
                BankAccountTypeComment = BankAccountTypeComment.Type1
            },
            new AccountConfiguration
            {
                BankName = "Marginalen Bank",
                ClearingNumberStart = 9230,
                ClearingNumberEnd = 9239,
                BankAccountType = BankAccountType.Type1,
                BankAccountTypeComment = BankAccountTypeComment.Type1
            },
            new AccountConfiguration
            {
                BankName = "MedMera Bank AB",
                ClearingNumberStart = 9650,
                ClearingNumberEnd = 9659,
                BankAccountType = BankAccountType.Type1,
                BankAccountTypeComment = BankAccountTypeComment.Type2
            },
            new AccountConfiguration
            {
                BankName = "Nordax Bank AB",
                ClearingNumberStart = 9640,
                ClearingNumberEnd = 9649,
                BankAccountType = BankAccountType.Type1,
                BankAccountTypeComment = BankAccountTypeComment.Type2
            },
            new AccountConfiguration
            {
                BankName = "Nordea",
                ClearingNumberStart = 1100,
                ClearingNumberEnd = 1199,
                BankAccountType = BankAccountType.Type1,
                BankAccountTypeComment = BankAccountTypeComment.Type1
            },
            new AccountConfiguration
            {
                BankName = "Nordea",
                ClearingNumberStart = 1400,
                ClearingNumberEnd = 2099,
                BankAccountType = BankAccountType.Type1,
                BankAccountTypeComment = BankAccountTypeComment.Type1
            },
            new AccountConfiguration
            {
                BankName = "Nordea",
                ClearingNumberStart = 3000,
                ClearingNumberEnd = 3299,
                BankAccountType = BankAccountType.Type1,
                BankAccountTypeComment = BankAccountTypeComment.Type1
            },     
            new AccountConfiguration
            {
                BankName = "Nordea",
                ClearingNumberStart = 3301,
                ClearingNumberEnd = 3399,
                BankAccountType = BankAccountType.Type1,
                BankAccountTypeComment = BankAccountTypeComment.Type1
            },
            new AccountConfiguration
            {
                BankName = "Nordea",
                ClearingNumberStart = 3410,
                ClearingNumberEnd = 3781,
                BankAccountType = BankAccountType.Type1,
                BankAccountTypeComment = BankAccountTypeComment.Type1
            },
            new AccountConfiguration
            {
                BankName = "Nordea",
                ClearingNumberStart = 3783,
                ClearingNumberEnd = 3999,
                BankAccountType = BankAccountType.Type1,
                BankAccountTypeComment = BankAccountTypeComment.Type1
            },
            new AccountConfiguration
            {
                BankName = "Nordea",
                ClearingNumberStart = 4000,
                ClearingNumberEnd = 4999,
                BankAccountType = BankAccountType.Type1,
                BankAccountTypeComment = BankAccountTypeComment.Type2
            },
            new AccountConfiguration
            {
                BankName = "Nordnet Bank",
                ClearingNumberStart = 9100,
                ClearingNumberEnd = 9109,
                BankAccountType = BankAccountType.Type1,
                BankAccountTypeComment = BankAccountTypeComment.Type2
            },
            new AccountConfiguration
            {
                BankName = "Resurs Bank",
                ClearingNumberStart = 9280,
                ClearingNumberEnd = 9289,
                BankAccountType = BankAccountType.Type1,
                BankAccountTypeComment = BankAccountTypeComment.Type1
            },
            new AccountConfiguration
            {
                BankName = "Riksgälden",
                ClearingNumberStart = 9880,
                ClearingNumberEnd = 9889,
                BankAccountType = BankAccountType.Type1,
                BankAccountTypeComment = BankAccountTypeComment.Type2
            },
            new AccountConfiguration
            {
                BankName = "Santander Consumer Bank AS",
                ClearingNumberStart = 9460,
                ClearingNumberEnd = 9469,
                BankAccountType = BankAccountType.Type1,
                BankAccountTypeComment = BankAccountTypeComment.Type1
            },
            new AccountConfiguration
            {
                BankName = "SBAB",
                ClearingNumberStart = 9250,
                ClearingNumberEnd = 9259,
                BankAccountType = BankAccountType.Type1,
                BankAccountTypeComment = BankAccountTypeComment.Type1
            },
            new AccountConfiguration
            {
                BankName = "SEB",
                ClearingNumberStart = 5000,
                ClearingNumberEnd = 5999,
                BankAccountType = BankAccountType.Type1,
                BankAccountTypeComment = BankAccountTypeComment.Type1
            },
            new AccountConfiguration
            {
                BankName = "SEB",
                ClearingNumberStart = 9120,
                ClearingNumberEnd = 9124,
                BankAccountType = BankAccountType.Type1,
                BankAccountTypeComment = BankAccountTypeComment.Type1
            },
            new AccountConfiguration
            {
                BankName = "SEB",
                ClearingNumberStart = 9130,
                ClearingNumberEnd = 9149,
                BankAccountType = BankAccountType.Type1,
                BankAccountTypeComment = BankAccountTypeComment.Type1
            },
            new AccountConfiguration
            {
                BankName = "Skandiabanken",
                ClearingNumberStart = 9150,
                ClearingNumberEnd = 9169,
                BankAccountType = BankAccountType.Type1,
                BankAccountTypeComment = BankAccountTypeComment.Type2
            },
            new AccountConfiguration
            {
                BankName = "Swedbank",
                ClearingNumberStart = 7000,
                ClearingNumberEnd = 7999,
                BankAccountType = BankAccountType.Type1,
                BankAccountTypeComment = BankAccountTypeComment.Type1
            },
            new AccountConfiguration
            {
                BankName = "Ålandsbanken Sverige AB",
                ClearingNumberStart = 2300,
                ClearingNumberEnd = 2399,
                BankAccountType = BankAccountType.Type1,
                BankAccountTypeComment = BankAccountTypeComment.Type2
            },

            //

            new AccountConfiguration
            {
                BankName = "Danske Bank",
                ClearingNumberStart = 9180,
                ClearingNumberEnd = 9189,
                BankAccountType = BankAccountType.Type2,
                BankAccountTypeComment = BankAccountTypeComment.Type1
            },
            new AccountConfiguration
            {
                BankName = "Handelsbanken",
                ClearingNumberStart = 6000,
                ClearingNumberEnd = 6999,
                BankAccountType = BankAccountType.Type2,
                BankAccountTypeComment = BankAccountTypeComment.Type2
            },
            new AccountConfiguration
            {
                BankName = "Nordea/Plusgirot",
                ClearingNumberStart = 9500,
                ClearingNumberEnd = 9549,
                BankAccountType = BankAccountType.Type2,
                BankAccountTypeComment = BankAccountTypeComment.Type3
            },
            new AccountConfiguration
            {
                BankName = "Nordea/Plusgirot",
                ClearingNumberStart = 9960,
                ClearingNumberEnd = 9969,
                BankAccountType = BankAccountType.Type2,
                BankAccountTypeComment = BankAccountTypeComment.Type3
            },
            new AccountConfiguration
            {
                BankName = "Nordea - personkonto",
                ClearingNumberStart = 3300,
                ClearingNumberEnd = 3300,
                BankAccountType = BankAccountType.Type2,
                BankAccountTypeComment = BankAccountTypeComment.Type1
            },
            new AccountConfiguration
            {
                BankName = "Nordea - personkonto",
                ClearingNumberStart = 3782,
                ClearingNumberEnd = 3782,
                BankAccountType = BankAccountType.Type2,
                BankAccountTypeComment = BankAccountTypeComment.Type1
            },
            new AccountConfiguration
            {
                BankName = "Riksgälden",
                ClearingNumberStart = 9890,
                ClearingNumberEnd = 9899,
                BankAccountType = BankAccountType.Type2,
                BankAccountTypeComment = BankAccountTypeComment.Type1
            },
            new AccountConfiguration
            {
                BankName = "Sparbanken Syd",
                ClearingNumberStart = 9570,
                ClearingNumberEnd = 9579,
                BankAccountType = BankAccountType.Type2,
                BankAccountTypeComment = BankAccountTypeComment.Type1
            },
            new AccountConfiguration
            {
                BankName = "Swedbank",
                ClearingNumberStart = 8000,
                ClearingNumberEnd = 8999,
                BankAccountType = BankAccountType.Type2,
                BankAccountTypeComment = BankAccountTypeComment.Type3
            },
            new AccountConfiguration
            {
                BankName = "Swedbank (f.d. Sparbanken Öresund)",
                ClearingNumberStart = 9300,
                ClearingNumberEnd = 9329,
                BankAccountType = BankAccountType.Type2,
                BankAccountTypeComment = BankAccountTypeComment.Type1
            },
            new AccountConfiguration
            {
                BankName = "Swedbank (f.d. Sparbanken Öresund)",
                ClearingNumberStart = 9330,
                ClearingNumberEnd = 9349,
                BankAccountType = BankAccountType.Type2,
                BankAccountTypeComment = BankAccountTypeComment.Type1
            },


        };

        public static AccountConfiguration GetConfigForClearingNumber(string number)
        {
            return GetConfigForClearingNumber(int.Parse(number?.ToDigits() ?? "0"));
        }
        public static AccountConfiguration GetConfigForClearingNumber(int number)
        {
           // if(number.ToString().Length != 4) throw new ArgumentOutOfRangeException(nameof(number));

            var config =
                AccountConfigurations.FirstOrDefault(x =>
                    x.ClearingNumberStart <= number && x.ClearingNumberEnd >= number);

            return config;
        }
    }
}