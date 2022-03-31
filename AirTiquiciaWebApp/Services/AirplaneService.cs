using AirTiquicia.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace AirTiquiciaWebApp.Services
{
    public class AirplaneService:IAirplaneService
    {
        private readonly HttpClient httpClient;
        public AirplaneService(HttpClient _httpClient)
        {
            this.httpClient = _httpClient;
        }

        public async Task<List<Airplane>> GetAirplanes()
        {
            return await httpClient.GetFromJsonAsync<List<Airplane>>("getairplanes"); 
        }
    }
}
