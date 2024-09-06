using TaxiServiceApp.Core.Entities;
using TaxiServiceApp.Core.Interfaces;

public class BookingService
{
    private readonly ICustomerService _customerService;
    private readonly IDriverService _driverService;
    private readonly IDistanceCalculatorService _distanceCalculatorService;
    private readonly IPaymentService _paymentService;
    private readonly IJourneyService _journeyService;

    public BookingService(ICustomerService customerService, IDriverService driverService,
        IDistanceCalculatorService distanceCalculatorService, IPaymentService paymentService,
        IJourneyService journeyService)
    {
        _customerService = customerService;
        _driverService = driverService;
        _distanceCalculatorService = distanceCalculatorService;
        _paymentService = paymentService;
        _journeyService = journeyService;
    }

    public Booking BookRide(int customerId, string startPostcode, string endPostcode, int passengers)
    {
        decimal distance = _distanceCalculatorService.CalculateDistance(startPostcode, endPostcode);
        decimal fare = distance * 10 + (passengers - 1) * 5.0m;

        bool paymentSuccessful = _paymentService.ProcessPayment(customerId, fare);

        if (!paymentSuccessful)
        {
            return null;
        }

        var booking = new Booking
        {
            StartLocation = startPostcode,
            EndLocation = endPostcode,
            Passengers = passengers,
            Fare = fare
        };

        return booking;
    }
}

