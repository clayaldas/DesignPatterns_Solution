namespace DesignPatterns.FactoryMethod.Factories
{
  public abstract class VehicleFactory
  {
    // Método fábrica (Factory Method).
    public abstract IVehicle CreateVehicle();


    // Permite utiliza los métodos de la interfaz (IVehicle)
    public IVehicle OrderVehicle()
    {
      IVehicle vehicle = CreateVehicle();

      vehicle.Start();
      vehicle.Drive();
      vehicle.Stop();
      return vehicle;
    }

  }
}
