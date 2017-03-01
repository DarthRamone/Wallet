using System;
using System.Threading.Tasks;
using GalaSoft.MvvmLight.Views;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;
using Realms.Sync;
using UIKit;
using Wallet.Shared.ViewModels;

namespace Wallet.iOS {
  
  public partial class LoadingVIewController : WalletBaseViewController {

    private iOSLocator Locator;

    public LoadingVIewController() : base("LoadingVIewController") {
    }

    public override void ViewDidLoad() {
      base.ViewDidLoad();

      LoadingView.Hidden = true;

      CreateAccountButton.TouchUpInside += async (sender, args) => {
        await Login(LoginTextField.Text, PasswordTextField.Text, true);
      };
      LoginButton.TouchUpInside += async (sender, args) => {
        await Login(LoginTextField.Text, PasswordTextField.Text,false);
      };
    }

    private async Task Login(string login, string password, bool newUser) {

      //TODO: try to move it to Shared logic

      LoadingView.Hidden = false;
      View.BringSubviewToFront(LoadingView);
      LoadingView.StartAnimating();

      try {
        var unityContainer = ServiceLocator.Current.GetInstance<IUnityContainer>();
        var navigationService = ServiceLocator.Current.GetInstance<INavigationService>() as NavigationService;

        var credentials = Credentials.UsernamePassword(login, password, newUser);
        var authUri = new Uri("http://188.166.69.22:9080");
        var user = await User.LoginAsync(credentials, authUri);
        var serverUri = new Uri("realm://188.166.69.22:9080/~/default");
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
      } catch {
        var popup = new UIAlertController();
        popup.Title = "Some shit happened";
        popup.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Cancel, (obj) => {
          popup.DismissViewController(true, null);
        }));
        PresentViewController(popup, true, null);
      } finally {
        LoadingView.Hidden = true;
        LoadingView.StopAnimating();
      }
    }
  }
}

