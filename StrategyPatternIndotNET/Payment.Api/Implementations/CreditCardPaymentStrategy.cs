using Payment.Api.Interfaces;

namespace Payment.Api.Implementations
{
    public class CreditCardPaymentStrategy : IPaymentStrategy
    {
        public void ProcessPayment(decimal amount)
        {
            // Implement credit card payment processing logic
            Console.WriteLine($"Processing credit card payment of {amount:C}");
        }
    }
}
