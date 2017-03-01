using System;

using Foundation;
using UIKit;

namespace Wallet.iOS {
  public partial class AccountTableViewCell : UITableViewCell {
    public static readonly NSString Key = new NSString("AccountTableViewCell");
    public static readonly UINib Nib;

    static AccountTableViewCell() {
      Nib = UINib.FromName("AccountTableViewCell", NSBundle.MainBundle);
    }

    protected AccountTableViewCell(IntPtr handle) : base(handle) {
      // Note: this .ctor should not contain any initialization logic.
    }
  }
}
