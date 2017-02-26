using System;
using System.Threading.Tasks;

namespace Wallet.Shared
{
  public interface IAccountsRepository : IRepository<Account>
  {
    Task Add(Account item);
  }
}
