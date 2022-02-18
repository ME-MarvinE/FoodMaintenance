using FoodMaintenance.Interfaces;
using FoodMaintenance.Models;
using Microsoft.Toolkit.Mvvm.Input;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FoodMaintenance.ViewModels
{
    public class DashboardViewModel : BaseViewModel
    {
        #region Fields
        private readonly DbContext _DbContext;
        #endregion

        #region Properties
        public List<UnitOfMeasurementDTO> UnitsOfMeasurement { get; set; } = new List<UnitOfMeasurementDTO>();
        public List<ProductTypeDTO> ProductTypes { get; set; } = new List<ProductTypeDTO>();
        public UnitOfMeasurementDTO? SelectedUnitOfMeasurement { get; set; }
        public ProductTypeDTO? SelectedProductType { get; set; }
        public string? AddUnitOfMeasurementName { get; set; }
        public string? AddProductTypeName { get; set; }
        #endregion

        #region Commands
        public ICommand GetProductTypesCommand { get; set; }
        public ICommand AddProductTypeCommand { get; set; }
        public ICommand UpdateProductTypeCommand { get; set; }
        public ICommand DeleteProductTypeCommand { get; set; }
        public ICommand DeleteAllProductTypesCommand { get; set; }
        public ICommand GetUnitsOfMeasurementCommand { get; set; }
        public ICommand AddUnitOfMeasurementCommand { get; set; }
        public ICommand UpdateUnitOfMeasurementCommand { get; set; }
        public ICommand DeleteUnitOfMeasurementCommand { get; set; }
        public ICommand DeleteAllUnitsOfMeasurementCommand { get; set; }
        #endregion

        #region Constructors
        public DashboardViewModel(INavigationService NavigationService, DbContext DbContext)
            : base(NavigationService)
        {
            //Didn't use AsyncRelayCommand because it eats up exceptions.
            GetProductTypesCommand = new RelayCommand(async () => { await GetProductTypes(); });
            AddProductTypeCommand = new RelayCommand(async () => { await AddProductType(); });
            UpdateProductTypeCommand = new RelayCommand(async () => { await UpdateProductType(); });
            DeleteProductTypeCommand = new RelayCommand(async () => { await DeleteProductType(); });
            DeleteAllProductTypesCommand = new RelayCommand(async () => { await DeleteAllProductTypes(); });
            GetUnitsOfMeasurementCommand = new RelayCommand(async () => { await GetUnitsOfMeasurement(); });
            AddUnitOfMeasurementCommand = new RelayCommand(async () => { await AddUnitOfMeasurement(); });
            UpdateUnitOfMeasurementCommand = new RelayCommand(async () => { await UpdateUnitOfMeasurement(); });
            DeleteUnitOfMeasurementCommand = new RelayCommand(async () => { await DeleteUnitOfMeasurement(); });
            DeleteAllUnitsOfMeasurementCommand = new RelayCommand(async () => { await DeleteAllUnitsOfMeasurement(); });

            _DbContext = DbContext;
            GetUnitsOfMeasurement();
        }
        #endregion

        #region Methods
        public async Task GetProductTypes()
        {
            ProductTypes = await _DbContext.GetProductTypes();
        }
        public async Task AddProductType()
        {
            await _DbContext.AddProductType(new ProductTypeDTO() { Name = AddProductTypeName });

            AddProductTypeName = "";
            await GetProductTypes();
        }
        public async Task UpdateProductType()
        {
            if (SelectedProductType != null)
            {
                await _DbContext.UpdateProductType(SelectedProductType);
            }

            await GetProductTypes();
        }
        public async Task DeleteProductType()
        {
            if (SelectedProductType != null)
            {
                await _DbContext.DeleteProductType(SelectedProductType.Id);
            }

            await GetProductTypes();
        }
        public async Task DeleteAllProductTypes()
        {
            await _DbContext.DeleteAllProductTypes();
            await GetProductTypes();
        }
        public async Task GetUnitsOfMeasurement()
        {
            UnitsOfMeasurement = await _DbContext.GetUnitsOfMeasurement();
        }
        public async Task AddUnitOfMeasurement()
        {
            await _DbContext.AddUnitOfMeasurement(new UnitOfMeasurementDTO() { Name = AddUnitOfMeasurementName });

            AddUnitOfMeasurementName = "";
            await GetUnitsOfMeasurement();
        }
        public async Task UpdateUnitOfMeasurement()
        {
            if (SelectedUnitOfMeasurement != null)
            {
                await _DbContext.UpdateUnitOfMeasurement(SelectedUnitOfMeasurement);
            }

            await GetUnitsOfMeasurement();
        }
        public async Task DeleteUnitOfMeasurement()
        {
            if (SelectedUnitOfMeasurement !=  null)
            {
                await _DbContext.DeleteUnitOfMeasurement(SelectedUnitOfMeasurement.Id);
            }

            await GetUnitsOfMeasurement();
        }
        public async Task DeleteAllUnitsOfMeasurement()
        {
            await _DbContext.DeleteAllUnitsOfMeasurement();
            await GetUnitsOfMeasurement();
        }
        #endregion
    }
}
