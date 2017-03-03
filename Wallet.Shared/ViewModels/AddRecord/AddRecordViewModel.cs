using System;
using System.Threading.Tasks;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using Wallet.Shared.Models;
using Wallet.Shared.Repositories.Accounts;
using Wallet.Shared.Repositories.Categories;
using Wallet.Shared.Repositories.Transactions;

namespace Wallet.Shared.ViewModels.AddRecord {

  public class AddRecordViewModel : WalletBaseViewModel, IAddRecordViewModel {

    private const string Zero = "0";
    private const string One = "1";
    private const string Two = "2";
    private const string Three = "3";
    private const string Four = "4";
    private const string Five = "5";
    private const string Six = "6";
    private const string Seven = "7";
    private const string Eight = "8";
    private const string Nine = "9";

    //HACK
    public bool IsRightButtonTapped { get; set; }

    private CrossPlatformColor _defaultColor;
    private CrossPlatformColor _selectedColor;

    private readonly IAccountsRepository _accountsRepository;
    private readonly ICategoriesRepository _categoriesRepository;
    private readonly ITransactionsRepository _transactionsRepository;

    private string _amountLabelText = Zero;
    public string AmountLabelText {
      get { return _amountLabelText; }
      set {
        _amountLabelText = value;
        RaisePropertyChanged(() => AmountLabelText);
      }
    }

    private string _leftButtonText;
    public string LeftButtonText {
      get { return _leftButtonText; }
      set {
        _leftButtonText = value;
        RaisePropertyChanged(() => LeftButtonText);
      }
    }

    private string _rightButtonText;
    public string RightButtonText {
      get { return _rightButtonText; }
      set {
        _rightButtonText = value;
        RaisePropertyChanged(() => RightButtonText);
      }
    }

    private string _signText = "-";
    public string SignText {
      get { return _signText; }
      set {
        _signText = value;
        RaisePropertyChanged(() => SignText);
      }
    }

    public RelayCommand Button0Action { get; private set; }
    public RelayCommand Button1Action { get; private set; }
    public RelayCommand Button2Action { get; private set; }
    public RelayCommand Button3Action { get; private set; }
    public RelayCommand Button4Action { get; private set; }
    public RelayCommand Button5Action { get; private set; }
    public RelayCommand Button6Action { get; private set; }
    public RelayCommand Button7Action { get; private set; }
    public RelayCommand Button8Action { get; private set; }
    public RelayCommand Button9Action { get; private set; }
    public RelayCommand AddRecordAction { get; private set; }
    public RelayCommand LeftButtonAction { get; private set; }
    public RelayCommand CommaButtonAction { get; private set; }
    public RelayCommand RightButtonAction { get; private set; }
    public RelayCommand DeleteButtonAction { get; private set; }
    public RelayCommand IncomeButtonAction { get; private set; }
    public RelayCommand ExpensesButtonAction { get; private set; }
    public RelayCommand TransferButtonAction { get; private set; }

    private CrossPlatformColor _incomeButtonColor;
    public CrossPlatformColor IncomeButtonColor { 
      get { return _incomeButtonColor; }
      set {
        _incomeButtonColor = value;
        RaisePropertyChanged(() => IncomeButtonColor);
      }
    }

    private CrossPlatformColor _expensesButtonColor;
    public CrossPlatformColor ExpensesButtonColor {
      get { return _expensesButtonColor; }
      set {
        _expensesButtonColor = value;
        RaisePropertyChanged(() => ExpensesButtonColor);
      }
    }

    private CrossPlatformColor _transButtonColor;
    public CrossPlatformColor TransButtonColor { 
      get { return _transButtonColor; }
      set {
        _transButtonColor = value;
        RaisePropertyChanged(() => TransButtonColor);
      }
    }

    public TransactionType TransactionType { get; private set; } = TransactionType.EXPENSES;

    public IUIStylingsModel MainStyling { get; private set; }

    public AddRecordViewModel(INavigationService navService,
                              IAccountsRepository accountsRepository,
                              ICategoriesRepository categoriesRepository,
                              ITransactionsRepository transactionsRepository)
      : base(navService) {

      _accountsRepository = accountsRepository;
      _categoriesRepository = categoriesRepository;
      _transactionsRepository = transactionsRepository;

      //HACK
      LeftButtonText = accountsRepository.Items[0].Name;
      RightButtonText = categoriesRepository.Items.Find(cat => cat.Name != "Transfer").Name;
      SetActions();
      SetStylings();
    }

    private void SetStylings() {
      _defaultColor = new CrossPlatformColor(237, 107, 149);
      _selectedColor = new CrossPlatformColor(237, 107, 149, 200);

      MainStyling = new UIStylingsModel { BackgroundColor = _defaultColor };

      _incomeButtonColor = _defaultColor;
      _expensesButtonColor = _selectedColor;
      _transButtonColor = _defaultColor;
    }

    private async Task ProcessBasicTransaction() {
      var transaction = new WalletTransaction();
      double amount;

      if (double.TryParse(AmountLabelText, out amount)) {
        
        if (TransactionType == TransactionType.EXPENSES)
          transaction.Amount = -amount;
        else
          transaction.Amount = amount;

        transaction.Date = new DateTimeOffset(DateTime.Now);
        await _transactionsRepository.AddTransaction(transaction, _rightButtonText, _leftButtonText);
      }
    }

