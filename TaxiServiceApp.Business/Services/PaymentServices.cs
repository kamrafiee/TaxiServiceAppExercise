using TaxiServiceApp.Core.Interfaces;

namespace TaxiServiceApp.Business.Services
{
    public class PaymentService : IPaymentService
    {
        public bool ProcessPayment(int customerId, decimal amount)
        {
            return true; // PLACEHOLDER. Returns true. 
        }
    }
}