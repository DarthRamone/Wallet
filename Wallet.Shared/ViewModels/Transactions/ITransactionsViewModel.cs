using System.Collections.ObjectModel;
using GalaSoft.MvvmLight.Command;
using Wallet.Shared.Models;

namespace Wallet.Shared.ViewModels.Transactions {

  public interface ITransactionsViewModel : IWalletBaseViewModel {

    ObservableCollection<WalletTransaction> Transactions { get; }

    RelayCommand<string> SelectTransactionAction { get; }

  }

}