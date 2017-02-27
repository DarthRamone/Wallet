using System;
namespace Wallet.Shared {


  public class CrossPlatformFont {
    
    public string FontName { get; set; }

    public int FontSize { get; set; }

    public CrossPlatformFont(string fontName, int fontSize) {
      this.FontName = fontName;
      this.FontSize = fontSize;
    }
  }

}
