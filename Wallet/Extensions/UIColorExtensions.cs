using System;
using UIKit;
using Wallet.Shared;

namespace Wallet {
  
  public static class UIColorExtensions {

    public static UIColor ToNative(this CrossPlatformColor color) {

      return UIColor.FromRGBA(color.Red, color.Green, color.Blue, color.Alpha);

    }
  }

}
