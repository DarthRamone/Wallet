using System;
using System.Collections.ObjectModel;
using System.Linq;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;

namespace Wallet.Shared {
  public class CategorySelectionViewModel : WalletBaseViewModel, ICategorySelectionViewModel, IDisposable {

    private readonly ICategoriesRepository _categoriesRepository;

    private Category _selectedCategory;
    public Category SelectedCategory { 
      get { return _selectedCategory; }
      set {
        _selectedCategory = value;
        RaisePropertyChanged(() => SelectedCategory);
        _navigationService.GoBack();
      }
    }

    public RelayCommand AddCategoryAction { get; private set; }

    public ObservableCollection<object> Categories { get; }

    public CategorySelectionViewModel(INavigationService navigationService,
                                      IApplicationViewModel applicationViewModel,
                                      ICategoriesRepository categoriesRepository) 
      : base(navigationService, applicationViewModel) {

      _categoriesRepository = categoriesRepository;

      Categories = new ObservableCollection<object>(_categoriesRepository.Items);

      _categoriesRepository.OnItemsInserted += ItemsInserted;

      SetCommands();
    }

    private void SetCommands() {
      AddCategoryAction = new RelayCommand(() => {
        _navigationService.NavigateTo(_applicationViewModel.CategoryCreationViewControllerKey);
      }, () => true);
    }

    private void ItemsInserted(object sender, int[] e) {
      var items = e.Select(index => _categoriesRepository.Items[index]);
      foreach (var item in items) {
        Categories.Add(item);
      }
    }

    public void Dispose() {
      _categoriesRepository.OnItemsInserted -= ItemsInserted;
    }

  }
}
