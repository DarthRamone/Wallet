using System;
using System.Threading.Tasks;

namespace Wallet.Shared.Providers {

  public interface ISyncingManager {

    bool IsSynchronized { get; }

    Task<bool> Sync();
  }

}