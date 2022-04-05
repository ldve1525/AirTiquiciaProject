using AirTiquicia.Core.Entities;
using AirTiquiciaWebApp.Services;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirTiquiciaWebApp.Pages.Crews
{
    public class CrewListBase : ComponentBase
    {
        [Inject]
        public ICrewService CrewService { get; set; }

        public List<Crew> Crews = new List<Crew>();

        protected override async Task OnInitializedAsync()
        {
            Crews = await CrewService.GetCrews();
        }
    }
}
