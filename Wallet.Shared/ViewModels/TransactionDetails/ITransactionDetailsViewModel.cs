using GalaSoft.MvvmLight.Command;

namespace Wallet.Shared.ViewModels.TransactionDetails {

  public interface ITransactionDetailsViewModel : IWalletBaseViewModel {

    string FirstItemButtonText { get; set; }

    string FirstItemLabelText { get; set; }

    string SecondItemButtonText { get; set; }

    string SecondItemLabelText { get; set; }

    string AmountLabelText { get; set; }

    RelayCommand DeleteTransactionAction { get; }

    void SetTransaction(string transactionId);

  }

}