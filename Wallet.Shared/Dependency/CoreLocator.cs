using Microsoft.Practices.Unity;
using Wallet.Shared.Repositories;
using Wallet.Shared.ViewModels;

namespace Wallet.Shared
{
  public class CoreLocator {

    protected readonly IUnityContainer UnityContainer;

    public CoreLocator(IUnityContainer container) {
      UnityContainer = container;
    }

    public void RegisterTypes() {
      UnityContainer.RegisterType<IAccountsRepository, AccountsRepository>(new ContainerControlledLifetimeManager());
      UnityContainer.RegisterType<ICategoriesRepository, CategoriesRepository>(new ContainerControlledLifetimeManager());
      UnityContainer.RegisterType<ITransactionsRepository, TransactionsRepository>(new ContainerControlledLifetimeManager());

      UnityContainer.RegisterType<ISummaryViewModel, SummaryViewModel>();
      UnityContainer.RegisterType<IAddRecordViewModel, AddRecordViewModel>();
      UnityContainer.RegisterType<IAccountsWidgetViewModel, AccountsWidgetViewModel>();
      UnityContainer.RegisterType<IAccountCreationViewModel, AccountCreationViewModel>();
      UnityContainer.RegisterType<ICategoryCreationViewModel, CategoryCreationViewModel>();
      UnityContainer.RegisterType<IAccountsSelectionViewModel, AccountsSelectionViewModel>();
      UnityContainer.RegisterType<ICategorySelectionViewModel, CategorySelectionViewModel>();
      UnityContainer.RegisterType<IAccountTransactionsViewModel, AccountTransactionsViewModel>();
    }
  }
}
