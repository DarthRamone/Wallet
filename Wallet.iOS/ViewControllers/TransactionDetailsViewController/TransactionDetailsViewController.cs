using GalaSoft.MvvmLight.Helpers;
using Microsoft.Practices.ServiceLocation;
using UIKit;
using Wallet.Shared.ViewModels.TransactionDetails;

namespace Wallet.iOS {
  public partial class TransactionDetailsViewController : WalletBaseViewController {

    private readonly ITransactionDetailsViewModel _viewModel;

    private string _firstItemButtonText;
    public string FirstItemButtonText {
      get { return _firstItemButtonText; }
      set {
        _firstItemButtonText = value;
        FirstItemButton.SetTitle(_firstItemButtonText, UIControlState.Normal);
      }
    }

    private string _secondItemButtonText;
    public string SecondItemButtonText {
      get { return _secondItemButtonText; }
      set {
        _secondItemButtonText = value;
        SecondButtonItem.SetTitle(_secondItemButtonText, UIControlState.Normal);
      }
    }


    public TransactionDetailsViewController(string transactionId) : base("TransactionDetailsViewController") {
      _viewModel = ServiceLocator.Current.GetInstance<ITransactionDetailsViewModel>();
      _viewModel.SetTransaction(transactionId);
    }

    public override void ViewDidLoad() {
      base.ViewDidLoad();

      _bindings.Add(this.SetBinding(() => _viewModel.AmountLabelText, () => AmountTextField.Text, BindingMode.TwoWay));
      _bindings.Add(this.SetBinding(() => _viewModel.FirstItemLabelText, () => FirstItemLabel.Text));
      _bindings.Add(this.SetBinding(() => _viewModel.FirstItemButtonText, () => FirstItemButtonText));
      _bindings.Add(this.SetBinding(() => _viewModel.SecondItemLabelText, () => SecondItemLabel.Text));
      _bindings.Add(this.SetBinding(() => _viewModel.SecondItemButtonText, () => SecondItemButtonText));

      DeleteButton.SetCommand(_viewModel.DeleteTransactionAction);
    }
  }
}

