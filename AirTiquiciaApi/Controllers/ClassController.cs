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
    public class ClassController : ControllerBase
    {
        private readonly IClassRepository _classRepository;
        public ClassController(IClassRepository classRepository)
        {
            _classRepository = classRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetClasses()
        {
            var classes = await _classRepository.GetClasses();

            return Ok(classes);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetClass(int id)
        {
            var flightClass = await _classRepository.GetClass(id);

            return Ok(flightClass);
        }

        [HttpPost]
        public async Task<IActionResult> AddClass(Class flightClass)
        {
            var result = await _classRepository.AddClass(flightClass);

            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateClass(Class flightClass)
        {
            var result = await _classRepository.UpdateClass(flightClass);

            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteClass(int id)
        {
            var result = await _classRepository.DeleteClass(id);

            return Ok(result);
        }
    }
}
