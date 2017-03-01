using UIKit;
using Wallet.Shared;

namespace Wallet.iOS {
  
  public static class UIColorExtensions {

    public static UIColor ToNative(this CrossPlatformColor color) {

      return UIColor.FromRGBA(color.Red, color.Green, color.Blue, color.Alpha);

    }
  }

}
