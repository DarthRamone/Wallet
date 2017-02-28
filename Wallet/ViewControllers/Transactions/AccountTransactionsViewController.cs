using Foundation;
using GalaSoft.MvvmLight.Helpers;
using Microsoft.Practices.ServiceLocation;
using UIKit;
using Wallet.Shared;

namespace Wallet {
  
  public partial class AccountTransactionsViewController : WalletBaseViewController {

    private Account _account;

    private IAccountTransactionsViewModel _viewModel;

    public AccountTransactionsViewController(Account account) : base("AccountTransactionsViewController") {
      _account = account;
      _viewModel = ServiceLocator.Current.GetInstance<IAccountTransactionsViewModel>();
    }

    public override void ViewDidLoad() {
      base.ViewDidLoad();
      TransactionsTableView.RegisterNibForCellReuse(RecordTableViewCell.Nib, RecordTableViewCell.Key);
      TransactionsTableView.Source = _viewModel.Transactions.GetTableViewSource(BindTransactionCell, RecordTableViewCell.Key, () => new TableViewSourceExtension<object>(null));
      _viewModel.InitializeWithAccount(_account);
    }

    #region TableView

    void BindTransactionCell(UITableViewCell cell, object model, NSIndexPath indexPath) {
      var transactionCell = cell as RecordTableViewCell;
      var transaction = model as WalletTransaction;
      transactionCell.ConfigureFor(transaction);
    }

    #endregion
  }
}

