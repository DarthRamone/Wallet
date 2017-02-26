using GalaSoft.MvvmLight;

namespace Wallet.Shared
{
  public class ApplicationViewModel : ViewModelBase, IApplicationViewModel
  {
    public string AddRecordViewControllerKey => "AddRecordViewControllerKey";

    public string SummaryViewControllerKey => "SummaryViewControllerKey";
  }
}
