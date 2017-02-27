using Microsoft.Practices.Unity;

namespace Wallet.Shared
{
  public class CoreLocator
  {
    public CoreLocator(IUnityContainer container)
    {
      container.RegisterType<IAccountsRepository, AccountsRepository>(new ContainerControlledLifetimeManager());
      container.RegisterType<ICategoriesRepository, CategoriesRepository>(new ContainerControlledLifetimeManager());
      container.RegisterType<ITransactionsRepository, TransactionsRepository>(new ContainerControlledLifetimeManager());

      container.RegisterType<ISummaryViewModel, SummaryViewModel>();
      container.RegisterType<IAddRecordViewModel, AddRecordViewModel>();
      container.RegisterType<IApplicationViewModel, ApplicationViewModel>();
      container.RegisterType<IAccountsSelectionViewModel, AccountsSelectionViewModel>();
      container.RegisterType<ICategorySelectionViewModel, CategorySelectionViewModel>();
    }
  }
}
