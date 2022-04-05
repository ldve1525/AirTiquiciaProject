using AirTiquicia.Core.Entities;
using AirTiquiciaWebApp.Services;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirTiquiciaWebApp.Pages.Crews
{
    public class CrewAddEditBase : ComponentBase
    {
        [Inject]
        public ICrewService CrewService { get; set; }

        public Crew crew { get; set; } = new Crew();

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Inject]
        public IFlightService FlightService { get; set; }
        public List<Flight> flights { get; set; } = new List<Flight>();
        public Flight flight { get; set; } = new Flight();

        [Inject]
        public IEmployeeService EmployeeService { get; set; }

        public List<Employee> employees { get; set; } = new List<Employee>();

        public Employee employee { get; set; } = new Employee();

        [Parameter]
        public string Id { get; set; }


        protected override async Task OnInitializedAsync()
        {
            
            employees = (await EmployeeService.GetEmployees()).ToList();
            flights = (await FlightService.GetFlights()).ToList();

            if (Id != null)
            {
                crew = await CrewService.GetCrew(int.Parse(Id));
                employee = await EmployeeService.GetEmployee(Id);
                flight.Id = crew.IdFlight;
                
            }
            else
            {
                crew.IdFlight = flights[0].Id;
                crew.IdPilot = employees[0].IdEmployee;
                crew.IdCopilot = employees[3].IdEmployee;
                crew.IdEmployee1 = employees[6].IdEmployee;
                crew.IdEmployee2 = employees[7].IdEmployee;
                crew.IdEmployee3 = employees[8].IdEmployee;
            }
        }

        protected async Task sendCrew()
        {

            if (Id == null)
            {
                await CrewService.AddCrew(crew);
            }
            else
            {
                await CrewService.UpdateCrew(crew);
            }


            NavigationManager.NavigateTo("/Tripulacion");
        }
    }
}
