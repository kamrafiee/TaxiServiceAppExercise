using System;

namespace TaxiServiceApp.Core.Interfaces
{
    public interface IPaymentService
    {
        bool ProcessPayment(int customerId, decimal amount);
    }
}