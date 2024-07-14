using Payment.Api.Interfaces;

namespace Payment.Api.Implementations
{
    public class BitcoinPaymentStrategy : IPaymentStrategy
    {
        public void ProcessPayment(decimal amount)
        {
            // Implement Bitcoin payment processing logic
            Console.WriteLine($"Processing Bitcoin payment of {amount:C}");
        }
    }
}
