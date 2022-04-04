using AirTiquicia.Core.Entities;
using AirTiquiciaWebApp.Services;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirTiquiciaWebApp.Pages.Prices
{
    public class PriceListBase : ComponentBase
    {
        [Inject]
        public IPriceService PriceService { get; set; }


        public List<Price> Prices = new List<Price>();

        protected override async Task OnInitializedAsync()
        {
            Prices = await PriceService.GetPrices();
        }
    }
}
