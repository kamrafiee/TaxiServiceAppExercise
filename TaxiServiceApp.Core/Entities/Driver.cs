namespace TaxiServiceApp.Core.Entities
{
    public class Driver
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CarType { get; set; }
        public int PassengerCapacity { get; set; }
        public List<int> Ratings { get; set; } = new List<int>();
        public double AverageRating => Ratings.Count > 0 ? Ratings.Average() : 0;
        public string Location { get; set; }
    }
}