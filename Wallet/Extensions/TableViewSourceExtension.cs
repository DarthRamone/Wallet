using System;
using Foundation;
using GalaSoft.MvvmLight.Helpers;
using UIKit;

namespace Wallet.iOS {

  public class TableViewSourceExtension<TViewModel> : ObservableTableViewSource<TViewModel> where TViewModel : class {

    private readonly Action<TViewModel> _onCellSelected;

    public TableViewSourceExtension(Action<TViewModel> onCellSelected) {
      _onCellSelected = onCellSelected;
    }

    public override UITableViewCell GetCell(UITableView view, NSIndexPath indexPath) {
      var cell = view.DequeueReusableCell(ReuseId, indexPath);
      BindCellDelegate?.Invoke(cell, GetItem(indexPath), indexPath);
      return cell;
    }

    public override void RowSelected(UITableView tableView, NSIndexPath indexPath) {
      base.RowSelected(tableView, indexPath);

      _onCellSelected?.Invoke(GetItem(indexPath));
    }

  }

  public class CollectionViewSourceExtension<TVIewModel, TCell> : ObservableCollectionViewSource<TVIewModel, TCell> where TCell : UICollectionViewCell
                                                                                                                      where TVIewModel : class {
    private readonly string _reuseId;
    private readonly Action<TVIewModel> _onCellSelected;
    private readonly Action<TVIewModel> _onCellDeselected;

    public CollectionViewSourceExtension(string reuseId,
                                         Action<TVIewModel> onCellSelected = null,
                                         Action<TVIewModel> onCellDeselected = null) {
      _reuseId = reuseId;
      _onCellSelected = onCellSelected;
      _onCellDeselected = onCellDeselected;
    }

    public override UICollectionViewCell GetCell(UICollectionView view, NSIndexPath indexPath) {
      var cell = view.DequeueReusableCell(_reuseId, indexPath);
      var item = GetItem(indexPath);
      BindCellDelegate?.Invoke(cell as TCell, item, indexPath);

      return cell as UICollectionViewCell;
    }

    public override void ItemDeselected(UICollectionView collectionView, NSIndexPath indexPath) {
      var vm = GetItem(indexPath);
      _onCellDeselected?.Invoke(vm);
    }

    public override void ItemSelected(UICollectionView collectionView, NSIndexPath indexPath) {
      var vm = GetItem(indexPath);
      _onCellSelected?.Invoke(vm);
    }
  }

}
