using AirTiquicia.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AirTiquicia.Core.Interfaces
{
    public interface ISeatRepository
    {
        Task<IEnumerable<Seat>> GetSeats();

        int GetLastSeat();

        Task<Seat> GetSeat(int id);

        Task<int> AddSeat(Seat Seat);

        Task<bool> UpdateSeat(Seat Seat);

        Task<bool> DeleteSeat(int id);
    }
}
