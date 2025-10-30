namespace DesignPatternsImplementation.Factory_Method.Products;

public class MotorCycle : IVehicle
{
    public void Drive()
    {
        Console.WriteLine("La moto se maneja");
    }

    public void Start()
    {
        Console.WriteLine("La moto se inicia");
    }

    public void Stop()
    {
        Console.WriteLine("La moto se detiene");
    }
}
