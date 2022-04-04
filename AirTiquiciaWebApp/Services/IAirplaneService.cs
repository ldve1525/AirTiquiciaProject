using AirTiquicia.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirTiquiciaWebApp.Services
{
    public interface IAirplaneService
    {
        Task<List<Airplane>> GetAirplanes();

        Task<Airplane> GetAirplane(string id);

        Task<bool> AddAirplane(Airplane airplane);

        Task<Airplane> UpdateAirplane(Airplane airplane);
    }
}

