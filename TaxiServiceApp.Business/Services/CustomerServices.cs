using TaxiServiceApp.Core.Entities;
using TaxiServiceApp.Core.Interfaces;

namespace TaxiServiceApp.Business.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public void RegisterCustomer(Customer customer)
        {
            _customerRepository.Add(customer);
        }

        public Customer GetCustomerById(int id)
        {
            return _customerRepository.GetById(id);
        }
    }
}