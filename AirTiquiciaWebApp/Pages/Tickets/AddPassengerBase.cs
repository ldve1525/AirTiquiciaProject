using AirTiquicia.Core.Entities;
using AirTiquiciaWebApp.Services;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Globalization;
using System.Threading;
using System.Text.Json;

namespace AirTiquiciaWebApp.Pages.Tickets
{
    public class AddPassengerBase : ComponentBase
    {
        [Inject]
        public IFlightService FlightService { get; set; }
        public Flight OutboundFlight { get; set; } = new Flight();
        public Flight ReturnFlight { get; set; } = new Flight();

        [Inject]
        public IAirportService AirportService { get; set; }
        public Airport DepartureAirport { get; set; } = new Airport();
        public Airport DestinationAirport { get; set; } = new Airport();

        [Inject]
        public IAirplaneService AirplaneService { get; set; }
        public Airplane OBAirplane { get; set; } = new Airplane();
        public Airplane ReturnAirplane { get; set; } = new Airplane();

        [Inject]
        public IAerolineService AerolineService { get; set; }
        public Aeroline OBAeroline { get; set; } = new Aeroline();
        public Aeroline ReturnAeroline { get; set; } = new Aeroline();

        [Inject]
        public IPriceService PriceService { get; set; }
        public Price OBPrice { get; set; } = new Price();
        public Price ReturnPrice { get; set; } = new Price();

        [Inject]
        public IPassengerService PassengerService { get; set; }
        public List<Passenger> Passengers { get; set; } = new List<Passenger>();
        public Passenger Passenger { get; set; } = new Passenger();

        [Inject]
        public ITicketService TicketService { get; set; }
        public Ticket Ticket { get; set; } = new Ticket();

        [Inject]
        public ISeatService SeatService { get; set; }
        public Seat Seat { get; set; } = new Seat();

        [Inject]
        public ILuggageService LuggageService { get; set; }
        public Luggage Luggage { get; set; } = new Luggage();

        [Inject]
        public Blazored.LocalStorage.ILocalStorageService localStorage { get; set; }

        [Parameter]
        public string seats { get; set; }

        public int Seats, Counter;

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        public List<string> Countries { get; set; } = new List<string>();

        public string OutboundDepartureDate, ReturnDepartureDate, formattedOBTimeSpan, formattedReturnTimeSpan;

        public bool Terms, RequireTerms;

        public string Class;

        public int FlightClass;

        protected override void OnInitialized()
        {
            Counter = 1;

            Seats = Convert.ToInt32(seats);

            for (int i = 0; i < Seats; i++)
            {
                Passengers.Add(new Passenger());
                Passengers[i].DocumentType = 1;
                Passengers[i].Birthdate = new DateTime(2000, 1, 1);
                Passengers[i].Nationality = "Costa Rica";
            }

            Countries = CountryList();
            
        }

        protected override async Task OnInitializedAsync()
        {
            var Outbound = await localStorage.GetItemAsync<Int32>("OutboundFlight");
            var Return = await localStorage.GetItemAsync<Int32>("ReturnFlight");

            //Seats = await localStorage.GetItemAsync<Int32>("Seats");

            OutboundFlight = await FlightService.GetFlight(Outbound);
            ReturnFlight = await FlightService.GetFlight(Return);

            Thread.CurrentThread.CurrentCulture = new CultureInfo("es-CR");

            OutboundDepartureDate = OutboundFlight.DepartureDate.ToString("dddd, MMMM dd, yyyy");
            OutboundDepartureDate = Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(OutboundDepartureDate.ToLower());

            ReturnDepartureDate = ReturnFlight.DepartureDate.ToString("dddd, MMMM dd, yyyy");
            ReturnDepartureDate = Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(ReturnDepartureDate.ToLower());

            var outboundDuration = OutboundFlight.ArrivalDate.Subtract(OutboundFlight.DepartureDate);
            formattedOBTimeSpan = string.Format("{0:D2} h {1:D2} m", outboundDuration.Hours, outboundDuration.Minutes);

            var returnDuration = ReturnFlight.ArrivalDate.Subtract(ReturnFlight.DepartureDate);
            formattedReturnTimeSpan = string.Format("{0:D2} h {1:D2} m", returnDuration.Hours, returnDuration.Minutes);

            DepartureAirport = await AirportService.GetAirport(OutboundFlight.DepartureAirport);
            DestinationAirport = await AirportService.GetAirport(OutboundFlight.DestinationAirport);

            OBAirplane = await AirplaneService.GetAirplane(OutboundFlight.IdAirplane);
            OBAeroline = await AerolineService.GetAeroline(OBAirplane.IdAeroline);

            ReturnAirplane = await AirplaneService.GetAirplane(ReturnFlight.IdAirplane);
            ReturnAeroline = await AerolineService.GetAeroline(ReturnAirplane.IdAeroline);

            FlightClass = Convert.ToInt32(await localStorage.GetItemAsync<string>("Class"));
            OBPrice = await PriceService.GetPrice(FlightClass, OutboundFlight.Id);
            ReturnPrice = await PriceService.GetPrice(FlightClass, ReturnFlight.Id);

            Class = FlightClass == 1 ? "Económica" : "Ejecutiva";
        }

