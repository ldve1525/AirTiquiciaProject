using System;
using System.Collections.Generic;
using System.Text;

namespace AirTiquicia.Core.DTOs
{
    public class PriceDTO
    {
        public int Id { get; set; }
        public int IdClass { get; set; }
        public int IdFlight { get; set; }
        public decimal Cost { get; set; }

    }
}
