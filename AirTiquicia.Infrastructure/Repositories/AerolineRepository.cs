using AirTiquicia.Core.Entities;
using AirTiquicia.Core.Interfaces;
using AirTiquicia.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirTiquicia.Infrastructure.Repositories
{
    public class AerolineRepository : IAerolineRepository
    {
        private readonly AirTiquiciaContext _context;

        public AerolineRepository(AirTiquiciaContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Aeroline>> GetAerolines()
        {
            var aerolines = await Task.FromResult(_context.Aeroline.ToList());

            return aerolines;
        }

        public async Task<Aeroline> GetAeroline(int id)
        {
            var aeroline = await Task.FromResult(_context.Aeroline.FirstOrDefault(x => x.Id == id));

            return aeroline;
        }

        public async Task<bool> AddAeroline(Aeroline aeroline)
        {
            bool added = false;
            try
            {
                _context.Aeroline.Add(aeroline);
                await _context.SaveChangesAsync();

                added = true;
            }
            catch (Exception)
            {

                throw;
            }

            return added;
        }
    }
}
