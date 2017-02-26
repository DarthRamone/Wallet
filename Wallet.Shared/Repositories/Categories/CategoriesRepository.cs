using System.Diagnostics;
using System.Threading.Tasks;

namespace Wallet.Shared
{
  public class CategoriesRepository : BaseRepository<Category>, ICategoriesRepository
  {
    public async Task Add(Category item)
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
