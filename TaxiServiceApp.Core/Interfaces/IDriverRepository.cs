using TaxiServiceApp.Core.Entities;

public interface IDriverRepository
{
    void Add(Driver driver);
    Driver GetById(int id);
    void Delete(int id);
    void Update(Driver driver);
    List<Driver> GetAllDrivers();
}