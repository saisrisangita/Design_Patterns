// Product: Computer

public class Computer
{
    public string Motherboard { get; set; }
    public string CPU { get; set; }
    public string RAM { get; set; }
    public string Storage { get; set; }
    public string GPU { get; set; }
    
}

// Builder: ComputerBuilder
//This is an interface which is used to define all the steps to create a product
public interface IComputerBuilder
{
    void BuildMotherboard();
    void BuildCPU();
    void BuildRAM();
    void BuildStorage();
    void BuildGPU();
    Computer GetComputer();
}

// Concrete Builder: GamingComputerBuilder

//This is a class which implements the Builder interface to create a complex product.
public class GamingComputerBuilder : IComputerBuilder
{
    private Computer computer;

    public GamingComputerBuilder()
    {
        computer = new Computer();
    }

    public void BuildMotherboard()
    {
        computer.Motherboard = "Gaming Motherboard";
    }

    public void BuildCPU()
    {
        computer.CPU = "High-Performance CPU";
    }

    public void BuildRAM()
    {
        computer.RAM = "16GB RAM";
    }

    public void BuildStorage()
    {
        computer.Storage = "1TB SSD";
    }

    public void BuildGPU()
    {
        computer.GPU = "Dedicated Gaming GPU";
    }

    public Computer GetComputer()
    {
        return computer;
    }
}

// Director


public class ComputerBuildDirector
{
    private IComputerBuilder computerBuilder;

    public ComputerBuildDirector(IComputerBuilder builder)
    {
        computerBuilder = builder;
    }

    public void ConstructComputer()
    {
        computerBuilder.BuildMotherboard();
        computerBuilder.BuildCPU();
        computerBuilder.BuildRAM();
        computerBuilder.BuildStorage();
        computerBuilder.BuildGPU();
    }
}

// Usage
public class Program
{
    public static void Main(string[] args)
    {
        IComputerBuilder computerBuilder = new GamingComputerBuilder();
        ComputerBuildDirector director = new ComputerBuildDirector(computerBuilder);

        director.ConstructComputer();

        Computer computer = computerBuilder.GetComputer();

        // Use the constructed computer
        Console.WriteLine($"Motherboard: {computer.Motherboard}");
        Console.WriteLine($"CPU: {computer.CPU}");
        Console.WriteLine($"RAM: {computer.RAM}");
        Console.WriteLine($"Storage: {computer.Storage}");
        Console.WriteLine($"GPU: {computer.GPU}");
    }
}
