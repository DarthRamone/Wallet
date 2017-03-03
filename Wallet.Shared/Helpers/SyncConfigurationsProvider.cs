using System;
using System.Threading.Tasks;
using Realms.Sync;

namespace Wallet.Shared.Providers {

  public class SyncConfigurationsProvider : ISyncConfigurationsProvider {

    public SyncConfiguration ActiveConfiguration { get; private set; }

    public async Task<bool> DoLogin(string username, string password, bool newUser) {

      try {
        var credentials = Credentials.UsernamePassword(username, password, newUser);
        var authUri = new Uri("http://188.166.69.22:9080");
        var user = await User.LoginAsync(credentials, authUri);
        var serverUri = new Uri("realm://188.166.69.22:9080/~/default");
        ActiveConfiguration = new SyncConfiguration(user, serverUri);
        return true;
      }
      catch {
        return false;
      }

    }

  }

}