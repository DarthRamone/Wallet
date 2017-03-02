using System;
using System.Collections.Specialized;
using CoreGraphics;
using Foundation;
using Microsoft.Practices.ServiceLocation;
using UIKit;
using Wallet.Shared.ViewModels;

namespace Wallet.iOS {

  public partial class NewSummaryViewController : WalletBaseViewController {

    private readonly IAccountsWidgetViewModel _accountsWidgetViewModel;

    public NewSummaryViewController() : base("NewSummaryViewController") {
      _accountsWidgetViewModel = ServiceLocator.Current.GetInstance<IAccountsWidgetViewModel>();
      _accountsWidgetViewModel.Accounts.CollectionChanged += AccountsCollectionChanged;
    }

    public override void ViewDidLoad() {
      base.ViewDidLoad();
      WidgetsCollectionView.BackgroundColor = UIColor.Brown;
      WidgetsCollectionView.RegisterNibForCell(AccountsWidgetCell.Nib, AccountsWidgetCell.Key);
      WidgetsCollectionView.Source = new SummaryCollectionViewSource(_accountsWidgetViewModel);
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

    }


    public class SummaryCollectionViewSource : UICollectionViewSource {

      private readonly IAccountsWidgetViewModel _accountsWidgetViewModel;

      public SummaryCollectionViewSource(IAccountsWidgetViewModel accountsWidgetViewModel) {
        _accountsWidgetViewModel = accountsWidgetViewModel;
      }

      public override nint NumberOfSections(UICollectionView collectionView) => 1;

      public override nint GetItemsCount(UICollectionView collectionView, nint section) => 1;

      public override UICollectionViewCell GetCell(UICollectionView collectionView, NSIndexPath indexPath) {
        var cell = collectionView.DequeueReusableCell(AccountsWidgetCell.Key, indexPath) as AccountsWidgetCell;
        cell.BackgroundColor = UIColor.Blue;
        cell.Configure(_accountsWidgetViewModel);
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
            height += 30;//TODO
            return new CGSize(collectionView.Frame.Width - 20, height);
          }
          default: {
            return new CGSize(collectionView.Frame.Width - 20, 200);
          }
        }
      }
    }
  }
}

