using FoodMaintenance.Interfaces;
using FoodMaintenance.Models;
using Microsoft.Toolkit.Mvvm.Input;
using System.Windows;
using System.Windows.Input;

namespace FoodMaintenance.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        #region Fields
        private readonly DbContext _DbContext;
        #endregion

        #region Properties
        public WindowState WindowState { get; set; } = WindowState.Maximized;
        #endregion

        #region Commands
        public ICommand ShowDashboardCommand { get; set; }
        public ICommand ShowAddProductCommand { get; set; }
        public ICommand ChangeWindowStateCommand { get; set; }
        public ICommand CloseWindowCommand { get; set; }
        #endregion

        #region Constructors
        public MainViewModel(INavigationService NavigationService, DbContext DbContext)
            :base(NavigationService)
        {
            ShowDashboardCommand = new RelayCommand(ShowDashboard);
            ShowAddProductCommand = new RelayCommand(ShowAddProduct);
            ChangeWindowStateCommand = new RelayCommand<WindowState>(ChangeWindowState);
            CloseWindowCommand = new RelayCommand<Window?>(CloseWindow);
            _DbContext = DbContext;
            ShowDashboard();
        }
        #endregion

        #region Methods
        public void ShowDashboard()
        {
            NavigationService.Navigate(new DashboardViewModel(NavigationService, _DbContext));
        }
        public void ShowAddProduct()
        {
            NavigationService.Navigate(new AddProductViewModel(NavigationService));
        }
        public void ChangeWindowState(WindowState WindowState)
        {
            this.WindowState = WindowState;
        }
        public void CloseWindow(Window? Window)
        {
            Window?.Close();
        }
        #endregion
    }
}
