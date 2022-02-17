using SQLite;
using SQLiteNetExtensions.Attributes;

namespace FoodMaintenance.Models
{
    [Table("Products")]
    public class Product
    {
        #region Properties
        [PrimaryKey, AutoIncrement, NotNull]
        public int Id { get; set; }
        [ForeignKey(typeof(ProductTypeDTO)), NotNull]
        public int TypeId { get; set; }
        [ManyToOne]
        public ProductTypeDTO? Type { get; set; }
        [NotNull]
        public int MinStockQuantity { get; set; }
        [ForeignKey(typeof(UnitOfMeasurementDTO)), NotNull]
        public int UnitOfMeasurementId { get; set; }
        [ManyToOne]
        public UnitOfMeasurementDTO? UnitOfMeasurement { get; set; }
        [NotNull]
        public bool IsActive { get; set; }
        #endregion
    }
}