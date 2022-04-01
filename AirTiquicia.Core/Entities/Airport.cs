using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace AirTiquicia.Core.Entities
{
    public partial class Airport
    {
        public Airport()
        {
            FlightDepartureAirportNavigation = new HashSet<Flight>();
            FlightDestinationAirportNavigation = new HashSet<Flight>();
            FlightStopoverNavigation = new HashSet<Flight>();
        }

        public string IdAirport { get; set; }
        public string Name { get; set; }
        public int IdCountry { get; set; }

        public virtual Country IdCountryNavigation { get; set; }
        public virtual ICollection<Flight> FlightDepartureAirportNavigation { get; set; }
        public virtual ICollection<Flight> FlightDestinationAirportNavigation { get; set; }
        public virtual ICollection<Flight> FlightStopoverNavigation { get; set; }
    }
}
