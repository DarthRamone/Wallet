using System.Collections.Generic;
using Realms;

namespace Wallet.Shared {
  
  public class Account : RealmObject {
    
    [PrimaryKey]
    public string Name { get; set; }

    public double Balance { get; set; }

    public string Currency { get; set; }

    public bool IsCash { get; set; }

    public IList<WalletTransaction> Transactions { get; }

  }
}
