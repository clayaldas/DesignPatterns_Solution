namespace DesignPatterns.FactoryMethod.Products
{
  public class Car : IVehicle
  {
    public void Start()
    {
      Console.WriteLine("Se inicia el paseo en auto");
    }

    public void Drive()
    {
      Console.WriteLine("Paseando en el auto");
    }

    public void Stop()
    {
      Console.WriteLine("El paseo en el auto ha terminado");
    }
  }
}
