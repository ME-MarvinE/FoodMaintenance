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
        public ProductDTO ProductToAdd { get; set; } = new ProductDTO();
        public ProductTypeDTO? SelectedProductType { get; set; }
        public ProductTypeDTO ProductTypeToAdd { get; set; } = new ProductTypeDTO();
        public UnitOfMeasurementDTO? SelectedUnitOfMeasurement { get; set; }
        public UnitOfMeasurementDTO UnitOfMeasurementToAdd { get; set; } = new UnitOfMeasurementDTO();
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
        public ICommand ReloadDataCommand { get; set; }
        #endregion

        #region Constructors
        public DashboardViewModel(INavigationService NavigationService, DbContext DbContext)
            : base(NavigationService)
        {
            //Didn't use AsyncRelayCommand because it eats exceptions.
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
            ReloadDataCommand = new RelayCommand(async () => { await ReloadData(); });

            _DbContext = DbContext;
        }
        #endregion

        #region Methods
        public async Task ReloadData()
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
            await _DbContext.AddProduct(ProductToAdd);
            ProductToAdd = new ProductDTO();
            await ReloadData();
        }
        public async Task UpdateProduct()
        {
            if (SelectedProduct != null)
            {
                await _DbContext.UpdateProduct(SelectedProduct);
            }

            await ReloadData();
        }
        public async Task DeleteProduct()
        {
            if (SelectedProduct != null)
            {
                await _DbContext.DeleteProduct(SelectedProduct.Id);
            }

            await ReloadData();
        }
        public async Task DeleteAllProducts()
        {
            await _DbContext.DeleteAllProducts();
            await ReloadData();
        }
        public async Task GetProductTypes()
        {
            ProductTypes = await _DbContext.GetProductTypes();
        }
        public async Task AddProductType()
        {
            await _DbContext.AddProductType(ProductTypeToAdd);
            ProductTypeToAdd = new ProductTypeDTO();

            await ReloadData();
        }
        public async Task UpdateProductType()
        {
            if (SelectedProductType != null)
            {
                await _DbContext.UpdateProductType(SelectedProductType);
            }

            await ReloadData();
        }
        public async Task DeleteProductType()
        {
            if (SelectedProductType != null)
            {
                await _DbContext.DeleteProductType(SelectedProductType.Id);
            }

            await ReloadData();
        }
        public async Task DeleteAllProductTypes()
        {
            await _DbContext.DeleteAllProductTypes();
            await ReloadData();
        }
        public async Task GetUnitsOfMeasurement()
        {
            UnitsOfMeasurement = await _DbContext.GetUnitsOfMeasurement();
        }
        public async Task AddUnitOfMeasurement()
        {
            await _DbContext.AddUnitOfMeasurement(UnitOfMeasurementToAdd);
            UnitOfMeasurementToAdd = new UnitOfMeasurementDTO();

            await ReloadData();
        }
        public async Task UpdateUnitOfMeasurement()
        {
            if (SelectedUnitOfMeasurement != null)
            {
                await _DbContext.UpdateUnitOfMeasurement(SelectedUnitOfMeasurement);
            }

            await ReloadData();
        }
        public async Task DeleteUnitOfMeasurement()
        {
            if (SelectedUnitOfMeasurement !=  null)
            {
                await _DbContext.DeleteUnitOfMeasurement(SelectedUnitOfMeasurement.Id);
            }

            await ReloadData();
        }
        public async Task DeleteAllUnitsOfMeasurement()
        {
            await _DbContext.DeleteAllUnitsOfMeasurement();
            await ReloadData();
        }
        #endregion
    }
}
