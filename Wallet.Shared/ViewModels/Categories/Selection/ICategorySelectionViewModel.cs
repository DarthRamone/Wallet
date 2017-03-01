using System.Collections.ObjectModel;
using GalaSoft.MvvmLight.Command;
using Wallet.Shared.Models;

namespace Wallet.Shared.ViewModels {

  public interface ICategorySelectionViewModel {

    Category SelectedCategory { get; set; }

    ObservableCollection<Category> Categories { get; }

    RelayCommand AddCategoryAction { get; }

  }
}
