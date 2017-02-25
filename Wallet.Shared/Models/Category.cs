using System.Collections.Generic;
using Realms;

namespace Wallet.Shared
{
  public class Category : RealmObject
  {
    [PrimaryKey]
    public string Name { get; set; }

    public IList<WalletTransaction> Transactions { get; }
  }
}
