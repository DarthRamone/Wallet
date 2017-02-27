using System;
using Foundation;
using Microsoft.Practices.ServiceLocation;
using UIKit;
using Wallet.Shared;

namespace Wallet {
  public partial class AccountSelectionViewController : WalletBaseViewController, IUITableViewDelegate, IUITableViewDataSource {

    private IAccountsSelectionViewModel _viewModel;

    public AccountSelectionViewController() : base("AccountSelectionViewController") {
      _viewModel = ServiceLocator.Current.GetInstance<IAccountsSelectionViewModel>();
    }

    public override void ViewDidLoad() {
      base.ViewDidLoad();
    }

    public override void DidReceiveMemoryWarning() {
      base.DidReceiveMemoryWarning();
      // Release any cached data, images, etc that aren't in use.
    }

    #region TableView

    public nint RowsInSection(UITableView tableView, nint section) => _viewModel.Accounts.Count;

    public nint NumberOfSections(UITableView tableView) => 1;

    public UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath) {
      var account = _viewModel.Accounts[indexPath.Row];
      var cell = new UITableViewCell(); //TODO
      cell.TextLabel.Text = account.Name;
      return cell;
    }

    [Export("tableView:didSelectRowAtIndexPath:")]
    public void RowSelected(UITableView tableView, NSIndexPath indexPath) {
      _viewModel.AccountSelected.Execute(_viewModel.Accounts[indexPath.Row]);
    }

    #endregion
  }
}

