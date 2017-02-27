using GalaSoft.MvvmLight.Helpers;
using Microsoft.Practices.ServiceLocation;
using UIKit;
using Wallet.Shared;

namespace Wallet
{
  public partial class AddRecordViewController : WalletBaseViewController
  {
    IAddRecordViewModel _viewModel;

    private Account _selectedAccount;
    public Account SelectedAccount {
      get { return _selectedAccount; }
      set {
        _selectedAccount = value;
        AccountSelectionButton.SetTitle(value.Name, UIControlState.Normal);
      }
    }

    private Category _selectedCategory;
    public Category SelectedCategory {
      get { return _selectedCategory; }
      set {
        _selectedCategory = value;
        CategorySelectionButton.SetTitle(value.Name, UIControlState.Normal);
      }
    }

    public AddRecordViewController() : base("AddRecordViewController")
    {
      _viewModel = ServiceLocator.Current.GetInstance<IAddRecordViewModel>();
      _selectedAccount = _viewModel.SelectedAccount;
      _selectedCategory = _viewModel.SelectedCategory;
    }

    public override void ViewDidLoad()
    {
      base.ViewDidLoad();
      AddRecordButton.SetCommand(_viewModel.AddRecordAction);
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
      //CommaButton.SetCommand(_viewModel.CommaButtonAction);
      DeleteButton.SetCommand(_viewModel.DeleteButtonAction);
      AccountSelectionButton.SetCommand(_viewModel.AccountSelectionAction);
      CategorySelectionButton.SetCommand(_viewModel.CategorySelectionAction);
      IncomeButton.SetCommand(_viewModel.IncomeButtonAction);
      ExpensesButton.SetCommand(_viewModel.ExpensesButtonAction);
      TransferButton.SetCommand(_viewModel.TransferButtonAction);

      _bindings.Add(this.SetBinding(() => _viewModel.AmountLabelText, () => AmountLabel.Text));
      _bindings.Add(this.SetBinding(() => _viewModel.SelectedAccount, () => SelectedAccount));
      _bindings.Add(this.SetBinding(() => _viewModel.SelectedCategory, () => SelectedCategory));
      _bindings.Add(this.SetBinding(() => _viewModel.ExpensesButtonColor, () => ExpensesButton.BackgroundColor).ConvertSourceToTarget(x => x.ToNative()));  
      _bindings.Add(this.SetBinding(() => _viewModel.IncomeButtonColor, () => IncomeButton.BackgroundColor).ConvertSourceToTarget(x => x.ToNative()));
      _bindings.Add(this.SetBinding(() => _viewModel.TransButtonColor, () => TransferButton.BackgroundColor).ConvertSourceToTarget(x => x.ToNative()));
      _bindings.Add(this.SetBinding(() => _viewModel.SignText, () => SignLabel.Text));

      HolderView.ApplyStyle(_viewModel.MainStyling);
      TemplatesButton.ApplyStyle(_viewModel.MainStyling);
      CategorySelectionButton.ApplyStyle(_viewModel.MainStyling);
      AccountSelectionButton.ApplyStyle(_viewModel.MainStyling);
      MiddleImageView.ApplyStyle(_viewModel.MainStyling);
    }
  }
}

