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
    public class SeatController : ControllerBase
    {
        private readonly ISeatRepository _seatRepository;
        public SeatController(ISeatRepository seatRepository)
        {
            _seatRepository = seatRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetSeats()
        {
            var seats = await _seatRepository.GetSeats();

            return Ok(seats);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSeat(int id)
        {
            var seat = await _seatRepository.GetSeat(id);

            return Ok(seat);
        }

        [HttpPost]
        public async Task<IActionResult> AddSeat(Seat seat)
        {
            var lastSeat = await _seatRepository.AddSeat(seat);

            return Ok(lastSeat);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateSeat(Seat seat)
        {
            var result = await _seatRepository.UpdateSeat(seat);

            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteSeat(int id)
        {
            var result = await _seatRepository.DeleteSeat(id);

            return Ok(result);
        }
    }
}
