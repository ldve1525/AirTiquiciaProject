using AirTiquicia.Core.DTOs;
using AirTiquicia.Core.Entities;
using AirTiquicia.Core.Interfaces;
using AirTiquicia.Infrastructure.Repositories;
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
    public class PassengerController : ControllerBase
    {
        private readonly IPassengerRepository _passengerRepository;
        public PassengerController(IPassengerRepository passengerRepository)
        {
            _passengerRepository = passengerRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetPassengers()
        {
            var passengers = await _passengerRepository.GetPassengers();

            return Ok(passengers);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPassenger(string id)
        {
            var passenger = await _passengerRepository.GetPassenger(id);

            return Ok(passenger);
        }

        [HttpPost]
        public async Task<IActionResult> AddPassenger(Passenger passenger)
        {
            var result = await _passengerRepository.AddPassenger(passenger);

            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdatePassenger(Passenger passenger)
        {
            var result = await _passengerRepository.UpdatePassenger(passenger);

            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> DeletePassenger(string id)
        {
            var result = await _passengerRepository.DeletePassenger(id);

            return Ok(result);
        }
    }
}
