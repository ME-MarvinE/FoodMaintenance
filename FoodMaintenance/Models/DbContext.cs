﻿using AutoMapper;
using SQLite;
using SQLiteNetExtensionsAsync.Extensions;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace FoodMaintenance.Models
{
    public class DbContext
    {
        #region Fields
        private readonly SQLiteAsyncConnection _Con;
        private readonly IMapper _Mapper;
        #endregion

        #region Constructors
        public DbContext(string DbName, string DbDirectory)
        : this(Path.Combine(DbDirectory, DbName))
        {
        }
        public DbContext(string DbPath)
        {
            _Con = new SQLiteAsyncConnection(DbPath);

            MapperConfiguration MapperConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<ProductType, ProductTypeDTO>()
                    .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                    .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));
                config.CreateMap<ProductTypeDTO, ProductType>()
                    .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                    .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));
                config.CreateMap<UnitOfMeasurement, UnitOfMeasurementDTO>()
                    .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                    .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));
                config.CreateMap<UnitOfMeasurementDTO, UnitOfMeasurement>()
                    .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                    .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));
            });

            _Mapper = MapperConfig.CreateMapper();
        }
        #endregion

        #region Methods
        protected async Task<SQLiteAsyncConnection> GetConnection()
        {
            await _Con.CreateTableAsync<Product>();
            await _Con.CreateTableAsync<ProductType>();
            await _Con.CreateTableAsync<UnitOfMeasurement>();
            return _Con;
        }
        public async Task<List<ProductTypeDTO>> GetProductTypes()
        {
            SQLiteAsyncConnection Con = await GetConnection();

            List<ProductType> ProductTypes = await Con.GetAllWithChildrenAsync<ProductType>();
            List<ProductTypeDTO> ProductTypesDTO;

            ProductTypesDTO = _Mapper.Map<List<ProductType>, List<ProductTypeDTO>>(ProductTypes);

            return ProductTypesDTO;
        }
        public async Task<ProductTypeDTO?> GetProductType(int Id)
        {
            SQLiteAsyncConnection Con = await GetConnection();

            ProductType? ProductType = await Con.GetWithChildrenAsync<ProductType?>(Id);
            return _Mapper.Map<ProductType?, ProductTypeDTO>(ProductType);
        }
        public async Task AddProductType(ProductTypeDTO ProductTypeDTO)
        {
            SQLiteAsyncConnection Con = await GetConnection();

            ProductType ProductType = _Mapper.Map<ProductTypeDTO, ProductType>(ProductTypeDTO);
            await Con.InsertWithChildrenAsync(ProductType);
        }
        public async Task UpdateProductType(ProductTypeDTO ProductTypeDTO)
        {
            SQLiteAsyncConnection Con = await GetConnection();

            ProductType ProductType = _Mapper.Map<ProductTypeDTO, ProductType>(ProductTypeDTO);
            await Con.UpdateWithChildrenAsync(ProductType);
        }
        public async Task DeleteProductType(int Id)
        {
            SQLiteAsyncConnection Con = await GetConnection();

            await Con.DeleteAsync<ProductType>(Id);
        }
        public async Task DeleteAllProductTypes()
        {
            SQLiteAsyncConnection Con = await GetConnection();

            await Con.DeleteAllAsync<ProductType>();
        }
        public async Task<List<UnitOfMeasurementDTO>> GetUnitsOfMeasurement()
        {
            SQLiteAsyncConnection Con = await GetConnection();

            List<UnitOfMeasurement> UnitsOfMeasurement = await Con.GetAllWithChildrenAsync<UnitOfMeasurement>();
            List<UnitOfMeasurementDTO> UnitsOfMeasurementDTO;

            UnitsOfMeasurementDTO = _Mapper.Map<List<UnitOfMeasurement>, List<UnitOfMeasurementDTO>>(UnitsOfMeasurement);

            return UnitsOfMeasurementDTO;
        }
        public async Task<UnitOfMeasurementDTO?> GetUnitOfMeasurement(int Id)
        {
            SQLiteAsyncConnection Con = await GetConnection();

            UnitOfMeasurement? UnitOfMeasurement = await Con.GetWithChildrenAsync<UnitOfMeasurement?>(Id);
            return _Mapper.Map<UnitOfMeasurement?, UnitOfMeasurementDTO>(UnitOfMeasurement);
        }
        public async Task AddUnitOfMeasurement(UnitOfMeasurementDTO UnitOfMeasurementDTO)
        {
            SQLiteAsyncConnection Con = await GetConnection();

            UnitOfMeasurement UnitOfMeasurement = _Mapper.Map<UnitOfMeasurementDTO, UnitOfMeasurement>(UnitOfMeasurementDTO);
            await Con.InsertWithChildrenAsync(UnitOfMeasurement);
        }
        public async Task UpdateUnitOfMeasurement(UnitOfMeasurementDTO UnitOfMeasurementDTO)
        {
            SQLiteAsyncConnection Con = await GetConnection();

            UnitOfMeasurement UnitOfMeasurement = _Mapper.Map<UnitOfMeasurementDTO, UnitOfMeasurement>(UnitOfMeasurementDTO);
            await Con.UpdateWithChildrenAsync(UnitOfMeasurement);
        }
        public async Task DeleteUnitOfMeasurement(int Id)
        {
            SQLiteAsyncConnection Con = await GetConnection();

            await Con.DeleteAsync<UnitOfMeasurement>(Id);
        }
        public async Task DeleteAllUnitsOfMeasurement()
        {
            SQLiteAsyncConnection Con = await GetConnection();

            await Con.DeleteAllAsync<UnitOfMeasurement>();
        }
        #endregion  
    }
}
