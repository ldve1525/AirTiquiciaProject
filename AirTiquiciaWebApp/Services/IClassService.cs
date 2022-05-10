using AirTiquicia.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirTiquiciaWebApp.Services
{
    public interface IClassService
    {
        Task<List<Class>> GetClasses();

        Task<Class> GetClass(int id);

        Task<bool> AddClass(Class flightClass);

        Task<Class> UpdateClass(Class flightClass);
    }
}
