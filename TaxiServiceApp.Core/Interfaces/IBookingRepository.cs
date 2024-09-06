using TaxiServiceApp.Core.Entities;

namespace TaxiServiceApp.Core.Interfaces
{
    public interface IBookingRepository
    {
        void Add(Booking booking);
        Booking GetById(int id);
        IEnumerable<Booking> GetAll();
        void Update(Booking booking);
        void Delete(int id);
        IEnumerable<Booking> GetBookingsByCustomerId(int customerId);
        IEnumerable<Booking> GetBookingsByDriverId(int driverId);
    }
}