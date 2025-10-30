using DesignPatternsImplementation.Factory_Method.Products;

namespace DesignPatternsImplementation.Factory_Method.Factories;

public class CarFactory : VehicleFactory
{
    public override IVehicle CreateVehicle()
    {
        return new Car();
    }
}
