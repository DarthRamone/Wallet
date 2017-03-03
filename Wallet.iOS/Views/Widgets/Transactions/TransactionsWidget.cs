using System;
using System.Linq;
using Foundation;
using GalaSoft.MvvmLight.Helpers;
using UIKit;
using Wallet.Shared.Models;
using Wallet.Shared.ViewModels;
using Wallet.Shared.ViewModels.TransactionsWidget;

namespace Wallet.iOS {
  public partial class TransactionsWidget : UICollectionViewCell {

    private ITransactionsWidgetViewModel _viewModel;

    public static readonly NSString Key = new NSString("TransactionsWidget");
    public static readonly UINib Nib;
    
    static TransactionsWidget() {
      Nib = UINib.FromName("TransactionsWidget", NSBundle.MainBundle);
    }

    protected TransactionsWidget(IntPtr handle) : base(handle) {
      // Note: this .ctor should not contain any initialization logic.
    }

    public void Configure(ITransactionsWidgetViewModel viewModel) {

      _viewModel = viewModel;

      TitleLabel.Text = "Transactions";
      TransactionsTableView.RegisterNibForCellReuse(RecordTableViewCell.Nib, RecordTableViewCell.Key);
      TransactionsTableView.Source = _viewModel.Transactions.GetTableViewSource(BindTransactionCell, RecordTableViewCell.Key, () => new TableViewSourceExtension<WalletTransaction>(TransactionSelected));
    }

    private void BindTransactionCell(UITableViewCell cell, WalletTransaction transaction, NSIndexPath indexPath) {
      var transactionCell = cell as RecordTableViewCell;
      transactionCell.ConfigureFor(transaction);
    }

    private void TransactionSelected(object item) {
      var transactions = _viewModel.Transactions.ToList();
      var transaction = transactions.First(t => t.Id.Equals((item as WalletTransaction).Id));
      var index = transactions.IndexOf(transaction);
      var indexPath = NSIndexPath.FromRowSection(index, 0);
      TransactionsTableView.DeselectRow(indexPath, true);
    }
  }
}
