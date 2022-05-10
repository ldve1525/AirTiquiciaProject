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
    public class SeatRepository : ISeatRepository
    {
        private readonly AirTiquiciaContext _context;

        public SeatRepository(AirTiquiciaContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Seat>> GetSeats()
        {
            var seats = await Task.FromResult(_context.Seat.ToList());

            return seats;
        }

        public async Task<Seat> GetSeat(int id)
        {
            var seat = await _context.Seat.FirstOrDefaultAsync(x => x.Id == id);

            return seat;
        }

        public int GetLastSeat()
        {
            Seat seat = new Seat();
            seat.Id = _context.Seat.Max(x => x.Id);

            return seat.Id;
        }

        public async Task<int> AddSeat(Seat seat)
        {
            int lastSeat;
            try
            {
                _context.Seat.Add(seat);
                await _context.SaveChangesAsync();

                lastSeat = GetLastSeat();
            }
            catch (Exception)
            {

                throw;
            }

            return lastSeat;
        }

        public async Task<bool> UpdateSeat(Seat seat)
        {
            var currentSeat= await GetSeat(seat.Id);

            currentSeat.Letter = seat.Letter;
            currentSeat.Row = seat.Row;
            currentSeat.IdClass = seat.IdClass;

            int rows = await _context.SaveChangesAsync();
            return rows > 0;
        }

        public async Task<bool> DeleteSeat(int id)
        {
            var currentSeat = await GetSeat(id);
            _context.Seat.Remove(currentSeat);

            int rows = await _context.SaveChangesAsync();
            return rows > 0;
        }
    }
}
