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
    public class AirplaneRepository : IAirplaneRepository
    {
        private readonly AirTiquiciaContext _context;

        public AirplaneRepository(AirTiquiciaContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Airplane>> GetAirplanes()
        {
            var airplanes = await Task.FromResult(_context.Airplane.ToList());

            return airplanes;
        }

        public async Task<Airplane> GetAirplane(string id)
        {
            //var airplane = await Task.FromResult(_context.Airplane.FirstOrDefault(x => x.IdAirplane == id));
            var airplane = await _context.Airplane.FirstOrDefaultAsync(x => x.IdAirplane == id);

            return airplane;
        }

        public async Task<bool> AddAirplane(Airplane airplane)
        {
            bool added = false;
            try
            {
                _context.Airplane.Add(airplane);
                await _context.SaveChangesAsync();

                added = true;   
            }
            catch (Exception)
            {

                throw;
            }
            
            return added;
        }

        public async Task<bool> UpdateAirplane(Airplane airplane)
        {
            var currentAirplane = await GetAirplane(airplane.IdAirplane);

            currentAirplane.IdAeroline = airplane.IdAeroline;
            currentAirplane.Description = airplane.Description;
            currentAirplane.Size = airplane.Size;
            currentAirplane.Capacity = airplane.Capacity;

            int rows = await _context.SaveChangesAsync();
            //
            return rows > 0; 
        }
    }
}
