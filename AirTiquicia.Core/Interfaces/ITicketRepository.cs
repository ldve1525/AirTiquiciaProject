using AirTiquicia.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AirTiquicia.Core.Interfaces
{
    public interface ITicketRepository
    {
        Task<IEnumerable<Ticket>> GetTickets();

        Task<Ticket> GetTicket(int id);

        Task<bool> AddTicket(Ticket Ticket);

        Task<bool> UpdateTicket(Ticket Ticket);

        Task<bool> DeleteTicket(int id);
    }
}
