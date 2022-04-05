using AirTiquicia.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace AirTiquiciaWebApp.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly HttpClient httpClient;
        public EmployeeService(HttpClient _httpClient)
        {
            this.httpClient = _httpClient;
        }

        public async Task<List<Employee>> GetEmployees()
        {
            return await httpClient.GetFromJsonAsync<List<Employee>>("employee");
        }

        public async Task<Employee> GetEmployee(string id)
        {
            return await httpClient.GetFromJsonAsync<Employee>("employee/" + id);
        }

        public async Task<bool> AddEmployee(Employee employee)
        {
            bool result = false;
            try
            {
                await httpClient.PostAsJsonAsync("employee/", employee);
                result = true;
            }
            catch (Exception)
            {

                throw;
            }

            return result;
        }

        public async Task<Employee> UpdateEmployee(Employee employee)
        {
            await httpClient.PutAsJsonAsync<Employee>("employee/", employee);

            return employee;
        }
    }
}
