using AirTiquicia.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace AirTiquiciaWebApp.Services
{
    public class TicketService : ITicketService
    {
        private readonly HttpClient httpClient;
        public TicketService(HttpClient _httpClient)
        {
            this.httpClient = _httpClient;
        }

        public async Task<List<Ticket>> GetTickets()
        {
            return await httpClient.GetFromJsonAsync<List<Ticket>>("ticket");
        }

        public async Task<Ticket> GetTicket(int id)
        {
            return await httpClient.GetFromJsonAsync<Ticket>("ticket/" + id);
        }

        public async Task<bool> AddTicket(Ticket ticket)
        {
            bool result = false;
            try
            {
                await httpClient.PostAsJsonAsync("ticket/", ticket);
                result = true;
            }
            catch (Exception)
            {

                throw;
            }

            return result;
        }

        public async Task<Ticket> UpdateTicket(Ticket ticket)
        {
            await httpClient.PutAsJsonAsync<Ticket>("ticket/", ticket);

            return ticket;
        }
    }
}
