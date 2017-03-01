using System.Collections.Generic;
using Realms;

namespace Wallet.Shared.Models
{
  public class Category : RealmObject
  {
    [PrimaryKey]
    public string Name { get; set; }

    public IList<WalletTransaction> Transactions { get; }
  }
}
