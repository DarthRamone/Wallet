using GalaSoft.MvvmLight.Command;

namespace Wallet.Shared.ViewModels.AccountCreation {

  public interface IAccountCreationViewModel : IWalletBaseViewModel {

    string AccountNameText { get; }

    string BalanceText { get; }

    string CurrencyText { get; }

    bool IsCash { get; }

    RelayCommand CreateButtonAction { get; }

  }

}
