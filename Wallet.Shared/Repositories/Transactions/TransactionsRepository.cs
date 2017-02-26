using System.Threading.Tasks;

namespace Wallet.Shared
{
  public class TransactionsRepository : BaseRepository<WalletTransaction>, ITransactionsRepository
  {
    public async Task AddTransaction(double amount, string categoryId, string accountId)
    {
      await _realm.WriteAsync(realm => {
        var acc = realm.Find<Account>(accountId);
        var cat = realm.Find<Category>(categoryId);
        if (acc != null && cat != null)
        {
          var transaction = new WalletTransaction();
          transaction.Account = acc;
          transaction.Category = cat;
          transaction.Amount = amount;
          realm.Add(transaction, false);
        }
      });
    }
  }
}
