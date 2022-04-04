﻿using System;
using System.Collections.Generic;
using System.Text;

namespace AirTiquicia.Core.DTOs
{
    public class FlightDTO
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string IdAirplane { get; set; }
        public string DepartureAirport { get; set; }
        public DateTime DepartureDate { get; set; }
        public string DestinationAirport { get; set; }
        public DateTime ArrivalDate { get; set; }
        public string Stopover { get; set; }

        public int hour { get; set; }
        public int time { get; set; }
    }
}
