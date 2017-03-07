using System;

using Foundation;
using UIKit;
using Wallet.Shared.Models;

namespace Wallet.iOS
{
  public partial class RecordTableViewCell : UITableViewCell
  {
    private UIColor _green = UIColor.FromRGB(48, 183, 48);

    public static readonly NSString Key = new NSString("RecordTableViewCell");
    public static readonly UINib Nib;

    static RecordTableViewCell()
    {
      Nib = UINib.FromName("RecordTableViewCell", NSBundle.MainBundle);
    }

    protected RecordTableViewCell(IntPtr handle) : base(handle)
    {
      // Note: this .ctor should not contain any initialization logic.
    }

    public void ConfigureFor(WalletTransaction transaction) {
      CategoryNameLabel.Text = transaction.Category.Name;
      AmountLabel.Text = transaction.Amount.ToString($"C{CurrenciesList.GetCurrency(transaction.Account.Currency).Symbol}");
      DateLabel.Text = transaction.Date.Date.ToString("d");
      AccountNameLabel.Text = transaction.Account.Name;
      AmountLabel.TextColor = transaction.Amount < 0 ? UIColor.Red : _green;
      CategoryImageView.Image = UIImage.FromFile("shopping");
    }
  }
}
