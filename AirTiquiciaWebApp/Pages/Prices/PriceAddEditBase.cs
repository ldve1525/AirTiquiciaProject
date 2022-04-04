using AirTiquicia.Core.Entities;
using AirTiquiciaWebApp.Services;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirTiquiciaWebApp.Pages.Prices
{
    public class PriceAddEditBase : ComponentBase
    {
        [Inject]
        public IPriceService PriceService { get; set; }

        public Price price { get; set; } = new Price();

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Inject]
        public IFlightService FlightService { get; set; }
        public List<Flight> flights { get; set; } = new List<Flight>();
        public Flight flight { get; set; } = new Flight();

        //[Inject]
        //public IClassService ClassService { get; set; }

        //public List<Class> classes { get; set; } = new List<Class>();

        [Parameter]
        public string Id { get; set; }


        protected override async Task OnInitializedAsync()
        {
            //classes = (await ClassService.GetClasses()).ToList();
            flights = (await FlightService.GetFlights()).ToList();

            if (Id != null)
            {
                price = await PriceService.GetPrice(int.Parse(Id));
                flight.Id = price.IdFlight;
            }
            else
            {
                price.IdClass = 1;
            }
        }

        protected async Task sendPrice()
        {

            if (Id == null)
            {
                await PriceService.AddPrice(price);
            }
            else
            {
                await PriceService.UpdatePrice(price);
            }


            NavigationManager.NavigateTo("/Precios");
        }
    }
}
