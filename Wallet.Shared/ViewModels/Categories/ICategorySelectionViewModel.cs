using System;
using System.Collections.Generic;

namespace Wallet.Shared {
  
  public interface ICategorySelectionViewModel {

    Category SelectedCategory { get; set; }

    List<Category> Categories { get; }

  }
}
