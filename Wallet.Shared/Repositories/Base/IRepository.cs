using System;
using System.Collections.Generic;

namespace Wallet.Shared
{
  public interface IRepository<T>
  {
    event EventHandler<int[]> OnItemsDeleted;
    event EventHandler<int[]> OnItemsInserted;
    event EventHandler<int[]> OnItemsModified;

    List<T> Items { get; }

    void Delete(T item);

    void Update(T item);
  }
}
