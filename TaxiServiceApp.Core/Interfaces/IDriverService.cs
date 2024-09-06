using TaxiServiceApp.Core.Entities;
using System.Collections.Generic;

namespace TaxiServiceApp.Core.Interfaces
{
    public interface IDriverService
    {
        void RegisterDriver(Driver driver);
        Driver GetDriverById(int id);
        void RateDriver(int driverId, int rating);
        IEnumerable<Driver> GetAvailableDrivers(string location);
    }
}