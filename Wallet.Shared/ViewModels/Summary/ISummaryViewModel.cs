using System;
using System.Collections.Generic;
using GalaSoft.MvvmLight.Command;

namespace Wallet.Shared
{
  public interface ISummaryViewModel
  {
    List<WalletTransaction> Transactions { get; }

    event EventHandler<int[]> OnItemsDeleted;
    event EventHandler<int[]> OnItemsInserted;
    event EventHandler<int[]> OnItemsModified;

    RelayCommand AddRecordButtonAction { get; }
  }
}
