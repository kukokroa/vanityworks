using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VanityWorks.Core
{
    public class Entity
    {
        public int Id { get; set; }

        public DateTime DateCreated { get; set; }

        public bool Deleted { get; set; }

        public DateTime DateDeleted { get; set; }
    }
}
