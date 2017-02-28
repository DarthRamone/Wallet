using Foundation;
using GalaSoft.MvvmLight.Helpers;
using Microsoft.Practices.ServiceLocation;
using UIKit;
using Wallet.Shared;

namespace Wallet {
  public partial class AccountSelectionViewController : WalletBaseViewController {

    private IAddRecordViewModel _addRecordViewModel;
    private IAccountsSelectionViewModel _viewModel;

    public AccountSelectionViewController(AddRecordViewModel addRecordViewModel) : base("AccountSelectionViewController") {
      _viewModel = ServiceLocator.Current.GetInstance<IAccountsSelectionViewModel>();
      _addRecordViewModel = addRecordViewModel;
    }

    public override void ViewDidLoad() {
      base.ViewDidLoad();

      AccountsTableView.RegisterNibForCellReuse(AccountTableViewCell.Nib, AccountTableViewCell.Key);
      AccountsTableView.Source = _viewModel.Accounts.GetTableViewSource(BindCell, AccountTableViewCell.Key, () => new TableViewSourceExtension<object>(AccountSelected));
      AddAccountButton.SetCommand(_viewModel.PlusButtonAction);
    }

    void BindCell(UITableViewCell cell, object model, NSIndexPath indexPath) {
      var accountCell = cell as AccountTableViewCell;
      var account = model as Account;
      accountCell.TextLabel.Text = account.Name;
    }

    void AccountSelected(object item) {
      
      var account = item as Account;

      _viewModel.SelectedAccount = account;

      if (_addRecordViewModel.TransactionType == TransactionType.TRANSFER) {
        if (_addRecordViewModel.IsRightButtonTapped)
          _addRecordViewModel.RightButtonText = account.Name;
        else
          _addRecordViewModel.LeftButtonText = account.Name;
      } else {
        _addRecordViewModel.LeftButtonText = account.Name;
      }

    }
  }
}

