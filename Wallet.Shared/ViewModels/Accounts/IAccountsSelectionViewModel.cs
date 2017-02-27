using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Wallet.Shared {
  
  public interface IAccountsSelectionViewModel {

    Account SelectedAccount { get; set; }

    List<Account> Accounts { get; }

    event EventHandler<int[]> OnItemsDeleted;
    event EventHandler<int[]> OnItemsInserted;
    event EventHandler<int[]> OnItemsModified;

    Task AddAccount(Account account);
  }
}
