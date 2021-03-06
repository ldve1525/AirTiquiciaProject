using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace AirTiquicia.Core.Entities
{
    public partial class Employee
    {
        public Employee()
        {
            Crew = new HashSet<Crew>();
        }

        public string IdEmployee { get; set; }
        public int JobCategory { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public virtual ICollection<Crew> Crew { get; set; }
    }
}
