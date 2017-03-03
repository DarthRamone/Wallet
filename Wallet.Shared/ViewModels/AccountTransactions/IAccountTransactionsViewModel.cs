using System.Collections.ObjectModel;
using Wallet.Shared.Models;

namespace Wallet.Shared.ViewModels {
  
  public interface IAccountTransactionsViewModel : IWalletBaseViewModel {
    
    void InitializeWithAccount(Account account);

    ObservableCollection<WalletTransaction> Transactions { get; }

  }

}
