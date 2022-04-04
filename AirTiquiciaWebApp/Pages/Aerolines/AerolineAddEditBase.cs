using AirTiquicia.Core.Entities;
using AirTiquiciaWebApp.Services;
using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;

namespace AirTiquiciaWebApp.Pages.Aerolines
{
    public class AerolineAddEditBase : ComponentBase
    {
        [Inject]
        public IAerolineService AerolineService { get; set; }

        public Aeroline aeroline { get; set; } = new Aeroline();

        [Inject]
        public NavigationManager NavigationManager { get; set; }


        [Parameter]
        public string Id { get; set; }

        protected override async Task OnInitializedAsync()
        {
            aeroline = await AerolineService.GetAeroline(int.Parse(Id));
        }

        protected async Task sendAeroline()
        {
            var result = await AerolineService.AddAeroline(aeroline);

            if (result)
            {
                NavigationManager.NavigateTo("/Aerolineas");
            }
        }
    }
}
