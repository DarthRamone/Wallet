using System.Collections.Generic;
using System.Threading.Tasks;

namespace Wallet.Shared
{
  public interface ITransactionsRepository : IRepository<WalletTransaction>
  {
    List<TransferTransaction> TransferTransactions { get; }

    Task AddTransaction(WalletTransaction transaction, string categoryId, string accountId);

    Task AddTransferTransaction(TransferTransaction transaction);
  }
}
