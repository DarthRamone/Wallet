using GalaSoft.MvvmLight.Helpers;
using Microsoft.Practices.ServiceLocation;
using UIKit;
using Wallet.Shared;

namespace Wallet
{
  public partial class AddRecordViewController : WalletBaseViewController
  {
    const string catName = "test category";
    const string accName = "test account";

    IAddRecordViewModel _viewModel;

    public AddRecordViewController() : base("AddRecordViewController")
    {
      _viewModel = ServiceLocator.Current.GetInstance<IAddRecordViewModel>();
    }

    public override void ViewDidLoad()
    {
      base.ViewDidLoad();
      AddRecordButton.SetCommand(_viewModel.AddRecordAction);
    }

    public override void DidReceiveMemoryWarning()
    {
      base.DidReceiveMemoryWarning();
      // Release any cached data, images, etc that aren't in use.
    }
  }
}

