using System.Collections.ObjectModel;
using GalaSoft.MvvmLight.Command;

namespace Wallet.Shared {
  
  public interface ISummaryViewModel {

    ObservableCollection<object> Accounts { get; }

    ObservableCollection<object> Transactions { get; }

    RelayCommand AddRecordButtonAction { get; }

    RelayCommand<Account> AccountSelected { get; }
  }

}
