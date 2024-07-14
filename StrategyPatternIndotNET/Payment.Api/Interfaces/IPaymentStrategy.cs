namespace Payment.Api.Interfaces
{
    public interface IPaymentStrategy
    {
        void ProcessPayment(decimal amount);
    }
}