    private async Task ProcessTransferTransaction() {
      var transaction = new TransferTransaction();
      double amount;
      if (double.TryParse(AmountLabelText, out amount)) {
        transaction.Amount = amount;
        await _transactionsRepository.AddTransferTransaction(transaction, _leftButtonText, _rightButtonText);
      }
    }

    private void SetActions() {
      
      AddRecordAction = new RelayCommand(async () => {
        
        switch (TransactionType) {
          case TransactionType.EXPENSES:
          await ProcessBasicTransaction();
            break;
          case TransactionType.INCOME:
            await ProcessBasicTransaction();
            break;
          case TransactionType.TRANSFER:
            await ProcessTransferTransaction();
            break;
        }

        _navigationService.GoBack();
      }, () => true);

      Button0Action = new RelayCommand(() => {
        if (AmountLabelText.Equals(Zero))
          return;
        AmountLabelText = AmountLabelText + Zero;
      }, () => true);

      Button1Action = new RelayCommand(() => {
        if (AmountLabelText.Equals(Zero)) {
          AmountLabelText = One;
          return;
        }
        AmountLabelText = AmountLabelText + One;
      }, () => true);

      Button2Action = new RelayCommand(() => {
        if (AmountLabelText.Equals(Zero)) {
          AmountLabelText = Two;
          return;
        }
        AmountLabelText = AmountLabelText + Two;
      }, () => true);

      Button3Action = new RelayCommand(() => {
        if (AmountLabelText.Equals(Zero)) {
          AmountLabelText = Three;
          return;
        }
        AmountLabelText = AmountLabelText + Three;
      }, () => true);

      Button4Action = new RelayCommand(() => {
        if (AmountLabelText.Equals(Zero)) {
          AmountLabelText = Four;
          return;
        }
        AmountLabelText = AmountLabelText + Four;
      }, () => true);

      Button5Action = new RelayCommand(() => {
        if (AmountLabelText.Equals(Zero)) {
          AmountLabelText = Five;
          return;
        }
        AmountLabelText = AmountLabelText + Five;
      }, () => true);

      Button6Action = new RelayCommand(() => {
        if (AmountLabelText.Equals(Zero)) {
          AmountLabelText = Six;
          return;
        }
        AmountLabelText = AmountLabelText + Six;
      }, () => true);

      Button7Action = new RelayCommand(() => {
        if (AmountLabelText.Equals(Zero)) {
          AmountLabelText = Seven;
          return;
        }
        AmountLabelText = AmountLabelText + Seven;
      }, () => true);

      Button8Action = new RelayCommand(() => {
        if (AmountLabelText.Equals(Zero)) {
          AmountLabelText = Eight;
          return;
        }
        AmountLabelText = AmountLabelText + Eight;
      }, () => true);

      Button9Action = new RelayCommand(() => {
        if (AmountLabelText.Equals(Zero)) {
          AmountLabelText = Nine;
          return;
        }
        AmountLabelText = AmountLabelText + Nine;
      }, () => true);

      DeleteButtonAction = new RelayCommand(() => {
        if (AmountLabelText.Length == 1) {
          AmountLabelText = Zero;
          return;
        }
        AmountLabelText = AmountLabelText.Remove(AmountLabelText.Length - 1);
      }, () => true);

      CommaButtonAction = new RelayCommand(() => {
      }, () => true);

      LeftButtonAction = new RelayCommand(() => {
        IsRightButtonTapped = false;
        _navigationService.NavigateTo(Pages.AccountSelectionViewControllerKey, this);
      }, () => true);

      RightButtonAction = new RelayCommand(() => {
        IsRightButtonTapped = true;
        if (TransactionType == TransactionType.TRANSFER) {
          _navigationService.NavigateTo(Pages.AccountSelectionViewControllerKey, this);
        } else {
          _navigationService.NavigateTo(Pages.CategorySelectionViewControllerKey, this);
        }
      }, () => true);

      ExpensesButtonAction = new RelayCommand(() => {
        IncomeButtonColor = _defaultColor;
        TransButtonColor = _defaultColor;
        ExpensesButtonColor = _selectedColor;
        SignText = "-";

        if (TransactionType == TransactionType.TRANSFER)
          RightButtonText = _categoriesRepository.Items.Find(cat => cat.Name != "Transfer").Name;

        TransactionType = TransactionType.EXPENSES;
      }, () => true);

      IncomeButtonAction = new RelayCommand(() => {
        IncomeButtonColor = _selectedColor;
        TransButtonColor = _defaultColor;
        ExpensesButtonColor = _defaultColor;
        SignText = "+";

        if (TransactionType == TransactionType.TRANSFER)
          RightButtonText = _categoriesRepository.Items.Find(cat => cat.Name != "Transfer").Name;

        TransactionType = TransactionType.INCOME;

      }, () => true);

      TransferButtonAction = new RelayCommand(() => {
        if (_accountsRepository.Items.Count <= 1) return;
        IncomeButtonColor = _defaultColor;
        TransButtonColor = _selectedColor;
        ExpensesButtonColor = _defaultColor;
        SignText = string.Empty;

        if (TransactionType != TransactionType.TRANSFER)
          RightButtonText = _accountsRepository.Items.Find(acc => acc.Name != _leftButtonText).Name;

        TransactionType = TransactionType.TRANSFER;
      }, () => true);
    }
  }
}
