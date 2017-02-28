﻿using System;
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

    public async Task AddTransferTransaction(TransferTransaction transaction, string sourceAccountId, string targetAccountId) {
      await _realm.WriteAsync(realm => {

        var sourceAccount = realm.Find<Account>(sourceAccountId);
        var targetAccount = realm.Find<Account>(targetAccountId);
        var transferCategory = realm.Find<Category>("Перевод"); //TODO: make category

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
      });
    }
  }
}
