using System;
using System.Collections.ObjectModel;
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

    public RelayCommand MoreButtonAction { get; private set; }

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

      MoreButtonAction = new RelayCommand(() => {
        _navigationService.NavigateTo(Pages.TransactionsViewControllerKey);
      }, () => true);
    }

    private void TransactionItemsDeleted(object sender, int[] e) {
      var indicies = e.Where(i => i < MAX_ITEMS_COUNT).OrderByDescending(i => i);

      foreach (var index in indicies) {
        Transactions.RemoveAt(index);
      }

      var currentTransactionsCount = Transactions.Count;
      if (currentTransactionsCount < _transactionsRepository.Transactions.Count) {
        for (int i = currentTransactionsCount; i < MAX_ITEMS_COUNT; i++) {
          if (_transactionsRepository.Transactions.Count - 1 > i) {
            Transactions.Add(_transactionsRepository.Transactions[i]);
          }
        }
      }
    }

    private void TransactionItemsInserted(object sender, int[] e) {
      var indicies = e.Where(i => i < MAX_ITEMS_COUNT);
      foreach (var index in indicies) {
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