using System.Collections.Generic;

namespace Wallet.Shared.Models {

  public static class CurrenciesList {

    public static Currency ReferenceCurrency =
      new Currency {Code = "usd", ExchangeRate = 1, Symbol = "$", Name = "US Dollars"};

    public static List<Currency> Currencies = new List<Currency> {
      new Currency { Code = "rub", ExchangeRate = 0.01428571429, Symbol = "₽", Name = "Rubles" },
      ReferenceCurrency
    };

    public static Currency GetCurrency(string code) {
      return Currencies.Find(c => c.Code.Equals(code));
    }

    public static double Convert(Currency from, Currency to, double amount) {

      var amountInUsd = amount * from.ExchangeRate;
      return amountInUsd / to.ExchangeRate;
    }

    public static double Convert(string from, string to, double amount) {
      var fromCurrency = GetCurrency(from);
      var toCurrency = GetCurrency(to);
      return Convert(fromCurrency, toCurrency, amount);
    }
  }

}
