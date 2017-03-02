using System;
using Realms;
using Realms.Sync;
using Wallet.Shared.Models;

namespace Wallet.Shared.Repositories {
  public class AccountsRepository : BaseRepository<Account>, IAccountsRepository {

    public override event EventHandler<int[]> OnItemsDeleted = delegate { };
    public override event EventHandler<int[]> OnItemsInserted = delegate { };
    public override event EventHandler<int[]> OnItemsModified = delegate { };

    public AccountsRepository(SyncConfiguration configuration) : base(configuration) {
      _items.SubscribeForNotifications((sender, changes, error) => {

        if (changes != null) {
          if (changes.InsertedIndices.Length != 0)
            OnItemsInserted?.Invoke(this, changes.InsertedIndices);

          if (changes.DeletedIndices.Length != 0)
            OnItemsDeleted?.Invoke(this, changes.DeletedIndices);

          if (changes.ModifiedIndices.Length != 0)
            OnItemsModified?.Invoke(this, changes.ModifiedIndices);
        }
      });
    }
  }
}
