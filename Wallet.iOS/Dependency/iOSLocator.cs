using Microsoft.Practices.Unity;
using Realms.Sync;
using Wallet.Shared;

namespace Wallet.iOS
{
  public class iOSLocator : CoreLocator
  {
    public iOSLocator(IUnityContainer container, SyncConfiguration configuration) : base(container, configuration)
    {
    }
  }
}
