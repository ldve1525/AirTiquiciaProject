using AirTiquicia.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AirTiquicia.Core.Interfaces
{
    public interface IFlightRepository
    {
        Task<IEnumerable<Flight>> GetFlights();

        Task<Flight> GetFlight(int id);

        Task<IEnumerable<Flight>> GetRoundtripFlight(string Airport1, string Airport2, string Date1, string Date2, int SeatsEconomic, int SeatsExecutive);

        Task<IEnumerable<Flight>> GetReturnFlight(string Airport1, string Airport2, string Date2, int SeatsEconomic, int SeatsExecutive);

        Task<bool> AddFlight(Flight flight);

        Task<bool> UpdateFlight(Flight flight);

        Task<bool> DeleteFlight(int id);
    }
}
