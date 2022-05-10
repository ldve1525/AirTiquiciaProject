using AirTiquicia.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace AirTiquiciaWebApp.Services
{
    public class ClassService : IClassService
    {
        private readonly HttpClient httpClient;
        public ClassService(HttpClient _httpClient)
        {
            this.httpClient = _httpClient;
        }

        public async Task<List<Class>> GetClasses()
        {
            return await httpClient.GetFromJsonAsync<List<Class>>("class");
        }

        public async Task<Class> GetClass(int id)
        {
            return await httpClient.GetFromJsonAsync<Class>("class/" + id);
        }

        public async Task<bool> AddClass(Class flightClass)
        {
            bool result = false;
            try
            {
                await httpClient.PostAsJsonAsync("class/", flightClass);
                result = true;
            }
            catch (Exception)
            {

                throw;
            }

            return result;
        }

        public async Task<Class> UpdateClass(Class flightClass)
        {
            await httpClient.PutAsJsonAsync<Class>("class/", flightClass);

            return flightClass;
        }
    }
}
