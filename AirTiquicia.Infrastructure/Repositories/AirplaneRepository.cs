using AirTiquicia.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AirTiquicia.Infrastructure.Repositories
{
    public class AirplaneRepository
    {
        public IEnumerable<Airplane> GetPlanes()
        {
            var airplanes = Enumerable.Range(1, 10).Select(x => new Airplane
            {
                PlaneId = "Airbus A320",
                Description =  $"Description {x}",
                Size= 1,
                Capacity= 38
            });

            return airplanes;
        }
    }
}
