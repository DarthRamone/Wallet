using System;
using System.Collections.ObjectModel;

namespace Wallet.Shared {
  
  public interface IAccountTransactionsViewModel {
    
    void InitializeWithAccount(Account account);

    ObservableCollection<object> Transactions { get; }

  }

}
