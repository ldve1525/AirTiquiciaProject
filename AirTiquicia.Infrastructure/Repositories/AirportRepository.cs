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
    public class AirportRepository : IAirportRepository
    {
        private readonly AirTiquiciaContext _context;

        public AirportRepository(AirTiquiciaContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Airport>> GetAirports()
        {
            var airport = await Task.FromResult(_context.Airport.ToList());

            return airport;
        }

        public async Task<Airport> GetAirport(string id)
        {
            var airport = await _context.Airport.FirstOrDefaultAsync(x => x.IdAirport == id);

            return airport;
        }

        public async Task<bool> AddAirport(Airport airport)
        {
            bool added = false;
            try
            {
                _context.Airport.Add(airport);
                await _context.SaveChangesAsync();

                added = true;
            }
            catch (Exception)
            {

                throw;
            }

            return added;
        }

        public async Task<bool> UpdateAirport(Airport airport)
        {
            var currentAport = await GetAirport(airport.IdAirport);

            currentAport.IdAirport = airport.IdAirport;
            currentAport.Name = airport.Name;
            currentAport.IdCountry = airport.IdCountry;
            currentAport.City = airport.City;

            int rows = await _context.SaveChangesAsync();
            return rows > 0;
        }

        public async Task<bool> DeleteAirport(string id)
        {
            var currentAport = await GetAirport(id);
            _context.Airport.Remove(currentAport);

            int rows = await _context.SaveChangesAsync();
            return rows > 0;
        }
    }
}
