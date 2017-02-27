using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Realms;

namespace Wallet.Shared
{
  public abstract class BaseRepository<T> : IRepository<T> where T : RealmObject
  {
    private IQueryable<T> _items => _realm.All<T>();

    protected readonly Realm _realm;

    public List<T> Items => _items.ToList();

    public event EventHandler<int[]> OnItemsDeleted = delegate { };
    public event EventHandler<int[]> OnItemsInserted = delegate { };
    public event EventHandler<int[]> OnItemsModified = delegate { };

    public BaseRepository()
    {
      _realm = Realm.GetInstance();
      _items.SubscribeForNotifications((IRealmCollection<T> sender, ChangeSet changes, Exception error) => {

        if (changes != null)
        {
          if (changes.InsertedIndices.Length != 0)
            OnItemsInserted?.Invoke(this, changes.InsertedIndices);

          if (changes.DeletedIndices.Length != 0)
            OnItemsDeleted?.Invoke(this, changes.DeletedIndices);

          if (changes.ModifiedIndices.Length != 0)
            OnItemsModified?.Invoke(this, changes.ModifiedIndices);
        }
      });
    }

    public async Task Add(T item)
    {
      try
      {
        await _realm.WriteAsync(r => r.Add(item));
      }
      catch (Realms.Exceptions.RealmDuplicatePrimaryKeyValueException e)
      {
        Debug.WriteLine(e.Message);
        //TODO: Handle duplicates
      }
    }

    public void Delete(T item)
    {
      throw new NotImplementedException();
    }

    public void Update(T item)
    {
      throw new NotImplementedException();
    }
  }
}
