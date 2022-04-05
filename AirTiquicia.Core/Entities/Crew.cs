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
        public string IdEmployee1 { get; set; }
        public string IdEmployee2 { get; set; }
        public string IdEmployee3 { get; set; }
        public string IdPilot { get; set; }
        public string IdCopilot { get; set; }

        public virtual Employee IdEmployeeNavigation { get; set; }
        public virtual Flight IdFlightNavigation { get; set; }
    }
}
