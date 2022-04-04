using System;
using System.Collections.Generic;
using System.Text;

namespace AirTiquicia.Core.Entities
{
    public partial class Price
    {
        public Price()
        {
            Ticket = new HashSet<Ticket>();
        }

        public int Id { get; set; }
        public int IdClass { get; set; }
        public int IdFlight { get; set; }
        public decimal Cost { get; set; }

        public virtual Class IdClassNavigation { get; set; }
        public virtual Flight IdFlightNavigation { get; set; }
        public virtual ICollection<Ticket> Ticket { get; set; }
    }
}
