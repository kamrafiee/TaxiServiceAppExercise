using System.Collections.Generic;
using TaxiServiceApp.Core.Entities;
using TaxiServiceApp.Core.Interfaces;

namespace TaxiServiceApp.Data.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly List<Customer> _customers = new();

        public void Add(Customer customer)
        {
            _customers.Add(customer);
        }

        public Customer GetById(int customerId)
        {
            return _customers.Find(c => c.Id == customerId);
        }
    }
}