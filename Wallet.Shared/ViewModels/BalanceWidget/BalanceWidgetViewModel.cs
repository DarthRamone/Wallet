using System;
using System.Linq;
using GalaSoft.MvvmLight.Views;
using Wallet.Shared.Models;
using Wallet.Shared.Repositories.Accounts;

namespace Wallet.Shared.ViewModels.BalanceWidget {

  public class BalanceWidgetViewModel : WalletBaseViewModel, IBalanceWidgetViewModel, IDisposable {

    private readonly IAccountsRepository _accountsRepository;

    private string _balance;
    public string Balance {
      get { return _balance; }
      set {
        _balance = value;
        RaisePropertyChanged(() => Balance);
      }
    }

    public BalanceWidgetViewModel(IAccountsRepository accountsRepository, INavigationService navigationService) : base(navigationService) {
      _accountsRepository = accountsRepository;
      _accountsRepository.OnItemsDeleted += AccountsChanged;
      _accountsRepository.OnItemsInserted += AccountsChanged;
      _accountsRepository.OnItemsModified += AccountsChanged;

      SetBalance();
    }

    private void SetBalance() {
      Balance = _accountsRepository.Items
        .Sum(account => CurrenciesList.Convert(account.Currency, CurrenciesList.ReferenceCurrency.Code, account.Balance))
        .ToString($"0.##{CurrenciesList.ReferenceCurrency.Symbol}");
    }

    private void AccountsChanged(object sender, int[] e) {
      SetBalance();
    }

    public void Dispose() {
      _accountsRepository.OnItemsDeleted -= AccountsChanged;
      _accountsRepository.OnItemsInserted -= AccountsChanged;
      _accountsRepository.OnItemsModified -= AccountsChanged;
    }

  }

}