using System;
using Realms.Sync;
using Wallet.Shared.Models;

namespace Wallet.Shared.Repositories {
  public class CategoriesRepository : BaseRepository<Category>, ICategoriesRepository {

    public override event EventHandler<int[]> OnItemsDeleted = delegate { };
    public override event EventHandler<int[]> OnItemsInserted = delegate { };
    public override event EventHandler<int[]> OnItemsModified = delegate { };

    public CategoriesRepository(SyncConfiguration configuration) : base(configuration) {

    }

  }
}
