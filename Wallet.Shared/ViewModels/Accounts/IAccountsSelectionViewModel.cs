using System.Collections.Generic;

namespace Wallet.Shared {
  
  public interface IAccountsSelectionViewModel {

    Account SelectedAccount { get; set; }

    List<Account> Accounts { get; }
  }
}
