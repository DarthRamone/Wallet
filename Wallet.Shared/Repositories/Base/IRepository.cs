using System.Collections.Generic;

namespace Wallet.Shared
{
  public interface IRepository<T>
  {
    List<T> Items { get; }

    void Delete(T item);

    void Update(T item);
  }
}
