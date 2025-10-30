namespace DesignPatternsImplementation.Factory_Method.Products;

public class Car : IVehicle
{
    public void Drive()
    {
        Console.WriteLine("El auto se maneja");
    }

    public void Start()
    {
        Console.WriteLine("El auto se inicia");
    }

    public void Stop()
    {
        Console.WriteLine("El auto se detiene");
    }
}
