﻿using System;
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

        public string Deleted { get; set; }

        public DateTime DateDeleted { get; set; }
        public DateTime DateUpdated { get; set; }
    }
}
