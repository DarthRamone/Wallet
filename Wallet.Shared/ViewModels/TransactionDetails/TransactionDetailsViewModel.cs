using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using Wallet.Shared.Models;
using Wallet.Shared.Repositories.Transactions;

namespace Wallet.Shared.ViewModels.TransactionDetails {

  public class TransactionDetailsViewModel : WalletBaseViewModel, ITransactionDetailsViewModel {

    private WalletTransaction _transaction;

    private readonly ITransactionsRepository _transactionsRepository;

    private string _firstItemButtonText;
    public string FirstItemButtonText {
      get { return _firstItemButtonText; }
      set {
        _firstItemButtonText = value;
        RaisePropertyChanged(() => FirstItemButtonText);
      }
    }

    private string _firstItemLabelText;
    public string FirstItemLabelText {
      get { return _firstItemLabelText; }
      set {
        _firstItemLabelText = value;
        RaisePropertyChanged(() => FirstItemLabelText);
      }
    }

    private string _secondItemButtonText;
    public string SecondItemButtonText {
      get { return _secondItemButtonText; }
      set {
        _secondItemButtonText = value;
        RaisePropertyChanged(() => SecondItemButtonText);
      }
    }

    private string _secondItemLabelText;
    public string SecondItemLabelText {
      get { return _secondItemLabelText; }
      set {
        _secondItemLabelText = value;
        RaisePropertyChanged(() => SecondItemLabelText);
      }
    }

    private string _amountLabelText;
    public string AmountLabelText {
      get { return _amountLabelText; }
      set {
        _amountLabelText = value;
        RaisePropertyChanged(() => _amountLabelText);
      }
    }

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

      if (_transaction.TransferTransaction == null) {
        FirstItemLabelText = "Account:";
        FirstItemButtonText = _transaction.Account.Name;

        SecondItemLabelText = "Category:";
        SecondItemButtonText = _transaction.Category.Name;

        AmountLabelText = _transaction.Amount.ToString("0.##");
      }
      else {
        FirstItemLabelText = "Source account:";
        FirstItemButtonText = _transaction.TransferTransaction.SourceTransaction.Account.Name;

        SecondItemLabelText = "Target account:";
        SecondItemButtonText = _transaction.TransferTransaction.TargetTransaction.Account.Name;

        AmountLabelText = _transaction.TransferTransaction.SourceTransaction.Amount.ToString("0.##");
      }
    }
  }

}