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
    public class PassengerRepository : IPassengerRepository
    {
        private readonly AirTiquiciaContext _context;

        public PassengerRepository(AirTiquiciaContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Passenger>> GetPassengers()
        {
            var passengers = await Task.FromResult(_context.Passenger.ToList());

            return passengers;
        }

        public async Task<Passenger> GetPassenger(string id)
        {
            var passenger = await _context.Passenger.FirstOrDefaultAsync(x => x.Id == id);

            return passenger;
        }

        public async Task<bool> AddPassenger(Passenger passenger)
        {
            bool added = false;
            try
            {
                _context.Passenger.Add(passenger);
                await _context.SaveChangesAsync();

                added = true;
            }
            catch (Exception)
            {

                throw;
            }

            return added;
        }

        public async Task<bool> UpdatePassenger(Passenger passenger)
        {
            var currentPassenger = await GetPassenger(passenger.Id);

            currentPassenger.Id = passenger.Id;
            currentPassenger.FirstName = passenger.FirstName;
            currentPassenger.LastName = passenger.LastName;
            currentPassenger.DocumentType = passenger.DocumentType;
            currentPassenger.Birthdate = passenger.Birthdate;
            currentPassenger.Nationality = passenger.Nationality;
            currentPassenger.Phone = passenger.Phone;
            currentPassenger.Email = passenger.Email;

            int rows = await _context.SaveChangesAsync();
            return rows > 0;
        }

        public async Task<bool> DeletePassenger(string id)
        {
            var currentPassenger = await GetPassenger(id);
            _context.Passenger.Remove(currentPassenger);

            int rows = await _context.SaveChangesAsync();
            return rows > 0;
        }
    }
}
