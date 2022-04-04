using AirTiquicia.Core.Entities;
using AirTiquiciaWebApp.Services;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirTiquiciaWebApp.Pages.Airplanes
{
    public class AirplaneAddEditBase : ComponentBase
    {
        [Inject]
        public IAirplaneService AirplaneService { get; set; }

        public Airplane airplane { get; set; } = new Airplane();

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Inject]
        public IAerolineService AerolineService { get; set; }

        public List<Aeroline> aerolines { get; set;} = new List<Aeroline>();

        [Parameter]
        public string Id { get; set; }

        public bool Disabled = false;

        protected override async Task OnInitializedAsync()
        {
            if (Id != null)
            {
                airplane = await AirplaneService.GetAirplane(Id);
                Disabled = true;
            }
                
            aerolines = ( await AerolineService.GetAerolines()).ToList();
            airplane.IdAeroline = aerolines[0].Id;
        }

        protected async Task sendAirplane()
        {
            if (Id == null )
            {
                await AirplaneService.AddAirplane(airplane);
            }
            else
            {
                await AirplaneService.UpdateAirplane(airplane);
            }


            NavigationManager.NavigateTo("/Aviones");
        }
    }
}
