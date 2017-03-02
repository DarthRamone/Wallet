using System.Collections.ObjectModel;
using Wallet.Shared.Models;

namespace Wallet.Shared.ViewModels {

  public interface ITransactionsWidgetViewModel {

    ObservableCollection<WalletTransaction> Transactions { get; }

  }

}