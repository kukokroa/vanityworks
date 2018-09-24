using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VanityWorks.Core.Domain
{
    public class InventoryLog: Entity
    {
        public User User { get; set; }
        
        public DateTime DateClosed { get; set; }

        public List<InventoryLogEntry> InventoryLogEntries { get; set; }
    }
}
