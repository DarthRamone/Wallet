using System;
using System.Collections.Generic;
using System.Threading.Tasks;
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

    public event EventHandler<int[]> OnItemsDeleted {
      add { _accountsRepository.OnItemsDeleted += value; }
      remove { _accountsRepository.OnItemsDeleted -= value; }
    }

    public event EventHandler<int[]> OnItemsInserted {
      add { _accountsRepository.OnItemsInserted += value; }
      remove { _accountsRepository.OnItemsInserted -= value; }
    }

    public event EventHandler<int[]> OnItemsModified {
      add { _accountsRepository.OnItemsModified += value; }
      remove { _accountsRepository.OnItemsModified -= value; }
    }

    public AccountsSelectionViewModel(INavigationService navigationService,
                                      IAccountsRepository accountsRepository,
                                      IApplicationViewModel applicationViewModel)
      : base(navigationService, 
             applicationViewModel) {
      _accountsRepository = accountsRepository;
      _selectedAccount = Accounts[0];
    }

    public async Task AddAccount(Account account) {
      await _accountsRepository.Add(account);
    }
  }
}
