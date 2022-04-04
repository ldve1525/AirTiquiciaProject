using AirTiquicia.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace AirTiquiciaWebApp.Services
{
    public class AirplaneService : IAirplaneService
    {
        private readonly HttpClient httpClient;
        public AirplaneService(HttpClient _httpClient)
        {
            this.httpClient = _httpClient;
        }

        public async Task<List<Airplane>> GetAirplanes()
        {
            return await httpClient.GetFromJsonAsync<List<Airplane>>("airplane"); 
        }

        public async Task<Airplane> GetAirplane(string id)
        {
            return await httpClient.GetFromJsonAsync<Airplane>("airplane/"+id);
        }

        public async Task<bool> AddAirplane(Airplane airplane)
        {
            bool result = false;
            try
            {
                await httpClient.PostAsJsonAsync("airplane/", airplane);
                result = true;
            }
            catch (Exception)
            {

                throw;
            }

            return result;
        }

        public async Task<Airplane> UpdateAirplane(Airplane airplane)
        {
            await httpClient.PutAsJsonAsync<Airplane>("airplane/", airplane);

            return airplane;
        }
    }
}
