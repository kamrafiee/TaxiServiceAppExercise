using NUnit.Framework;
using Moq;
using TaxiServiceApp.Business.Services;
using TaxiServiceApp.Core.Entities;
using TaxiServiceApp.Core.Interfaces;


namespace TaxiServiceApp.Tests
{
    [TestFixture]
    public class BookingServiceTests
    {
        private Mock<ICustomerService> _customerServiceMock;
        private Mock<IDriverService> _driverServiceMock;
        private Mock<IDistanceCalculatorService> _distanceCalculatorServiceMock;
        private Mock<IPaymentService> _paymentServiceMock;
        private Mock<IJourneyService> _journeyServiceMock;
        private BookingService _bookingService;

        [SetUp]
        public void SetUp()
        {
            _customerServiceMock = new Mock<ICustomerService>();
            _driverServiceMock = new Mock<IDriverService>();
            _distanceCalculatorServiceMock = new Mock<IDistanceCalculatorService>();
            _paymentServiceMock = new Mock<IPaymentService>();
            _journeyServiceMock = new Mock<IJourneyService>();

            _bookingService = new BookingService(
                _customerServiceMock.Object,
                _driverServiceMock.Object,
                _distanceCalculatorServiceMock.Object,
                _paymentServiceMock.Object,
                _journeyServiceMock.Object
            );
        }

        [Test]
        public void BookRide_ShouldReturnBooking_WhenValidInputProvided()
        {
            var customerId = 1;
            var startPostcode = "PostcodeA";
            var endPostcode = "PostcodeB";
            var passengers = 2;

            var driver = new Driver { Id = 1, Name = "Jane Smith", CarType = "Sedan", PassengerCapacity = 4 };
            _driverServiceMock.Setup(ds => ds.GetAvailableDrivers(startPostcode)).Returns(new List<Driver> { driver });

            _distanceCalculatorServiceMock.Setup(dcs => dcs.CalculateDistance(startPostcode, endPostcode)).Returns(5.0m); 

            decimal expectedFare = 5.0m * 10 + (passengers - 1) * 5.0m;
            _paymentServiceMock.Setup(ps => ps.ProcessPayment(customerId, It.IsAny<decimal>())).Returns(true);

            var booking = _bookingService.BookRide(customerId, startPostcode, endPostcode, passengers);

            Assert.That(booking, Is.Not.Null);
            Assert.That(booking.StartLocation, Is.EqualTo(startPostcode));
            Assert.That(booking.EndLocation, Is.EqualTo(endPostcode));
            Assert.That(booking.Passengers, Is.EqualTo(passengers));
            Assert.That(booking.Fare, Is.EqualTo(expectedFare));
        }


        [Test]
        public void BookRide_ShouldReturnNull_WhenNoAvailableDrivers()
        {
            var customerId = 1;
            var startPostcode = "PostcodeA";
            var endPostcode = "PostcodeB";
            var passengers = 2;

            _driverServiceMock.Setup(ds => ds.GetAvailableDrivers(startPostcode)).Returns(new List<Driver>());

            var booking = _bookingService.BookRide(customerId, startPostcode, endPostcode, passengers);

            Assert.That(booking, Is.Null);
        }
    }
}
