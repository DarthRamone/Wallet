using GalaSoft.MvvmLight.Helpers;
using Microsoft.Practices.ServiceLocation;
using Wallet.Shared.ViewModels;

namespace Wallet.iOS {

  public partial class CategoryCreationViewController : WalletBaseViewController {

    private readonly ICategoryCreationViewModel _viewModel;

    public CategoryCreationViewController() : base("CategoryCreationViewController") {
      _viewModel = ServiceLocator.Current.GetInstance<ICategoryCreationViewModel>();
    }

    public override void ViewDidLoad() {
      base.ViewDidLoad();
      _bindings.Add(this.SetBinding(() => _viewModel.CateggoryNameText, () => CategoryNameTextField.Text, BindingMode.TwoWay));
      CategoryCreationButton.SetCommand(_viewModel.CreateCategoryAction);
    }
  }
}

