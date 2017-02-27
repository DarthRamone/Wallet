namespace Wallet.Shared {
  
  public interface IUIStylingsModel {
    
    CrossPlatformColor BackgroundColor { get; set; }
    CrossPlatformColor BorderColor { get; set; }
    CrossPlatformColor TintColor { get; set; }
    CrossPlatformColor OnTintColor { get; set; }
    CrossPlatformColor TextColor { get; set; }

    CrossPlatformFont Font { get; set; }

    float? CornerRadius { get; set; }
    float? BorderWidth { get; set; }

    UICorners RoundedCorners { get; set; }

    IUIStylingsModel Copy();

  }

}
