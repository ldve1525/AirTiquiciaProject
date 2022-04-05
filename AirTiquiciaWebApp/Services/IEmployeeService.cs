using AirTiquicia.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirTiquiciaWebApp.Services
{
    public interface IEmployeeService
    {
        Task<List<Employee>> GetEmployees();

        Task<Employee> GetEmployee(string id);

        Task<bool> AddEmployee(Employee employee);

        Task<Employee> UpdateEmployee(Employee employee);
    }
}
