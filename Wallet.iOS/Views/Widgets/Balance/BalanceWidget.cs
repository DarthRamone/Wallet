using System;

using Foundation;
using GalaSoft.MvvmLight.Helpers;
using UIKit;
using Wallet.Shared.ViewModels.BalanceWidget;

namespace Wallet.iOS {
  public partial class BalanceWidget : UICollectionViewCell {

    private Binding _balanceBinding;

    private IBalanceWidgetViewModel _viewModel;

    public static readonly NSString Key = new NSString("BalanceWidget");
    public static readonly UINib Nib;

    static BalanceWidget() {
      Nib = UINib.FromName("BalanceWidget", NSBundle.MainBundle);
    }

    protected BalanceWidget(IntPtr handle) : base(handle) {
      // Note: this .ctor should not contain any initialization logic.
    }

    public void Configure(IBalanceWidgetViewModel viewModel) {
      _balanceBinding?.Detach();
      _viewModel = viewModel;
      _balanceBinding = this.SetBinding(() => _viewModel.Balance, () => BalanceLabel.Text);
    }

  }
}
