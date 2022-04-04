using AirTiquicia.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AirTiquicia.Core.Interfaces
{
    public interface IAerolineRepository
    {
        Task<IEnumerable<Aeroline>> GetAerolines();

        Task<Aeroline> GetAeroline(int id);

        Task<bool> AddAeroline(Aeroline aeroline);
    }
}
