using AirTiquicia.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AirTiquicia.Core.Interfaces
{
    public interface IPassengerRepository
    {
        Task<IEnumerable<Passenger>> GetPassengers();

        Task<Passenger> GetPassenger(string id);

        Task<bool> AddPassenger(Passenger passenger);

        Task<bool> UpdatePassenger(Passenger passenger);

        Task<bool> DeletePassenger(string id);
    }
}
