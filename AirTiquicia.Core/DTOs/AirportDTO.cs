using System;
using System.Collections.Generic;
using System.Text;

namespace AirTiquicia.Core.DTOs
{
    public class AirportDTO
    {
        public string IdAirport { get; set; }
        public string Name { get; set; }
        public int IdCountry { get; set; }
        public string City { get; set; }
    }
}
