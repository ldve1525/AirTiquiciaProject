using AirTiquicia.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirTiquiciaWebApp.Services
{
    public interface ILuggageService
    {
        Task<List<Luggage>> GetLuggages();

        Task<Luggage> GetLuggage(int id);

        Task<int> AddLuggage(Luggage luggage);

        Task<Luggage> UpdateLuggage(Luggage luggage);
    }
}
