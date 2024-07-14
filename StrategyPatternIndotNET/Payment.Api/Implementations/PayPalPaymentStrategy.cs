using Payment.Api.Interfaces;

namespace Payment.Api.Implementations
{
    public class PayPalPaymentStrategy : IPaymentStrategy
    {
        public void ProcessPayment(decimal amount)
        {
            // Implement PayPal payment processing logic
            Console.WriteLine($"Processing PayPal payment of {amount:C}");
        }
    }
}
