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
    public class TicketController : ControllerBase
    {
        private readonly ITicketRepository _ticketRepository;
        public TicketController(ITicketRepository ticketRepository)
        {
            _ticketRepository = ticketRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetTickets()
        {
            var tickets = await _ticketRepository.GetTickets();

            return Ok(tickets);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTicket(int id)
        {
            var ticket = await _ticketRepository.GetTicket(id);

            return Ok(ticket);
        }

        [HttpPost]
        public async Task<IActionResult> AddTicket(Ticket ticket)
        {
            var result = await _ticketRepository.AddTicket(ticket);

            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateTicket(Ticket ticket)
        {
            var result = await _ticketRepository.UpdateTicket(ticket);

            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteTicket(int id)
        {
            var result = await _ticketRepository.DeleteTicket(id);

            return Ok(result);
        }
    }
}
