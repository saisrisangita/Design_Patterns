
// Product: PaymentProcessor
//This is an interface for creating the objects.
using System.Diagnostics;

public interface IPaymentProcessor
{
    void ProcessPayment(decimal amount);
}

// Concrete Products
//This is a class which implements the Product interface.
public class CreditCardProcessor : IPaymentProcessor
{
    public void ProcessPayment(decimal amount)
    {
        Console.WriteLine($"Payment processed using Credit Card: {amount} USD");
    }
}

public class PayPalProcessor : IPaymentProcessor
{
    public void ProcessPayment(decimal amount)
    {
        Console.WriteLine($"Payment processed using PayPal: {amount} USD");
    }
}

// Factory: PaymentProcessorFactory
//This is an abstract class and declares the factory method, which returns an object of type Product.
public interface IPaymentProcessorFactory
{
    IPaymentProcessor CreatePaymentProcessor();
}

// Concrete Factories
//This is a class which implements the Creator class and overrides the factory
//method to return an instance of a ConcreteProduct.
public class CreditCardProcessorFactory : IPaymentProcessorFactory
{
    public IPaymentProcessor CreatePaymentProcessor()
    {
        return new CreditCardProcessor();
    }
}

public class PayPalProcessorFactory : IPaymentProcessorFactory
{
    public IPaymentProcessor CreatePaymentProcessor()
    {
        return new PayPalProcessor();
    }
}

// Usage
public class Program
{
    public static void Main(string[] args)
    {
        
        // Create a CreditCardProcessor using the factory
        IPaymentProcessorFactory creditCardFactory = new CreditCardProcessorFactory();
        IPaymentProcessor creditCardProcessor = creditCardFactory.CreatePaymentProcessor();
        creditCardProcessor.ProcessPayment(100);

        // Create a PayPalProcessor using the factory
        IPaymentProcessorFactory paypalFactory = new PayPalProcessorFactory();
        IPaymentProcessor paypalProcessor = paypalFactory.CreatePaymentProcessor();
        paypalProcessor.ProcessPayment(200);

    }
}
