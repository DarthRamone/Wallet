using Foundation;
using GalaSoft.MvvmLight.Helpers;
using Microsoft.Practices.ServiceLocation;
using UIKit;
using Wallet.Shared.Models;
using Wallet.Shared.ViewModels;

namespace Wallet.iOS {
  
  public partial class AccountTransactionsViewController : WalletBaseViewController {

    private readonly Account _account;

    private readonly IAccountTransactionsViewModel _viewModel;

    public AccountTransactionsViewController(Account account) : base("AccountTransactionsViewController") {
      _account = account;
      _viewModel = ServiceLocator.Current.GetInstance<IAccountTransactionsViewModel>();
    }

    public override void ViewDidLoad() {
      base.ViewDidLoad();
      TransactionsTableView.RegisterNibForCellReuse(RecordTableViewCell.Nib, RecordTableViewCell.Key);
      TransactionsTableView.Source = _viewModel.Transactions.GetTableViewSource(BindTransactionCell, RecordTableViewCell.Key, () => new TableViewSourceExtension<WalletTransaction>(null));
      _viewModel.InitializeWithAccount(_account);
    }

    #region TableView

    private void BindTransactionCell(UITableViewCell cell, WalletTransaction transaction, NSIndexPath indexPath) {
      var transactionCell = cell as RecordTableViewCell;
      transactionCell?.ConfigureFor(transaction);
    }

    #endregion
  }
}

