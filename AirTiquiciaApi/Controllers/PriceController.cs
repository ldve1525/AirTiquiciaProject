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
    public class PriceController : ControllerBase
    {
        private readonly IPriceRepository _priceRepository;
        public PriceController(IPriceRepository priceRepository)
        {
            _priceRepository = priceRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetPrices()
        {
            var prices = await _priceRepository.GetPrices();

            return Ok(prices);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPrice(int id)
        {
            var price = await _priceRepository.GetPrice(id);

            return Ok(price);
        }

        [HttpGet("{idClass}/{idFlight}")]
        public async Task<IActionResult> GetPrice(int idClass, int idFlight)
        {
            var price = await _priceRepository.GetPrice(idClass, idFlight);

            return Ok(price);
        }

        [HttpPost]
        public async Task<IActionResult> AddPrice(Price price)
        {
            var result = await _priceRepository.AddPrice(price);

            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdatePrice(Price price)
        {
            var result = await _priceRepository.UpdatePrice(price);

            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> DeletePrice(int id)
        {
            var result = await _priceRepository.DeletePrice(id);

            return Ok(result);
        }
    }
}
