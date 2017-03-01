using GalaSoft.MvvmLight.Helpers;
using Microsoft.Practices.ServiceLocation;
using Wallet.Shared.ViewModels;

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
    }
  }
}

