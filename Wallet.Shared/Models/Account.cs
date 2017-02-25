using System;
using System.Collections.Generic;
using Realms;

namespace Wallet.Shared
{
  public class Account : RealmObject
  {
    [PrimaryKey]
    public string Id { get; set; }

    public IList<Transaction> Transactions { get; set; }
  }
}
