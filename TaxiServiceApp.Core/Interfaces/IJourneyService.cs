using TaxiServiceApp.Core.Entities;

namespace TaxiServiceApp.Core.Interfaces
{
    public interface IJourneyService
    {
        void SaveJourney(Journey journey);
    }
}
