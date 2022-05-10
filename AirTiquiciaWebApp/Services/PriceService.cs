using AirTiquicia.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace AirTiquiciaWebApp.Services
{
    public class PriceService : IPriceService
    {
        private readonly HttpClient httpClient;
        public PriceService(HttpClient _httpClient)
        {
            this.httpClient = _httpClient;
        }

        public async Task<List<Price>> GetPrices()
        {
            return await httpClient.GetFromJsonAsync<List<Price>>("price");
        }

        public async Task<Price> GetPrice(int id)
        {
            return await httpClient.GetFromJsonAsync<Price>("price/" + id);
        }

        public async Task<Price> GetPrice(int idClass, int idFlight)
        {
            return await httpClient.GetFromJsonAsync<Price>("price/" + idClass + "/" + idFlight);
        }

        public async Task<bool> AddPrice(Price price)
        {
            bool result = false;
            try
            {
                await httpClient.PostAsJsonAsync("price/", price);
                result = true;
            }
            catch (Exception)
            {

                throw;
            }

            return result;
        }

        public async Task<Price> UpdatePrice(Price price)
        {
            await httpClient.PutAsJsonAsync<Price>("price/", price);

            return price;
        }
    }
}
