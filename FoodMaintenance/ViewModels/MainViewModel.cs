using FoodMaintenance.Interfaces;
using Microsoft.Toolkit.Mvvm.Input;
using System.Windows.Input;

namespace FoodMaintenance.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        #region Commands
        public ICommand ShowDashboardCommand { get; set; }
        public ICommand ShowAddProductCommand { get; set; }
        #endregion

        #region Constructors
        public MainViewModel(INavigationService NavigationService)
            :base(NavigationService)
        {
            ShowDashboardCommand = new RelayCommand(ShowDashboard);
            ShowAddProductCommand = new RelayCommand(ShowAddProduct);
            ShowDashboard();
        }
        #endregion

        #region Methods
        public void ShowDashboard()
        {
            NavigationService.Navigate(new DashboardViewModel(NavigationService));
        }
        public void ShowAddProduct()
        {
            NavigationService.Navigate(new AddProductViewModel(NavigationService));
        }
        #endregion
    }
}
