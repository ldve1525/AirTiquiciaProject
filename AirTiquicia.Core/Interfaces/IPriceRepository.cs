using AirTiquicia.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AirTiquicia.Core.Interfaces
{
    public interface IPriceRepository
    {
        Task<IEnumerable<Price>> GetPrices();

        Task<Price> GetPrice(int id);

        Task<Price> GetPrice(int idClass, int idFlight);

        Task<bool> AddPrice(Price price);

        Task<bool> UpdatePrice(Price price);

        Task<bool> DeletePrice(int id);
    }
}
