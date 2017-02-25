using Realms;

namespace Wallet.Shared
{
  public class Transaction : RealmObject
  {
    public string Id { get; set; }

    public float Amount { get; set; }

    public Category Category { get; set; }

    public Account Account { get; set; }

  }
}
