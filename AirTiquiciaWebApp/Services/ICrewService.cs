using AirTiquicia.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirTiquiciaWebApp.Services
{
    public interface ICrewService
    {
        Task<List<Crew>> GetCrews();

        Task<Crew> GetCrew(int id);

        Task<bool> AddCrew(Crew crew);

        Task<Crew> UpdateCrew(Crew crew);
    }
}
