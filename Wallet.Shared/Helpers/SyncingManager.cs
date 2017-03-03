using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using Realms;
using Realms.Sync;

namespace Wallet.Shared.Providers {

  public class SyncingManager : ISyncingManager, IDisposable, IObserver<SyncProgress> {

    private Realm _realm;

    private readonly IDisposable _token;

    private CancellationTokenSource _source;

    public bool IsSynchronized { get; private set; }

    public SyncingManager(ISyncConfigurationsProvider configurationsProvider) {
      _realm = Realm.GetInstance(configurationsProvider.ActiveConfiguration);

      var session = _realm.GetSession();
      var downloadsObservable =
        session.GetProgressObservable(ProgressDirection.Download, ProgressMode.ReportIndefinitely);

      _token = downloadsObservable.Subscribe(this);
      _source = new CancellationTokenSource();
    }

    public async Task<bool> Sync() {
      try {
        //TODO: some logic instead of delay
        await Task.Delay(30000, _source.Token);
        return false;
      } catch {
        return true;
      }
    }

    public void Dispose() {
      _token?.Dispose();
    }

    public void OnCompleted() {
      Debug.WriteLine("Sync completed");
      _token.Dispose();
      _source.Cancel();
    }

    public void OnError(Exception error) {
      Debug.WriteLine("Sync error");
    }

    public void OnNext(SyncProgress value) {
      Debug.WriteLine($"Sync status: {value.TransferredBytes}/{value.TransferableBytes}");
      if (value.TransferableBytes != 0 && value.TransferredBytes == value.TransferableBytes)
        OnCompleted();
    }

  }

}