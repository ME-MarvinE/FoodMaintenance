﻿using SQLite;
using SQLiteNetExtensions.Attributes;
using System.Collections.Generic;

namespace FoodMaintenance.Models
{
    [Table("ProductTypes")]
    public class ProductType
    {
        #region Properties
        [PrimaryKey, AutoIncrement, NotNull]
        public int Id { get; set; }
        [NotNull]
        public string? Name { get; set; }
        [OneToMany(CascadeOperations = CascadeOperation.All, ReadOnly = true)]
        public List<Product>? Products { get; set; }
        #endregion
    }
}

