using TaxiServiceApp.Core.Entities;

namespace TaxiServiceApp.Core.Interfaces
{
    public interface IBookingService
    {
        Journey BookRide(int customerId, string startPostcode, string endPostcode, int passengers);
    }
}