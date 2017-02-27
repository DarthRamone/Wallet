using System;
using Foundation;
using GalaSoft.MvvmLight.Helpers;
using UIKit;

namespace Wallet {

  public class TableViewSourceExtension<TViewModel> : ObservableTableViewSource<TViewModel> where TViewModel : class {
    
    Action<TViewModel> onCellSelected;

    public TableViewSourceExtension(Action<TViewModel> onCellSelected) {
      this.onCellSelected = onCellSelected;
    }

    public override UITableViewCell GetCell(UITableView view, NSIndexPath indexPath) {
      var cell = view.DequeueReusableCell(ReuseId, indexPath);
      BindCellDelegate?.Invoke(cell, GetItem(indexPath), indexPath);
      return cell;
    }

    public override void RowSelected(UITableView tableView, NSIndexPath indexPath) {
      base.RowSelected(tableView, indexPath);

      onCellSelected?.Invoke(GetItem(indexPath));
    }

  }

  public class CollectionViewSourceExtension<TVIewModel, TCell> : ObservableCollectionViewSource<TVIewModel, TCell> where TCell : UICollectionViewCell
                                                                                                                      where TVIewModel : class {
    string reuseId;
    Action<TVIewModel> onCellSelected;
    Action<TVIewModel> onCellDeselected;

    public CollectionViewSourceExtension(string reuseId,
                                         Action<TVIewModel> onCellSelected = null,
                                         Action<TVIewModel> onCellDeselected = null) {
      this.reuseId = reuseId;
      this.onCellSelected = onCellSelected;
      this.onCellDeselected = onCellDeselected;
    }

    public override UICollectionViewCell GetCell(UICollectionView view, NSIndexPath indexPath) {
      var cell = view.DequeueReusableCell(reuseId, indexPath);
      var item = GetItem(indexPath);
      BindCellDelegate?.Invoke(cell as TCell, item, indexPath);

      return cell as UICollectionViewCell;
    }

    public override void ItemDeselected(UICollectionView collectionView, NSIndexPath indexPath) {
      var vm = GetItem(indexPath);
      onCellDeselected?.Invoke(vm);
    }

    public override void ItemSelected(UICollectionView collectionView, NSIndexPath indexPath) {
      var vm = GetItem(indexPath);
      onCellSelected?.Invoke(vm);
    }
  }

}
