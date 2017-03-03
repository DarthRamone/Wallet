using GalaSoft.MvvmLight.Command;

namespace Wallet.Shared.ViewModels.CategoryCreation {

  public interface ICategoryCreationViewModel {

    string CateggoryNameText { get; set; }

    RelayCommand CreateCategoryAction { get; }

  }

}