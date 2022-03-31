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
    public class AirplaneController : Controller
    {
        [HttpGet]
        [Route("/GetAirplanes")]
        public IActionResult GetPlanes()
        {
            var airplane = new AirplaneRepository().GetPlanes();
            return Ok(airplane);
        }
    }
}
