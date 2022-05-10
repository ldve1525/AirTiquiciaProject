using AirTiquicia.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
namespace AirTiquiciaWebApp.Services
{
    public class LuggageService : ILuggageService
    {
        private readonly HttpClient httpClient;
        public LuggageService(HttpClient _httpClient)
        {
            this.httpClient = _httpClient;
        }

        public async Task<List<Luggage>> GetLuggages()
        {
            return await httpClient.GetFromJsonAsync<List<Luggage>>("luggage");
        }

        public async Task<Luggage> GetLuggage(int id)
        {
            return await httpClient.GetFromJsonAsync<Luggage>("luggage/" + id);
        }

        public async Task<int> AddLuggage(Luggage luggage)
        {
            int lastLuggage;
            luggage.Id = 0;
            try
            {
                var response = await httpClient.PostAsJsonAsync("luggage/", luggage);
                lastLuggage = await response.Content.ReadAsAsync<int>();
            }
            catch (Exception)
            {

                throw;
            }

            return lastLuggage;
        }

        public async Task<Luggage> UpdateLuggage(Luggage luggage)
        {
            await httpClient.PutAsJsonAsync<Luggage>("luggage/", luggage);

            return luggage;
        }
    }
}
