using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Realms;
using Wallet.Shared.Models;
using Wallet.Shared.Providers;

namespace Wallet.Shared.Repositories {
  
  public class TransactionsRepository : BaseRepository<WalletTransaction>, ITransactionsRepository {

    private Account _account;

    //private IQueryable<WalletTransaction> _transactions => _realm.All<WalletTransaction>()
      //.OrderByDescending(t => t.Date);

    private IQueryable<WalletTransaction> _transactions {
      get {
        return _account == null
          ? _realm.All<WalletTransaction>().OrderByDescending(t => t.Date)
          : _realm.All<WalletTransaction>().Where(t => t.Account == _account).OrderByDescending(t => t.Date);
      }
    }

    public List<WalletTransaction> Transactions => _transactions.ToList();

    public override event EventHandler<int[]> OnItemsDeleted = delegate { };
    public override event EventHandler<int[]> OnItemsInserted = delegate { };
    public override event EventHandler<int[]> OnItemsModified = delegate { };

    public TransactionsRepository(ISyncConfigurationsProvider configurationsProvider) : base(configurationsProvider) {

      _notificationsToken = SubscribeForNotifications();
    }

    public async Task AddTransaction(WalletTransaction transaction, string categoryId, string accountId) {
      await _realm.WriteAsync(realm => {
        var acc = realm.Find<Account>(accountId);
        var cat = realm.Find<Category>(categoryId);
        if (acc != null && cat != null) {
          transaction.Account = acc;
          transaction.Category = cat;
          cat.Transactions.Add(transaction);
          acc.Transactions.Add(transaction);
          acc.Balance += transaction.Amount;
          realm.Add(transaction);
        }
      });

    }

    public async Task AddTransferTransaction(TransferTransaction transaction, string sourceAccountId, string targetAccountId) {
      await _realm.WriteAsync(realm => {

        var sourceAccount = realm.Find<Account>(sourceAccountId);
        var targetAccount = realm.Find<Account>(targetAccountId);
        var transferCategory = realm.Find<Category>("Transfer"); //TODO: make category

        //TODO: CURRENCIES

        var date = new DateTimeOffset(DateTime.Now);

        var sourceTransaction = new WalletTransaction {
          Account = sourceAccount,
          Category = transferCategory,
          Amount = -transaction.Amount,
          Date = date,
          TransferTransaction = transaction
        };

        var targetTransaction = new WalletTransaction {
          Account = targetAccount,
          Category = transferCategory,
          Amount = transaction.Amount * transaction.ExchangeRate,
          Date = date,
          TransferTransaction = transaction
        };

        transaction.SourceTransaction = sourceTransaction;
        transaction.TargetTransaction = targetTransaction;

        realm.Add(transaction);
        realm.Add(sourceTransaction);
        realm.Add(targetTransaction);

        sourceAccount.Balance -= transaction.Amount;
        targetAccount.Balance += transaction.Amount;
      });
    }

    public void SetAccountForFiltering(Account account) {
      _account = _realm.Find<Account>(account.Name);
      _notificationsToken.Dispose();
      _notificationsToken = SubscribeForNotifications();
    }

    private IDisposable SubscribeForNotifications() {

      return _transactions.SubscribeForNotifications((sender, changes, error) => {

        if (changes != null) {
          if (changes.InsertedIndices.Length != 0)
            OnItemsInserted?.Invoke(this, changes.InsertedIndices);

          if (changes.DeletedIndices.Length != 0)
            OnItemsDeleted?.Invoke(this, changes.DeletedIndices);

          if (changes.ModifiedIndices.Length != 0)
            OnItemsModified?.Invoke(this, changes.ModifiedIndices);
        }
      });

    }

  }
}
