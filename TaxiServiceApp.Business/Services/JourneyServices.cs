using TaxiServiceApp.Core.Entities;
using TaxiServiceApp.Core.Interfaces;

namespace TaxiServiceApp.Data.Repositories
{
    public class JourneyService : IJourneyService
    {
        private readonly IDriverService _driverService;
        public JourneyService()
        {
            _driverService = _driverService;
        }
        public void SaveJourney(Journey journey)
        {
            // PLACEHOLDER.
        }
    }
}