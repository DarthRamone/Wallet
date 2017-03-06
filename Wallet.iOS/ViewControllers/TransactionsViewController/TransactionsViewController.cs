using Foundation;
using GalaSoft.MvvmLight.Helpers;
using Microsoft.Practices.ServiceLocation;
using UIKit;
using Wallet.Shared.Models;
using Wallet.Shared.ViewModels.Transactions;

namespace Wallet.iOS {
  public partial class TransactionsViewController : WalletBaseViewController {

    private readonly ITransactionsViewModel _viewModel;

    public TransactionsViewController() : base("TransactionsViewController") {
      _viewModel = ServiceLocator.Current.GetInstance<ITransactionsViewModel>();
    }

    public override void ViewDidLoad() {
      base.ViewDidLoad();
      TransactionsTableView.RegisterNibForCellReuse(RecordTableViewCell.Nib, RecordTableViewCell.Key);
      TransactionsTableView.Source = _viewModel.Transactions.GetTableViewSource(BindTransactionCell, RecordTableViewCell.Key, () => new TableViewSourceExtension<WalletTransaction>(null));
    }

    #region TableView

    private void BindTransactionCell(UITableViewCell cell, WalletTransaction transaction, NSIndexPath indexPath) {
      var transactionCell = cell as RecordTableViewCell;
      transactionCell?.ConfigureFor(transaction);
    }

    #endregion
  }
}

