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

namespace AirTiquiciaApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AirplaneController : ControllerBase
    {
        private readonly IAirplaneRepository _airplaneRepository;
        private readonly IMapper _mapper; 
        public AirplaneController(IAirplaneRepository airplaneRepository, IMapper mapper)
        {
            _airplaneRepository = airplaneRepository;
            _mapper = mapper;
        }

        [HttpGet]
        //[Route("/GetAirplanes")]
        public async Task<IActionResult> GetAirplanes()
        {
            var airplanes = await _airplaneRepository.GetAirplanes();
            var airplanesDTO = _mapper.Map<IEnumerable<AirplaneDTO>>(airplanes);

            return Ok(airplanesDTO);
        }

        [HttpGet("{id}")]
        //[Route("/GetAirplane")]
        public async Task<IActionResult> GetAirplane(string id)
        {
            var airplane = await _airplaneRepository.GetAirplane(id);
            var airplaneDTO = _mapper.Map<AirplaneDTO>(airplane);

            return Ok(airplaneDTO);
        }

        [HttpPost]
        public async Task<IActionResult> AddAirplane(AirplaneDTO airplaneDTO)
        {
            var airplane = _mapper.Map<Airplane>(airplaneDTO);
            var result = await _airplaneRepository.AddAirplane(airplane);

            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAirplane(AirplaneDTO airplaneDTO)
        {
            var airplane = _mapper.Map<Airplane>(airplaneDTO);
            //airplane.IdAirplane = id;

            var result = await _airplaneRepository.UpdateAirplane(airplane);

            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAirplane(string id)
        {
            var result = await _airplaneRepository.DeleteAirplane(id);

            return Ok(result);
        }
    }
}
