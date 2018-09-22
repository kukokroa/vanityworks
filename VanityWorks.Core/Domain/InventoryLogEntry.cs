using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VanityWorks.Core.Domain
{
    public class InventoryLogEntry: Entity
    {
        public Item Item { get; set; }

        public decimal quantity { get; set; }

        public InventoryLogEntryTypes InventoryLogEntryType { get; set; }

        public InventoryLog InventoryLog { get; set; }

        public enum InventoryLogEntryTypes
        {
            LogEntry = 0,
            NewStock = 1
        }
    }
    
}
