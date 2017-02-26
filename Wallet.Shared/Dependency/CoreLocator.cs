using System;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;

namespace Wallet.Shared
{
  public class CoreLocator
  {
    public CoreLocator()
    {
      SimpleIoc.Default.Register<ISummaryViewModel, SummaryViewModel>();
    }
  }
}
