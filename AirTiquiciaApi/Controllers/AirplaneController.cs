using AirTiquicia.Core.Interfaces;
using AirTiquicia.Infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirTiquiciaApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AirplaneController : ControllerBase
    {
        private readonly IAirplaneRepository _airplaneRepository;
        public AirplaneController(IAirplaneRepository airplaneRepository)
        {
            _airplaneRepository = airplaneRepository;
        }

        [HttpGet]
        //[Route("/GetAirplanes")]
        public async Task<IActionResult> GetAirplanes()
        {
            var airplanes = await _airplaneRepository.GetAirplanes();
            return Ok(airplanes);
        }

        [HttpGet("{id}")]
        //[Route("/GetAirplane")]
        public async Task<IActionResult> GetAirplane(string id)
        {
            var airplane = await _airplaneRepository.GetAirplane(id);
            return Ok(airplane);
        }
    }
}
