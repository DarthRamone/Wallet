using System;
using System.Threading.Tasks;

namespace Wallet.Shared
{
  public class TransactionsRepository : BaseRepository<WalletTransaction>, ITransactionsRepository
  {
    public async Task AddTransaction(WalletTransaction transaction, string categoryId, string accountId)
    {
      await _realm.WriteAsync(realm =>
      {
        var acc = realm.Find<Account>(accountId);
        var cat = realm.Find<Category>(categoryId);
        if (acc != null && cat != null)
        {
          transaction.Account = acc;
          transaction.Category = cat;
          realm.Add(transaction);
        }
      });
    }
  }
}
