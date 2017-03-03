using GalaSoft.MvvmLight.Command;
using Wallet.Shared.Models;

namespace Wallet.Shared.ViewModels {
  
  public interface ISummaryViewModel {

    RelayCommand AddRecordButtonAction { get; }

    RelayCommand<Account> AccountSelected { get; }
  }

}
