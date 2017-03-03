using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using Wallet.Shared.Models;
using Wallet.Shared.Repositories;
using Wallet.Shared.Repositories.Accounts;

namespace Wallet.Shared.ViewModels.AccountCreation {

  public class AccountCreationViewModel : WalletBaseViewModel, IAccountCreationViewModel {

    private readonly IAccountsRepository _accountsRepository;

    private string _accountNameText;
    public string AccountNameText {
      get { return _accountNameText; }
      set {
        _accountNameText = value;
        RaisePropertyChanged(() => AccountNameText);
      }
    }

    private string _balanceNameText;
    public string BalanceText {
      get { return _balanceNameText; }
      set {
        _balanceNameText = value;
        RaisePropertyChanged(() => BalanceText);
      }
    }

    private string _currencyText;
    public string CurrencyText {
      get { return _currencyText; }
      set {
        _currencyText = value;
        RaisePropertyChanged(() => CurrencyText);
      }
    }

    private bool _isCash;
    public bool IsCash {
      get { return _isCash; }
      set {
        _isCash = value;
        RaisePropertyChanged(() => _isCash);
      }
    }

    public RelayCommand CreateButtonAction { get; private set;  }

    public AccountCreationViewModel(INavigationService navigationService,
                                    IAccountsRepository accountsRepository)
      : base(navigationService) {

      _accountsRepository = accountsRepository;

      SetCommands();
    }

    private void SetCommands() {

      CreateButtonAction = new RelayCommand(async () => {
        var currency = (CurrencyText.ToLower() == "rub" || CurrencyText.ToLower() == "usd") ?
          CurrencyText.ToLower() : "rub";

        await _accountsRepository.Add(new Account {
          Name = AccountNameText,
          Balance = double.Parse(BalanceText),
          Currency = currency,
          IsCash = IsCash
        });

        _navigationService.GoBack();
      }, () => true);
    }

  }
}
