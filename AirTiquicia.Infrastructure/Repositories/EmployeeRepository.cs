using AirTiquicia.Core.Entities;
using AirTiquicia.Core.Interfaces;
using AirTiquicia.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirTiquicia.Infrastructure.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly AirTiquiciaContext _context;

        public EmployeeRepository(AirTiquiciaContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Employee>> GetEmployees()
        {
            var employees = await Task.FromResult(_context.Employee.ToList());

            return employees;
        }

        public async Task<Employee> GetEmployee(string id)
        {
            var employee = await _context.Employee.FirstOrDefaultAsync(x => x.IdEmployee == id);

            return employee;
        }

        public async Task<bool> AddEmployee(Employee employee)
        {
            bool added = false;
            try
            {
                _context.Employee.Add(employee);
                await _context.SaveChangesAsync();

                added = true;
            }
            catch (Exception)
            {

                throw;
            }

            return added;
        }

        public async Task<bool> UpdateEmployee(Employee employee)
        {
            var currentEmployee = await GetEmployee(employee.IdEmployee);

            currentEmployee.JobCategory = employee.JobCategory;
            currentEmployee.FirstName = employee.FirstName;
            currentEmployee.LastName = employee.LastName;

            int rows = await _context.SaveChangesAsync();
            return rows > 0;
        }

        public async Task<bool> DeleteEmployee(string id)
        {
            var currentEmployee = await GetEmployee(id);
            _context.Employee.Remove(currentEmployee);

            int rows = await _context.SaveChangesAsync();
            return rows > 0;
        }
    }
}
