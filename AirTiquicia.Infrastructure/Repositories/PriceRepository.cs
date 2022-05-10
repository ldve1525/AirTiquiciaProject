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
    public class PriceRepository : IPriceRepository
    {
        private readonly AirTiquiciaContext _context;

        public PriceRepository(AirTiquiciaContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Price>> GetPrices()
        {
            var prices = await Task.FromResult(_context.Price.ToList());

            return prices;
        }

        public async Task<Price> GetPrice(int id)
        {
            var price = await _context.Price.FirstOrDefaultAsync(x => x.Id == id);

            return price;
        }

        public async Task<Price> GetPrice(int idClass, int idFlight)
        {
            var price = await _context.Price.FirstOrDefaultAsync(x => x.IdClass == idClass && x.IdFlight == idFlight);

            return price;
        }

        public async Task<bool> AddPrice(Price price)
        {
            bool added = false;
            try
            {
                _context.Price.Add(price);
                await _context.SaveChangesAsync();

                added = true;
            }
            catch (Exception)
            {

                throw;
            }

            return added;
        }

        public async Task<bool> UpdatePrice(Price price)
        {
            var currentPrice = await GetPrice(price.Id);

            currentPrice.IdClass= price.IdClass;
            currentPrice.IdFlight = price.IdFlight;
            currentPrice.Cost = price.Cost;

            int rows = await _context.SaveChangesAsync();
            return rows > 0;
        }

        public async Task<bool> DeletePrice(int id)
        {
            var currentPrice = await GetPrice(id);
            _context.Price.Remove(currentPrice);

            int rows = await _context.SaveChangesAsync();
            return rows > 0;
        }
    }
}
