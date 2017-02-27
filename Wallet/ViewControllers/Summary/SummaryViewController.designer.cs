// WARNING
//
// This file has been generated automatically by Xamarin Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace Wallet
{
  [Register("OverviewViewController")]
  partial class SummaryViewController {
    
    [Outlet]
    UICollectionView AccountsCollectionView { get; set; }

    [Outlet]
    NSLayoutConstraint AccountCollectionViewHeightConstraint { get; set; }

    [Outlet]
    UICollectionViewFlowLayout AccountsCollectionViewFlowLayout{ get; set; }

    [Outlet]
    UITableView TransactionsTableView { get; set; }

    [Outlet]
    UIButton AddRecordButton { get; set; }

    void ReleaseDesignerOutlets()
    {
    }
  }
}
