using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace AirTiquicia.Core.Entities
{
    public partial class Flight
    {
        public Flight()
        {
            Crew = new HashSet<Crew>();
            Ticket = new HashSet<Ticket>();
        }

        public int Id { get; set; }
        public string Code { get; set; }
        public string IdAirplane { get; set; }
        public string DepartureAirport { get; set; }
        public DateTime DepartureDate { get; set; }
        public string DestinationAirport { get; set; }
        public DateTime ArrivalDate { get; set; }
        public string Stopover { get; set; }
        public int Type { get; set; }
        public int SeatsEconomic { get; set; }
        public int SeatsExecutive { get; set; }
        

        public virtual Airport DepartureAirportNavigation { get; set; }
        public virtual Airport DestinationAirportNavigation { get; set; }
        public virtual Airplane IdAirplaneNavigation { get; set; }
        public virtual Airport StopoverNavigation { get; set; }
        public virtual ICollection<Crew> Crew { get; set; }
        public virtual ICollection<Price> Price { get; set; }
        public virtual ICollection<Ticket> Ticket { get; set; }
    }
}
