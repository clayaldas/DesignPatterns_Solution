using DesignPatternsImplementation.Factory_Method.Products;

namespace DesignPatternsImplementation.Factory_Method.Factories;

public abstract class VehicleFactory
{
    public abstract IVehicle CreateVehicle();

    public IVehicle OrderVehicle()
    {
        IVehicle vehicle = CreateVehicle();

        vehicle.Start();
        vehicle.Drive();
        vehicle.Stop();
        
        return vehicle;
    }
}
