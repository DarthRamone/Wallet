using System;
using System.Collections.ObjectModel;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using Wallet.Shared.Models;
using Wallet.Shared.Repositories.Accounts;

namespace Wallet.Shared.ViewModels.AccountsWidget {

  public class AccountsWidgetViewModel : WalletBaseViewModel, IAccountsWidgetViewModel, IDisposable {

    public ObservableCollection<object> Accounts { get; }

    public RelayCommand<Account> AccountSelected { get; private set;  }

    private readonly IAccountsRepository _accountsRepository;

    public AccountsWidgetViewModel(IAccountsRepository accountsRepository,
                                   INavigationService navigationService)
      : base(navigationService) {

      _accountsRepository = accountsRepository;
      _accountsRepository.OnItemsInserted += AccountItemsInserted;

      SetupCommands();

      Accounts = new ObservableCollection<object>(_accountsRepository.Items);
    }

    private void SetupCommands() {
      AccountSelected = new RelayCommand<Account>(account => {
        _navigationService.NavigateTo(Pages.AccountTransactionsViewControllerKey, account);
      }, account => true);
    }

    private void AccountItemsInserted(object sender, int[] e) {
      foreach (var index in e) {
        Accounts.Add(_accountsRepository.Items[index]);
      }
    }

    public void Dispose() {
      _accountsRepository.OnItemsInserted -= AccountItemsInserted;
    }

  }

}