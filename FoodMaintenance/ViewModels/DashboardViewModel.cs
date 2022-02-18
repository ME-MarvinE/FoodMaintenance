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
        public List<ProductDTO> Products { get; set; } = new List<ProductDTO>();
        public List<ProductTypeDTO> ProductTypes { get; set; } = new List<ProductTypeDTO>();
        public List<UnitOfMeasurementDTO> UnitsOfMeasurement { get; set; } = new List<UnitOfMeasurementDTO>();
        public ProductDTO? SelectedProduct { get; set; }
        public UnitOfMeasurementDTO? SelectedUnitOfMeasurement { get; set; }
        public ProductTypeDTO? SelectedProductType { get; set; }
        public string? NewProductName { get; set; }
        public ProductTypeDTO? NewProductType { get; set; }
        public int NewProductMinStockQuantity { get; set; }
        public UnitOfMeasurementDTO? NewProductUnitOfMeasurement { get; set; }
        public bool NewProductIsActive { get; set; } = true;
        public string? AddUnitOfMeasurementName { get; set; }
        public string? AddProductTypeName { get; set; }
        #endregion

        #region Commands
        public ICommand GetProductsCommand { get; set; }
        public ICommand AddProductCommand { get; set; }
        public ICommand UpdateProductCommand { get; set; }
        public ICommand DeleteProductCommand { get; set; }
        public ICommand DeleteAllProductsCommand { get; set; }
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
        public ICommand LoadedCommand { get; set; }
        #endregion

        #region Constructors
        public DashboardViewModel(INavigationService NavigationService, DbContext DbContext)
            : base(NavigationService)
        {
            //Didn't use AsyncRelayCommand because it eats up exceptions.
            GetProductsCommand = new RelayCommand(async () => { await GetProducts(); });
            AddProductCommand = new RelayCommand(async () => { await AddProduct(); });
            UpdateProductCommand = new RelayCommand(async () => { await UpdateProduct(); });
            DeleteProductCommand = new RelayCommand(async () => { await DeleteProduct(); });
            DeleteAllProductsCommand = new RelayCommand(async () => { await DeleteAllProducts(); });
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
            LoadedCommand = new RelayCommand(async () => { await ReloadAllData(); });

            _DbContext = DbContext;
        }
        #endregion

        #region Methods
        public async Task ReloadAllData()
        {
            await GetProducts();
            await GetProductTypes();
            await GetUnitsOfMeasurement();
        }
        public async Task GetProducts()
        {
            Products = await _DbContext.GetProducts();
        }
        public async Task AddProduct()
        {
            await _DbContext.AddProduct(new ProductDTO()
            {
                Name = NewProductName,
                Type = NewProductType,
                MinStockQuantity = NewProductMinStockQuantity,
                UnitOfMeasurement = NewProductUnitOfMeasurement,
                IsActive = NewProductIsActive
            });

            NewProductName = "";
            NewProductType = null;
            NewProductMinStockQuantity = 0;
            NewProductUnitOfMeasurement = null;
            NewProductIsActive = true;
            await GetProducts();
        }
        public async Task UpdateProduct()
        {
            if (SelectedProduct != null)
            {
                await _DbContext.UpdateProduct(SelectedProduct);
            }

            await ReloadAllData();
        }
        public async Task DeleteProduct()
        {
            if (SelectedProduct != null)
            {
                await _DbContext.DeleteProduct(SelectedProduct.Id);
            }

            await ReloadAllData();
        }
        public async Task DeleteAllProducts()
        {
            await _DbContext.DeleteAllProducts();
            await ReloadAllData();
        }
        public async Task GetProductTypes()
        {
            ProductTypes = await _DbContext.GetProductTypes();
        }
        public async Task AddProductType()
        {
            await _DbContext.AddProductType(new ProductTypeDTO() { Name = AddProductTypeName });
            AddProductTypeName = "";

            await ReloadAllData();
        }
        public async Task UpdateProductType()
        {
            if (SelectedProductType != null)
            {
                await _DbContext.UpdateProductType(SelectedProductType);
            }

            await ReloadAllData();
        }
        public async Task DeleteProductType()
        {
            if (SelectedProductType != null)
            {
                await _DbContext.DeleteProductType(SelectedProductType.Id);
            }

            await ReloadAllData();
        }
        public async Task DeleteAllProductTypes()
        {
            await _DbContext.DeleteAllProductTypes();
            await ReloadAllData();
        }
        public async Task GetUnitsOfMeasurement()
        {
            UnitsOfMeasurement = await _DbContext.GetUnitsOfMeasurement();
        }
        public async Task AddUnitOfMeasurement()
        {
            await _DbContext.AddUnitOfMeasurement(new UnitOfMeasurementDTO() { Name = AddUnitOfMeasurementName });
            AddUnitOfMeasurementName = "";

            await ReloadAllData();
        }
        public async Task UpdateUnitOfMeasurement()
        {
            if (SelectedUnitOfMeasurement != null)
            {
                await _DbContext.UpdateUnitOfMeasurement(SelectedUnitOfMeasurement);
            }

            await ReloadAllData();
        }
        public async Task DeleteUnitOfMeasurement()
        {
            if (SelectedUnitOfMeasurement !=  null)
            {
                await _DbContext.DeleteUnitOfMeasurement(SelectedUnitOfMeasurement.Id);
            }

            await ReloadAllData();
        }
        public async Task DeleteAllUnitsOfMeasurement()
        {
            await _DbContext.DeleteAllUnitsOfMeasurement();
            await ReloadAllData();
        }
        #endregion
    }
}
