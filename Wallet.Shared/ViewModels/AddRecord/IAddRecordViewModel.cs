using System;
using GalaSoft.MvvmLight.Command;

namespace Wallet.Shared
{
  public interface IAddRecordViewModel
  {
    string AmountLabelText { get; }

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
  }
}
