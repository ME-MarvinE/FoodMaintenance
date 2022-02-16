using FoodMaintenance.ViewModels;
using System;

namespace FoodMaintenance.Interfaces
{
    public interface INavigationService
    {
        #region Properties
        BaseViewModel? CurrentViewModel { get; }
        #endregion

        #region Events
        event EventHandler? Navigated;
        #endregion

        #region Methods
        void Navigate(BaseViewModel? ViewModel);
        #endregion
    }
}
