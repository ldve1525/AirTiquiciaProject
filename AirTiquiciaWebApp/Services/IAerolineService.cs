using AirTiquicia.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AirTiquiciaWebApp.Services
{
    public interface IAerolineService
    {
        Task<List<Aeroline>> GetAerolines();

        Task<Aeroline> GetAeroline(int id);

        Task<bool> AddAeroline(Aeroline aeroline);
    }
}
