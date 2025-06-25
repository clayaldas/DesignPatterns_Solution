namespace DesignPatterns.FactoryMethod.Products
{
  public class MotorCycle : IVehicle
  {
    public void Start()
    {
      Console.WriteLine("Se inicia el paseo en la moto");
    }

    public void Drive()
    {
      Console.WriteLine("Paseando en la moto");
    }

    public void Stop()
    {
      Console.WriteLine("El paseo en la moto ha terminado");
    }
  }
}
