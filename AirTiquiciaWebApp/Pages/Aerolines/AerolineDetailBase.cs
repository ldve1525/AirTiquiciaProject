using AirTiquicia.Core.Entities;
using AirTiquiciaWebApp.Services;
using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;

namespace AirTiquiciaWebApp.Pages.Aerolines
{
    public class AerolineDetailBase : ComponentBase
    {
        [Inject]
        public IAerolineService AerolineService { get; set; }

        [Parameter]
        public int id { get; set; }

        public Aeroline aeroline = new Aeroline();

        protected override async Task OnInitializedAsync()
        {
            aeroline = await AerolineService.GetAeroline(id);
        }
    }
}
