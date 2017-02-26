using System;
using System.Collections.Generic;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;

namespace Wallet.Shared
{
  public class SummaryViewModel : WalletBaseViewModel, ISummaryViewModel
  {
    private ITransactionsRepository _transactionsRepository;

    public List<WalletTransaction> Transactions => _transactionsRepository.Items;

    public event EventHandler<int[]> OnItemsDeleted
    {
      add { _transactionsRepository.OnItemsDeleted += value; }
      remove { _transactionsRepository.OnItemsDeleted -= value; }
    }

    public event EventHandler<int[]> OnItemsInserted
    {
      add { _transactionsRepository.OnItemsInserted += value; }
      remove { _transactionsRepository.OnItemsInserted -= value; }
    }

    public event EventHandler<int[]> OnItemsModified
    {
      add { _transactionsRepository.OnItemsModified += value; }
      remove { _transactionsRepository.OnItemsModified -= value; }
    }

    public RelayCommand AddRecordButtonAction { get; private set; }

    public SummaryViewModel (INavigationService navigationService,
                             IApplicationViewModel applicationViewModel,
                             ITransactionsRepository transactionsRepository) 
      : base(navigationService,
             applicationViewModel)
    {
      _transactionsRepository = transactionsRepository;

      AddRecordButtonAction = new RelayCommand(() => {
        _navigationService.NavigateTo(_applicationViewModel.AddRecordViewControllerKey);
      }, () => true);
    }
  }
}
