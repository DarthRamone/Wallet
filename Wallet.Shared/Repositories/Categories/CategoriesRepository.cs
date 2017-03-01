using Realms.Sync;
using Wallet.Shared.Models;

namespace Wallet.Shared.Repositories {
  public class CategoriesRepository : BaseRepository<Category>, ICategoriesRepository {

    public CategoriesRepository(SyncConfiguration configuration) : base(configuration) {

    }

  }
}
