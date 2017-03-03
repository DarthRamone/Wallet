using System;
using Realms;
using Wallet.Shared.Models;
using Wallet.Shared.Providers;

namespace Wallet.Shared.Repositories.Categories {
  public class CategoriesRepository : BaseRepository<Category>, ICategoriesRepository {

    public override event EventHandler<int[]> OnItemsDeleted = delegate { };
    public override event EventHandler<int[]> OnItemsInserted = delegate { };
    public override event EventHandler<int[]> OnItemsModified = delegate { };

    public CategoriesRepository(ISyncConfigurationsProvider configurationsProvider) : base(configurationsProvider) {

      _notificationsToken = _items.SubscribeForNotifications((sender, changes, error) => {

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
