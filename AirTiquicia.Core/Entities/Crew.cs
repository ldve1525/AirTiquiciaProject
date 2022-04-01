using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace AirTiquicia.Core.Entities
{
    public partial class Crew
    {
        public int Id { get; set; }
        public int IdFlight { get; set; }
        public string IdEmployee { get; set; }

        public virtual Employee IdEmployeeNavigation { get; set; }
        public virtual Flight IdFlightNavigation { get; set; }
    }
}
