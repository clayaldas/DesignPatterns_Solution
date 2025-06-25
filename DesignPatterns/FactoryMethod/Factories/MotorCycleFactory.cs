using DesignPatterns.FactoryMethod.Products;

namespace DesignPatterns.FactoryMethod.Factories
{
    internal class MotorCycleFactory : VehicleFactory
    {
        public override IVehicle CreateVehicle()
        {
            return new MotorCycle();
        }
    }
}
