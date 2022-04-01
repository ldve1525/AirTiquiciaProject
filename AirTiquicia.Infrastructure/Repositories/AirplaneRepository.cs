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
            var airplane = await Task.FromResult(_context.Airplane.FirstOrDefault(x => x.IdAirplane == id));

            return airplane;
        }
    }
}
