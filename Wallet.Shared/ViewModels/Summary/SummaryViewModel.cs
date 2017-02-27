using System;
using System.Collections.ObjectModel;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;

namespace Wallet.Shared
{
  public class SummaryViewModel : WalletBaseViewModel, ISummaryViewModel, IDisposable {
    
    private ITransactionsRepository _transactionsRepository;

    public ObservableCollection<object> Transactions { get; private set; }

    public RelayCommand AddRecordButtonAction { get; private set; }

    public SummaryViewModel(INavigationService navigationService,
                             IApplicationViewModel applicationViewModel,
                             ITransactionsRepository transactionsRepository,
                             ICategoriesRepository catsRepo,
                             IAccountsRepository accsRepo)
      : base(navigationService,
             applicationViewModel) {
      _transactionsRepository = transactionsRepository;

      Initialize(catsRepo, accsRepo);//HACK

      AddRecordButtonAction = new RelayCommand(() => {
        _navigationService.NavigateTo(_applicationViewModel.AddRecordViewControllerKey);
      }, () => true);

      Transactions = new ObservableCollection<object>(_transactionsRepository.Items);

      _transactionsRepository.OnItemsInserted += ItemsInserted;
    }

    async void Initialize(ICategoriesRepository catsRepo, IAccountsRepository accsRepo) {
      await catsRepo.Add(new Category { Name = "test category" });
      await accsRepo.Add(new Account { Name = "test account" });
    }

    void ItemsDeleted(object sender, int[] e) {
      throw new NotImplementedException();
    }

    void ItemsInserted(object sender, int[] e) {
      var index = e[0];
      Transactions.Insert(0, _transactionsRepository.Items[index]);
    }

    void ItemsModified(object sender, int[] e) {
      throw new NotImplementedException();
    }

    public void Dispose() {
      _transactionsRepository.OnItemsInserted -= ItemsDeleted;
    }
  }
}
