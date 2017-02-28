using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;

namespace Wallet.Shared {
  public class AccountCreationViewModel : WalletBaseViewModel, IAccountCreationViewModel {

    private IAccountsRepository _accountsRepository;

    string _accountNameText;
    public string AccountNameText {
      get { return _accountNameText; }
      set {
        _accountNameText = value;
        RaisePropertyChanged(() => AccountNameText);
      }
    }

    string _balanceNameText;
    public string BalanceText {
      get { return _balanceNameText; }
      set {
        _balanceNameText = value;
        RaisePropertyChanged(() => BalanceText);
      }
    }

    string _currencyText;
    public string CurrencyText {
      get { return _currencyText; }
      set {
        _currencyText = value;
        RaisePropertyChanged(() => CurrencyText);
      }
    }

    bool _isCash;
    public bool IsCash {
      get { return _isCash; }
      set {
        _isCash = value;
        RaisePropertyChanged(() => _isCash);
      }
    }

    public RelayCommand CreateButtonAction { get; private set; }

    public AccountCreationViewModel(INavigationService navigationService,
                                    IApplicationViewModel applicationViewModel,
                                    IAccountsRepository accountsRepository) 
      : base(navigationService, applicationViewModel) {

      _accountsRepository = accountsRepository;

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
