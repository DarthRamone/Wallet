using System;
using Realms.Sync;
using Wallet.Shared.Models;

namespace Wallet.Shared.Repositories {
  public class AccountsRepository : BaseRepository<Account>, IAccountsRepository {

    public override event EventHandler<int[]> OnItemsDeleted = delegate { };
    public override event EventHandler<int[]> OnItemsInserted = delegate { };
    public override event EventHandler<int[]> OnItemsModified = delegate { };

    public AccountsRepository(SyncConfiguration configuration) : base(configuration) {
    }
  }
}
