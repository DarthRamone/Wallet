using System.Linq;
using GalaSoft.MvvmLight.Views;
using Wallet.Shared.Models;
using Wallet.Shared.Repositories.Accounts;

namespace Wallet.Shared.ViewModels.BalanceWidget {

  public class BalanceWidgetViewModel : WalletBaseViewModel, IBalanceWidgetViewModel {

    private IAccountsRepository _accountsRepository;

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
      Balance = _accountsRepository.Items
                                   .Sum(account => CurrenciesList.Convert(account.Currency, CurrenciesList.ReferenceCurrency.Code, account.Balance))
                                   .ToString($"0.##{CurrenciesList.ReferenceCurrency.Symbol}");
    }

  }

}