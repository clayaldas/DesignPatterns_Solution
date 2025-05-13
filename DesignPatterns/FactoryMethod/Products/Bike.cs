namespace DesignPatterns.FactoryMethod.Products
{
    public class Bike : IVehicle
    {
        public void Drive()
        {
            Console.WriteLine("Paseando en la bicicleta");
        }

        public void Start()
        {
            Console.WriteLine("Iniciando el paseo en la bicicleta");
        }

        public void Stop()
        {
            Console.WriteLine("Deteniendo el paseo en la bicicleta");
        }
    }
}
