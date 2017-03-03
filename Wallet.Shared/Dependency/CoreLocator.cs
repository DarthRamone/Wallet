using Microsoft.Practices.Unity;
using Wallet.Shared.Repositories;
using Wallet.Shared.Repositories.Accounts;
using Wallet.Shared.Repositories.Categories;
using Wallet.Shared.Repositories.Transactions;
using Wallet.Shared.ViewModels;
using Wallet.Shared.ViewModels.AccountCreation;
using Wallet.Shared.ViewModels.AccountsWidget;
using Wallet.Shared.ViewModels.AccountSelection;
using Wallet.Shared.ViewModels.AddRecord;
using Wallet.Shared.ViewModels.CategoryCreation;
using Wallet.Shared.ViewModels.CategorySelection;
using Wallet.Shared.ViewModels.Summary;
using Wallet.Shared.ViewModels.TransactionsWidget;

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
      UnityContainer.RegisterType<ITransactionsWidgetViewModel, TransactionsWidgetViewModel>();
      UnityContainer.RegisterType<IAccountTransactionsViewModel, AccountTransactionsViewModel>();
    }
  }
}
