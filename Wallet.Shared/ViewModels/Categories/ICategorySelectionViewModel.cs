using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace Wallet.Shared {

  public interface ICategorySelectionViewModel {

    Category SelectedCategory { get; set; }

    ObservableCollection<object> Categories { get; }

    Task AddCategory(Category category);
  }
}
