using AirTiquicia.Core.Entities;
using AirTiquicia.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirTiquicia.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CrewController : ControllerBase
    {
        private readonly ICrewRepository _crewRepository;
        public CrewController(ICrewRepository crewRepository)
        {
            _crewRepository = crewRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetCrews()
        {
            var crews = await _crewRepository.GetCrews();
            return Ok(crews);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCrew(int id)
        {
            var crew = await _crewRepository.GetCrew(id);
            return Ok(crew);
        }

        public async Task<IActionResult> AddCrew(Crew crew)
        {
            var result = await _crewRepository.AddCrew(crew);
            return Ok(result);
        }
    }
}
