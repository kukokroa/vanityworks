using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VanityWorks.Core.Domain
{
    public class User : Entity
    {
        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }
         
        public string EmailAddress { get; set; }

        public string Password { get; set; }

        public DateTime Birthday { get; set; }

        public string ContactNumber { get; set; }

        public bool Admin { get; set; }

        public string GetFullName()
        {
            return $"{FirstName} {MiddleName} {LastName}";
        }
    }
}
