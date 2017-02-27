using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using GalaSoft.MvvmLight.Views;

namespace Wallet.Shared {
  public class CategorySelectionViewModel : WalletBaseViewModel, ICategorySelectionViewModel, IDisposable {

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

    public ObservableCollection<object> Categories { get; private set; }

    public CategorySelectionViewModel(INavigationService navigationService,
                                      IApplicationViewModel applicationViewModel,
                                      ICategoriesRepository categoriesRepository) 
      : base(navigationService, applicationViewModel) {
      _categoriesRepository = categoriesRepository;
      Categories = new ObservableCollection<object>(_categoriesRepository.Items);
      _categoriesRepository.OnItemsInserted += ItemsInserted;
    }

    void ItemsInserted(object sender, int[] e) {
      Categories.Add(_categoriesRepository.Items[e[0]]);
    }

    public async Task AddCategory(Category category) {
      await _categoriesRepository.Add(category);
    }

    public void Dispose() {
      _categoriesRepository.OnItemsInserted -= ItemsInserted;
    }
  }
}
