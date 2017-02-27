using GalaSoft.MvvmLight.Helpers;
using Microsoft.Practices.ServiceLocation;
using UIKit;
using Wallet.Shared;

namespace Wallet
{
  public partial class AddRecordViewController : WalletBaseViewController
  {
    IAddRecordViewModel _viewModel;

    public AddRecordViewController() : base("AddRecordViewController")
    {
      _viewModel = ServiceLocator.Current.GetInstance<IAddRecordViewModel>();
    }

    public override void ViewDidLoad()
    {
      base.ViewDidLoad();
      AddRecordButton.SetCommand(_viewModel.AddRecordAction);
      Button0.SetCommand(_viewModel.Button0Action);
      Button1.SetCommand(_viewModel.Button1Action);
      Button2.SetCommand(_viewModel.Button2Action);
      Button3.SetCommand(_viewModel.Button3Action);
      Button4.SetCommand(_viewModel.Button4Action);
      Button5.SetCommand(_viewModel.Button5Action);
      Button6.SetCommand(_viewModel.Button6Action);
      Button7.SetCommand(_viewModel.Button7Action);
      Button8.SetCommand(_viewModel.Button8Action);
      Button9.SetCommand(_viewModel.Button9Action);
      //CommaButton.SetCommand(_viewModel.CommaButtonAction);
      DeleteButton.SetCommand(_viewModel.DeleteButtonAction);

      _bindings.Add(this.SetBinding(() => _viewModel.AmountLabelText, () => AmountLabel.Text));
    }
  }
}

