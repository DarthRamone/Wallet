using System.Collections.Generic;
using System.Threading.Tasks;
using Wallet.Shared.Models;

namespace Wallet.Shared.Repositories.Transactions
{
  public interface ITransactionsRepository : IRepository<WalletTransaction>
  {
    List<WalletTransaction> Transactions { get; }

    Task AddTransaction(WalletTransaction transaction, string categoryId, string accountId);

    Task RemoveTransaction(string transactionId);

    Task AddTransferTransaction(TransferTransaction transaction, string sourceAccountId, string targetAccountId, double amount);

    void SetAccountForFiltering(Account account);

  }
}
