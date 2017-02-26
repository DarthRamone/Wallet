using UIKit;
using Wallet.Shared;

namespace Wallet
{
  public partial class AddRecordViewController : WalletBaseViewController
  {
    const string catName = "test category";
    const string accName = "test account";

    ITransactionsRepository _transactionsRepo;

    IAddRecordViewModel _viewModel;

    public AddRecordViewController(ITransactionsRepository transactionsRepo,
                                   IAddRecordViewModel viewModel) : base("AddRecordViewController")
    {
      _transactionsRepo = transactionsRepo;
      _viewModel = viewModel;
    }

    public override void ViewDidLoad()
    {
      base.ViewDidLoad();
      AddRecordButton.TouchUpInside += async (sender, e) => {
        await _transactionsRepo.AddTransaction(500, catName, accName);
        NavigationController.PopViewController(true);
      };
      // Perform any additional setup after loading the view, typically from a nib.
    }

    public override void DidReceiveMemoryWarning()
    {
      base.DidReceiveMemoryWarning();
      // Release any cached data, images, etc that aren't in use.
    }
  }
}

