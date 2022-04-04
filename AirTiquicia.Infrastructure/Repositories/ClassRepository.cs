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
    public class ClassRepository : IClassRepository
    {
        private readonly AirTiquiciaContext _context;

        public ClassRepository(AirTiquiciaContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Class>> GetClasses()
        {
            var classes = await Task.FromResult(_context.Class.ToList());

            return classes;
        }

        public async Task<Class> GetClass(int id)
        {
            var flightClass = await _context.Class.FirstOrDefaultAsync(x => x.Id == id);

            return flightClass;
        }

        public async Task<bool> AddClass(Class flightClass)
        {
            bool added = false;
            try
            {
                _context.Class.Add(flightClass);
                await _context.SaveChangesAsync();

                added = true;
            }
            catch (Exception)
            {

                throw;
            }

            return added;
        }

        public async Task<bool> UpdateClass(Class flightClass)
        {
            var currentClass = await GetClass(flightClass.Id);

            currentClass.Description = flightClass.Description;

            int rows = await _context.SaveChangesAsync();
            return rows > 0;
        }

        public async Task<bool> DeleteClass(int id)
        {
            var currentClass = await GetClass(id);
            _context.Class.Remove(currentClass);

            int rows = await _context.SaveChangesAsync();
            return rows > 0;
        }
    }
}
