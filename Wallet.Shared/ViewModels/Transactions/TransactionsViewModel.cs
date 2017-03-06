using System;
using System.Collections.ObjectModel;
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
    }

    public void SetCommands() {
      SelectTransactionAction = new RelayCommand<string>(transactionId => {
        _navigationService.NavigateTo(Pages.TransactionDetailsViewControllerKey, transactionId);
      }, transactionId => true);
    }

    public void Dispose() {
    }

  }

}