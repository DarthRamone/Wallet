using System.Collections.ObjectModel;

namespace Wallet.Shared {
  
  public interface IAccountTransactionsViewModel {
    
    void InitializeWithAccount(Account account);

    ObservableCollection<WalletTransaction> Transactions { get; }

  }

}
