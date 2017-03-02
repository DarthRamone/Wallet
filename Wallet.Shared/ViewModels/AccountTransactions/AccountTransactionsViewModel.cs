using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using GalaSoft.MvvmLight.Views;
using Wallet.Shared.Models;
using Wallet.Shared.Repositories;

namespace Wallet.Shared.ViewModels {

  public class AccountTransactionsViewModel : WalletBaseViewModel, IAccountTransactionsViewModel, IDisposable {

    private Account _account;

    private readonly ITransactionsRepository _transactionsRepository;

    private IEnumerable<WalletTransaction> TransactionsForAccount => _transactionsRepository.Transactions.Where(t => t.Account.Name.Equals(_account.Name));

    public ObservableCollection<WalletTransaction> Transactions { get; }

    public AccountTransactionsViewModel(INavigationService navigationService,
                                        ITransactionsRepository transactionsRepository)
      : base(navigationService) {

      _transactionsRepository = transactionsRepository;
      Transactions = new ObservableCollection<WalletTransaction>();
      _transactionsRepository.OnItemsDeleted += TransactionItemsDeleted;
      _transactionsRepository.OnItemsInserted += TransactionItemsInserted;
    }

    public void InitializeWithAccount(Account account) {
      _account = account;
      _transactionsRepository.SetAccountForFiltering(account);
      foreach (var transaction in TransactionsForAccount) {
        Transactions.Add(transaction);
      }
    }

    private void TransactionItemsDeleted(object sender, int[] e) {
      if (_account == null) return;
      foreach(var index in e) Transactions.RemoveAt(index);
    }

    private void TransactionItemsInserted(object sender, int[] e) {
      if (_account == null) return;
      foreach (var index in e) {
        Transactions.Insert(index, _transactionsRepository.Transactions[index]);
      }
    }

    public void Dispose() {
      _transactionsRepository.OnItemsDeleted -= TransactionItemsDeleted;
      _transactionsRepository.OnItemsInserted -= TransactionItemsInserted;
    }

  }

}
