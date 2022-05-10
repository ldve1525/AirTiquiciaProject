using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace AirTiquicia.Core.Entities
{
    public partial class Airplane
    {
        public Airplane()
        {
            Flight = new HashSet<Flight>();
        }

        public string IdAirplane { get; set; }
        public int IdAeroline { get; set; }
        public string Description { get; set; }
        public int Size { get; set; }
        public int CapacityEconomic { get; set; }
        public int CapacityExecutive { get; set; }

        public virtual Aeroline IdAerolineNavigation { get; set; }
        public virtual ICollection<Flight> Flight { get; set; }
    }
}
