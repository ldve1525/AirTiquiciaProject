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
    public class LuggageRepository : ILuggageRepository
    {
        private readonly AirTiquiciaContext _context;

        public LuggageRepository(AirTiquiciaContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Luggage>> GetLuggages()
        {
            var luggages = await Task.FromResult(_context.Luggage.ToList());

            return luggages;
        }

        public async Task<Luggage> GetLuggage(int id)
        {
            var luggage = await _context.Luggage.FirstOrDefaultAsync(x => x.Id == id);

            return luggage;
        }

        public int GetLastLuggage()
        {
            Luggage luggage = new Luggage();
            luggage.Id = _context.Luggage.Max(x => x.Id);

            return luggage.Id;
        }

        public async Task<int> AddLuggage(Luggage luggage)
        {
            int lastLuggage;
            try
            {
                _context.Luggage.Add(luggage);
                await _context.SaveChangesAsync();

                lastLuggage = GetLastLuggage();
            }
            catch (Exception)
            {

                throw;
            }

            return lastLuggage;
        }

        public async Task<bool> UpdateLuggage(Luggage luggage)
        {
            var currentLuggage = await GetLuggage(luggage.Id);

            currentLuggage.Quantity = luggage.Quantity;
            currentLuggage.Weight = luggage.Weight;
            currentLuggage.Cost = luggage.Cost;

            int rows = await _context.SaveChangesAsync();
            return rows > 0;
        }

        public async Task<bool> DeleteLuggage(int id)
        {
            var currentLuggage = await GetLuggage(id);
            _context.Luggage.Remove(currentLuggage);

            int rows = await _context.SaveChangesAsync();
            return rows > 0;
        }
    }
}
