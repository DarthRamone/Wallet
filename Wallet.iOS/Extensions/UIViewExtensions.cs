using UIKit;
using Wallet.Shared;

namespace Wallet.iOS {

  public static class UIViewExtensions {

    public static void ApplyStyle(this UIView view, IUIStylingsModel style) {
      if (style.BackgroundColor != null) {
        view.BackgroundColor = style.BackgroundColor.ToNative();
      }

      if (style.BorderColor != null) {
        view.Layer.BorderColor = style.BorderColor.ToNative().CGColor;
      }

      if (style.BorderWidth != null) {
        view.Layer.BorderWidth = style.BorderWidth.Value;
      }

      if (style.CornerRadius != null) {
        view.Layer.CornerRadius = (float)style.CornerRadius;
      }

      if (style.TintColor != null) {
        view.TintColor = style.TintColor.ToNative();
      }
    }
  }
}
