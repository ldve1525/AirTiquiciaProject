using AirTiquicia.Core.Entities;
using AirTiquiciaWebApp.Services;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AirTiquiciaWebApp.Pages.Aerolines
{
    public class AerolineListBase : ComponentBase
    {
        [Inject]
        public IAerolineService AerolineService { get; set; }

        public List<Aeroline> Aerolines = new List<Aeroline>();

        protected override async Task OnInitializedAsync()
        {
            Aerolines = await AerolineService.GetAerolines();
        }
    }
}
