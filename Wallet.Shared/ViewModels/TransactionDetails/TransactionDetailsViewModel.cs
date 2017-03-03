using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using Wallet.Shared.Models;
using Wallet.Shared.Repositories.Transactions;

namespace Wallet.Shared.ViewModels.TransactionDetails {

  public class TransactionDetailsViewModel : WalletBaseViewModel, ITransactionDetailsViewModel {

    private WalletTransaction _transaction;

    private readonly ITransactionsRepository _transactionsRepository;

    public RelayCommand DeleteTransactionAction { get; private set; }

    public TransactionDetailsViewModel(INavigationService navigationService, ITransactionsRepository transactionsRepository) : base(navigationService) {
      _transactionsRepository = transactionsRepository;
      SetCommands();
    }

    private void SetCommands() {
      DeleteTransactionAction = new RelayCommand(async () => {
        await _transactionsRepository.RemoveTransaction(_transaction.Id);
        _navigationService.GoBack();
      }, () => true);
    }


    public void SetTransaction(string transactionId) {
      _transaction = _transactionsRepository.Items.Find(t => t.Id == transactionId);
    }
  }

}