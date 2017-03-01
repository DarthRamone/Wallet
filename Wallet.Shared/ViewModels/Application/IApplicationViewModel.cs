namespace Wallet.Shared.ViewModels
{
  public interface IApplicationViewModel
  {
    string SummaryViewControllerKey { get; }

    string AddRecordViewControllerKey { get; }

    string AccountSelectionViewControllerKey { get; }

    string CategorySelectionViewControllerKey { get; }

    string AccountTransactionsViewControllerKey { get; }

    string AccountCreationViewControllerKey { get; }

    string CategoryCreationViewControllerKey { get; }
  }
}
