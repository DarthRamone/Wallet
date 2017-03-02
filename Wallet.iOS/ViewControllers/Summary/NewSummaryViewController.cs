using System;
using System.Collections.Specialized;
using CoreGraphics;
using Foundation;
using GalaSoft.MvvmLight.Helpers;
using Microsoft.Practices.ServiceLocation;
using UIKit;
using Wallet.Shared.ViewModels;

namespace Wallet.iOS {

  public partial class NewSummaryViewController : WalletBaseViewController {

    private readonly ISummaryViewModel _summaryViewModel;

    private readonly IAccountsWidgetViewModel _accountsWidgetViewModel;

    private readonly ITransactionsWidgetViewModel _transactionsWidgetViewModel;

    public NewSummaryViewController() : base("NewSummaryViewController") {
      _summaryViewModel = ServiceLocator.Current.GetInstance<ISummaryViewModel>();
      _accountsWidgetViewModel = ServiceLocator.Current.GetInstance<IAccountsWidgetViewModel>();
      _transactionsWidgetViewModel = ServiceLocator.Current.GetInstance<ITransactionsWidgetViewModel>();

      _accountsWidgetViewModel.Accounts.CollectionChanged += AccountsCollectionChanged;
    }

    public override void ViewDidLoad() {
      base.ViewDidLoad();

      AddRecordButton.SetCommand(_summaryViewModel.AddRecordButtonAction);

      WidgetsCollectionView.BackgroundColor = UIColor.Brown;
      WidgetsCollectionView.RegisterNibForCell(AccountsWidgetCell.Nib, AccountsWidgetCell.Key);
      WidgetsCollectionView.RegisterNibForCell(TransactionsWidget.Nib, TransactionsWidget.Key);
      WidgetsCollectionView.Source = new SummaryCollectionViewSource(_accountsWidgetViewModel, _transactionsWidgetViewModel);
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

      private readonly IAccountsWidgetViewModel _accountsWidgetViewModel;
      private readonly ITransactionsWidgetViewModel _transactionsWidgetViewModel;

      public SummaryCollectionViewSource(
        IAccountsWidgetViewModel accountsWidgetViewModel,
        ITransactionsWidgetViewModel transactionsWidgetViewModel) {
        _accountsWidgetViewModel = accountsWidgetViewModel;
        _transactionsWidgetViewModel = transactionsWidgetViewModel;
      }

      public override nint NumberOfSections(UICollectionView collectionView) => 1;

      public override nint GetItemsCount(UICollectionView collectionView, nint section) => 2;

      public override UICollectionViewCell GetCell(UICollectionView collectionView, NSIndexPath indexPath) {
        
        if (indexPath.Row == 0) {
          var _accountWidgetCell = collectionView.DequeueReusableCell(AccountsWidgetCell.Key, indexPath) as AccountsWidgetCell;
          _accountWidgetCell.Configure(_accountsWidgetViewModel);
          return _accountWidgetCell;
        }

        var cell = collectionView.DequeueReusableCell(TransactionsWidget.Key, indexPath) as TransactionsWidget;
        cell.Configure(_transactionsWidgetViewModel);
        return cell;
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
            height += 60;//TODO: Count height properly
            return new CGSize(collectionView.Frame.Width - 20, height);
          }
          default: {
            return new CGSize(collectionView.Frame.Width - 20, 390); //TODO: Count height properly
          }
        }
      }
    }
  }
}

