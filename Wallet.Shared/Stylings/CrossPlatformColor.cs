using System;
namespace Wallet.Shared {
  
  public class CrossPlatformColor : IEquatable<CrossPlatformColor> {
    public int Red { get; set; }

    public int Blue { get; set; }

    public int Green { get; set; }

    public int Alpha { get; set; }

    public CrossPlatformColor(int red, int green, int blue, int alpha = 255) {
      Red = red;
      Green = green;
      Blue = blue;
      Alpha = alpha;
    }


    #region IEquatable implementation

    public bool Equals(CrossPlatformColor other) {
      bool isEqual = false;
      if (Blue == other.Blue && 
          Green == other.Green && 
          Red == other.Red && 
          Alpha == other.Alpha) {
        isEqual = true;
      }

      return isEqual;
    }

    #endregion
  }

}
