using TaxiServiceApp.Core.Entities;

namespace TaxiServiceApp.Core.Interfaces
{
    public interface ICustomerRepository
    {
        void Add(Customer customer);
        Customer GetById(int customerId);
    }
}