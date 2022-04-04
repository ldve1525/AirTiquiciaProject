using AirTiquicia.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AirTiquicia.Core.Interfaces
{
    public interface IAirportRepository
    {
        Task<IEnumerable<Airport>> GetAirports();

        Task<Airport> GetAirport(string id);

        Task<bool> AddAirport(Airport airport);

        Task<bool> UpdateAirport(Airport airport);

        Task<bool> DeleteAirport(string id);
    }
}
