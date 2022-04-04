using AirTiquicia.Core.Entities;
using AirTiquiciaWebApp.Services;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirTiquiciaWebApp.Pages.Flights
{
    public class FlightListBase : ComponentBase
    {
        [Inject]
        public IFlightService FlightService { get; set; }


        public List<Flight> Flights = new List<Flight>();

        protected override async Task OnInitializedAsync()
        {
            Flights = await FlightService.GetFlights();
        }
    }
}
