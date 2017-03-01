using System;

using Foundation;
using UIKit;

namespace Wallet.iOS {
  public partial class CategoryTableViewCell : UITableViewCell {
    public static readonly NSString Key = new NSString("CategoryTableViewCell");
    public static readonly UINib Nib;

    static CategoryTableViewCell() {
      Nib = UINib.FromName("CategoryTableViewCell", NSBundle.MainBundle);
    }

    protected CategoryTableViewCell(IntPtr handle) : base(handle) {
      // Note: this .ctor should not contain any initialization logic.
    }
  }
}
