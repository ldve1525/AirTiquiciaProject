using AirTiquicia.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirTiquiciaWebApp.Services
{
    public interface ISeatService
    {
        Task<List<Seat>> GetSeats();

        Task<Seat> GetSeat(int id);

        Task<int> AddSeat(Seat Seat);

        Task<Seat> UpdateSeat(Seat Seat);
    }
}
