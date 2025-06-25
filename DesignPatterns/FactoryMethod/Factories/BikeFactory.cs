using DesignPatterns.FactoryMethod.Products;

namespace DesignPatterns.FactoryMethod.Factories
{
    public class BikeFactory : VehicleFactory
    {
        public override IVehicle CreateVehicle()
        {
            return new Bike();
        }
    }
}
