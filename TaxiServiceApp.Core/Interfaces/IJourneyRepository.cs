using TaxiServiceApp.Core.Entities;

namespace TaxiServiceApp.Core.Interfaces
{
    public interface IJourneyRepository
    {
        void Add(Journey journey);
        List<Journey> GetByCustomerId(int customerId);
        List<Journey> GetByDriverId(int driverId);
    }
}