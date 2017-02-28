using System;
using Realms;

namespace Wallet.Shared
{
  public class WalletTransaction : RealmObject {
    
    [PrimaryKey]
    public string Id { get; set; }

    public double Amount { get; set; }

    public Category Category { get; set; }

    public Account Account { get; set; }

    public DateTimeOffset Date { get; set; }

    public TransferTransaction TransferTransaction { get; set; }

    public WalletTransaction()
    {
      Id = Guid.NewGuid().ToString();
    }
  }
}
