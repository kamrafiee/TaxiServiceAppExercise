using TaxiServiceApp.Core.Interfaces;

namespace TaxiServiceApp.Business.Services
{
    public class DistanceCalculatorService : IDistanceCalculatorService
    {
        public decimal CalculateDistance(string startPostcode, string endPostcode)
        {
            // PLACEHOLDER. Returns example fixed distance.
            return 10m;
        }
    }
}