using System.Collections.ObjectModel;
using GalaSoft.MvvmLight.Command;
using Wallet.Shared.Models;

namespace Wallet.Shared.ViewModels.CategorySelection {

  public interface ICategorySelectionViewModel : IWalletBaseViewModel {

    Category SelectedCategory { get; set; }

    ObservableCollection<Category> Categories { get; }

    RelayCommand AddCategoryAction { get; }

  }
}
