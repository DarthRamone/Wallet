using System;
using Realms;

namespace Wallet.Shared {
  
  public class TransferTransaction : RealmObject {

    [PrimaryKey]
    public string Id { get; set; }

    public WalletTransaction SourceTransaction { get; set; }

    public WalletTransaction TargetTransaction { get; set; }

    public double ExchangeRate { get; set; }

    public TransferTransaction ()
    {
      Id = Guid.NewGuid().ToString();
    }
  }

}
