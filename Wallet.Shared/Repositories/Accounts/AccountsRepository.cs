using System.Diagnostics;
using System.Threading.Tasks;
using Realms;

namespace Wallet.Shared
{
  public class AccountsRepository : BaseRepository<Account>, IAccountsRepository
  {
    public async Task Add(Account item)
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
  }
}
