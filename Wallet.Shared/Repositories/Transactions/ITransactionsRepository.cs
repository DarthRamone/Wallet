using System.Collections.Generic;
using System.Threading.Tasks;
using Wallet.Shared.Models;

namespace Wallet.Shared.Repositories
{
  public interface ITransactionsRepository : IRepository<WalletTransaction>
  {
    List<TransferTransaction> TransferTransactions { get; }

    List<WalletTransaction> SortedTransactions { get; }

    Task AddTransaction(WalletTransaction transaction, string categoryId, string accountId);

    Task AddTransferTransaction(TransferTransaction transaction, string sourceAccountId, string targetAccountId);
  }
}
