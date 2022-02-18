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
        [ForeignKey(typeof(ProductType)), NotNull]
        public int TypeId { get; set; }
        [ManyToOne(CascadeOperations = CascadeOperation.All)]
        public ProductType? Type { get; set; }
        [NotNull]
        public int MinStockQuantity { get; set; }
        [ForeignKey(typeof(UnitOfMeasurement)), NotNull]
        public int UnitOfMeasurementId { get; set; }
        [ManyToOne(CascadeOperations = CascadeOperation.All)]
        public UnitOfMeasurement? UnitOfMeasurement { get; set; }
        [NotNull]
        public bool IsActive { get; set; }
        #endregion
    }
}