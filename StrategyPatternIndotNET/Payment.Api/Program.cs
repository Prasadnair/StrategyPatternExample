using Payment.Api.Implementations;
using Payment.Api.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Register services
builder.Services.AddSingleton<IPaymentContext, PaymentContext>();
builder.Services.AddSingleton<CreditCardPaymentStrategy>();
builder.Services.AddSingleton<PayPalPaymentStrategy>();
builder.Services.AddSingleton<BitcoinPaymentStrategy>();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapPost("/pay", async (decimal amount, 
                           string method, 
                           IPaymentContext paymentContext, 
                           IServiceProvider serviceProvider) =>
{
    IPaymentStrategy strategy = method.ToLower() switch
    {
        "creditcard" => serviceProvider.GetService<CreditCardPaymentStrategy>(),
        "paypal" => serviceProvider.GetService<PayPalPaymentStrategy>(),
        "bitcoin" => serviceProvider.GetService<BitcoinPaymentStrategy>(),
        _ => throw new NotSupportedException("Invalid payment method selected.")
    };

    paymentContext.SetPaymentStrategy(strategy);
    paymentContext.ExecutePayment(amount);

    return Results.Ok($"Payment of {amount:C} using {method} processed successfully.");
});




app.Run();


