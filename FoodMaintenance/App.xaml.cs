using FoodMaintenance.Interfaces;
using FoodMaintenance.Models;
using FoodMaintenance.Services;
using FoodMaintenance.ViewModels;
using System.Windows;

namespace FoodMaintenance
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        #region Fields
        private readonly INavigationService _NavigationService = new NavigationService();
        private readonly DbContext _DbContext = new DbContext("FoodMaintenance.db");
        #endregion

        #region Methods
        protected override void OnStartup(StartupEventArgs e)
        {
            MainWindow = new MainWindow()
            {
                DataContext = new MainViewModel(_NavigationService, _DbContext)
            };

            MainWindow.Show();

            base.OnStartup(e);
        }
        #endregion
    }
}
