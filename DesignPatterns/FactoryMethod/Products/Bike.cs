namespace DesignPatterns.FactoryMethod.Products
{
  public class Bike : IVehicle
  {
    public void Start()
    {
      Console.WriteLine("Se inicia el paseo en la bicicleta");
    }

    public void Drive()
    {
      Console.WriteLine("Paseando en la bicicleta");
    }

    public void Stop()
    {
      Console.WriteLine("El paseo en la bicicleta ha terminado");
    }
  }
}
