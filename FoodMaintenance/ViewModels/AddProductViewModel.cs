using FoodMaintenance.Interfaces;

namespace FoodMaintenance.ViewModels
{
    public class AddProductViewModel : BaseViewModel
    {
        public AddProductViewModel(INavigationService NavigationService)
            : base(NavigationService)
        {
        }
    }
}
