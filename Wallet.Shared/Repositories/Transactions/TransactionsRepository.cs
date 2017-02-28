using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Wallet.Shared {
  
  public class TransactionsRepository : BaseRepository<WalletTransaction>, ITransactionsRepository {

    public List<TransferTransaction> TransferTransactions => _realm.All<TransferTransaction>().ToList();

    public async Task AddTransaction(WalletTransaction transaction, string categoryId, string accountId) {
      await _realm.WriteAsync(realm => {
        var acc = realm.Find<Account>(accountId);
        var cat = realm.Find<Category>(categoryId);
        if (acc != null && cat != null) {
          transaction.Account = acc;
          transaction.Category = cat;
          realm.Add(transaction);
        }
      });
    }

    public async Task AddTransferTransaction(TransferTransaction transaction) {
      await _realm.WriteAsync(realm => {
        realm.Add(transaction);
      });
    }
  }
}
