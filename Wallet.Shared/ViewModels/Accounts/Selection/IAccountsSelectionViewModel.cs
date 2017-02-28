using System.Collections.ObjectModel;
using System.Threading.Tasks;
using GalaSoft.MvvmLight.Command;

namespace Wallet.Shared {
  
  public interface IAccountsSelectionViewModel {

    Account SelectedAccount { get; set; }

    ObservableCollection<object> Accounts { get; }

    Task AddAccount(Account account);

    RelayCommand PlusButtonAction { get; }
  }
}
