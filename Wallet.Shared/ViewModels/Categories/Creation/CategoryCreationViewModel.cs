﻿using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using Wallet.Shared.Models;
using Wallet.Shared.Repositories;

namespace Wallet.Shared.ViewModels {

  public class CategoryCreationViewModel : WalletBaseViewModel, ICategoryCreationViewModel {

    private readonly ICategoriesRepository _categoriesRepository;

    public string CateggoryNameText { get; set; }

    public RelayCommand CreateCategoryAction { get; private set; }

    public CategoryCreationViewModel(INavigationService navigationService,
      IApplicationViewModel applicationViewModel,
      ICategoriesRepository categoriesRepository)
      : base(navigationService, applicationViewModel) {

      _categoriesRepository = categoriesRepository;

      SetCommands();
    }

    private void SetCommands() {
      CreateCategoryAction = new RelayCommand(async () => {
        var category = new Category {Name = CateggoryNameText};
        await _categoriesRepository.Add(category);
        _navigationService.GoBack();
      }, () => true);
    }

  }

}