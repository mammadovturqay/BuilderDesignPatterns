public interface ICarBuilder
{
    void Reset();
    void SetSeats(int number);
    void SetEngine(string engine);
    void SetTripComputer();
    void SetGPS();
    Car GetCar();
}

public interface ICarManualBuilder
{
    void Reset();
    void SetSeats(int number);
    void SetEngine(string engine);
    void SetTripComputer();
    void SetGPS();
    Manual GetManual();
}

public class CarBuilder : ICarBuilder
{
    private Car car;

    public CarBuilder()
    {
        Reset();
    }

    public void Reset()
    {
        car = new Car();
    }

    public void SetSeats(int number)
    {
        car.Seats = number;
    }

    public void SetEngine(string engine)
    {
        car.Engine = engine;
    }

    public void SetTripComputer()
    {
        car.HasTripComputer = true;
    }

    public void SetGPS()
    {
        car.HasGPS = true;
    }

    public Car GetCar()
    {
        return car;
    }
}

public class CarManualBuilder : ICarManualBuilder
{
    private Manual manual;

    public CarManualBuilder()
    {
        Reset();
    }

    public void Reset()
    {
        manual = new Manual();
    }

    public void SetSeats(int number)
    {
        manual.SeatsInstruction = $"oturma yeri : {number}";
    }

    public void SetEngine(string engine)
    {
        manual.EngineInstruction = $"Motor : {engine}";
    }

    public void SetTripComputer()
    {
        manual.TripComputerInstruction = "Installing trip computer....";
    }

    public void SetGPS()
    {
        manual.GPSInstruction = "Install GPS....";
    }

    public Manual GetManual()
    {
        return manual;
    }
}

public class Car
{
    public int Seats { get; set; }
    public string Engine { get; set; }
    public bool HasTripComputer { get; set; }
    public bool HasGPS { get; set; }
}

public class Manual
{
    public string SeatsInstruction { get; set; }
    public string EngineInstruction { get; set; }
    public string TripComputerInstruction { get; set; }
    public string GPSInstruction { get; set; }
}


class Program
{
    static void Main()
    {
        ICarBuilder builder = new CarBuilder();
        builder.SetSeats(5);
        builder.SetEngine("V8");
        builder.SetTripComputer();
        builder.SetGPS();

        Car car = builder.GetCar();

        Console.WriteLine("Car creating :");
        Console.WriteLine($"oturmaq yeri : {car.Seats}");
        Console.WriteLine($"Motor : {car.Engine}");
        Console.WriteLine($"Has Trip Computer (True or false ): {car.HasTripComputer}");
        Console.WriteLine($"Has GPS (True or false ): {car.HasGPS}");

        ICarManualBuilder manualBuilder = new CarManualBuilder();
        manualBuilder.SetSeats(5);
        manualBuilder.SetEngine("V8");
        manualBuilder.SetTripComputer();
        manualBuilder.SetGPS();

        Manual carManual = manualBuilder.GetManual();

        Console.WriteLine("\nCar Manual creating :");
        Console.WriteLine($"oturma yeri : {carManual.SeatsInstruction}");
        Console.WriteLine($"Motor: {carManual.EngineInstruction}");
        Console.WriteLine($"Trip Computer instructionns  : {carManual.TripComputerInstruction}");
        Console.WriteLine($"GPS  insturctions : {carManual.GPSInstruction}");
    }
}
