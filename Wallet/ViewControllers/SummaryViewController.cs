﻿using System;
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

    private ISummaryViewModel _viewModel;

    public SummaryViewController(ISummaryViewModel summaryViewModel) : base("OverviewViewController")
    {
      _viewModel = summaryViewModel;
    }

    public override void ViewDidLoad()
    {
      base.ViewDidLoad();
      // Perform any additional setup after loading the view, typically from a nib.
      AddRecordButton.SetCommand(_viewModel.AddRecordButtonAction);

      TransactionsTableView.RegisterNibForCellReuse(RecordTableViewCell.Nib, cellId);

      _viewModel.OnItemsInserted += (sender, e) =>
      {
        //TODO: reload rows instead of all the data
        TransactionsTableView.ReloadData();
      };
    }

    public override void DidReceiveMemoryWarning()
    {
      base.DidReceiveMemoryWarning();
      // Release any cached data, images, etc that aren't in use.
    }

    public nint RowsInSection(UITableView tableView, nint section) => _viewModel.Transactions.Count;

    public nint NumberOfSections(UITableView tableView) => 1;

    public UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
    {
      var transaction = _viewModel.Transactions[indexPath.Row];

      var cell = tableView.DequeueReusableCell(cellId, indexPath) as RecordTableViewCell;
      cell.CategoryNameLabel.Text = transaction.Category.Name;
      cell.AmountLabel.Text = transaction.Amount.ToString();
      cell.DateLabel.Text = DateTime.Now.ToString("d");
      cell.AccountNameLabel.Text = transaction.Account.Name;
      return cell;
    }
  }
}

