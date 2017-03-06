using System.Linq;
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
      TransactionsTableView.Source = _viewModel.Transactions.GetTableViewSource(BindTransactionCell, RecordTableViewCell.Key, () => new TableViewSourceExtension<WalletTransaction>(TransactionSelected));
    }

    private void BindTransactionCell(UITableViewCell cell, WalletTransaction transaction, NSIndexPath indexPath) {
      var transactionCell = cell as RecordTableViewCell;
      transactionCell?.ConfigureFor(transaction);
    }

    private void TransactionSelected(object item) {
      var transactions = _viewModel.Transactions.ToList();
      // ReSharper disable once PossibleNullReferenceException
      var transaction = transactions.First(t => t.Id.Equals((item as WalletTransaction).Id));
      var index = transactions.IndexOf(transaction);
      var indexPath = NSIndexPath.FromRowSection(index, 0);
      _viewModel.SelectTransactionAction.Execute(transaction.Id);
      TransactionsTableView.DeselectRow(indexPath, true);
    }
  }
}

