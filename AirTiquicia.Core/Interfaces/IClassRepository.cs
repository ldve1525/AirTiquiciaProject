using AirTiquicia.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AirTiquicia.Core.Interfaces
{
    public interface IClassRepository
    {
        Task<IEnumerable<Class>> GetClasses();

        Task<Class> GetClass(int id);

        Task<bool> AddClass(Class flightClass);

        Task<bool> UpdateClass(Class flightClass);

        Task<bool> DeleteClass(int id);
    }
}
