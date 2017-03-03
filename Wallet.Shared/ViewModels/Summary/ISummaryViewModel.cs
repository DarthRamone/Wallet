using GalaSoft.MvvmLight.Command;
using Wallet.Shared.Models;

namespace Wallet.Shared.ViewModels.Summary {
  
  public interface ISummaryViewModel : IWalletBaseViewModel {

    RelayCommand AddRecordButtonAction { get; }

    RelayCommand<Account> AccountSelected { get; }
  }

}
