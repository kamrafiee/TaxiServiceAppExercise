namespace TaxiServiceApp.Core.Interfaces
{
    public interface IDistanceCalculatorService
    {
        decimal CalculateDistance(string startPostcode, string endPostcode);
    }
}