using TaxiServiceApp.Core.Entities;

namespace TaxiServiceApp.Core.Entities
{
    public class Journey
    {
        public int Id { get; set; }
        public Customer Customer { get; set; }
        public Driver Driver { get; set; }
        public string StartLocation { get; set; }
        public string EndLocation { get; set; }
        public double Distance { get; set; } 
        public decimal Fare { get; set; }
        public int Passengers { get; set; }
    }
}