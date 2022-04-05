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
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;
        public EmployeeController(IEmployeeRepository employeeRepository, IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetEmployees()
        {
            var employees = await _employeeRepository.GetEmployees();
            var employeesDTO = _mapper.Map<IEnumerable<EmployeeDTO>>(employees);

            return Ok(employeesDTO);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployee(string id)
        {
            var employee = await _employeeRepository.GetEmployee(id);
            var employeeDTO = _mapper.Map<EmployeeDTO>(employee);

            return Ok(employeeDTO);
        }

        [HttpPost]
        public async Task<IActionResult> AddEmployee(EmployeeDTO employeeDTO)
        {
            var employee = _mapper.Map<Employee>(employeeDTO);
            var result = await _employeeRepository.AddEmployee(employee);

            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateEmployee(EmployeeDTO employeeDTO)
        {
            var employee = _mapper.Map<Employee>(employeeDTO);

            var result = await _employeeRepository.UpdateEmployee(employee);

            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteEmployee(string id)
        {
            var result = await _employeeRepository.DeleteEmployee(id);

            return Ok(result);
        }
    }
}
