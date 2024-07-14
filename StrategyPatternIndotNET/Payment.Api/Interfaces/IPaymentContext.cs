namespace Payment.Api.Interfaces
{
    public interface IPaymentContext
    {
        void SetPaymentStrategy(IPaymentStrategy paymentStrategy);
        void ExecutePayment(decimal amount);
    }
}