        public static List<string> CountryList()
        {
            List<string> CultureList = new List<string>();

            CultureInfo[] getCultureInfo = CultureInfo.GetCultures(CultureTypes.SpecificCultures);

            foreach (CultureInfo getCulture in getCultureInfo)
            {
                RegionInfo GetRegionInfo = new RegionInfo(getCulture.LCID);

                if (!(CultureList.Contains(GetRegionInfo.DisplayName)))
                {
                    CultureList.Add(GetRegionInfo.DisplayName);
                }
            }

            CultureList.Sort();
            return CultureList;
        }

        protected void AcceptTerms()
        {
            Terms = (Terms == false);

            if (RequireTerms)
                RequireTerms = false;
        }

        protected async Task AddPassengers()
        {
            if (Terms)
            {
                foreach (var passenger in Passengers)
                {
                    await PassengerService.AddPassenger(passenger);

                    await SetSeats(OBAirplane, OutboundFlight);

                    await UpdateFlightSeats(OutboundFlight);

                    await SetLuggage();

                    Ticket.IdFlight = OutboundFlight.Id;
                    Ticket.IdPassenger = passenger.Id;
                    Ticket.IdClass = FlightClass;
                    Ticket.IdPrice = OBPrice.Id;
                    Ticket.Date = DateTime.Now;
                    Ticket.IdSeat = Seat.Id;
                    Ticket.IdLuggage = Luggage.Id;

                    await TicketService.AddTicket(Ticket);
                }

                var json = JsonSerializer.Serialize(Passengers);
                await localStorage.SetItemAsync("Passengers", json);

                NavigationManager.NavigateTo("/Usuarios/Viaje");
            }
            else
            {
                RequireTerms = true;
            }
            
        }

        protected async Task SetSeats(Airplane airplane, Flight flight)
        {
            switch (airplane.Size)
            {
                case 1:
                    if (FlightClass == 1)
                    {
                        int seat = airplane.CapacityEconomic - flight.SeatsEconomic + 1;
                        Seat.Row = seat / 4 + 3;
                        Seat.Letter = seat % 4;
                        Seat.IdClass = 1;
                    }
                    else
                    {
                        int seat = airplane.CapacityExecutive - flight.SeatsExecutive + 1;
                        Seat.Row = seat / 4 + 1;
                        Seat.Letter = seat % 4;
                        Seat.IdClass = 2;
                    }
                    break;
                case 2:
                    if (FlightClass == 1)
                    {
                        int seat = airplane.CapacityEconomic - flight.SeatsEconomic + 1;
                        Seat.Row = seat / 6 + 4;
                        Seat.Letter = seat % 6;
                        Seat.IdClass = 1;
                    }
                    else
                    {
                        int seat = airplane.CapacityExecutive - flight.SeatsExecutive + 1;
                        Seat.Row = seat / 4 + 1;
                        Seat.Letter = seat % 4;
                        Seat.IdClass = 2;
                    }
                    break;
                case 3:
                    if (FlightClass == 1)
                    {
                        int seat = airplane.CapacityExecutive - flight.SeatsExecutive + 1;
                        Seat.Row = seat / 6 + 4;
                        Seat.Letter = seat % 6;
                        Seat.IdClass = 1;
                    }
                    else
                    {
                        int seat = airplane.CapacityExecutive - flight.SeatsExecutive + 1;
                        Seat.Row = seat / 4 + 1;
                        Seat.Letter = seat % 4;
                        Seat.IdClass = 2;
                    }
                    break;
            }

            Seat.Id = await SeatService.AddSeat(Seat);
        }

        protected async Task UpdateFlightSeats(Flight flight)
        {
            if (FlightClass == 1)
            {
                flight.SeatsEconomic = flight.SeatsEconomic - 1;
                await FlightService.UpdateFlight(flight);
            }
            else
            {
                flight.SeatsExecutive = flight.SeatsExecutive - 1;
                await FlightService.UpdateFlight(flight);
            }
        }

        protected async Task SetLuggage()
        {
            Luggage.Quantity = await localStorage.GetItemAsync<Int32>("LuggageQuantity");
            Luggage.Weight = await localStorage.GetItemAsync<Int32>("LuggageWeight");
            Luggage.Cost = await localStorage.GetItemAsync<Decimal>("LuggageCost");

            Luggage.Id = await LuggageService.AddLuggage(Luggage);
        }
    }
}
