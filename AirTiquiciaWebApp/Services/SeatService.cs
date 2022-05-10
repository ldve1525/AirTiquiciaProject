using AirTiquicia.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace AirTiquiciaWebApp.Services
{
    public class SeatService : ISeatService
    {
        private readonly HttpClient httpClient;
        public SeatService(HttpClient _httpClient)
        {
            this.httpClient = _httpClient;
        }

        public async Task<List<Seat>> GetSeats()
        {
            return await httpClient.GetFromJsonAsync<List<Seat>>("seat");
        }

        public async Task<Seat> GetSeat(int id)
        {
            return await httpClient.GetFromJsonAsync<Seat>("seat/" + id);
        }

        public async Task<int> AddSeat(Seat seat)
        {
            seat.Id = 0;
            int lastSeat;
            try
            {
                var response = await httpClient.PostAsJsonAsync("seat/", seat);
                lastSeat = await response.Content.ReadAsAsync<int>();
            }
            catch (Exception)
            {

                throw;
            }

            return lastSeat;
        }

        public async Task<Seat> UpdateSeat(Seat seat)
        {
            await httpClient.PutAsJsonAsync<Seat>("class/", seat);

            return seat;
        }
    }
}
