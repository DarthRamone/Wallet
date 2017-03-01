using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Views;

namespace Wallet.Shared
{
  public class WalletBaseViewModel : ViewModelBase, IWalletBaseViewModel
  {
    protected INavigationService _navigationService;

    protected IApplicationViewModel _applicationViewModel;

    public WalletBaseViewModel(INavigationService navigationService,
                               IApplicationViewModel applicationViewModel)
    {
      _navigationService = navigationService;
      _applicationViewModel = applicationViewModel;
    }
  }
}
