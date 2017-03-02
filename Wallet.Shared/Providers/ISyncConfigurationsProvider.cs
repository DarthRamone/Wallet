using System.Threading.Tasks;
using Realms.Sync;

namespace Wallet.Shared.Providers {

  public interface ISyncConfigurationsProvider {

    SyncConfiguration ActiveConfiguration { get; }

    Task<bool> DoLogin(string username, string password, bool newUser);

  }

}