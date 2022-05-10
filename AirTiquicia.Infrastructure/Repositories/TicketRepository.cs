using AirTiquicia.Core.Entities;
using AirTiquicia.Core.Interfaces;
using AirTiquicia.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirTiquicia.Infrastructure.Repositories
{
    public class TicketRepository : ITicketRepository
    {
        private readonly AirTiquiciaContext _context;

        public TicketRepository(AirTiquiciaContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Ticket>> GetTickets()
        {
            var Tickets = await Task.FromResult(_context.Ticket.ToList());

            return Tickets;
        }

        public async Task<Ticket> GetTicket(int id)
        {
            var Ticket = await _context.Ticket.FirstOrDefaultAsync(x => x.Id == id);

            return Ticket;
        }

        public async Task<bool> AddTicket(Ticket Ticket)
        {
            bool added;

            try
            {
                _context.Ticket.Add(Ticket);
                await _context.SaveChangesAsync();

                added = true;
            }
            catch (Exception)
            {

                throw;
            }

            return added;
        }

        public async Task<bool> UpdateTicket(Ticket Ticket)
        {
            var currentTicket = await GetTicket(Ticket.Id);

            currentTicket.IdFlight = Ticket.IdFlight;
            currentTicket.IdPassenger = Ticket.IdPassenger;
            currentTicket.IdClass = Ticket.IdClass;
            currentTicket.IdPrice = Ticket.IdPrice;
            currentTicket.Date = Ticket.Date;
            currentTicket.IdSeat = Ticket.IdSeat;
            currentTicket.IdLuggage = Ticket.IdLuggage;

            int rows = await _context.SaveChangesAsync();
            return rows > 0;
        }

        public async Task<bool> DeleteTicket(int id)
        {
            var currentTicket = await GetTicket(id);
            _context.Ticket.Remove(currentTicket);

            int rows = await _context.SaveChangesAsync();
            return rows > 0;
        }
    }
}
