using GalaSoft.MvvmLight.Views;

namespace Wallet.Shared
{
  public class AddRecordViewModel : WalletBaseViewModel, IAddRecordViewModel
  {
    public AddRecordViewModel(INavigationService navService,
                              IApplicationViewModel appViewModel)
      : base(navService, appViewModel)
    {
    }
  }
}
