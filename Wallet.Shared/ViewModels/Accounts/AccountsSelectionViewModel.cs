using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using GalaSoft.MvvmLight.Views;

namespace Wallet.Shared {
  
  public class AccountsSelectionViewModel : WalletBaseViewModel, IAccountsSelectionViewModel, IDisposable {

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

    public ObservableCollection<object> Accounts { get; private set; }

    public AccountsSelectionViewModel(INavigationService navigationService,
                                      IAccountsRepository accountsRepository,
                                      IApplicationViewModel applicationViewModel)
      : base(navigationService, 
             applicationViewModel) {
      _accountsRepository = accountsRepository;
      Accounts = new ObservableCollection<object>(_accountsRepository.Items);

      _accountsRepository.OnItemsInserted += ItemsInserted;

      _selectedAccount = Accounts[0] as Account;
    }

    void ItemsInserted(object sender, int[] e) {
      Accounts.Add(_accountsRepository.Items[e[0]]);
    }

    public async Task AddAccount(Account account) {
      await _accountsRepository.Add(account);
    }

    public void Dispose() {
      _accountsRepository.OnItemsInserted -= ItemsInserted;
    }
  }
}
