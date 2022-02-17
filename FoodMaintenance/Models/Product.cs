using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodMaintenance.Models
{
    public class Product : BaseObservableModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Type { get; set; }
        public int MinStockQuantity { get; set; }
        public UnitOfMeasurement UnitOfMeasurement { get; set; }
        public bool IsActive { get; set; }
    }
}
