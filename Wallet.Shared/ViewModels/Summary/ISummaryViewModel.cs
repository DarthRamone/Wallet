﻿using System.Collections.ObjectModel;
using GalaSoft.MvvmLight.Command;

namespace Wallet.Shared {
  
  public interface ISummaryViewModel {
    
    ObservableCollection<object> Transactions { get; }

    RelayCommand AddRecordButtonAction { get; }

  }

}
