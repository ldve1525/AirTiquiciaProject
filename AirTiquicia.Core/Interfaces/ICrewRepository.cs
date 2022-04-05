using AirTiquicia.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AirTiquicia.Core.Interfaces
{
    public interface ICrewRepository
    {
        Task<IEnumerable<Crew>> GetCrews();

        Task<Crew> GetCrew(int id);

        Task<bool> AddCrew(Crew crew);
    }
}
