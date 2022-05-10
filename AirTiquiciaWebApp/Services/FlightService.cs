using AirTiquicia.Core.Entities;
using AirTiquicia.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace AirTiquiciaWebApp.Services
{
    public class FlightService : IFlightService
    {
        private readonly HttpClient httpClient;
        public FlightService(HttpClient _httpClient)
        {
            this.httpClient = _httpClient;
        }

        public async Task<List<Flight>> GetFlights()
        {
            return await httpClient.GetFromJsonAsync<List<Flight>>("flight");
        }

        public async Task<Flight> GetFlight(int id)
        {
            return await httpClient.GetFromJsonAsync<Flight>("flight/" + id);
        }

        public async Task<List<FlightDTO>> GetRoundtripFlight(string Airport1, string Airport2, string Date1, string Date2, int SeatsEconomic, int SeatsExecutive)
        {
            return await httpClient.GetFromJsonAsync<List<FlightDTO>>("flight/" + Airport1 + "/" + Airport2 + "/" + Date1 + "/" + Date2 + "/" + SeatsEconomic + "/" + SeatsExecutive);
        }

        public async Task<List<FlightDTO>> GetReturnFlight(string Airport1, string Airport2, string Date2, int SeatsEconomic, int SeatsExecutive)
        {
            return await httpClient.GetFromJsonAsync<List<FlightDTO>>("flight/" + Airport1 + "/" + Airport2 + "/" + Date2 + "/" + SeatsEconomic + "/" + SeatsExecutive);
        }

        public async Task<bool> AddFlight(Flight flight)
        {
            bool result = false;
            try
            {
                await httpClient.PostAsJsonAsync("flight/", flight);
                result = true;
            }
            catch (Exception)
            {

                throw;
            }

            return result;
        }

        public async Task<Flight> UpdateFlight(Flight flight)
        {
            await httpClient.PutAsJsonAsync<Flight>("flight/", flight);

            return flight;
        }
    }
}
