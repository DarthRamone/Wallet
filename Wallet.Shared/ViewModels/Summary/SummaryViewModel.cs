using System;
using System.Collections.ObjectModel;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;

namespace Wallet.Shared
{
  public class SummaryViewModel : WalletBaseViewModel, ISummaryViewModel, IDisposable {

    private IAccountsRepository _accountsRepository;
    private ITransactionsRepository _transactionsRepository;

    public ObservableCollection<object> Accounts { get; private set; }
    public ObservableCollection<object> Transactions { get; private set; }

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
      Transactions = new ObservableCollection<object>(_transactionsRepository.Items);

      _accountsRepository.OnItemsInserted += AccountItemsInserted;
      _transactionsRepository.OnItemsInserted += TransactionItemsInserted;
    }

    void SetupCommands() {
      
      AddRecordButtonAction = new RelayCommand(() => {
        _navigationService.NavigateTo(_applicationViewModel.AddRecordViewControllerKey);
      }, () => true);

      AccountSelected = new RelayCommand<Account>(account => {
        _navigationService.NavigateTo(_applicationViewModel.AccountTransactionsViewControllerKey, account);
      }, account => true);
    }

    async void Initialize(ICategoriesRepository catsRepo, IAccountsRepository accsRepo) {
      await catsRepo.Add(new Category { Name = "test category" });
      await accsRepo.Add(new Account { Name = "test account" });
    }

    void ItemsDeleted(object sender, int[] e) {
      throw new NotImplementedException();
    }

    void TransactionItemsInserted(object sender, int[] e) {
      var index = e[0];
      Transactions.Insert(0, _transactionsRepository.Items[index]);
    }

    void AccountItemsInserted(object sender, int[] e) {
      Accounts.Add(_accountsRepository.Items[e[0]]);
    }

    void ItemsModified(object sender, int[] e) {
      throw new NotImplementedException();
    }

    public void Dispose() {
      _accountsRepository.OnItemsInserted -= AccountItemsInserted;
      _transactionsRepository.OnItemsInserted -= TransactionItemsInserted;
    }
  }
}
