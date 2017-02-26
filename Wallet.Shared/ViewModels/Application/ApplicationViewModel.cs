using System;
using GalaSoft.MvvmLight;

namespace Wallet.Shared
{
  public class ApplicationViewModel : ViewModelBase, IApplicationViewModel
  {
    public string AddRecordViewControllerKey => nameof(AddRecordViewControllerKey);

    public string SummaryViewControllerKey => nameof(SummaryViewControllerKey);
  }
}
