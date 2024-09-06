using NUnit.Framework;
using TaxiServiceApp.Core.Entities;
using TaxiServiceApp.Core.Interfaces;
using TaxiServiceApp.Business.Services;
using Moq;

namespace TaxiServiceApp.Tests
{
    [TestFixture]
    public class DriverServiceTests
    {
        private DriverService _driverService;
        private Mock<IDriverRepository> _mockDriverRepo;

        [SetUp]
        public void SetUp()
        {
            _mockDriverRepo = new Mock<IDriverRepository>();
            _driverService = new DriverService(_mockDriverRepo.Object);
        }

        [Test]
        public void RegisterDriver_ValidDriver_AddsDriver()
        {
            var driver = new Driver { Id = 1, Name = "Jane Smith", CarType = "Sedan", PassengerCapacity = 4 };

            _driverService.RegisterDriver(driver);

            _mockDriverRepo.Verify(repo => repo.Add(driver), Times.Once);
        }

        [Test]
        public void GetDriverById_ExistingDriver_ReturnsDriver()
        {
            var driver = new Driver { Id = 1, Name = "Jane Smith", CarType = "Sedan", PassengerCapacity = 4 };
            _mockDriverRepo.Setup(repo => repo.GetById(1)).Returns(driver);

            var result = _driverService.GetDriverById(1);

            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.EqualTo(driver));
        }

        [Test]
        public void GetDriverById_NonExistingDriver_ReturnsNull()
        {
            _mockDriverRepo.Setup(repo => repo.GetById(2)).Returns((Driver)null);

            var result = _driverService.GetDriverById(2);

            Assert.That(result, Is.Null);
        }
    }
}