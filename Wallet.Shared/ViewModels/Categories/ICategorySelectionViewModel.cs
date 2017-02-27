using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Wallet.Shared {
  
  public interface ICategorySelectionViewModel {

    Category SelectedCategory { get; set; }

    List<Category> Categories { get; }

    Task AddCategory(Category category);

    event EventHandler<int[]> OnItemsDeleted;
    event EventHandler<int[]> OnItemsInserted;
    event EventHandler<int[]> OnItemsModified;
  }
}
