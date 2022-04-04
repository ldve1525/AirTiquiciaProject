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

        public Flight flight { get; set; } = new Flight();

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Inject]
        public IAirplaneService AirplaneService { get; set; }

        public List<Airplane> airplanes { get; set; } = new List<Airplane>();

        [Inject]
        public IAirportService AirportService { get; set; }

        public List<Airport> airports { get; set; } = new List<Airport>();
        public Airport airport { get; set; } = new Airport();

        [Parameter]
        public string Id { get; set; }

        public int departureHour;

        public int departureMinutes;

        public int arrivalHour;

        public int arrivalMinutes;

        protected override async Task OnInitializedAsync()
        {
            airplanes = (await AirplaneService.GetAirplanes()).ToList();
            airports = (await AirportService.GetAirports()).ToList();

            if (Id != null)
            {
                flight = await FlightService.GetFlight(int.Parse(Id));
                departureHour = flight.DepartureDate.Hour;
                departureMinutes = flight.DepartureDate.Minute;
                arrivalHour = flight.ArrivalDate.Hour;
                arrivalMinutes = flight.ArrivalDate.Minute;
            }
            else
            {
                flight.DepartureDate = DateTime.Now;
                flight.ArrivalDate = DateTime.Now;
                flight.IdAirplane = airplanes[0].IdAirplane;
                flight.DepartureAirport = airports[0].IdAirport;
                flight.DestinationAirport = airports[0].IdAirport;
                flight.Stopover = airports[0].IdAirport;
            }
        }

        protected async Task sendFlight()
        {
            flight.DepartureDate = flight.DepartureDate.AddHours(departureHour);
            flight.DepartureDate = flight.DepartureDate.AddMinutes(departureMinutes);

            flight.ArrivalDate = flight.ArrivalDate.AddHours(arrivalHour);
            flight.ArrivalDate = flight.ArrivalDate.AddMinutes(arrivalMinutes);

            if (Id == null)
            {
                await FlightService.AddFlight(flight);
            }
            else
            {
                await FlightService.UpdateFlight(flight);
            }


            NavigationManager.NavigateTo("/Vuelos");
        }
    }
}
