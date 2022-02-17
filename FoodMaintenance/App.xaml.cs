using FoodMaintenance.Interfaces;
using FoodMaintenance.Services;
using FoodMaintenance.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace FoodMaintenance
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        #region Properties
        private INavigationService NavigationService { get; } = new NavigationService();
        #endregion

        #region Methods
        protected override void OnStartup(StartupEventArgs e)
        {
            MainWindow = new MainWindow()
            {
                DataContext = new MainViewModel(NavigationService)
            };

            MainWindow.Show();

            base.OnStartup(e);
        }
        #endregion
    }
}
