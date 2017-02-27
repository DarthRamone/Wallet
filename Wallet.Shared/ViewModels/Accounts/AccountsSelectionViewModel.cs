using System.Collections.Generic;
using GalaSoft.MvvmLight.Views;

namespace Wallet.Shared {
  
  public class AccountsSelectionViewModel : WalletBaseViewModel, IAccountsSelectionViewModel {

    private IAccountsRepository _accountsRepository;

    private Account _selectedAccount;
    public Account SelectedAccount {
      get { return _selectedAccount; }
      set {
        _selectedAccount = value;
        RaisePropertyChanged(() => SelectedAccount);
        _navigationService.GoBack();
      }
    }

    public List<Account> Accounts => _accountsRepository.Items;

    public AccountsSelectionViewModel(INavigationService navigationService,
                                      IAccountsRepository accountsRepository,
                                      IApplicationViewModel applicationViewModel)
      : base(navigationService, 
             applicationViewModel) {
      _accountsRepository = accountsRepository;
      _selectedAccount = Accounts[0];
    }

  }
}
