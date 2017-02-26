using System;
using System.Threading.Tasks;

namespace Wallet.Shared
{
  public interface ICategoriesRepository : IRepository<Category>
  {
    Task Add(Category item);
  }
}
