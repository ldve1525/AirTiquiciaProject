using AirTiquicia.Core.Entities;
using AirTiquicia.Core.DTOs;
using AirTiquiciaWebApp.Services;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace AirTiquiciaWebApp.Pages.Tickets
{
    public class SearchFlightsBase : ComponentBase
    {
        [Inject]
        public IFlightService FlightService { get; set; }

        public List<Flight> Flights = new List<Flight>();

        public FlightDTO Flight { get; set; } = new FlightDTO();

        [Inject]
        public IAirportService AirportService { get; set; }

        public List<Airport> Airports { get; set; } = new List<Airport>();

        [Inject]
        public IClassService ClassService { get; set; }

        public Class Class { get; set; } = new Class();

        [Inject]
        public Blazored.LocalStorage.ILocalStorageService localStorage { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        public int flight, type;

        protected override async Task OnInitializedAsync()
        {
            Airports = (await AirportService.GetAirports()).ToList();
            Flight.DepartureDate = DateTime.Now;
            Flight.ArrivalDate = DateTime.Now;
            Flight.DepartureAirport = "SJO";

            //Flight.DestinationAirport = "SFO";
            //Flight.DepartureDate = Convert.ToDateTime("2022-05-16");
            //Flight.ArrivalDate = Convert.ToDateTime("2022-05-17");
            Flight.DestinationAirport = "NULL";
            Class.Id = 1;
            flight = 1;
            type = 1;
        }

        protected async Task searchFlights()
        {
            await localStorage.SetItemAsync("Class", Class.Id);

            if (Class.Id == 1)
            {
                Flight.SeatsEconomic = Flight.Adults + Flight.Kids + Flight.Babies;
                Flight.SeatsExecutive = 0;
                await localStorage.SetItemAsync("Seats", Flight.SeatsEconomic);
            }
            else
            {
                Flight.SeatsExecutive = Flight.Adults + Flight.Kids + Flight.Babies;
                Flight.SeatsEconomic = 0;
                await localStorage.SetItemAsync("Seats", Flight.SeatsExecutive);
            }

            await localStorage.SetItemAsync("DepartureAirport", Flight.DepartureAirport);
            await localStorage.SetItemAsync("DestinationAirport", Flight.DestinationAirport);
            await localStorage.SetItemAsync("DepartureDate", Flight.DepartureDate.ToString("yyyy-MM-dd"));
            await localStorage.SetItemAsync("ArrivalDate", Flight.ArrivalDate.ToString("yyyy-MM-dd"));
            await localStorage.SetItemAsync("SeatsEconomic", Flight.SeatsEconomic);
            await localStorage.SetItemAsync("SeatsExecutive", Flight.SeatsExecutive);

            NavigationManager.NavigateTo("/Usuarios/Seleccionar");
        }
    }
}
