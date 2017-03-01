using Foundation;
using GalaSoft.MvvmLight.Helpers;
using Microsoft.Practices.ServiceLocation;
using UIKit;
using Wallet.Shared.Models;
using Wallet.Shared.ViewModels;

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
                                                                            () => new TableViewSourceExtension<Category>(CategorySelected));
      AddCategoriesButton.SetCommand(_viewModel.AddCategoryAction);
    }

    private void BindCell(UITableViewCell cell, Category category, NSIndexPath indexPath) {
      var categoryCell = cell as CategoryTableViewCell;
      categoryCell.TextLabel.Text = category.Name;
    }

    private void CategorySelected(object item) {
      _viewModel.SelectedCategory = item as Category;
      _addRecordViewModel.RightButtonText = (item as Category).Name;
    }
  }
}

