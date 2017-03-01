using Microsoft.Practices.Unity;
using Realms.Sync;
using Wallet.Shared.Repositories;
using Wallet.Shared.ViewModels;

namespace Wallet.Shared
{
  public class CoreLocator
  {
    public CoreLocator(IUnityContainer container, SyncConfiguration configuration)
    {
      //var accountsRepository

      container.RegisterType<IAccountsRepository, AccountsRepository>(new ContainerControlledLifetimeManager());
      container.RegisterType<ICategoriesRepository, CategoriesRepository>(new ContainerControlledLifetimeManager());
      container.RegisterType<ITransactionsRepository, TransactionsRepository>(new ContainerControlledLifetimeManager());

      container.RegisterType<ISummaryViewModel, SummaryViewModel>();
      container.RegisterType<IAddRecordViewModel, AddRecordViewModel>();
      container.RegisterType<IApplicationViewModel, ApplicationViewModel>();
      container.RegisterType<IAccountCreationViewModel, AccountCreationViewModel>();
      container.RegisterType<ICategoryCreationViewModel, CategoryCreationViewModel>();
      container.RegisterType<IAccountsSelectionViewModel, AccountsSelectionViewModel>();
      container.RegisterType<ICategorySelectionViewModel, CategorySelectionViewModel>();
      container.RegisterType<IAccountTransactionsViewModel, AccountTransactionsViewModel>();
    }
  }
}
