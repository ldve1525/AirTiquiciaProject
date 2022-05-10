using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blazored.LocalStorage;
using AirTiquiciaWebApp.Services;
using AirTiquicia.Core.Entities;
using AirTiquicia.Core.DTOs;
using Blazored.Modal.Services;

namespace AirTiquiciaWebApp.Pages.Tickets
{
    public class ChooseFlightBase : ComponentBase
    {
        [Inject]
        public IFlightService FlightService { get; set; }

        public List<FlightDTO> Flights = new List<FlightDTO>();
        public List<FlightDTO> ReturnFlights = new List<FlightDTO>();

        public Flight OutboundFlight { get; set; } = new Flight();
        public Flight ReturnFlight { get; set; } = new Flight();

        [Inject]
        public IPriceService PriceService { get; set; }
        public Price Price { get; set; } = new Price();

        [Inject]
        public IAirplaneService AirplaneService { get; set; }
        public Airplane Airplane { get; set; } = new Airplane();

        [Inject]
        public IAerolineService AerolineService { get; set; }
        public Aeroline Aeroline { get; set; } = new Aeroline();

        [Inject]
        public Blazored.LocalStorage.ILocalStorageService localStorage { get; set; }

        [Inject]
        public IModalService modal { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        public int orderBy { get; set; } = 1;
        public int Outbound;
        public int Return;

        public bool obFlight, returnFlight, showModal;

        protected override async Task OnInitializedAsync()
        {
            int FlightClass = Convert.ToInt32(await localStorage.GetItemAsync<string>("Class"));

            string DepartureAirport = await localStorage.GetItemAsync<string>("DepartureAirport");
            string DestinationAirport = await localStorage.GetItemAsync<string>("DestinationAirport");
            string DepartureDate = await localStorage.GetItemAsync<string>("DepartureDate");
            string ArrivalDate = await localStorage.GetItemAsync<string>("ArrivalDate");
            int SeatsEconomic = Convert.ToInt32(await localStorage.GetItemAsync<string>("SeatsEconomic"));
            int SeatsExecutive = Convert.ToInt32(await localStorage.GetItemAsync<string>("SeatsExecutive"));

            Flights = await FlightService.GetRoundtripFlight(DepartureAirport, DestinationAirport, DepartureDate, ArrivalDate, SeatsEconomic, SeatsExecutive);
            Flights = Flights.OrderBy(f => f.DepartureDate).ToList();

            if (Flights.Count > 0)
            {
                foreach (var flight in Flights)
                {
                    Price = await PriceService.GetPrice(FlightClass, flight.Id);
                    flight.Cost = Price.Cost;
                }

                ReturnFlights = await FlightService.GetReturnFlight(DestinationAirport, DepartureAirport, ArrivalDate, SeatsEconomic, SeatsExecutive);
                ReturnFlights = ReturnFlights.OrderBy(f => f.DepartureDate).ToList();

                foreach (var returnFlight in ReturnFlights)
                {
                    Price = await PriceService.GetPrice(FlightClass, returnFlight.Id);
                    returnFlight.Cost = Price.Cost;
                }
            }
                
        }

        protected void SelectOutboundFlight(ChangeEventArgs args)
        {
            Outbound = Convert.ToInt32(args.Value);
            obFlight = true;
        }

        protected void SelectReturnFlight(ChangeEventArgs args)
        {
            Return = Convert.ToInt32(args.Value);
            returnFlight = true;
        }

        protected void OrderBy(ChangeEventArgs e)
        {
            orderBy = Convert.ToInt32(e.Value);

            switch (orderBy)
            {
                case 1:
                    Flights = Flights.OrderBy(f => f.DepartureDate).ToList();
                    ReturnFlights = ReturnFlights.OrderBy(f => f.DepartureDate).ToList();
                    break;
                case 2:
                    Flights = Flights.OrderBy(f => f.Cost).ToList();
                    ReturnFlights = ReturnFlights.OrderBy(f => f.Cost).ToList();
                    break;
                case 3:
                    Flights = Flights.OrderByDescending(f => f.Cost).ToList();
                    ReturnFlights = ReturnFlights.OrderByDescending(f => f.Cost).ToList();
                    break;
            }
        }

        protected async Task selectFlights()
        {
            if (obFlight && returnFlight)
            {
                await localStorage.SetItemAsync("OutboundFlight", Outbound);
                await localStorage.SetItemAsync("ReturnFlight", Return);

                NavigationManager.NavigateTo("/Usuarios/Equipaje");
            }
            else
            {
                showModal = true;
            }
            
        }
    }
}
