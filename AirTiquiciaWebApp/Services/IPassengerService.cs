using AirTiquicia.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirTiquiciaWebApp.Services
{
    public interface IPassengerService
    {
        Task<List<Passenger>> GetPassengers();

        Task<Passenger> GetPassenger(string id);

        Task<bool> AddPassenger(Passenger passenger);

        Task<Passenger> UpdatePassenger(Passenger passenger);
    }
}
