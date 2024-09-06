using System;

namespace TaxiServiceApp.Core.Entities
{
    public class Booking
    {
        public int Id { get; set; } 
        public int CustomerId { get; set; } 
        public int DriverId { get; set; } 
        public string StartLocation { get; set; } 
        public string EndLocation { get; set; }
        public double Distance { get; set; } 
        public decimal Fare { get; set; }
        public int Passengers { get; set; }
        public DateTime BookingTime { get; set; } 
        public DateTime JourneyStartTime { get; set; } 
        public DateTime JourneyEndTime { get; set; }

        public void CalculateFare(double ratePerMile)
        {
            Fare = (decimal)(Distance * ratePerMile) + (Passengers - 1) * 5; 
        }
    }
}