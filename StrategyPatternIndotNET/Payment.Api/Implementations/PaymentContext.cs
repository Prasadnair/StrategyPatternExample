using Payment.Api.Interfaces;

namespace Payment.Api.Implementations
{
    public class PaymentContext : IPaymentContext
    {
        private IPaymentStrategy _paymentStrategy;

        public void SetPaymentStrategy(
            IPaymentStrategy paymentStrategy
            )
        {
            _paymentStrategy = paymentStrategy;
        }
        public void ExecutePayment(decimal amount)
        {
            _paymentStrategy.ProcessPayment(amount);
        }
        
    }
}
