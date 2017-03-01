using Realms.Sync;
using Wallet.Shared.Models;

namespace Wallet.Shared.Repositories {
  public class AccountsRepository : BaseRepository<Account>, IAccountsRepository {

    public AccountsRepository(SyncConfiguration configuration) : base(configuration) {
    }
  }
}
