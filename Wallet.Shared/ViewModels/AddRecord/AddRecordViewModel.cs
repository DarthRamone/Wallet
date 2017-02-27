using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;

namespace Wallet.Shared
{
  public class AddRecordViewModel : WalletBaseViewModel, IAddRecordViewModel
  {
    private ITransactionsRepository _transactionsRepository;

    public RelayCommand AddRecordAction { get; private set; }

    public AddRecordViewModel(INavigationService navService,
                              IApplicationViewModel appViewModel,
                              ITransactionsRepository transactionsRepository)
      : base(navService, appViewModel)
    {
      _transactionsRepository = transactionsRepository;

      AddRecordAction = new RelayCommand(async () => {
          var transaction = new WalletTransaction();
          transaction.Amount = 700;
          await _transactionsRepository.AddTransaction(transaction, "test category", "test account");
          _navigationService.GoBack();
      }, () => true);
    }
  }
}
