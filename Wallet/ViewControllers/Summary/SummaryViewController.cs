using Foundation;
using GalaSoft.MvvmLight.Helpers;
using Microsoft.Practices.ServiceLocation;
using UIKit;
using Wallet.Shared;

namespace Wallet
{
  public partial class SummaryViewController : WalletBaseViewController {
    
    private ISummaryViewModel _viewModel;

    public SummaryViewController() : base("OverviewViewController") {
      _viewModel = ServiceLocator.Current.GetInstance<ISummaryViewModel>();
    }

    public override void ViewDidLoad() {
      base.ViewDidLoad();
      AddRecordButton.SetCommand(_viewModel.AddRecordButtonAction);

      TransactionsTableView.RegisterNibForCellReuse(RecordTableViewCell.Nib, RecordTableViewCell.Key);
      TransactionsTableView.Source = _viewModel.Transactions.GetTableViewSource(BindCell, RecordTableViewCell.Key, () => new TableViewSourceExtension<object>(null));
    }

    void BindCell(UITableViewCell cell, object model, NSIndexPath indexPath) {
      var transactionCell = cell as RecordTableViewCell;
      var transaction = model as WalletTransaction;
      transactionCell.CategoryNameLabel.Text = transaction.Category.Name;
      transactionCell.AmountLabel.Text = transaction.Amount.ToString();
      transactionCell.DateLabel.Text = transaction.Date.Date.ToString("d");
      transactionCell.AccountNameLabel.Text = transaction.Account.Name;
    }

  }
}

