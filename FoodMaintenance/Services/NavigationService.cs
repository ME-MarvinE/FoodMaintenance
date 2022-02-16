using FoodMaintenance.Interfaces;
using FoodMaintenance.ViewModels;
using System;

namespace FoodMaintenance.Services
{
    public class NavigationService : INavigationService
    {
        #region Properties
        public BaseViewModel? CurrentViewModel { get; private set; }
        #endregion

        #region Events
        public event EventHandler? Navigated;
        #endregion

        #region Methods
        protected void OnNavigated()
        {
            Navigated?.Invoke(this, EventArgs.Empty);
        }
        public void Navigate(BaseViewModel ViewModel)
        {
            if (CurrentViewModel != ViewModel)
            {
                CurrentViewModel?.Dispose();
                CurrentViewModel = ViewModel;
                OnNavigated();
            }
        }
        #endregion



    }
}
