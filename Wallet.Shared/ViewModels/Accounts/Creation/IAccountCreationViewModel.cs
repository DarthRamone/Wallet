using GalaSoft.MvvmLight.Command;

namespace Wallet.Shared.ViewModels {

  public interface IAccountCreationViewModel {

    string AccountNameText { get; }

    string BalanceText { get; }

    string CurrencyText { get; }

    bool IsCash { get; }

    RelayCommand CreateButtonAction { get; }

  }

}
