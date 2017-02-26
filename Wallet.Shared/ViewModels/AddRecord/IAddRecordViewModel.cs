using System;
using GalaSoft.MvvmLight.Command;

namespace Wallet.Shared
{
  public interface IAddRecordViewModel
  {
    RelayCommand AddRecordAction { get; }
  }
}
