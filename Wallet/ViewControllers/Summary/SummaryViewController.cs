using CoreGraphics;
using Foundation;
using GalaSoft.MvvmLight.Helpers;
using Microsoft.Practices.ServiceLocation;
using UIKit;
using Wallet.Shared;

namespace Wallet {
  public partial class SummaryViewController : WalletBaseViewController {

    private ISummaryViewModel _viewModel;

    private ObservableCollectionViewSource<object, AccountCollectionViewCell> _source;

    public SummaryViewController() : base("OverviewViewController") {
      _viewModel = ServiceLocator.Current.GetInstance<ISummaryViewModel>();
    }

    public override void ViewDidLoad() {
      base.ViewDidLoad();

      AddRecordButton.SetCommand(_viewModel.AddRecordButtonAction);

      // CollectionView
      AccountsCollectionView.RegisterNibForCell(AccountCollectionViewCell.Nib, AccountCollectionViewCell.Key);
      _source = _viewModel.Accounts.GetCollectionViewSource(BindAccountCell,
                                                  factory: () => new CollectionViewSourceExtension<object, AccountCollectionViewCell>(AccountCollectionViewCell.Key, AccountSelected));
      AccountsCollectionView.Source = _source;
      _viewModel.Accounts.CollectionChanged += CollectionChanged;

      // TableView
      TransactionsTableView.RegisterNibForCellReuse(RecordTableViewCell.Nib, RecordTableViewCell.Key);
      TransactionsTableView.Source = _viewModel.Transactions.GetTableViewSource(BindTransactionCell, RecordTableViewCell.Key, () => new TableViewSourceExtension<object>(null));

      AccountCollectionViewHeightConstraint = NSLayoutConstraint.Create(AccountsCollectionView, NSLayoutAttribute.Height, NSLayoutRelation.Equal, 1, 70);
      View.AddConstraint(AccountCollectionViewHeightConstraint);
    }

    public override void ViewWillAppear(bool animated) {
      base.ViewWillAppear(animated);
      var inset = AccountsCollectionViewFlowLayout.SectionInset;
      var cellSize = new CGSize((View.Frame.Width - inset.Top * 4) / 3, 50);
      AccountsCollectionViewFlowLayout.ItemSize = cellSize;
      SetCollectionViewHeight();
    }

    #region TableView

    void BindTransactionCell(UITableViewCell cell, object model, NSIndexPath indexPath) {
      var transactionCell = cell as RecordTableViewCell;
      var transaction = model as WalletTransaction;
      transactionCell.CategoryNameLabel.Text = transaction.Category.Name;
      transactionCell.AmountLabel.Text = transaction.Amount.ToString();
      transactionCell.DateLabel.Text = transaction.Date.Date.ToString("d");
      transactionCell.AccountNameLabel.Text = transaction.Account.Name;
    }

    #endregion

    #region CollectionView

    void BindAccountCell(AccountCollectionViewCell cell, object model, NSIndexPath indexPath) {
      var account = model as Account;
      cell.AccountNameLabel.Text = account.Name;
    }

    void AccountSelected(object account) {
    }

    void CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) {
      SetCollectionViewHeight();
    }

    #endregion

    void SetCollectionViewHeight() {
      var count = _viewModel.Accounts.Count;
      var insets = AccountsCollectionViewFlowLayout.SectionInset;
      var cellHeight = AccountsCollectionViewFlowLayout.ItemSize.Height;

      var rowsCount = count / 3;
      if (count % 3 != 0) rowsCount++;

      var height = (rowsCount * cellHeight) + ((rowsCount + 1) * insets.Top);

      AccountCollectionViewHeightConstraint.Constant = height;

      UIView.Animate(0.2, View.LayoutSubviews);
    }
  }
}

