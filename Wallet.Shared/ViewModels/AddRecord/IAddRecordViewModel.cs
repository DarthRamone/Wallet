using GalaSoft.MvvmLight.Command;

namespace Wallet.Shared
{
  public interface IAddRecordViewModel
  {
    //HACK
    bool IsRightButtonTapped { get; set; }

    string LeftButtonText { get; set; }

    string RightButtonText { get; set; }

    string AmountLabelText { get; }

    string SignText { get; }

    TransactionType TransactionType { get; }

    RelayCommand AddRecordAction { get; }
    RelayCommand Button0Action { get; }
    RelayCommand Button1Action { get; }
    RelayCommand Button2Action { get; }
    RelayCommand Button3Action { get; }
    RelayCommand Button4Action { get; }
    RelayCommand Button5Action { get; }
    RelayCommand Button6Action { get; }
    RelayCommand Button7Action { get; }
    RelayCommand Button8Action { get; }
    RelayCommand Button9Action { get; }
    RelayCommand CommaButtonAction { get; }
    RelayCommand DeleteButtonAction { get; }
    RelayCommand LeftButtonAction { get; }
    RelayCommand RightButtonAction { get; }
    RelayCommand IncomeButtonAction { get; }
    RelayCommand ExpensesButtonAction { get; }
    RelayCommand TransferButtonAction { get; }

    CrossPlatformColor IncomeButtonColor { get; }
    CrossPlatformColor ExpensesButtonColor { get; }
    CrossPlatformColor TransButtonColor { get; }

    IUIStylingsModel MainStyling { get; }
  }
}
