using System.Collections.Generic;
using GalaSoft.MvvmLight.Helpers;
using UIKit;

namespace Wallet.iOS
{
  public class WalletBaseViewController : UIViewController
  {
    protected readonly List<Binding> _bindings;

    public WalletBaseViewController(string nibName) : base(nibName, null)
    {
      _bindings = new List<Binding>();
    }
  }
}
