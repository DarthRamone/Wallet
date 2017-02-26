using System;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;

namespace Wallet.Shared
{
  public class SummaryViewModel : WalletBaseViewModel, ISummaryViewModel
  {
    public RelayCommand AddRecordButtonAction { get; private set; }

    public SummaryViewModel (INavigationService navigationService,
                             IApplicationViewModel applicationViewModel) 
      : base(navigationService,
             applicationViewModel)
    {
      AddRecordButtonAction = new RelayCommand(() => {
        _navigationService.NavigateTo(_applicationViewModel.AddRecordViewControllerKey);
      }, () => true);
    }
  }
}
