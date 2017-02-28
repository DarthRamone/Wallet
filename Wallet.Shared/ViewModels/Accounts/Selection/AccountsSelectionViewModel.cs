using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using GalaSoft.MvvmLight.Command;
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

    public RelayCommand PlusButtonAction { get; private set; }

    public ObservableCollection<object> Accounts { get; private set; }

    public AccountsSelectionViewModel(INavigationService navigationService,
                                      IAccountsRepository accountsRepository,
                                      IApplicationViewModel applicationViewModel)
      : base(navigationService, 
             applicationViewModel) {
      _accountsRepository = accountsRepository;
      Accounts = new ObservableCollection<object>(_accountsRepository.Items);

      _accountsRepository.OnItemsInserted += ItemsInserted;

      PlusButtonAction = new RelayCommand(() => {
        _navigationService.NavigateTo(_applicationViewModel.AccountCreationViewControllerKey);
      }, () => true);
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
