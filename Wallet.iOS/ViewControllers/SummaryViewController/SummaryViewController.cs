﻿using UIKit;
using System;
using CoreGraphics;
using Foundation;
using GalaSoft.MvvmLight.Helpers;
using Microsoft.Practices.ServiceLocation;
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

      _accountsWidgetViewModel.OnAccountsChanged += AccountsCollectionChanged;
      _transactionsWidgetViewModel.OnTransactionsChanged += TransactionsChanged;
    }

    public override void ViewDidLoad() {
      base.ViewDidLoad();

      AddRecordButton.SetCommand(_summaryViewModel.AddRecordButtonAction);

      WidgetsCollectionView.BackgroundColor = UIColor.Brown;

      WidgetsCollectionView.RegisterNibForCell(BalanceWidget.Nib, BalanceWidget.Key);
      WidgetsCollectionView.RegisterNibForCell(AccountsWidgetCell.Nib, AccountsWidgetCell.Key);
      WidgetsCollectionView.RegisterNibForCell(TransactionsWidget.Nib, TransactionsWidget.Key);

      WidgetsCollectionView.Source = new SummaryCollectionViewSource(_balanceWidgetViewModel, _accountsWidgetViewModel, _transactionsWidgetViewModel);
      WidgetsCollectionView.Delegate = new SummaryCollectionViewLayoutDelegate(_accountsWidgetViewModel, _transactionsWidgetViewModel);
      WidgetsCollectionView.SetCollectionViewLayout(WidgetsCollectionViewFlowLayout, false);
    }

    public override void ViewWillAppear(bool animated) {
      base.ViewWillAppear(animated);
      var hSectionInset = WidgetsCollectionViewFlowLayout.SectionInset.Left;
      WidgetsCollectionViewFlowLayout.ItemSize = new CGSize(View.Frame.Width - hSectionInset * 8, 200);
    }

    //TODO: Unsubscribe
    private void AccountsCollectionChanged(object sender, EventArgs e) {
      WidgetsCollectionView.ReloadItems(new[] { NSIndexPath.FromRowSection(0, 0) });
    }

    //TODO: Unsubscribe
    private void TransactionsChanged(object sender, EventArgs e) {
      WidgetsCollectionView.ReloadItems(new[] { NSIndexPath.FromRowSection(1, 0) });
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

      private const float _titleHeight = 28;
      private const float _accountCellHeight = 50;
      private const float _minimumLineSpacing = 10;
      private const float _transactionCellHeight = 60;

      private UIEdgeInsets _sectionEdgeInsets = new UIEdgeInsets(10, 10, 10, 10);

      private readonly IAccountsWidgetViewModel _accountsWidgetViewModel;
      private readonly ITransactionsWidgetViewModel _transactionsWidgetViewModel;

      public SummaryCollectionViewLayoutDelegate(
        IAccountsWidgetViewModel accountsWidgetViewModel,
        ITransactionsWidgetViewModel transactionsWidgetViewModel) {

        _accountsWidgetViewModel = accountsWidgetViewModel;
        _transactionsWidgetViewModel = transactionsWidgetViewModel;
      }

      public override nfloat GetMinimumLineSpacingForSection(UICollectionView collectionView, UICollectionViewLayout layout, nint section) {
        return _minimumLineSpacing;
      }

      public override UIEdgeInsets GetInsetForSection(UICollectionView collectionView, UICollectionViewLayout layout, nint section) {
        return _sectionEdgeInsets;
      }

      public override CGSize GetSizeForItem(UICollectionView collectionView, UICollectionViewLayout layout, NSIndexPath indexPath) {
        
        var width = collectionView.Frame.Width - _sectionEdgeInsets.Left - _sectionEdgeInsets.Right;

        switch (indexPath.Row) {
          case 0: {
            var linesCount = _accountsWidgetViewModel.Accounts.Count / 3;
            linesCount += _accountsWidgetViewModel.Accounts.Count % 3 == 0 ? 0 : 1;
            nfloat height = _accountCellHeight * linesCount;
            height += _minimumLineSpacing * (linesCount - 1);
            height += _sectionEdgeInsets.Top + _sectionEdgeInsets.Bottom + _titleHeight;
            return new CGSize(width, height);
          }
          case 1: {
            return new CGSize(width, 100);
          }
          default: {
            var height = _transactionCellHeight * _transactionsWidgetViewModel.Transactions.Count;
            return new CGSize(width, height + _titleHeight + 64);
          }
        }
      }
    }
  }
}

