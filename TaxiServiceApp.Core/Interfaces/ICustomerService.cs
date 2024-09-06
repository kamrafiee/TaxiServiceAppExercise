using TaxiServiceApp.Core.Entities;

namespace TaxiServiceApp.Core.Interfaces
{
    public interface ICustomerService
    {
        void RegisterCustomer(Customer customer);
        Customer GetCustomerById(int id);
    }
}