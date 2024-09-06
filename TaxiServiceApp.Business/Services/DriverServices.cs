using TaxiServiceApp.Core.Entities;
using TaxiServiceApp.Core.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace TaxiServiceApp.Business.Services
{
    public class DriverService : IDriverService
    {
        private readonly IDriverRepository _driverRepository;

        public DriverService(IDriverRepository driverRepository)
        {
            _driverRepository = driverRepository;
        }

        public void RegisterDriver(Driver driver)
        {
            _driverRepository.Add(driver);
        }

        public Driver GetDriverById(int id)
        {
            return _driverRepository.GetById(id);
        }

        public void RateDriver(int driverId, int rating)
        {
            var driver = _driverRepository.GetById(driverId);
            if (driver != null)
            {
                driver.Ratings.Add(rating);
                _driverRepository.Update(driver);
            }
        }

        public IEnumerable<Driver> GetAvailableDrivers(string location)
        {
            // Assuming that you have a method in your repository that filters based on location
            return _driverRepository.GetAllDrivers().Where(d => d.Location == location);
        }
    }
}