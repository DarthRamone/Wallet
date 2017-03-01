using System.Collections.ObjectModel;
using GalaSoft.MvvmLight.Command;

namespace Wallet.Shared {

  public interface ICategorySelectionViewModel {

    Category SelectedCategory { get; set; }

    ObservableCollection<Category> Categories { get; }

    RelayCommand AddCategoryAction { get; }

  }
}
