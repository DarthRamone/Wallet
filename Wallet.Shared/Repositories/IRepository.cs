using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Wallet.Shared.Repositories {

  public interface IRepository<T> {

    event EventHandler<int[]> OnItemsDeleted;
    event EventHandler<int[]> OnItemsInserted;
    event EventHandler<int[]> OnItemsModified;

    List<T> Items { get; }

    Task Add(T item);

    void Delete(T item);

    void Update(T item);
  }
}
