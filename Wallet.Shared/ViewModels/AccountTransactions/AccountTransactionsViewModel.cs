using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using GalaSoft.MvvmLight.Views;

namespace Wallet.Shared {
  
  public class AccountTransactionsViewModel : WalletBaseViewModel, IAccountTransactionsViewModel, IDisposable {

    private Account _account;

    private ITransactionsRepository _transactionsRepository;

    private List<WalletTransaction> _transactionsForAccount {
      get {
        return _transactionsRepository.Items.Where(t => t.Account.Name.Equals(_account.Name)).ToList();
      }
    }

    public ObservableCollection<object> Transactions { get; private set; }

    public AccountTransactionsViewModel(INavigationService navigationService,
                                        IApplicationViewModel applicationViewModel,
                                        ITransactionsRepository transactionsRepository)
      : base(navigationService, applicationViewModel) {

      _transactionsRepository = transactionsRepository;
      Transactions = new ObservableCollection<object>();
      _transactionsRepository.OnItemsInserted += ItemsInserted;
    }

    public void InitializeWithAccount(Account account) {
      if (account != null) {
        _account = account;
        foreach (var transaction in _transactionsForAccount) {
          Transactions.Add(transaction);
        }
      }
    }

    public void Dispose() {
      _transactionsRepository.OnItemsInserted -= ItemsInserted;
    }

    void ItemsInserted(object sender, int[] e) {
      Transactions.Add(_transactionsRepository.Items[e[0]]);
    }
  }

}
