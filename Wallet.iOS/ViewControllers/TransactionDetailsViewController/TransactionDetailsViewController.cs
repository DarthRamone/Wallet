using GalaSoft.MvvmLight.Helpers;
using Microsoft.Practices.ServiceLocation;
using UIKit;
using Wallet.Shared.ViewModels.TransactionDetails;

namespace Wallet.iOS {
  public partial class TransactionDetailsViewController : UIViewController {

    private readonly ITransactionDetailsViewModel _viewModel;

    public TransactionDetailsViewController(string transactionId) : base("TransactionDetailsViewController", null) {
      _viewModel = ServiceLocator.Current.GetInstance<ITransactionDetailsViewModel>();
      _viewModel.SetTransaction(transactionId);
    }

    public override void ViewDidLoad() {
      base.ViewDidLoad();
      DeleteButton.SetCommand(_viewModel.DeleteTransactionAction);
    }
  }
}

