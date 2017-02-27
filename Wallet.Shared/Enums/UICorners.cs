using System;
namespace Wallet.Shared {
  
  [Flags]
  public enum UICorners {
    TopLeft = 1,
    TopRight = 2,
    BottomLeft = 4,
    BottomRight = 8,
    All = 15
  }

}
