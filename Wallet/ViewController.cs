using System;
using Realms;
using UIKit;
using Wallet.Shared;

namespace Wallet
{
  public partial class ViewController : UIViewController
  {
    protected ViewController(IntPtr handle) : base(handle)
    {
      // Note: this .ctor should not contain any initialization logic.
    }

    public override async void ViewDidLoad()
    {
      base.ViewDidLoad();

      var accountsRepo = new AccountsRepository();
      var categoriesRepo = new CategoriesRepository();
      var transactionsRepo = new TransactionsRepository();

      accountsRepo.OnItemsInserted += (object sender, int[] e) =>
      {
        Console.WriteLine($"inserted: {e}");
      };
      transactionsRepo.OnItemsInserted += (sender, e) =>
      {
        var t = transactionsRepo.Items;
        Console.WriteLine("");
      };

      var account = new Account();
      account.Name = "test account";
      await accountsRepo.Add(account);
      var category = new Category();
      category.Name = "test category";
      await categoriesRepo.Add(category);
      var transaction = new WalletTransaction();
      await transactionsRepo.Add(transaction);

    }

    public override void DidReceiveMemoryWarning()
    {
      base.DidReceiveMemoryWarning();
      // Release any cached data, images, etc that aren't in use.
    }
  }
}
