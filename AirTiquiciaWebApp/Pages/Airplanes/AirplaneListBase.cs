using AirTiquicia.Core.Entities;
using AirTiquiciaWebApp.Services;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirTiquiciaWebApp.Pages.Airplanes
{
    public class AirplaneListBase : ComponentBase
    {
        [Inject]
        public IAirplaneService AirplaneService { get; set; }

        //public IEnumerable<Airplane> Airplanes { get; set; }

        public List<Airplane> Airplanes = new List<Airplane>();

        protected override async Task OnInitializedAsync()
        {
            //Airplanes = (await AirplaneService.GetAirplanes()).ToList();
            Airplanes = await AirplaneService.GetAirplanes();
        }
    }
}
