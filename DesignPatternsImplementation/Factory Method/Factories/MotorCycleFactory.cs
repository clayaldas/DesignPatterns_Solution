using DesignPatternsImplementation.Factory_Method.Products;

namespace DesignPatternsImplementation.Factory_Method.Factories;

public class MotorCycleFactory : VehicleFactory
{
    public override IVehicle CreateVehicle()
    {
        return new MotorCycle();
    }
}
