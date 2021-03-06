﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Realms;
using Wallet.Shared.Providers;

namespace Wallet.Shared.Repositories {
  
  public abstract class BaseRepository<T> : IDisposable, IRepository<T> where T : RealmObject {

    protected IDisposable _notificationsToken;

    protected IQueryable<T> _items => _realm.All<T>();

    protected readonly Realm _realm;

    public List<T> Items => _items.ToList();

    public abstract event EventHandler<int[]> OnItemsDeleted;
    public abstract event EventHandler<int[]> OnItemsInserted;
    public abstract event EventHandler<int[]> OnItemsModified;

    public BaseRepository(ISyncConfigurationsProvider configurationsProvider) {
      _realm = Realm.GetInstance(configurationsProvider.ActiveConfiguration);
    }

    public async Task Add(T item) {
      
      try {
        await _realm.WriteAsync(r => r.Add(item));
      } catch (Realms.Exceptions.RealmDuplicatePrimaryKeyValueException e) {
        Debug.WriteLine(e.Message);
        //TODO: Handle duplicates
      }
    }

    public void Delete(T item) {
      throw new NotImplementedException();
    }

    public void Update(T item) {
      throw new NotImplementedException();
    }

    public void Dispose() {
      _notificationsToken.Dispose();
    }

  }
}
