using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VanityWorks.Core.Domain
{
    public class InventoryEntry : Entity
    {
        public string Name { get; set; }
        public int ItemId { get; set; }
        public decimal Quantity { get; set; }
        public enum InventoryLogEntryTypes
        {
            LogEntry = 0,
            NewStock = 1
        }
        public InventoryLogEntryTypes InventoryLogEntryType { get; set; }
    }

}
