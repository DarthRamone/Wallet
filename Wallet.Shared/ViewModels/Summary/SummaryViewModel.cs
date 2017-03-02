using System;
using System.Collections.ObjectModel;
using System.Linq;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using Wallet.Shared.Models;
using Wallet.Shared.Repositories;

namespace Wallet.Shared.ViewModels {
  
  public class SummaryViewModel : WalletBaseViewModel, ISummaryViewModel, IDisposable {

    private readonly IAccountsRepository _accountsRepository;
    private readonly ITransactionsRepository _transactionsRepository;

    public ObservableCollection<object> Accounts { get; }
    public ObservableCollection<WalletTransaction> Transactions { get; }

    public RelayCommand<Account> AccountSelected { get; private set; }
    public RelayCommand AddRecordButtonAction { get; private set; }

    public SummaryViewModel(INavigationService navigationService,
                             IApplicationViewModel applicationViewModel,
                             ITransactionsRepository transactionsRepository,
                             ICategoriesRepository categoriesRepository,
                             IAccountsRepository accountsRepository)
      : base(navigationService,
             applicationViewModel) {

      _accountsRepository = accountsRepository;
      _transactionsRepository = transactionsRepository;

      Initialize(categoriesRepository, accountsRepository);//HACK

      SetupCommands();

      Accounts = new ObservableCollection<object>(_accountsRepository.Items);
      Transactions = new ObservableCollection<WalletTransaction>(_transactionsRepository.SortedTransactions);

      _accountsRepository.OnItemsInserted += AccountItemsInserted;

      _transactionsRepository.OnItemsDeleted += TransactionItemsDeleted;
      _transactionsRepository.OnItemsInserted += TransactionItemsInserted;
      _transactionsRepository.OnItemsModified += TransactionItemsModified;
    }

    private void SetupCommands() {

      AddRecordButtonAction = new RelayCommand(() => {
        _navigationService.NavigateTo(_applicationViewModel.AddRecordViewControllerKey);
      }, () => true);

      AccountSelected = new RelayCommand<Account>(account => {
        _navigationService.NavigateTo(_applicationViewModel.AccountTransactionsViewControllerKey, account);
      }, account => true);
    }

    private async void Initialize(ICategoriesRepository catsRepo, IAccountsRepository accsRepo) {
      
      await catsRepo.Add(new Category { Name = "Transfer" });
      await catsRepo.Add(new Category { Name = "Drinks" });
      await catsRepo.Add(new Category { Name = "Weed" });
      await catsRepo.Add(new Category { Name = "Junk food" });
      await catsRepo.Add(new Category { Name = "Salary" });

      await accsRepo.Add(new Account { Name = "Cash", Currency = "rub", IsCash = true });
      await accsRepo.Add(new Account { Name = "Credit card", Currency = "usd", IsCash = false });
    }

    private void TransactionItemsDeleted(object sender, int[] e) {
      foreach(var index in e) Transactions.RemoveAt(index);
    }

    private void TransactionItemsInserted(object sender, int[] e) {
      foreach (var index in e) {
        Transactions.Insert(index, _transactionsRepository.SortedTransactions[index]);
      }
    }

    private void AccountItemsInserted(object sender, int[] e) {
      Accounts.Add(_accountsRepository.Items[e[0]]);
    }

    private void TransactionItemsModified(object sender, int[] e) {
    }

    public void Dispose() {
      _accountsRepository.OnItemsInserted -= AccountItemsInserted;
      _transactionsRepository.OnItemsDeleted -= TransactionItemsDeleted;
      _transactionsRepository.OnItemsInserted -= TransactionItemsInserted;
      _transactionsRepository.OnItemsModified -= TransactionItemsModified;
    }
  }
}
