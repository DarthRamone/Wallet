using System;

using Foundation;
using UIKit;

namespace Wallet
{
  public partial class RecordTableViewCell : UITableViewCell
  {
    public static readonly NSString Key = new NSString("RecordTableViewCell");
    public static readonly UINib Nib;

    static RecordTableViewCell()
    {
      Nib = UINib.FromName("RecordTableViewCell", NSBundle.MainBundle);
    }

    protected RecordTableViewCell(IntPtr handle) : base(handle)
    {
      // Note: this .ctor should not contain any initialization logic.
    }
  }
}
