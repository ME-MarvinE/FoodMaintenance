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
        [NotNull]
        public string? Name { get; set; }
        [ForeignKey(typeof(ProductType))]
        public string? TypeName { get; set; }
        [ManyToOne]
        public ProductType? Type { get; set; }
        [NotNull]
        public float MinStockQuantity { get; set; }
        [ForeignKey(typeof(UnitOfMeasurement))]
        public string? UnitOfMeasurementName { get; set; }
        [ManyToOne]
        public UnitOfMeasurement? UnitOfMeasurement { get; set; }
        [NotNull]
        public bool IsActive { get; set; }
        #endregion
    }
}