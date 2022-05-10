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
    public class LuggageController : ControllerBase
    {
        private readonly ILuggageRepository _luggageRepository;
        public LuggageController(ILuggageRepository luggageRepository)
        {
            _luggageRepository = luggageRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetLuggages()
        {
            var luggages = await _luggageRepository.GetLuggages();

            return Ok(luggages);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetLuggage(int id)
        {
            var luggage = await _luggageRepository.GetLuggage(id);

            return Ok(luggage);
        }

        [HttpPost]
        public async Task<IActionResult> AddLuggage(Luggage luggage)
        {
            var lastLuggage = await _luggageRepository.AddLuggage(luggage);

            return Ok(lastLuggage);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateLuggage(Luggage luggage)
        {
            var result = await _luggageRepository.UpdateLuggage(luggage);

            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteLuggage(int id)
        {
            var result = await _luggageRepository.DeleteLuggage(id);

            return Ok(result);
        }
    }
}
