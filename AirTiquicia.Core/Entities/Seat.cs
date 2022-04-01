using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace AirTiquicia.Core.Entities
{
    public partial class Seat
    {
        public int Id { get; set; }
        public int Letter { get; set; }
        public int Row { get; set; }
        public int IdClass { get; set; }

        public virtual Class IdClassNavigation { get; set; }
    }
}
