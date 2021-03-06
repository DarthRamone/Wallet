﻿namespace Wallet.Shared.Models {
  
  public class Currency {

    public string Code { get; set; }

    public string Symbol { get; set; }

    public double ExchangeRate { get; set; }

    public string Name { get; set; }

    public string GetFormattedValue(double amount) => $"{amount:N}{Symbol}".Replace(".00", string.Empty);
  }

}
