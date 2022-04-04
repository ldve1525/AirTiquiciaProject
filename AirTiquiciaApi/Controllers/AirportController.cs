using AirTiquicia.Core.DTOs;
using AirTiquicia.Core.Entities;
using AirTiquicia.Core.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirTiquicia.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AirportController : ControllerBase
    {
        private readonly IAirportRepository _airportRepository;
        private readonly IMapper _mapper;
        public AirportController(IAirportRepository airportRepository, IMapper mapper)
        {
            _airportRepository = airportRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAirports()
        {
            var airports = await _airportRepository.GetAirports();
            var airportsDTO = _mapper.Map<IEnumerable<AirportDTO>>(airports);

            return Ok(airportsDTO);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAirport(string id)
        {
            var airport = await _airportRepository.GetAirport(id);
            var airportDTO = _mapper.Map<AirportDTO>(airport);

            return Ok(airportDTO);
        }

        [HttpPost]
        public async Task<IActionResult> AddAirport(AirportDTO airportDTO)
        {
            var airport = _mapper.Map<Airport>(airportDTO);
            var result = await _airportRepository.AddAirport(airport);

            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAirport(AirportDTO airportDTO)
        {
            var airport = _mapper.Map<Airport>(airportDTO);

            var result = await _airportRepository.UpdateAirport(airport);

            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAirport(string id)
        {
            var result = await _airportRepository.DeleteAirport(id);

            return Ok(result);
        }
    }
}
