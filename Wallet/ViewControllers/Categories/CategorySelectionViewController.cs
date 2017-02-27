using Foundation;
using GalaSoft.MvvmLight.Helpers;
using Microsoft.Practices.ServiceLocation;
using UIKit;
using Wallet.Shared;

namespace Wallet {
  public partial class CategorySelectionViewController : WalletBaseViewController {
    
    private IAddRecordViewModel _addRecordViewModel;
    private ICategorySelectionViewModel _viewModel;

    public CategorySelectionViewController(AddRecordViewModel addRecordViewModel) : base("CategoriesSelectionViewController") {
      _addRecordViewModel = addRecordViewModel;
      _viewModel = ServiceLocator.Current.GetInstance<ICategorySelectionViewModel>();
    }

    public override void ViewDidLoad() {
      base.ViewDidLoad();

      CategoriesTableView.RegisterNibForCellReuse(CategoryTableViewCell.Nib, CategoryTableViewCell.Key);
      CategoriesTableView.Source = _viewModel.Categories.GetTableViewSource(BindCell, 
                                                                            CategoryTableViewCell.Key, 
                                                                            () => new TableViewSourceExtension<object>(CategorySelected));

      //TODO: move to viewModel
      AddCategoriesButton.TouchUpInside += (sender, e) => {
        var popup = UIAlertController.Create("Category creation", "Enter category name", UIAlertControllerStyle.Alert);
        popup.AddTextField((UITextField obj) => { });
        var button = UIAlertAction.Create("Create", UIAlertActionStyle.Cancel, async alertAction => {
          var category = new Category { Name = popup.TextFields[0].Text };
          await _viewModel.AddCategory(category);
        });
        popup.AddAction(button);
        PresentViewController(popup, true, () => { });
      };
      // Perform any additional setup after loading the view, typically from a nib.
    }

    void BindCell(UITableViewCell cell, object model, NSIndexPath indexPath) {
      var categoryCell = cell as CategoryTableViewCell;
      var category = model as Category;
      categoryCell.TextLabel.Text = category.Name;
    }

    void CategorySelected(object item) {
      _viewModel.SelectedCategory = item as Category;
      _addRecordViewModel.SelectedCategory = item as Category;
    }
  }
}

