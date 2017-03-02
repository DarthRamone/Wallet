using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Views;

namespace Wallet.Shared.ViewModels
{
  public class WalletBaseViewModel : ViewModelBase, IWalletBaseViewModel
  {
    protected INavigationService _navigationService;

    public WalletBaseViewModel(INavigationService navigationService)
    {
      _navigationService = navigationService;
    }
  }
}
