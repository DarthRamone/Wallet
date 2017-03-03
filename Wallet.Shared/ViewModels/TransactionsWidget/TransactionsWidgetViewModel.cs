using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using Wallet.Shared.Models;
using Wallet.Shared.Repositories.Transactions;

namespace Wallet.Shared.ViewModels.TransactionsWidget {

  public class TransactionsWidgetViewModel : WalletBaseViewModel, ITransactionsWidgetViewModel, IDisposable {

    private const int MAX_ITEMS_COUNT = 6;

    private readonly ITransactionsRepository _transactionsRepository;

    public ObservableCollection<WalletTransaction> Transactions { get; }

    public RelayCommand<string> SelectTransactionAction { get; private set; }

    public TransactionsWidgetViewModel(INavigationService navigationService,
                                       ITransactionsRepository transactionsRepository) : base(navigationService) {

      _transactionsRepository = transactionsRepository;
      Transactions = new ObservableCollection<WalletTransaction>(_transactionsRepository.Transactions.Take(MAX_ITEMS_COUNT));

      _transactionsRepository.OnItemsDeleted += TransactionItemsDeleted;
      _transactionsRepository.OnItemsInserted += TransactionItemsInserted;
      _transactionsRepository.OnItemsModified += TransactionItemsModified;

      SetCommands();
    }

    private void SetCommands() {
      SelectTransactionAction = new RelayCommand<string>(id => {
        _navigationService.NavigateTo(Pages.TransactionDetailsViewControllerKey, id);
      }, id => true);
    }

    private void TransactionItemsDeleted(object sender, int[] e) {
      //TODO: figure out how to handle deletions 
      for (int i = 0; i < e.Length; i++) {
        Transactions.RemoveAt(i == 0 ? e[i] : e[i] - i);
        if (_transactionsRepository.Transactions.Count >= MAX_ITEMS_COUNT) {
          Transactions.Add(_transactionsRepository.Transactions[MAX_ITEMS_COUNT - 1]);
        }
      }
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