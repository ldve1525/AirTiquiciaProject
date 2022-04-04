using AirTiquicia.Core.Entities;
using AirTiquicia.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AirTiquicia.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AerolineController : ControllerBase
    {
        private readonly IAerolineRepository _aerolineRepository;
        public AerolineController(IAerolineRepository aerolineRepository)
        {
            _aerolineRepository = aerolineRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAerolines()
        {
            var aerolines = await _aerolineRepository.GetAerolines();
            return Ok(aerolines);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAeroline(int id)
        {
            var aeroline = await _aerolineRepository.GetAeroline(id);
            return Ok(aeroline);
        }

        public async Task<IActionResult> AddAeroline(Aeroline aeroline)
        {
            var result = await _aerolineRepository.AddAeroline(aeroline);
            return Ok(result);
        }
    }
}
