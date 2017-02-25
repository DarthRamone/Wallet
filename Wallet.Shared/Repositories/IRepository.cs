using System.Collections.Generic;
using System.Threading.Tasks;

namespace Wallet.Shared
{
  public interface IRepository<T>
  {
    List<T> Items { get; }

    Task Add(T item);

    void Delete(T item);

    void Update(T item);
  }
}
