using System.Collections.Generic;
using TaxiServiceApp.Core.Entities;
using TaxiServiceApp.Core.Interfaces;

namespace TaxiServiceApp.Data.Repositories
{
    public class JourneyRepository : IJourneyRepository
    {
        private readonly List<Journey> _journeys = new();

        public void Add(Journey journey)
        {
            _journeys.Add(journey);
        }

        public List<Journey> GetByCustomerId(int customerId)
        {
            return _journeys.FindAll(j => j.Customer.Id == customerId);
        }

        public List<Journey> GetByDriverId(int driverId)
        {
            return _journeys.FindAll(j => j.Driver.Id == driverId);
        }
    }
}