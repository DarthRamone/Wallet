using System;
using System.Collections.Generic;
using Foundation;
using GalaSoft.MvvmLight.Helpers;
using UIKit;

namespace Wallet
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
