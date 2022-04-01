using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace AirTiquicia.Core.Entities
{
    public partial class Luggage
    {
        public Luggage()
        {
            Ticket = new HashSet<Ticket>();
        }

        public int Id { get; set; }
        public int? Quantity { get; set; }
        public int Weight { get; set; }
        public decimal Cost { get; set; }

        public virtual ICollection<Ticket> Ticket { get; set; }
    }
}
