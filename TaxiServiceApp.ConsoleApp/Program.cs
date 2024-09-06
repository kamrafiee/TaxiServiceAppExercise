using System;
using TaxiServiceApp.Business.Services;
using TaxiServiceApp.Core.Interfaces;
using TaxiServiceApp.Data.Repositories;
using Moq;
using TaxiServiceApp.Core.Entities;

namespace TaxiServiceApp.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            IDriverRepository driverRepository = new DriverRepository();
            IDriverService driverService = new DriverService(driverRepository);
            IJourneyService journeyService = new JourneyService();
            ICustomerService customerService = new Mock<ICustomerService>().Object;
            IDistanceCalculatorService distanceCalculatorService = new Mock<IDistanceCalculatorService>().Object;
            IPaymentService paymentService = new Mock<IPaymentService>().Object;

            var newDriver = new Driver { Id = 1, Name = "John Doe", CarType = "Sedan", PassengerCapacity = 4 };
            driverService.RegisterDriver(newDriver);
            Console.WriteLine("Driver registered successfully.");

            var bookingService = new BookingService(customerService, driverService, distanceCalculatorService, paymentService, journeyService);
            var booking = bookingService.BookRide(1, "PostcodeA", "PostcodeB", 2);
            if (booking != null)
            {
                Console.WriteLine("Ride booked successfully.");
            }
            else
            {
                Console.WriteLine("No available drivers.");
            }

            Console.ReadLine();
        }
    }
}