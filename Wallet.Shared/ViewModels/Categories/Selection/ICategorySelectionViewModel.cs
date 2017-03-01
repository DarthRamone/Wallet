using System.Collections.ObjectModel;
using System.Threading.Tasks;
using GalaSoft.MvvmLight.Command;

namespace Wallet.Shared {

  public interface ICategorySelectionViewModel {

    Category SelectedCategory { get; set; }

    ObservableCollection<object> Categories { get; }

    RelayCommand AddCategoryAction { get; }

  }
}
