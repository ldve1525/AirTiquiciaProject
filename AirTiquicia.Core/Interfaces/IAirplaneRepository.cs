using AirTiquicia.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AirTiquicia.Core.Interfaces
{
    public interface IAirplaneRepository
    {
        Task<IEnumerable<Airplane>> GetAirplanes();

        Task<Airplane> GetAirplane(string id);

        Task<bool> AddAirplane(Airplane airplane);

        Task<bool> UpdateAirplane(Airplane airplane);

        Task<bool> DeleteAirplane(string id);
    }
}
