using AirTiquicia.Core.Entities;
using AirTiquiciaWebApp.Services;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirTiquiciaWebApp.Pages.Flights
{
    public class FlightAddEditBase : ComponentBase
    {
        [Inject]
        public IFlightService FlightService { get; set; }

        public Flight Flight { get; set; } = new Flight();

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Inject]
        public IAirplaneService AirplaneService { get; set; }

        public List<Airplane> Airplanes { get; set; } = new List<Airplane>();
        public Airplane Airplane { get; set; } = new Airplane();

        [Inject]
        public IAirportService AirportService { get; set; }

        public List<Airport> Airports { get; set; } = new List<Airport>();

        [Parameter]
        public string Id { get; set; }

        public int departureHour;

        public int departureMinutes;

        public int arrivalHour;

        public int arrivalMinutes;

        protected override async Task OnInitializedAsync()
        {
            Airplanes = (await AirplaneService.GetAirplanes()).ToList();
            Airports = (await AirportService.GetAirports()).ToList();

            if (Id != null)
            {
                Flight = await FlightService.GetFlight(int.Parse(Id));
                departureHour = Flight.DepartureDate.Hour;
                departureMinutes = Flight.DepartureDate.Minute;
                arrivalHour = Flight.ArrivalDate.Hour;
                arrivalMinutes = Flight.ArrivalDate.Minute;
            }
            else
            {
                Flight.DepartureDate = DateTime.Now;
                Flight.ArrivalDate = DateTime.Now;
                Flight.IdAirplane = Airplanes[0].IdAirplane;
                Flight.DepartureAirport = Airports[0].IdAirport;
                Flight.DestinationAirport = Airports[0].IdAirport;
                Flight.Stopover = "NULL";
                Flight.Type = 1;
            }
        }

        protected async Task sendFlight()
        {
            Flight.DepartureDate = Flight.DepartureDate.AddHours(departureHour);
            Flight.DepartureDate = Flight.DepartureDate.AddMinutes(departureMinutes);

            Flight.ArrivalDate = Flight.ArrivalDate.AddHours(arrivalHour);
            Flight.ArrivalDate = Flight.ArrivalDate.AddMinutes(arrivalMinutes);

            Airplane = await AirplaneService.GetAirplane(Flight.IdAirplane);
            Flight.SeatsEconomic = Airplane.CapacityEconomic;
            Flight.SeatsExecutive = Airplane.CapacityExecutive;

            if (Flight.Stopover == "NULL")
                Flight.Stopover = null;

            if (Id == null)
            {
                await FlightService.AddFlight(Flight);
            }
            else
            {
                await FlightService.UpdateFlight(Flight);
            }


            NavigationManager.NavigateTo("/Vuelos");
        }
    }
}
