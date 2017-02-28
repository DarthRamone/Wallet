using GalaSoft.MvvmLight;

namespace Wallet.Shared
{
  public class ApplicationViewModel : ViewModelBase, IApplicationViewModel
  {
    public string AddRecordViewControllerKey => "AddRecordViewControllerKey";

    public string SummaryViewControllerKey => "SummaryViewControllerKey";

    public string AccountSelectionViewControllerKey => "AccountSelectinViewControllerKey";

    public string CategorySelectionViewControllerKey => "CategorySelectionViewControllerKey";

    public string AccountTransactionsViewControllerKey => "AccountTransactionsViewControllerKey";

    public string AccountCreationViewControllerKey => "AccountCreationViewControllerKey";
  }
}
