using System;
using Foundation;
using Microsoft.Practices.ServiceLocation;
using UIKit;
using Wallet.Shared;

namespace Wallet {
  public partial class CategorySelectionViewController : WalletBaseViewController, IUITableViewDelegate, IUITableViewDataSource {
    
    private IAddRecordViewModel _addRecordViewModel;
    private ICategorySelectionViewModel _viewModel;

    public CategorySelectionViewController(AddRecordViewModel addRecordViewModel) : base("CategoriesSelectionViewController") {
      _addRecordViewModel = addRecordViewModel;
      _viewModel = ServiceLocator.Current.GetInstance<ICategorySelectionViewModel>();
    }

    public override void ViewDidLoad() {
      base.ViewDidLoad();

      _viewModel.OnItemsInserted += (sender, e) => {
        //TODO: Reload rows instead of whole data
        CategoriesTableView.ReloadData();
      };

      //TODO: move to viewModel
      AddCategoriesButton.TouchUpInside += (sender, e) => {
        var popup = UIAlertController.Create("Category creation", "Enter category name", UIAlertControllerStyle.Alert);
        popup.AddTextField((UITextField obj) => { });
        var button = UIAlertAction.Create("Create", UIAlertActionStyle.Cancel, alertAction => {
          var category = new Category { Name = popup.TextFields[0].Text };
          _viewModel.AddCategory(category);
        });
        popup.AddAction(button);
        PresentViewController(popup, true, () => { });
      };
      // Perform any additional setup after loading the view, typically from a nib.
    }

    public override void DidReceiveMemoryWarning() {
      base.DidReceiveMemoryWarning();
      // Release any cached data, images, etc that aren't in use.
    }

    #region TableView

    public nint RowsInSection(UITableView tableView, nint section) => _viewModel.Categories.Count;

    public nint NumberOfSections(UITableView tableView) => 1;

    public UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath) {
      var account = _viewModel.Categories[indexPath.Row];
      var cell = new UITableViewCell(); //TODO
      cell.TextLabel.Text = account.Name;
      return cell;
    }

    [Export("tableView:didSelectRowAtIndexPath:")]
    public void RowSelected(UITableView tableView, NSIndexPath indexPath) {
      _viewModel.SelectedCategory = _viewModel.Categories[indexPath.Row];
      _addRecordViewModel.SelectedCategory = _viewModel.Categories[indexPath.Row];
    }

    #endregion
  }
}

