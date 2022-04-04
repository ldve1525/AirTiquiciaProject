using AirTiquicia.Core.Entities;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace AirTiquiciaWebApp.Services
{
    public class AerolineService : IAerolineService
    {
        private readonly HttpClient httpClient;
        public AerolineService(HttpClient _httpClient)
        {
            this.httpClient = _httpClient;
        }

        public async Task<List<Aeroline>> GetAerolines()
        {
            return await httpClient.GetFromJsonAsync<List<Aeroline>>("aeroline");
        }

        public async Task<Aeroline> GetAeroline(int id)
        {
            return await httpClient.GetFromJsonAsync<Aeroline>("aeroline/" + id);
        }

        public async Task<bool> AddAeroline(Aeroline aeroline)
        {
            bool result = false;
            try
            {
                await httpClient.PostAsJsonAsync("aeroline/", aeroline);
                result = true;
            }
            catch (Exception)
            {

                throw;
            }

            return result;
        }
    }
}
