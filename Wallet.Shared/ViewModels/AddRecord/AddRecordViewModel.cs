using System;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;

namespace Wallet.Shared {
  public class AddRecordViewModel : WalletBaseViewModel, IAddRecordViewModel {
    
    private ITransactionsRepository _transactionsRepository;

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

    private Account _selectedAccount;
    public Account SelectedAccount { 
      get { return _selectedAccount; } 
      set {
        _selectedAccount = value;
        RaisePropertyChanged(() => SelectedAccount);
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

    public RelayCommand AccountSelectionAction { get; private set; }

    public AddRecordViewModel(INavigationService navService,
                              IApplicationViewModel appViewModel,
                              IAccountsRepository accountsRepository,
                              ICategoriesRepository categoriesRepository,
                              ITransactionsRepository transactionsRepository)
      : base(navService, appViewModel) {
      _transactionsRepository = transactionsRepository;
      Initialize(categoriesRepository, accountsRepository);
      SelectedAccount = accountsRepository.Items[0];
      SetActions();
    }

    async void Initialize(ICategoriesRepository catsRepo, IAccountsRepository accsRepo) {
      await catsRepo.Add(new Category { Name = "test category" });
      await accsRepo.Add(new Account { Name = "test account" });
      SelectedAccount = accsRepo.Items[0];//HACK
    }

    void SetActions() {
      
      AddRecordAction = new RelayCommand(async () => {
        var transaction = new WalletTransaction();
        double amount;
        if (double.TryParse(AmountLabelText, out amount)) {
          transaction.Amount = amount;
          transaction.Date = new DateTimeOffset(DateTime.Now);
          await _transactionsRepository.AddTransaction(transaction, "test category", "test account");
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

      AccountSelectionAction = new RelayCommand(() => {
        _navigationService.NavigateTo(_applicationViewModel.AccountSelectionViewControllerKey, this);
      }, () => true);
    }
  }
}
