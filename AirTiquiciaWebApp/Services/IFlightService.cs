using AirTiquicia.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirTiquiciaWebApp.Services
{
    public interface IFlightService
    {
        Task<List<Flight>> GetFlights();

        Task<Flight> GetFlight(int id);

        Task<bool> AddFlight(Flight flight);

        Task<Flight> UpdateFlight(Flight flight);
    }
}
