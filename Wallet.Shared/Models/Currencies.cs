using System.Collections.Generic;

namespace Wallet.Shared.Models {
  public static class CurrenciesList {

    public static List<Currency> Currencies = new List<Currency> {
      new Currency { Code = "rub", ExchangeRate = 0.01428571429, Symbol = "₽", Name = "Rubles" },
      new Currency { Code = "usd", ExchangeRate = 1, Symbol = "$", Name = "US Dollars" }
    };

    public static Currency GetCurrency(string code) {
      return Currencies.Find(c => c.Code.Equals(code));
    }
  }
}
