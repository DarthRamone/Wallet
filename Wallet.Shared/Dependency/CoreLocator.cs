using GalaSoft.MvvmLight.Ioc;

namespace Wallet.Shared
{
  public class CoreLocator
  {
    public CoreLocator()
    {
      SimpleIoc.Default.Register<IAccountsRepository, AccountsRepository>();
      SimpleIoc.Default.Register<ICategoriesRepository, CategoriesRepository>();
      SimpleIoc.Default.Register<ITransactionsRepository, TransactionsRepository>();
      SimpleIoc.Default.Register<ISummaryViewModel, SummaryViewModel>();
      SimpleIoc.Default.Register<IAddRecordViewModel, AddRecordViewModel>();
    }
  }
}
