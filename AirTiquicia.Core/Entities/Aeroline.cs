using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace AirTiquicia.Core.Entities
{
    public partial class Aeroline
    {
        public Aeroline()
        {
            Airplane = new HashSet<Airplane>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Airplane> Airplane { get; set; }
    }
}
