using System.Collections.Generic;
using System.Linq;
using TaxiServiceApp.Core.Entities;
using TaxiServiceApp.Core.Interfaces;

namespace TaxiServiceApp.Data.Repositories
{
    public class DriverRepository : IDriverRepository
    {
        private readonly List<Driver> _drivers = new();

        public void Add(Driver driver)
        {
            _drivers.Add(driver);
        }

        public Driver GetById(int id)
        {
            return _drivers.FirstOrDefault(d => d.Id == id);
        }

        public void Delete(int id)
        {
            var driver = GetById(id);
            if (driver != null)
            {
                _drivers.Remove(driver);
            }
        }

        public void Update(Driver driver)
        {
            var existingDriver = GetById(driver.Id);
            if (existingDriver != null)
            {
                existingDriver.Name = driver.Name;
                existingDriver.CarType = driver.CarType;
                existingDriver.PassengerCapacity = driver.PassengerCapacity;
            }
        }

        public List<Driver> GetAllDrivers()
        {
            return _drivers.ToList();
        }
    }
}