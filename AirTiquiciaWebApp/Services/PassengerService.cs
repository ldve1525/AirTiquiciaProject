using AirTiquicia.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace AirTiquiciaWebApp.Services
{
    public class PassengerService : IPassengerService
    {
        private readonly HttpClient httpClient;
        public PassengerService(HttpClient _httpClient)
        {
            this.httpClient = _httpClient;
        }

        public async Task<List<Passenger>> GetPassengers()
        {
            return await httpClient.GetFromJsonAsync<List<Passenger>>("passenger");
        }

        public async Task<Passenger> GetPassenger(string id)
        {
            return await httpClient.GetFromJsonAsync<Passenger>("passenger/" + id);
        }

        public async Task<bool> AddPassenger(Passenger passenger)
        {
            bool result = false;
            try
            {
                await httpClient.PostAsJsonAsync("passenger/", passenger);
                result = true;
            }
            catch (Exception)
            {

                throw;
            }

            return result;
        }

        public async Task<Passenger> UpdatePassenger(Passenger passenger)
        {
            await httpClient.PutAsJsonAsync<Passenger>("passenger/", passenger);

            return passenger;
        }
    }
}
