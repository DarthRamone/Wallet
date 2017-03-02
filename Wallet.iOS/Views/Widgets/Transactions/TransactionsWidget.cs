using System;

using Foundation;
using GalaSoft.MvvmLight.Helpers;
using UIKit;
using Wallet.Shared.Models;
using Wallet.Shared.ViewModels;

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

      TransactionsTableView.RegisterNibForCellReuse(RecordTableViewCell.Nib, RecordTableViewCell.Key);
      TransactionsTableView.Source = _viewModel.Transactions.GetTableViewSource(BindTransactionCell, RecordTableViewCell.Key, () => new TableViewSourceExtension<WalletTransaction>(null));
    }

    private void BindTransactionCell(UITableViewCell cell, WalletTransaction transaction, NSIndexPath indexPath) {
      var transactionCell = cell as RecordTableViewCell;
      transactionCell.ConfigureFor(transaction);
    }
  }
}
