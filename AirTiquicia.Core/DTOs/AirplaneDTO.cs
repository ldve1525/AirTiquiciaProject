﻿using System;
using System.Collections.Generic;
using System.Text;

namespace AirTiquicia.Core.DTOs
{
    public class AirplaneDTO
    {
        public string IdAirplane { get; set; }
        public int IdAeroline { get; set; }
        public string Description { get; set; }
        public int Size { get; set; }
        public int Capacity { get; set; }
    }
}
