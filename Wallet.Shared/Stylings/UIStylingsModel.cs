namespace Wallet.Shared {

  public class UIStylingsModel : IUIStylingsModel {
    public CrossPlatformColor BackgroundColor { get; set; }
    public CrossPlatformColor BorderColor { get; set; }
    public CrossPlatformColor TintColor { get; set; }
    public CrossPlatformColor OnTintColor { get; set; }
    public CrossPlatformColor TextColor { get; set; }

    public CrossPlatformFont Font { get; set; }

    public float? CornerRadius { get; set; }
    public float? BorderWidth { get; set; }

    public UICorners RoundedCorners { get; set; } = UICorners.All;

    public IUIStylingsModel Copy() {
      return new UIStylingsModel {
        BackgroundColor = BackgroundColor,
        BorderColor = BorderColor,
        TintColor = TintColor,
        OnTintColor = OnTintColor,
        TextColor = TextColor,
        Font = Font,
        CornerRadius = CornerRadius,
        BorderWidth = BorderWidth,
        RoundedCorners = RoundedCorners
      };
    }
  }
}
