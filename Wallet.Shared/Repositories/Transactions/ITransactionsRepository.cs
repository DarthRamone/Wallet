using System;
using System.Threading.Tasks;

namespace Wallet.Shared
{
  public interface ITransactionsRepository : IRepository<WalletTransaction>
  {
    Task AddTransaction(double amount, string categoryId, string accountId);
  }
}
