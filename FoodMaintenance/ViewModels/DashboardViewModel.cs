using FoodMaintenance.Interfaces;

namespace FoodMaintenance.ViewModels
{
    public class DashboardViewModel : BaseViewModel
    {
        #region Constructors
        public DashboardViewModel(INavigationService NavigationService)
            : base(NavigationService)
        {
        }
        #endregion
    }
}
