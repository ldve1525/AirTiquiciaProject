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
    public class FlightController : ControllerBase
    {
        private readonly IFlightRepository _flightRepository;
        public FlightController(IFlightRepository flightRepository)
        {
            _flightRepository = flightRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetFlights()
        {
            var flights = await _flightRepository.GetFlights();

            return Ok(flights);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetFlight(int id)
        {
            var flight = await _flightRepository.GetFlight(id);

            return Ok(flight);
        }

        [HttpPost]
        public async Task<IActionResult> AddFlight(Flight flight)
        {
            var result = await _flightRepository.AddFlight(flight);

            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateFlight(Flight flight)
        {
            var result = await _flightRepository.UpdateFlight(flight);

            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteFlight(int id)
        {
            var result = await _flightRepository.DeleteFlight(id);

            return Ok(result);
        }
    }
}
