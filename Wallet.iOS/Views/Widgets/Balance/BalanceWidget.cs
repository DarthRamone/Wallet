using System;

using Foundation;
using UIKit;

namespace Wallet.iOS {
  public partial class BalanceWidget : UICollectionViewCell {
    public static readonly NSString Key = new NSString("BalanceWidget");
    public static readonly UINib Nib;

    static BalanceWidget() {
      Nib = UINib.FromName("BalanceWidget", NSBundle.MainBundle);
    }

    protected BalanceWidget(IntPtr handle) : base(handle) {
      // Note: this .ctor should not contain any initialization logic.
    }
  }
}
