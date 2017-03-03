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

    public event EventHandler OnAccountsChanged = delegate { };

    private readonly IAccountsRepository _accountsRepository;

    public AccountsWidgetViewModel(IAccountsRepository accountsRepository,
                                   INavigationService navigationService)
      : base(navigationService) {

      _accountsRepository = accountsRepository;
      _accountsRepository.OnItemsDeleted += AccountItemsDeleted;
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
      OnAccountsChanged?.Invoke(this, EventArgs.Empty);
    }

    private void AccountItemsDeleted(object sender, int[] e) {
      foreach (var index in e) {
        Accounts.RemoveAt(index);
      }
      OnAccountsChanged?.Invoke(this, EventArgs.Empty);
    }

    public void Dispose() {
      _accountsRepository.OnItemsDeleted -= AccountItemsDeleted;
      _accountsRepository.OnItemsInserted -= AccountItemsInserted;
    }

  }

}