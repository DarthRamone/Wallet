using System.Collections.ObjectModel;
using GalaSoft.MvvmLight.Command;
using Wallet.Shared.Models;

namespace Wallet.Shared.ViewModels.AccountsWidget {

  public interface IAccountsWidgetViewModel {

    ObservableCollection<object> Accounts { get; }

    RelayCommand<Account> AccountSelected { get; }

  }

}