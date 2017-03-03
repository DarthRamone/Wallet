using System.Collections.ObjectModel;
using System.Threading.Tasks;
using GalaSoft.MvvmLight.Command;
using Wallet.Shared.Models;

namespace Wallet.Shared.ViewModels.AccountSelection {
  
  public interface IAccountsSelectionViewModel {

    Account SelectedAccount { get; set; }

    ObservableCollection<Account> Accounts { get; }

    Task AddAccount(Account account);

    RelayCommand PlusButtonAction { get; }
  }
}
