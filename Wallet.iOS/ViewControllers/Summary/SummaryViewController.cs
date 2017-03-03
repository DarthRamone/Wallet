using System;
using System.Collections.Specialized;
using CoreGraphics;
using Foundation;
using GalaSoft.MvvmLight.Helpers;
using Microsoft.Practices.ServiceLocation;
using UIKit;
using Wallet.Shared.ViewModels.AccountsWidget;
using Wallet.Shared.ViewModels.BalanceWidget;
using Wallet.Shared.ViewModels.Summary;
using Wallet.Shared.ViewModels.TransactionsWidget;

namespace Wallet.iOS {

  public partial class SummaryViewController : WalletBaseViewController {

    private readonly ISummaryViewModel _summaryViewModel;

    private readonly IBalanceWidgetViewModel _balanceWidgetViewModel;
    private readonly IAccountsWidgetViewModel _accountsWidgetViewModel;
    private readonly ITransactionsWidgetViewModel _transactionsWidgetViewModel;

    public SummaryViewController() : base("SummaryViewController") {
      _summaryViewModel = ServiceLocator.Current.GetInstance<ISummaryViewModel>();
      _balanceWidgetViewModel = ServiceLocator.Current.GetInstance<IBalanceWidgetViewModel>();
      _accountsWidgetViewModel = ServiceLocator.Current.GetInstance<IAccountsWidgetViewModel>();
      _transactionsWidgetViewModel = ServiceLocator.Current.GetInstance<ITransactionsWidgetViewModel>();

      _accountsWidgetViewModel.Accounts.CollectionChanged += AccountsCollectionChanged;
    }

    public override void ViewDidLoad() {
      base.ViewDidLoad();

      AddRecordButton.SetCommand(_summaryViewModel.AddRecordButtonAction);

      WidgetsCollectionView.BackgroundColor = UIColor.Brown;

      WidgetsCollectionView.RegisterNibForCell(BalanceWidget.Nib, BalanceWidget.Key);
      WidgetsCollectionView.RegisterNibForCell(AccountsWidgetCell.Nib, AccountsWidgetCell.Key);
      WidgetsCollectionView.RegisterNibForCell(TransactionsWidget.Nib, TransactionsWidget.Key);

      WidgetsCollectionView.Source = new SummaryCollectionViewSource(_balanceWidgetViewModel, _accountsWidgetViewModel, _transactionsWidgetViewModel);
      WidgetsCollectionView.Delegate = new SummaryCollectionViewLayoutDelegate(_accountsWidgetViewModel);
      WidgetsCollectionView.SetCollectionViewLayout(WidgetsCollectionViewFlowLayout, false);
    }

    public override void ViewWillAppear(bool animated) {
      base.ViewWillAppear(animated);
      var hSectionInset = WidgetsCollectionViewFlowLayout.SectionInset.Left;
      WidgetsCollectionViewFlowLayout.ItemSize = new CGSize(View.Frame.Width - hSectionInset * 8, 200);
    }

    //TODO: Unsubscribe
    private void AccountsCollectionChanged(object sender, NotifyCollectionChangedEventArgs e) {
      WidgetsCollectionView.ReloadItems(new[] { NSIndexPath.FromRowSection(0, 0) });
    }


    public class SummaryCollectionViewSource : UICollectionViewSource {

      private readonly IBalanceWidgetViewModel _balanceWidgetViewModel;
      private readonly IAccountsWidgetViewModel _accountsWidgetViewModel;
      private readonly ITransactionsWidgetViewModel _transactionsWidgetViewModel;

      public SummaryCollectionViewSource(
        IBalanceWidgetViewModel balanceWidgetViewModel,
        IAccountsWidgetViewModel accountsWidgetViewModel,
        ITransactionsWidgetViewModel transactionsWidgetViewModel) {
        _balanceWidgetViewModel = balanceWidgetViewModel;
        _accountsWidgetViewModel = accountsWidgetViewModel;
        _transactionsWidgetViewModel = transactionsWidgetViewModel;
      }

      public override nint NumberOfSections(UICollectionView collectionView) => 1;

      public override nint GetItemsCount(UICollectionView collectionView, nint section) => 3;

      public override UICollectionViewCell GetCell(UICollectionView collectionView, NSIndexPath indexPath) {

        switch (indexPath.Row) {
          case 0: {
            var accountWidget =
              collectionView.DequeueReusableCell(AccountsWidgetCell.Key, indexPath) as AccountsWidgetCell;
            accountWidget?.Configure(_accountsWidgetViewModel);
            return accountWidget;
          }
          case 1: {
            var balanceWidget = collectionView.DequeueReusableCell(BalanceWidget.Key, indexPath) as BalanceWidget;
            balanceWidget?.Configure(_balanceWidgetViewModel);
            return balanceWidget;
          }
          default: {
            var transactionsWidget =
              collectionView.DequeueReusableCell(TransactionsWidget.Key, indexPath) as TransactionsWidget;
            transactionsWidget?.Configure(_transactionsWidgetViewModel);
            return transactionsWidget;
          }
        }
      }

    }

    public class SummaryCollectionViewLayoutDelegate : UICollectionViewDelegateFlowLayout {

      private const float _itemHeight = 50;

      private readonly IAccountsWidgetViewModel _accountsWidgetViewModel;

      public SummaryCollectionViewLayoutDelegate(IAccountsWidgetViewModel accountsWidgetViewModel) {
        _accountsWidgetViewModel = accountsWidgetViewModel;
      }

      public override CGSize GetSizeForItem(UICollectionView collectionView, UICollectionViewLayout layout, NSIndexPath indexPath) {
        switch (indexPath.Row) {
          case 0: {
            var height = _itemHeight * (_accountsWidgetViewModel.Accounts.Count / 3);
            height += _itemHeight * (_accountsWidgetViewModel.Accounts.Count % 3);
            height += 60; //TODO: Count height properly
            return new CGSize(collectionView.Frame.Width - 20, height);
          }
          case 1: {
            return new CGSize(collectionView.Frame.Width - 20, 100);
          }
          default: {
            return new CGSize(collectionView.Frame.Width - 20, 390); //TODO: Count height properly
          }
        }
      }
    }
  }
}

