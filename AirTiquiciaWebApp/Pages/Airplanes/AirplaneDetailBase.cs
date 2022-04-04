using AirTiquicia.Core.Entities;
using AirTiquiciaWebApp.Services;
using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;


namespace AirTiquiciaWebApp.Pages.Airplanes
{
    public class AirplaneDetailBase : ComponentBase
    {
        [Inject]
        public IAirplaneService AirplaneService { get; set; }

        [Parameter]
        public string id { get; set; }

        public Airplane airplane = new Airplane();

        protected override async Task OnInitializedAsync()
        {
            airplane = await AirplaneService.GetAirplane(id);
        }
    }
}
