using System;
using CoreGraphics;
using Foundation;
using GalaSoft.MvvmLight.Helpers;
using UIKit;
using Wallet.Shared.Models;
using Wallet.Shared.ViewModels;

namespace Wallet.iOS {
  public partial class AccountsWidgetCell : UICollectionViewCell {

    private IAccountsWidgetViewModel _viewModel;

    private ObservableCollectionViewSource<object, AccountCollectionViewCell> _source;

    public static readonly NSString Key = new NSString("AccountsWidgetCell");
    public static readonly UINib Nib;

    static AccountsWidgetCell() {
      Nib = UINib.FromName("AccountsWidgetCell", NSBundle.MainBundle);
    }

    protected AccountsWidgetCell(IntPtr handle) : base(handle) {
      // Note: this .ctor should not contain any initialization logic.
    }

    public void Configure(IAccountsWidgetViewModel viewModel) {

      _viewModel = viewModel;

      AccountsCollectionView.RegisterNibForCell(AccountCollectionViewCell.Nib, AccountCollectionViewCell.Key);
      _source = viewModel.Accounts.GetCollectionViewSource(BindAccountCell,
        factory: () => new CollectionViewSourceExtension<object, AccountCollectionViewCell>(AccountCollectionViewCell.Key, AccountSelected));
      AccountsCollectionView.Source = _source;

      var inset = AccountsCollectionViewFlowLayout.SectionInset;
      var cellSize = new CGSize((Frame.Width - inset.Top * 4) / 3, 50);
      AccountsCollectionViewFlowLayout.ItemSize = cellSize;
    }

    private void BindAccountCell(AccountCollectionViewCell cell, object model, NSIndexPath indexPath) {
      var account = model as Account;
      cell.AccountNameLabel.Text = account.Name;
      cell.AccountBalanceLabel.Text = account.Balance.ToString($"0.##{CurrenciesList.GetCurrency(account.Currency).Symbol}");
    }

    private void AccountSelected(object account) {
      _viewModel.AccountSelected.Execute(account);
    }
  }
}
