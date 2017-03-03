using System.Collections.ObjectModel;
using GalaSoft.MvvmLight.Command;
using Wallet.Shared.Models;

namespace Wallet.Shared.ViewModels.TransactionsWidget {

  public interface ITransactionsWidgetViewModel : IWalletBaseViewModel {

    ObservableCollection<WalletTransaction> Transactions { get; }

    RelayCommand<string> SelectTransactionAction { get; }
  }

}