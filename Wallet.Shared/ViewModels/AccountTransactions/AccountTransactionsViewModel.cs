using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using GalaSoft.MvvmLight.Views;

namespace Wallet.Shared {

  public class AccountTransactionsViewModel : WalletBaseViewModel, IAccountTransactionsViewModel, IDisposable {

    private Account _account;

    private readonly ITransactionsRepository _transactionsRepository;

    private List<WalletTransaction> _transactionsForAccount {
      get {
        return _transactionsRepository.SortedTransactions.Where(t => t.Account.Name.Equals(_account.Name)).ToList();
      }
    }

    public ObservableCollection<WalletTransaction> Transactions { get; }

    public AccountTransactionsViewModel(INavigationService navigationService,
                                        IApplicationViewModel applicationViewModel,
                                        ITransactionsRepository transactionsRepository)
      : base(navigationService, applicationViewModel) {

      _transactionsRepository = transactionsRepository;
      Transactions = new ObservableCollection<WalletTransaction>();
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
      if (_account == null) return;
      var items = e.Select(index => _transactionsRepository.Items[index])
                   .Where(item => item.Account.Name == _account.Name)
                   .OrderByDescending(item => item.Date)
                   .ToList();
      foreach (var item in items) Transactions.Add(item);
    }
  }

}
