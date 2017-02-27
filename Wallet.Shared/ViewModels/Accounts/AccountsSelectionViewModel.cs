using System;
using System.Collections.Generic;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;

namespace Wallet.Shared {
  
  public class AccountsSelectionViewModel : WalletBaseViewModel, IAccountsSelectionViewModel {

    private IAccountsRepository _accountsRepository;

    //private Account _selectedAccount;
    public Account SelectedAccount { get; set; }

    public List<Account> Accounts => _accountsRepository.Items;

    public RelayCommand<Account> AccountSelected { get; private set; }

    public AccountsSelectionViewModel(INavigationService navigationService,
                                      IAccountsRepository accountsRepository,
                                      IApplicationViewModel applicationViewModel)
      : base(navigationService, 
             applicationViewModel) {
      _accountsRepository = accountsRepository;

      AccountSelected = new RelayCommand<Account>(account => {
        _navigationService.GoBack();
      }, account => true);
    }

  }
}
