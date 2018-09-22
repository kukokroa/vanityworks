using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VanityWorks.Core.Domain
{
    public class Item : Entity
    {
        public string Name { get; set; }

        public string SupplierName { get; set; }

        public string Unit { get; set; } //kg, mL, L, g

        public decimal UnitQuantity { get; set; }

        public decimal UnitQuantityPrice { get; set; } //Actual price : UnitQuantity / UnitQuantityPrice

        public DateTime DateCreated { get; set; }

        public decimal Price()
        {
            return UnitQuantityPrice / UnitQuantity;
        }

    }
}
