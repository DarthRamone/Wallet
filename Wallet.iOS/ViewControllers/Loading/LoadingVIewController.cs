﻿using System.Threading.Tasks;
using GalaSoft.MvvmLight.Views;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;
using UIKit;
using Wallet.Shared;
using Wallet.Shared.Providers;

namespace Wallet.iOS {
  
  public partial class LoadingVIewController : WalletBaseViewController {

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

      var unityContainer = ServiceLocator.Current.GetInstance<IUnityContainer>();
      var navigationService = ServiceLocator.Current.GetInstance<INavigationService>() as NavigationService;
      var configurationProvider = ServiceLocator.Current.GetInstance<ISyncConfigurationsProvider>();
      var result = await configurationProvider.DoLogin(login, password, newUser);

      if (result) {
        var locator = new iOSLocator(unityContainer);
        locator.RegisterTypes();

        navigationService?.Configure(Pages.LoadingViewControllerKey, typeof(LoadingVIewController));
        navigationService?.Configure(Pages.SummaryViewControllerKey, typeof(SummaryViewController));
        navigationService?.Configure(Pages.AddRecordViewControllerKey, typeof(AddRecordViewController));
        navigationService?.Configure(Pages.AccountCreationViewControllerKey, typeof(AccountCreationViewController));
        navigationService?.Configure(Pages.CategoryCreationViewControllerKey, typeof(CategoryCreationViewController));
        navigationService?.Configure(Pages.AccountSelectionViewControllerKey, typeof(AccountSelectionViewController));
        navigationService?.Configure(Pages.CategorySelectionViewControllerKey, typeof(CategorySelectionViewController));
        navigationService?.Configure(Pages.AccountTransactionsViewControllerKey, typeof(AccountTransactionsViewController));

        navigationService?.NavigateTo(Pages.SummaryViewControllerKey);
      }
      else {
        var popup = new UIAlertController { Title = "Some shit happened" };
        popup.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Cancel, obj => {
          popup.DismissViewController(true, null);
        }));
        PresentViewController(popup, true, null);
      }

      LoadingView.Hidden = true;
      LoadingView.StopAnimating();
    }
  }
}

