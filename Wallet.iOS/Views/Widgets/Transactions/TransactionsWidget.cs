using System;

using Foundation;
using UIKit;

namespace Wallet.iOS {
  public partial class TransactionsWidget : UICollectionViewCell {
    public static readonly NSString Key = new NSString("TransactionsWidget");
    public static readonly UINib Nib;

    static TransactionsWidget() {
      Nib = UINib.FromName("TransactionsWidget", NSBundle.MainBundle);
    }

    protected TransactionsWidget(IntPtr handle) : base(handle) {
      // Note: this .ctor should not contain any initialization logic.
    }
  }
}
