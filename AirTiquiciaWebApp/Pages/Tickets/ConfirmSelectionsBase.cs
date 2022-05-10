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
using AirTiquiciaWebApp.Email;
using Blazored.Modal.Services;

namespace AirTiquiciaWebApp.Pages.Tickets
{
    public class ConfirmSelectionsBase : ComponentBase
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
        public Airplane Airplane { get; set; } = new Airplane();

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
        public Passenger Passenger1 { get; set; } = new Passenger();

        [Inject]
        public Blazored.LocalStorage.ILocalStorageService localStorage { get; set; }

        public string OutboundDepartureDate, ReturnDepartureDate, formattedOBTimeSpan, formattedReturnTimeSpan;

        public string Class;

        [Inject]
        public IModalService modal { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        public int Counter = 1;

        public int FlightClass;

        public bool confirmed, sent;


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

            Airplane = await AirplaneService.GetAirplane(OutboundFlight.IdAirplane);
            OBAeroline = await AerolineService.GetAeroline(Airplane.IdAeroline);

            Airplane = await AirplaneService.GetAirplane(ReturnFlight.IdAirplane);
            ReturnAeroline = await AerolineService.GetAeroline(Airplane.IdAeroline);

            FlightClass = Convert.ToInt32(await localStorage.GetItemAsync<string>("Class"));
            OBPrice = await PriceService.GetPrice(FlightClass, OutboundFlight.Id);
            await localStorage.SetItemAsync("OBIdPrice", OBPrice.Id);
            ReturnPrice = await PriceService.GetPrice(FlightClass, ReturnFlight.Id);
            await localStorage.SetItemAsync("ReturnIdPrice", ReturnPrice.Id);

            Class = FlightClass == 1 ? "Económica" : "Ejecutiva";

            string json = await localStorage.GetItemAsync<string>("Passengers");
            Passengers = JsonSerializer.Deserialize<List<Passenger>>(json);

            confirmed = true;
        }

        public void SendEmail()
        {
            EmailHelper emailHelper = new EmailHelper();
            bool emailResponse = emailHelper.SendEmail(Passengers[0], DepartureAirport, OutboundFlight, OBAeroline, Class, OBPrice);

            if (emailResponse)
            {
                sent = true;
            }
        }
    }
}
