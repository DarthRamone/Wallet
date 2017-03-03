﻿using System;
using System.Collections.ObjectModel;
using System.Linq;
using GalaSoft.MvvmLight.Views;
using Wallet.Shared.Models;
using Wallet.Shared.Repositories.Transactions;

namespace Wallet.Shared.ViewModels.TransactionsWidget {

  public class TransactionsWidgetViewModel : WalletBaseViewModel, ITransactionsWidgetViewModel, IDisposable {

    private const int MAX_ITEMS_COUNT = 6;

    private readonly ITransactionsRepository _transactionsRepository;

    public ObservableCollection<WalletTransaction> Transactions { get; }

    public TransactionsWidgetViewModel(INavigationService navigationService,
                                       ITransactionsRepository transactionsRepository) : base(navigationService) {

      _transactionsRepository = transactionsRepository;
      Transactions = new ObservableCollection<WalletTransaction>(_transactionsRepository.Transactions.Take(MAX_ITEMS_COUNT));

      _transactionsRepository.OnItemsDeleted += TransactionItemsDeleted;
      _transactionsRepository.OnItemsInserted += TransactionItemsInserted;
      _transactionsRepository.OnItemsModified += TransactionItemsModified;
    }

    private void TransactionItemsDeleted(object sender, int[] e) {
      foreach(var index in e) Transactions.RemoveAt(index);
    }

    private void TransactionItemsInserted(object sender, int[] e) {
      foreach (var index in e) {
        Transactions.Insert(index, _transactionsRepository.Transactions[index]);
        if (Transactions.Count > MAX_ITEMS_COUNT) Transactions.RemoveAt(MAX_ITEMS_COUNT);
      }
    }

    private void TransactionItemsModified(object sender, int[] e) {
    }

    public void Dispose() {
      _transactionsRepository.OnItemsDeleted -= TransactionItemsDeleted;
      _transactionsRepository.OnItemsInserted -= TransactionItemsInserted;
      _transactionsRepository.OnItemsModified -= TransactionItemsModified;
    }
  }

}