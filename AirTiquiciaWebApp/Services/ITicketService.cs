using AirTiquicia.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirTiquiciaWebApp.Services
{
    public interface ITicketService
    {
        Task<List<Ticket>> GetTickets();

        Task<Ticket> GetTicket(int id);

        Task<bool> AddTicket(Ticket ticket);

        Task<Ticket> UpdateTicket(Ticket ticket);
    }
}