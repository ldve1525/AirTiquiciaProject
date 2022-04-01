using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace AirTiquicia.Core.Entities
{
    public partial class Country
    {
        public Country()
        {
            Airport = new HashSet<Airport>();
        }

        public int Id { get; set; }
        public string CountryName { get; set; }

        public virtual ICollection<Airport> Airport { get; set; }
    }
}
