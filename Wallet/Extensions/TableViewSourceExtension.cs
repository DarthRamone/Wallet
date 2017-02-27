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

}
