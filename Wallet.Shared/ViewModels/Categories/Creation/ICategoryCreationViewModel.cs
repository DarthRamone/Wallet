using GalaSoft.MvvmLight.Command;

namespace Wallet.Shared.ViewModels {

  public interface ICategoryCreationViewModel {

    string CateggoryNameText { get; set; }

    RelayCommand CreateCategoryAction { get; }

  }

}