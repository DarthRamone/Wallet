using System;

using Foundation;
using UIKit;

namespace Wallet {
  public partial class AccountCollectionViewCell : UICollectionViewCell {
    public static readonly NSString Key = new NSString("AccountCollectionViewCell");
    public static readonly UINib Nib;

    static AccountCollectionViewCell() {
      Nib = UINib.FromName("AccountCollectionViewCell", NSBundle.MainBundle);
    }

    protected AccountCollectionViewCell(IntPtr handle) : base(handle) {
      // Note: this .ctor should not contain any initialization logic.
    }
  }
}
