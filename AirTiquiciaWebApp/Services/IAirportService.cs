using AirTiquicia.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirTiquiciaWebApp.Services
{
    public interface IAirportService
    {
        Task<List<Airport>> GetAirports();

        Task<Airport> GetAirport(string id);

        Task<bool> AddAirport(Airport airport);

        Task<Airport> UpdateAirport(Airport airport);
    }
}
