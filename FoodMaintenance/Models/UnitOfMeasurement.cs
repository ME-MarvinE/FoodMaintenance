using SQLite;
using SQLiteNetExtensions.Attributes;
using System.Collections.Generic;

namespace FoodMaintenance.Models
{
    [Table("UnitsOfMeasurement")]
    public class UnitOfMeasurement
    {
        #region Properties
        [PrimaryKey, NotNull]
        public string? Name { get; set; }
        [OneToMany]
        public List<Product>? Products { get; set; }
        #endregion
    }
}