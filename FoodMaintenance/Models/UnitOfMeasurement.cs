using SQLite;
using SQLiteNetExtensions.Attributes;
using System.Collections.Generic;

namespace FoodMaintenance.Models
{
    [Table("UnitsOfMeasurement")]
    public class UnitOfMeasurement
    {
        #region Properties
        [PrimaryKey, AutoIncrement, NotNull]
        public int Id { get; set; }
        [NotNull]
        public string? Name { get; set; }
        [OneToMany]
        public List<ProductDTO>? Products { get; set; }
        #endregion
    }
}