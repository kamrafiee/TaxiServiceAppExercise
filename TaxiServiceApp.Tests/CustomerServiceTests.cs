using NUnit.Framework;
using TaxiServiceApp.Core.Entities;
using TaxiServiceApp.Core.Interfaces;
using TaxiServiceApp.Business.Services;
using Moq;

namespace TaxiServiceApp.Tests
{
    [TestFixture]
    public class CustomerServiceTests
    {
        private CustomerService _customerService;
        private Mock<ICustomerRepository> _mockCustomerRepo;

        [SetUp]
        public void SetUp()
        {
            _mockCustomerRepo = new Mock<ICustomerRepository>();
            _customerService = new CustomerService(_mockCustomerRepo.Object);
        }

        [Test]
        public void RegisterCustomer_ValidCustomer_AddsCustomer()
        {
            var customer = new Customer { Id = 1, Name = "John Doe", CreditCardDetails = "1234-5678-9012-3456" };

            _customerService.RegisterCustomer(customer);

            _mockCustomerRepo.Verify(repo => repo.Add(customer), Times.Once);
        }

        [Test]
        public void GetCustomerById_ExistingCustomer_ReturnsCustomer()
        {
            var customer = new Customer { Id = 1, Name = "John Doe", CreditCardDetails = "1234-5678-9012-3456" };
            _mockCustomerRepo.Setup(repo => repo.GetById(1)).Returns(customer);

            var result = _customerService.GetCustomerById(1);

            Assert.That(customer, Is.EqualTo(result));
        }

        [Test]
        public void GetCustomerById_NonExistingCustomer_ReturnsNull()
        {
            _mockCustomerRepo.Setup(repo => repo.GetById(2)).Returns((Customer)null);

            var result = _customerService.GetCustomerById(2);

            Assert.That(result, Is.Null);
        }
    }
}