using System;
using GalaSoft.MvvmLight.Helpers;
using Microsoft.Practices.ServiceLocation;
using UIKit;
using Wallet.Shared;

namespace Wallet {
  public partial class AccountCreationViewController : WalletBaseViewController {

    public IAccountCreationViewModel _viewModel;

    public AccountCreationViewController() : base("AccountCreationViewController") {
      _viewModel = ServiceLocator.Current.GetInstance<IAccountCreationViewModel>();
    }

    public override void ViewDidLoad() {
      base.ViewDidLoad();
      _bindings.Add(this.SetBinding(() => _viewModel.AccountNameText, () => AccountNameTextField.Text, BindingMode.TwoWay));
      _bindings.Add(this.SetBinding(() => _viewModel.BalanceText, () => BalanceTextField.Text, BindingMode.TwoWay));
      _bindings.Add(this.SetBinding(() => _viewModel.CurrencyText, () => CurrencyTextField.Text, BindingMode.TwoWay));
      //_bindings.Add(this.SetBinding(() => _viewModel.IsCash, () => IsCashSwitch.On, BindingMode.TwoWay));
      CreateButton.SetCommand(_viewModel.CreateButtonAction);
      //CreateButton.TouchUpInside += (sender, e) => {
      //  _viewModel.CreateButtonAction.Execute(null);
      //};
      // Perform any additional setup after loading the view, typically from a nib.
    }

    public override void DidReceiveMemoryWarning() {
      base.DidReceiveMemoryWarning();
      // Release any cached data, images, etc that aren't in use.
    }
  }
}

