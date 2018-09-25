using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VanityWorks.Core.Domain
{
    public class Inventory : Entity
    {
        public string Name { get; set; }

        public decimal Price { get; set; }
        public decimal UnitQuantity { get; set; }

    }

}
