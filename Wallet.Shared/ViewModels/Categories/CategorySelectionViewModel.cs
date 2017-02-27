using System;
using System.Collections.Generic;
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

    public CategorySelectionViewModel(INavigationService navigationService,
                                      IApplicationViewModel applicationViewModel,
                                      ICategoriesRepository categoriesRepository) 
      : base(navigationService, applicationViewModel) {
      _categoriesRepository = categoriesRepository;
    }
  }
}
