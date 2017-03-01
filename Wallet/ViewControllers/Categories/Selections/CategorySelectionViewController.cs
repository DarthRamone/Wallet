using Foundation;
using GalaSoft.MvvmLight.Helpers;
using Microsoft.Practices.ServiceLocation;
using UIKit;
using Wallet.Shared;

namespace Wallet {
  public partial class CategorySelectionViewController : WalletBaseViewController {
    
    private readonly IAddRecordViewModel _addRecordViewModel;
    private readonly ICategorySelectionViewModel _viewModel;

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
      AddCategoriesButton.SetCommand(_viewModel.AddCategoryAction);
    }

    void BindCell(UITableViewCell cell, object model, NSIndexPath indexPath) {
      var categoryCell = cell as CategoryTableViewCell;
      var category = model as Category;
      categoryCell.TextLabel.Text = category.Name;
    }

    void CategorySelected(object item) {
      _viewModel.SelectedCategory = item as Category;
      _addRecordViewModel.RightButtonText = (item as Category).Name;
    }
  }
}

