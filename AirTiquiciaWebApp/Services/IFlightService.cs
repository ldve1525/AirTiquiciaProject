using AirTiquicia.Core.Entities;
using AirTiquicia.Core.DTOs;
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

        Task<List<FlightDTO>> GetRoundtripFlight(string Airport1, string Airport2, string Date1, string Date2, int SeatsEconomic, int SeatsExecutive);

        Task<List<FlightDTO>> GetReturnFlight(string Airport1, string Airport2, string Date2, int SeatsEconomic, int SeatsExecutive);

        Task<bool> AddFlight(Flight flight);

        Task<Flight> UpdateFlight(Flight flight);
    }
}
