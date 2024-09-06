using System.Collections.Generic;
using System.Linq;
using TaxiServiceApp.Core.Entities;
using TaxiServiceApp.Core.Interfaces;

namespace TaxiServiceApp.Data.Repositories
{
    public class BookingRepository : IBookingRepository
    {
        private readonly List<Booking> _bookings = new List<Booking>();
        private int _nextId = 1;

        public void Add(Booking booking)
        {
            booking.Id = _nextId++;
            _bookings.Add(booking);
        }

        public Booking GetById(int id)
        {
            return _bookings.FirstOrDefault(b => b.Id == id);
        }

        public IEnumerable<Booking> GetAll()
        {
            return _bookings;
        }

        public void Update(Booking booking)
        {
            var existingBooking = GetById(booking.Id);
            if (existingBooking != null)
            {
                existingBooking.CustomerId = booking.CustomerId;
                existingBooking.DriverId = booking.DriverId;
                existingBooking.StartLocation = booking.StartLocation;
                existingBooking.EndLocation = booking.EndLocation;
                existingBooking.Distance = booking.Distance;
                existingBooking.Fare = booking.Fare;
                existingBooking.Passengers = booking.Passengers;
                existingBooking.JourneyStartTime = booking.JourneyStartTime;
                existingBooking.JourneyEndTime = booking.JourneyEndTime;
            }
        }

        public void Delete(int id)
        {
            var booking = GetById(id);
            if (booking != null)
            {
                _bookings.Remove(booking);
            }
        }

        public IEnumerable<Booking> GetBookingsByCustomerId(int customerId)
        {
            return _bookings.Where(b => b.CustomerId == customerId);
        }

        public IEnumerable<Booking> GetBookingsByDriverId(int driverId)
        {
            return _bookings.Where(b => b.DriverId == driverId);
        }
    }
}
