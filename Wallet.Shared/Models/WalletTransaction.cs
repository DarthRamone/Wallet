using System;
using Realms;

namespace Wallet.Shared
{
  public class WalletTransaction : RealmObject
  {
    [PrimaryKey]
    public string Id { get; set; }

    public float Amount { get; set; }

    public Category Category { get; set; }

    public Account Account { get; set; }

    public WalletTransaction()
    {
      Id = Guid.NewGuid().ToString();
    }
  }
}
