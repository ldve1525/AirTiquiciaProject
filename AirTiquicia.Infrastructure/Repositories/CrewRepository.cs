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
    public class CrewRepository : ICrewRepository
    {
        private readonly AirTiquiciaContext _context;

        public CrewRepository(AirTiquiciaContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Crew>> GetCrews()
        {
            var crews = await Task.FromResult(_context.Crew.ToList());

            return crews;
        }

        public async Task<Crew> GetCrew(int id)
        {
            var crew = await Task.FromResult(_context.Crew.FirstOrDefault(x => x.Id == id));

            return crew;
        }

        public async Task<bool> AddCrew(Crew crew)
        {
            bool added = false;
            try
            {
                _context.Crew.Add(crew);
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
