using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GalaSoft.MvvmLight.Views;

namespace Wallet.Shared {
  public class CategorySelectionViewModel : WalletBaseViewModel, ICategorySelectionViewModel {

    private ICategoriesRepository _categoriesRepository;

    private Category _selectedCategory;
    public Category SelectedCategory { 
      get { return _selectedCategory; }
      set {
        _selectedCategory = value;
        RaisePropertyChanged(() => SelectedCategory);
        _navigationService.GoBack();
      }
    }

    public List<Category> Categories => _categoriesRepository.Items;

    public event EventHandler<int[]> OnItemsDeleted {
      add { _categoriesRepository.OnItemsDeleted += value; }
      remove { _categoriesRepository.OnItemsDeleted -= value; }
    }

    public event EventHandler<int[]> OnItemsInserted {
      add { _categoriesRepository.OnItemsInserted += value; }
      remove { _categoriesRepository.OnItemsInserted -= value; }
    }

    public event EventHandler<int[]> OnItemsModified {
      add { _categoriesRepository.OnItemsModified += value; }
      remove { _categoriesRepository.OnItemsModified -= value; }
    }

    public CategorySelectionViewModel(INavigationService navigationService,
                                      IApplicationViewModel applicationViewModel,
                                      ICategoriesRepository categoriesRepository) 
      : base(navigationService, applicationViewModel) {
      _categoriesRepository = categoriesRepository;
    }

    public async Task AddCategory(Category category) {
      await _categoriesRepository.Add(category);
    }
  }
}
