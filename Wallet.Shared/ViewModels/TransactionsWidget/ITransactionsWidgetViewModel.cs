using System;
using System.Collections.ObjectModel;
using GalaSoft.MvvmLight.Command;
using Wallet.Shared.Models;

namespace Wallet.Shared.ViewModels.TransactionsWidget {

  public interface ITransactionsWidgetViewModel : IWalletBaseViewModel {

    ObservableCollection<WalletTransaction> Transactions { get; }

    event EventHandler OnTransactionsChanged;

    RelayCommand<string> SelectTransactionAction { get; }

    RelayCommand MoreButtonAction { get;  }
  }

}