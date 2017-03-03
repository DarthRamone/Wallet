using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using Wallet.Shared.Models;
using Wallet.Shared.Repositories;

namespace Wallet.Shared.ViewModels.Summary {
  
  public class SummaryViewModel : WalletBaseViewModel, ISummaryViewModel {

    public RelayCommand<Account> AccountSelected { get; private set; }
    public RelayCommand AddRecordButtonAction { get; private set; }

    public SummaryViewModel(INavigationService navigationService,
                             ICategoriesRepository categoriesRepository,
                             IAccountsRepository accountsRepository)
      : base(navigationService) {

      Initialize(categoriesRepository, accountsRepository);//HACK

      SetupCommands();
    }

    private void SetupCommands() {

      AddRecordButtonAction = new RelayCommand(() => {
        _navigationService.NavigateTo(Pages.AddRecordViewControllerKey);
      }, () => true);

      AccountSelected = new RelayCommand<Account>(account => {
        _navigationService.NavigateTo(Pages.AccountTransactionsViewControllerKey, account);
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
  }
}
