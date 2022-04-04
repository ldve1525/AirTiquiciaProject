using AirTiquicia.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace AirTiquiciaWebApp.Services
{
    public class AirportService : IAirportService
    {
        private readonly HttpClient httpClient;
        public AirportService(HttpClient _httpClient)
        {
            this.httpClient = _httpClient;
        }

        public async Task<List<Airport>> GetAirports()
        {
            return await httpClient.GetFromJsonAsync<List<Airport>>("airport");
        }

        public async Task<Airport> GetAirport(string id)
        {
            return await httpClient.GetFromJsonAsync<Airport>("airport/" + id);
        }

        public async Task<bool> AddAirport(Airport airport)
        {
            bool result = false;
            try
            {
                await httpClient.PostAsJsonAsync("airport/", airport);
                result = true;
            }
            catch (Exception)
            {

                throw;
            }

            return result;
        }

        public async Task<Airport> UpdateAirport(Airport airport)
        {
            await httpClient.PutAsJsonAsync<Airport>("airport/", airport);

            return airport;
        }
    }
}
