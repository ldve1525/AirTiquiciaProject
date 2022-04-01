using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace AirTiquicia.Core.Entities
{
    public partial class Ticket
    {
        public int Id { get; set; }
        public int IdFlight { get; set; }
        public string IdPassenger { get; set; }
        public int IdClass { get; set; }
        public decimal Price { get; set; }
        public DateTime Date { get; set; }
        public int IdSeat { get; set; }
        public int IdLuggage { get; set; }

        public virtual Class IdClassNavigation { get; set; }
        public virtual Flight IdFlightNavigation { get; set; }
        public virtual Luggage IdLuggageNavigation { get; set; }
        public virtual Passenger IdPassengerNavigation { get; set; }
    }
}
