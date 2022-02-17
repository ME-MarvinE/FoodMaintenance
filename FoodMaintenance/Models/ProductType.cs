using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodMaintenance.Models
{
    public class ProductType : BaseObservableModel
    {
        #region Properties
        public int Id { get; set; }
        public string? Name { get; set; }
        #endregion
    }
}
