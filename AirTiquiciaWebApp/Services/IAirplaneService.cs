using AirTiquicia.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirTiquiciaWebApp.Services
{
    interface IAirplaneService
    {
        Task<List<Airplane>> GetAirplanes();
    }
}
