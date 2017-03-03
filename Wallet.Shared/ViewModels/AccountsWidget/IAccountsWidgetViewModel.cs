using System;
using System.Collections.ObjectModel;
using GalaSoft.MvvmLight.Command;
using Wallet.Shared.Models;

namespace Wallet.Shared.ViewModels.AccountsWidget {

  public interface IAccountsWidgetViewModel : IWalletBaseViewModel {

    ObservableCollection<object> Accounts { get; }

    event EventHandler OnAccountsChanged;

    RelayCommand<Account> AccountSelected { get; }

  }

}