using System;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;

namespace Wallet.Shared {
  public class AddRecordViewModel : WalletBaseViewModel, IAddRecordViewModel {

    const string ZERO = "0";
    const string ONE = "1";
    const string TWO = "2";
    const string THREE = "3";
    const string FOUR = "4";
    const string FIVE = "5";
    const string SIX = "6";
    const string SEVEN = "7";
    const string EIGHT = "8";
    const string NINE = "9";

    private CrossPlatformColor _defaultColor;
    private CrossPlatformColor _selectedColor;

    private TransactionType _transactionType = TransactionType.EXPENSES;

    private IAccountsRepository _accountsRepository;
    private ITransactionsRepository _transactionsRepository;

    private Account _sourceAccount;
    private Account _targetAccount;

    private Category _selectedCategory;

    private string _amountLabelText = ZERO;
    public string AmountLabelText {
      get {
        return _amountLabelText;
      }
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

    string _signText = "-";
    public string SignText {
      get { return _signText; }
      set {
        _signText = value;
        RaisePropertyChanged(() => SignText);
      }
    }

    public RelayCommand AddRecordAction { get; private set; }
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
    public RelayCommand CommaButtonAction { get; private set; }
    public RelayCommand DeleteButtonAction { get; private set; }
    public RelayCommand LeftButtonAction { get; private set; }
    public RelayCommand RightButtonAction { get; private set; }

    public RelayCommand IncomeButtonAction { get; private set; }
    public RelayCommand ExpensesButtonAction { get; private set; }
    public RelayCommand TransferButtonAction { get; private set; }

    public CrossPlatformColor _incomeButtonColor;
    public CrossPlatformColor IncomeButtonColor { 
      get { return _incomeButtonColor; }
      set {
        _incomeButtonColor = value;
        RaisePropertyChanged(() => IncomeButtonColor);
      }
    }

    public CrossPlatformColor _expensesButtonColor;
    public CrossPlatformColor ExpensesButtonColor { 
      get { return _expensesButtonColor; }
      set {
        _expensesButtonColor = value;
        RaisePropertyChanged(() => ExpensesButtonColor);
      }
    }

    public CrossPlatformColor _transButtonColor;
    public CrossPlatformColor TransButtonColor { 
      get { return _transButtonColor; }
      set {
        _transButtonColor = value;
        RaisePropertyChanged(() => TransButtonColor);
      }
    }

    public IUIStylingsModel MainStyling { get; private set; }

    public AddRecordViewModel(INavigationService navService,
                              IApplicationViewModel appViewModel,
                              IAccountsRepository accountsRepository,
                              ICategoriesRepository categoriesRepository,
                              ITransactionsRepository transactionsRepository)
      : base(navService, appViewModel) {

      _accountsRepository = accountsRepository;
      _transactionsRepository = transactionsRepository;

      //HACK
      LeftButtonText = accountsRepository.Items[0].Name;
      RightButtonText = categoriesRepository.Items[0].Name;
      SetActions();
      SetStylings();
    }

    void SetStylings() {
      _defaultColor = new CrossPlatformColor(237, 107, 149);
      _selectedColor = new CrossPlatformColor(237, 107, 149, 200);

      MainStyling = new UIStylingsModel { BackgroundColor = _defaultColor };

      _incomeButtonColor = _defaultColor;
      _expensesButtonColor = _selectedColor;
      _transButtonColor = _defaultColor;
    }

    void SetActions() {
      
      AddRecordAction = new RelayCommand(async () => {
        var transaction = new WalletTransaction();
        double amount;
        if (double.TryParse(AmountLabelText, out amount)) {

          switch (_transactionType) {
            case TransactionType.EXPENSES:
              transaction.Amount = -amount;
              break;
            case TransactionType.INCOME:
              transaction.Amount = amount;
              break;
            case TransactionType.TRANSFER:
              //var sourceTransaction
              break;
          }

          transaction.Date = new DateTimeOffset(DateTime.Now);
          await _transactionsRepository.AddTransaction(transaction, _rightButtonText, _leftButtonText);
        }
        _navigationService.GoBack();
      }, () => true);

      Button0Action = new RelayCommand(() => {
        if (AmountLabelText.Equals(ZERO))
          return;
        AmountLabelText = AmountLabelText + ZERO;
      }, () => true);

      Button1Action = new RelayCommand(() => {
        if (AmountLabelText.Equals(ZERO)) {
          AmountLabelText = ONE;
          return;
        }
        AmountLabelText = AmountLabelText + ONE;
      }, () => true);

      Button2Action = new RelayCommand(() => {
        if (AmountLabelText.Equals(ZERO)) {
          AmountLabelText = TWO;
          return;
        }
        AmountLabelText = AmountLabelText + TWO;
      }, () => true);

      Button3Action = new RelayCommand(() => {
        if (AmountLabelText.Equals(ZERO)) {
          AmountLabelText = THREE;
          return;
        }
        AmountLabelText = AmountLabelText + THREE;
      }, () => true);

      Button4Action = new RelayCommand(() => {
        if (AmountLabelText.Equals(ZERO)) {
          AmountLabelText = FOUR;
          return;
        }
        AmountLabelText = AmountLabelText + FOUR;
      }, () => true);

      Button5Action = new RelayCommand(() => {
        if (AmountLabelText.Equals(ZERO)) {
          AmountLabelText = FIVE;
          return;
        }
        AmountLabelText = AmountLabelText + FIVE;
      }, () => true);

      Button6Action = new RelayCommand(() => {
        if (AmountLabelText.Equals(ZERO)) {
          AmountLabelText = SIX;
          return;
        }
        AmountLabelText = AmountLabelText + SIX;
      }, () => true);

      Button7Action = new RelayCommand(() => {
        if (AmountLabelText.Equals(ZERO)) {
          AmountLabelText = SEVEN;
          return;
        }
        AmountLabelText = AmountLabelText + SEVEN;
      }, () => true);

      Button8Action = new RelayCommand(() => {
        if (AmountLabelText.Equals(ZERO)) {
          AmountLabelText = EIGHT;
          return;
        }
        AmountLabelText = AmountLabelText + EIGHT;
      }, () => true);

      Button9Action = new RelayCommand(() => {
        if (AmountLabelText.Equals(ZERO)) {
          AmountLabelText = NINE;
          return;
        }
        AmountLabelText = AmountLabelText + NINE;
      }, () => true);

      DeleteButtonAction = new RelayCommand(() => {
        if (AmountLabelText.Length == 1) {
          AmountLabelText = ZERO;
          return;
        }
        AmountLabelText = AmountLabelText.Remove(AmountLabelText.Length - 1);
      }, () => true);

      LeftButtonAction = new RelayCommand(() => {
        _navigationService.NavigateTo(_applicationViewModel.AccountSelectionViewControllerKey, this);
      }, () => true);

      RightButtonAction = new RelayCommand(() => {
        _navigationService.NavigateTo(_applicationViewModel.CategorySelectionViewControllerKey, this);
      }, () => true);

      ExpensesButtonAction = new RelayCommand(() => {
        IncomeButtonColor = _defaultColor;
        TransButtonColor = _defaultColor;
        ExpensesButtonColor = _selectedColor;
        _transactionType = TransactionType.EXPENSES;
        SignText = "-";
      }, () => true);

      IncomeButtonAction = new RelayCommand(() => {
        IncomeButtonColor = _selectedColor;
        TransButtonColor = _defaultColor;
        ExpensesButtonColor = _defaultColor;
        _transactionType = TransactionType.INCOME;
        SignText = "+";
      }, () => true);

      TransferButtonAction = new RelayCommand(() => {
        if (_accountsRepository.Items.Count <= 1) return;
        IncomeButtonColor = _defaultColor;
        TransButtonColor = _selectedColor;
        ExpensesButtonColor = _defaultColor;
        _transactionType = TransactionType.TRANSFER;
        SignText = string.Empty;
      }, () => true);
    }
  }
}
