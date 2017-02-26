using System;
using Foundation;
using GalaSoft.MvvmLight.Helpers;
using UIKit;
using Wallet.Shared;

namespace Wallet
{
  public partial class SummaryViewController : WalletBaseViewController, IUITableViewDataSource, IUITableViewDelegate
  {
    const string cellId = "cellId";
    const string catName = "test category";
    const string accName = "test account";

    //will be removed ofc
    private AccountsRepository _accountsRepository;
    private CategoriesRepository _categoriesRepository;
    private TransactionsRepository _transactionsRepository;

    private ISummaryViewModel _viewModel;


    public SummaryViewController(ISummaryViewModel summaryViewModel) : base("OverviewViewController")
    {
      _viewModel = summaryViewModel;

      _accountsRepository = new AccountsRepository();
      _categoriesRepository = new CategoriesRepository();
      _transactionsRepository = new TransactionsRepository();
    }

    public override async void ViewDidLoad()
    {
      base.ViewDidLoad();
      // Perform any additional setup after loading the view, typically from a nib.
      AddRecordButton.SetCommand(_viewModel.AddRecordButtonAction);

      TransactionsTableView.RegisterNibForCellReuse(RecordTableViewCell.Nib, cellId);

      _accountsRepository.OnItemsInserted += (object sender, int[] e) =>
      {
        Console.WriteLine($"inserted: {e}");
      };
      _transactionsRepository.OnItemsInserted += (sender, e) =>
      {
        //TODO: reload rows instead of all the data
        TransactionsTableView.ReloadData();
      };

      var account = new Account();
      account.Name = accName;
      await _accountsRepository.Add(account);

      var category = new Category();
      category.Name = catName;
      await _categoriesRepository.Add(category);

      //var transaction = new WalletTransaction();
      await _transactionsRepository.AddTransaction(1000, catName, accName);
    }

    public override void DidReceiveMemoryWarning()
    {
      base.DidReceiveMemoryWarning();
      // Release any cached data, images, etc that aren't in use.
    }

    public nint RowsInSection(UITableView tableView, nint section)
    {
      return _transactionsRepository.Items.Count;
    }

    public nint NumberOfSections(UITableView tableView)
    {
      return 1;
    }

    public UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
    {
      var transaction = _transactionsRepository.Items[indexPath.Row];

      var cell = tableView.DequeueReusableCell(cellId, indexPath) as RecordTableViewCell;
      cell.CategoryNameLabel.Text = transaction.Category.Name;
      cell.AmountLabel.Text = transaction.Amount.ToString();
      cell.DateLabel.Text = DateTime.Now.ToString("d");
      cell.AccountNameLabel.Text = transaction.Account.Name;
      return cell;
    }
  }
}

