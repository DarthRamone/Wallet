using Microsoft.Practices.Unity;

namespace Wallet.Shared
{
  public class CoreLocator
  {
    public CoreLocator(IUnityContainer container)
    {
      container.RegisterType<ISummaryViewModel, SummaryViewModel>();
      container.RegisterType<IAccountsRepository, AccountsRepository>();
      container.RegisterType<IAddRecordViewModel, AddRecordViewModel>();
      container.RegisterType<ICategoriesRepository, CategoriesRepository>();
      container.RegisterType<IApplicationViewModel, ApplicationViewModel>();
      container.RegisterType<ITransactionsRepository, TransactionsRepository>();
    }
  }
}
