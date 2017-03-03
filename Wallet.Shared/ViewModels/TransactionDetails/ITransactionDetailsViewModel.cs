using GalaSoft.MvvmLight.Command;

namespace Wallet.Shared.ViewModels.TransactionDetails {

  public interface ITransactionDetailsViewModel : IWalletBaseViewModel {

    RelayCommand DeleteTransactionAction { get; }

    void SetTransaction(string transactionId);

  }

}