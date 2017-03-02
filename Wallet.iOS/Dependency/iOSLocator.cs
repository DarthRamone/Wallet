using Microsoft.Practices.Unity;
using Wallet.Shared;

namespace Wallet.iOS {
  public class iOSLocator : CoreLocator {
    public iOSLocator(IUnityContainer container) : base(container) {
    }
  }
}
