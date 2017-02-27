using System.Threading.Tasks;

namespace Wallet.Shared
{
  public interface ITransactionsRepository : IRepository<WalletTransaction>
  {
    Task AddTransaction(WalletTransaction transaction, string categoryId, string accountId);
  }
}
