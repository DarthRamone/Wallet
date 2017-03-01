using GalaSoft.MvvmLight.Command;

namespace Wallet.Shared.ViewModels.Categories.Creation {

  public interface ICategoryCreationViewModel {

    string CateggoryNameText { get; set; }

    RelayCommand CreateCategoryAction { get; }

  }

}