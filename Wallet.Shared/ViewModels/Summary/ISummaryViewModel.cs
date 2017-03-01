using System.Collections.ObjectModel;
using GalaSoft.MvvmLight.Command;
using Wallet.Shared.Models;

namespace Wallet.Shared.ViewModels {
  
  public interface ISummaryViewModel {

    ObservableCollection<object> Accounts { get; }

    ObservableCollection<WalletTransaction> Transactions { get; }

    RelayCommand AddRecordButtonAction { get; }

    RelayCommand<Account> AccountSelected { get; }
  }

}
