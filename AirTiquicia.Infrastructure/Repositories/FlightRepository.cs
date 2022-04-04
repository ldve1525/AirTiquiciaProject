using AirTiquicia.Core.Entities;
using AirTiquicia.Core.Interfaces;
using AirTiquicia.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirTiquicia.Infrastructure.Repositories
{
    public class FlightRepository : IFlightRepository
    {
        private readonly AirTiquiciaContext _context;

        public FlightRepository(AirTiquiciaContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Flight>> GetFlights()
        {
            var flights = await Task.FromResult(_context.Flight.ToList());

            return flights;
        }

        public async Task<Flight> GetFlight(int id)
        {
            var flight = await _context.Flight.FirstOrDefaultAsync(x => x.Id == id);

            return flight;
        }

        public async Task<bool> AddFlight(Flight flight)
        {
            bool added = false;
            try
            {
                _context.Flight.Add(flight);
                await _context.SaveChangesAsync();

                added = true;
            }
            catch (Exception)
            {

                throw;
            }

            return added;
        }

        public async Task<bool> UpdateFlight(Flight flight)
        {
            var currentFlight = await GetFlight(flight.Id);

            currentFlight.Code = flight.Code;
            currentFlight.IdAirplane = flight.IdAirplane;
            currentFlight.DepartureAirport = flight.DepartureAirport;
            currentFlight.DepartureDate = flight.DepartureDate;
            currentFlight.DestinationAirport = flight.DestinationAirport;
            currentFlight.ArrivalDate = flight.ArrivalDate;
            currentFlight.Stopover = flight.Stopover;

            int rows = await _context.SaveChangesAsync();
            return rows > 0;
        }

        public async Task<bool> DeleteFlight(int id)
        {
            var currentFlight = await GetFlight(id);
            _context.Flight.Remove(currentFlight);

            int rows = await _context.SaveChangesAsync();
            return rows > 0;
        }
    }
}
