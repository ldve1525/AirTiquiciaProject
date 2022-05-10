using AirTiquicia.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
namespace AirTiquicia.Core.Interfaces
{
    public interface ILuggageRepository
    {
        Task<IEnumerable<Luggage>> GetLuggages();

        Task<Luggage> GetLuggage(int id);

        int GetLastLuggage();

        Task<int> AddLuggage(Luggage luggage);

        Task<bool> UpdateLuggage(Luggage luggage);

        Task<bool> DeleteLuggage(int id);
    }
}
