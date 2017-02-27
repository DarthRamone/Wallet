using System.Collections.Generic;
using GalaSoft.MvvmLight.Command;

namespace Wallet.Shared {
  
  public interface IAccountsSelectionViewModel {

    Account SelectedAccount { get; set; }

    List<Account> Accounts { get; }

    RelayCommand<Account> AccountSelected { get; }

  }
}
