using System;
using System.Collections.ObjectModel;
using System.Linq;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using Wallet.Shared.Models;
using Wallet.Shared.Repositories.Transactions;

namespace Wallet.Shared.ViewModels.Transactions {

  public class TransactionsViewModel : WalletBaseViewModel, ITransactionsViewModel, IDisposable {

    private ITransactionsRepository _transactionsRepository;

    public ObservableCollection<WalletTransaction> Transactions { get; }

    public RelayCommand<string> SelectTransactionAction { get; private set;  }

    public TransactionsViewModel(INavigationService navigationService,
                                 ITransactionsRepository transactionsRepository) : base(navigationService) {
      _transactionsRepository = transactionsRepository;
      Transactions = new ObservableCollection<WalletTransaction>(_transactionsRepository.Transactions);

      _transactionsRepository.OnItemsDeleted += TransactionsDeleted;
      _transactionsRepository.OnItemsInserted += TransactionsInserted;
      _transactionsRepository.OnItemsModified += TransactionsModified;
    }

    public void SetCommands() {
      SelectTransactionAction = new RelayCommand<string>(transactionId => {
        _navigationService.NavigateTo(Pages.TransactionDetailsViewControllerKey, transactionId);
      }, transactionId => true);
    }

    private void TransactionsInserted(object sender, int[] e) {
      var items = e.Select(index => _transactionsRepository.Transactions[index]);
      foreach (var item in items) {
        Transactions.Add(item);
      }
    }

    private void TransactionsDeleted(object sender, int[] e) {
      var indicies = e.OrderByDescending(i => i);
      foreach (var i in  indicies) {
        Transactions.RemoveAt(i);
      }
    }

    private void TransactionsModified(object sender, int[] e) {
      foreach (var index in e) {
        Transactions[index] = _transactionsRepository.Transactions[index];
      }
    }

    public void Dispose() {
      _transactionsRepository.OnItemsDeleted -= TransactionsDeleted;
      _transactionsRepository.OnItemsInserted -= TransactionsInserted;
      _transactionsRepository.OnItemsModified -= TransactionsModified;
    }

  }

}