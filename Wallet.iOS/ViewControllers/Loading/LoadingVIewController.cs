using System;
using GalaSoft.MvvmLight.Views;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;
using Realms.Sync;
using Wallet.Shared.ViewModels;

namespace Wallet.iOS {
  public partial class LoadingVIewController : WalletBaseViewController {

    private iOSLocator Locator;

    public LoadingVIewController() : base("LoadingVIewController") {
    }

    public override async void ViewDidAppear(bool animated) {

      base.ViewDidAppear(animated);

      var unityContainer = ServiceLocator.Current.GetInstance<IUnityContainer>();
      var navigationService = ServiceLocator.Current.GetInstance<INavigationService>() as NavigationService;

      var credentials = Credentials.UsernamePassword("test@test.com", "test", false);
      var authUri = new Uri("http://localhost:9080");
      var user = await User.LoginAsync(credentials, authUri);
      var serverUri = new Uri("realm://localhost:9080/~/default");
      var configuration = new SyncConfiguration(user, serverUri);

      Locator = new iOSLocator(unityContainer, configuration);

      var applicationViewModel = ServiceLocator.Current.GetInstance<IApplicationViewModel>();

      navigationService?.Configure(applicationViewModel.LoadingViewControllerKey, typeof(LoadingVIewController));
      navigationService?.Configure(applicationViewModel.SummaryViewControllerKey, typeof(SummaryViewController));
      navigationService?.Configure(applicationViewModel.AddRecordViewControllerKey, typeof(AddRecordViewController));
      navigationService?.Configure(applicationViewModel.AccountCreationViewControllerKey, typeof(AccountCreationViewController));
      navigationService?.Configure(applicationViewModel.CategoryCreationViewControllerKey, typeof(CategoryCreationViewController));
      navigationService?.Configure(applicationViewModel.AccountSelectionViewControllerKey, typeof(AccountSelectionViewController));
      navigationService?.Configure(applicationViewModel.CategorySelectionViewControllerKey, typeof(CategorySelectionViewController));
      navigationService?.Configure(applicationViewModel.AccountTransactionsViewControllerKey, typeof(AccountTransactionsViewController));

      navigationService.NavigateTo(applicationViewModel.SummaryViewControllerKey);
    }

  }
}

