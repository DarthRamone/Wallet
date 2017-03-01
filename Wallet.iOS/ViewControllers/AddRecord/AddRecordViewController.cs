using GalaSoft.MvvmLight.Helpers;
using Microsoft.Practices.ServiceLocation;
using UIKit;
using Wallet.Shared.ViewModels;

namespace Wallet.iOS
{
  public partial class AddRecordViewController : WalletBaseViewController
  {

    readonly IAddRecordViewModel _viewModel;

    public string LeftButtonText {
      get { return LeftButton.Title(UIControlState.Normal); }
      set { LeftButton.SetTitle(value, UIControlState.Normal); }
    }

    public string RightButtonText {
      get { return RightButton.Title(UIControlState.Normal); }
      set { RightButton.SetTitle(value, UIControlState.Normal); }
    }

    public AddRecordViewController() : base("AddRecordViewController")
    {
      _viewModel = ServiceLocator.Current.GetInstance<IAddRecordViewModel>();
    }

    public override void ViewDidLoad()
    {
      base.ViewDidLoad();

      Button0.SetCommand(_viewModel.Button0Action);
      Button1.SetCommand(_viewModel.Button1Action);
      Button2.SetCommand(_viewModel.Button2Action);
      Button3.SetCommand(_viewModel.Button3Action);
      Button4.SetCommand(_viewModel.Button4Action);
      Button5.SetCommand(_viewModel.Button5Action);
      Button6.SetCommand(_viewModel.Button6Action);
      Button7.SetCommand(_viewModel.Button7Action);
      Button8.SetCommand(_viewModel.Button8Action);
      Button9.SetCommand(_viewModel.Button9Action);
      LeftButton.SetCommand(_viewModel.LeftButtonAction);
      CommaButton.SetCommand(_viewModel.CommaButtonAction);
      RightButton.SetCommand(_viewModel.RightButtonAction);
      AddRecordButton.SetCommand(_viewModel.AddRecordAction);
      DeleteButton.SetCommand(_viewModel.DeleteButtonAction);
      IncomeButton.SetCommand(_viewModel.IncomeButtonAction);
      ExpensesButton.SetCommand(_viewModel.ExpensesButtonAction);
      TransferButton.SetCommand(_viewModel.TransferButtonAction);

      _bindings.Add(this.SetBinding(() => _viewModel.SignText, () => SignLabel.Text));
      _bindings.Add(this.SetBinding(() => _viewModel.LeftButtonText, () => LeftButtonText));
      _bindings.Add(this.SetBinding(() => _viewModel.RightButtonText, () => RightButtonText));
      _bindings.Add(this.SetBinding(() => _viewModel.AmountLabelText, () => AmountLabel.Text));
      _bindings.Add(this.SetBinding(() => _viewModel.IncomeButtonColor, () => IncomeButton.BackgroundColor).ConvertSourceToTarget(x => x.ToNative()));
      _bindings.Add(this.SetBinding(() => _viewModel.TransButtonColor, () => TransferButton.BackgroundColor).ConvertSourceToTarget(x => x.ToNative()));
      _bindings.Add(this.SetBinding(() => _viewModel.ExpensesButtonColor, () => ExpensesButton.BackgroundColor).ConvertSourceToTarget(x => x.ToNative()));

      HolderView.ApplyStyle(_viewModel.MainStyling);
      TemplatesButton.ApplyStyle(_viewModel.MainStyling);
      RightButton.ApplyStyle(_viewModel.MainStyling);
      LeftButton.ApplyStyle(_viewModel.MainStyling);
      MiddleImageView.ApplyStyle(_viewModel.MainStyling);
    }
  }
}

