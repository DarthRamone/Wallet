using System;
using GalaSoft.MvvmLight.Command;

namespace Wallet.Shared
{
  public interface ISummaryViewModel
  {
    RelayCommand AddRecordButtonAction { get; }
  }
}
