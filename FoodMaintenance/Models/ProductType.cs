using SQLite;
using SQLiteNetExtensions.Attributes;
using System.Collections.Generic;

namespace FoodMaintenance.Models
{
    [Table("ProductTypes")]
    public class ProductType
    {
        #region Properties
        [PrimaryKey, NotNull]
        public string? Name { get; set; }
        [OneToMany]
        public List<Product>? Products { get; set; }
        #endregion
    }
}

