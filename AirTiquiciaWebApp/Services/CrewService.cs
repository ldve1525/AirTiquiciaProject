using AirTiquicia.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace AirTiquiciaWebApp.Services
{
    public class CrewService : ICrewService
    {
        private readonly HttpClient httpClient;
        public CrewService(HttpClient _httpClient)
        {
            this.httpClient = _httpClient;
        }

        public async Task<List<Crew>> GetCrews()
        {
            return await httpClient.GetFromJsonAsync<List<Crew>>("crew");
        }

        public async Task<Crew> GetCrew(int id)
        {
            return await httpClient.GetFromJsonAsync<Crew>("crew/" + id);
        }

        public async Task<bool> AddCrew(Crew crew)
        {
            bool result = false;
            try
            {
                await httpClient.PostAsJsonAsync("crew/", crew);
                result = true;
            }
            catch (Exception)
            {

                throw;
            }

            return result;
        }

        public async Task<Crew> UpdateCrew(Crew crew)
        {
            await httpClient.PutAsJsonAsync<Crew>("crew/", crew);

            return crew;
        }
    }
}
