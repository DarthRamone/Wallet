using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Realms;

namespace Wallet.Shared
{
  public class AccountsRepository : IRepository<Account>
  {
    private Realm _realm;

    public AccountsRepository()
    {
      _realm = Realm.GetInstance();
    }

    public List<Account> Items => _realm.All<Account>().ToList();

    public async Task Add(Account item)
    {
      await _realm.WriteAsync(realm => {
        realm.Add(item, false);
      });
    }

    public void Delete(Account item)
    {
      throw new NotImplementedException();
    }

    public void Update(Account item)
    {
      throw new NotImplementedException();
    }
  }
}
