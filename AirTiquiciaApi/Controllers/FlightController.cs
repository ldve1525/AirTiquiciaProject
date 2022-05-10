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

        [HttpGet("{Airport1}/{Airport2}/{Date1}/{Date2}/{SeatsEconomic}/{SeatsExecutive}")]
        public async Task<IActionResult> GetRoundtripFlight(string Airport1, string Airport2, string Date1, string Date2, int SeatsEconomic, int SeatsExecutive)
        {
            var flights = await _flightRepository.GetRoundtripFlight(Airport1, Airport2, Date1, Date2, SeatsEconomic, SeatsExecutive);

            return Ok(flights);
        }

        [HttpGet("{Airport1}/{Airport2}/{Date2}/{SeatsEconomic}/{SeatsExecutive}")]
        public async Task<IActionResult> GetReturnFlight(string Airport1, string Airport2, string Date2, int SeatsEconomic, int SeatsExecutive)
        {
            var flights = await _flightRepository.GetReturnFlight(Airport1, Airport2, Date2, SeatsEconomic, SeatsExecutive);

            return Ok(flights);
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
