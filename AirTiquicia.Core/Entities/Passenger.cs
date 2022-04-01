using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace AirTiquicia.Core.Entities
{
    public partial class Passenger
    {
        public Passenger()
        {
            Ticket = new HashSet<Ticket>();
        }

        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int DocumentType { get; set; }
        public DateTime Birthdate { get; set; }
        public string Nationality { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public int? IdUser { get; set; }

        public virtual ICollection<Ticket> Ticket { get; set; }
    }
}
