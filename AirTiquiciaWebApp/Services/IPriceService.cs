using AirTiquicia.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirTiquiciaWebApp.Services
{
    public interface IPriceService
    {
        Task<List<Price>> GetPrices();

        Task<Price> GetPrice(int id);

        Task<bool> AddPrice(Price orice);

        Task<Price> UpdatePrice(Price orice);
    }
}
