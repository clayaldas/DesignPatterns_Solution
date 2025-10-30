using DesignPatternsImplementation.Factory_Method.Factories;
using DesignPatternsImplementation.Factory_Method.Products;
using DesignPatternsImplementation.Singleton;

namespace DesignPatternsImplementation;

internal class Program
{
    static void Main(string[] args)
    {
        #region Patron Singleton
        /*
         
        Console.WriteLine("Patrón creacional: Singleton!");
        Console.WriteLine();

        //MySingleton mySingleton = new MySingleton();
        MySingleton instance1 = MySingleton.GetInstance();
        Console.WriteLine($"Intancia 1: {instance1.Id}");

        MySingleton instance2 = MySingleton.GetInstance();
        Console.WriteLine($"Intancia 2: {instance2.Id}");

        MySingleton instance3 = MySingleton.GetInstance();
        Console.WriteLine($"Intancia 3: {instance3.Id}");

        MySingleton instance4 = MySingleton.GetInstance();
        Console.WriteLine($"Intancia 4: {instance4.Id}");

        */
        #endregion

        Console.WriteLine("Patrón Factory Method");
        Console.WriteLine();

        VehicleFactory vehicleFactory = null;

        bool option = true;
        while (true)
        {
            Console.WriteLine("\nSeleccione el vehiculo de su preferencia: " +
                "\n 1. Auto, 2. Moto, 3. Salir");

            int vehicleChoice = Convert.ToInt32(Console.ReadLine());

            switch (vehicleChoice)
            {
                case 1: 
                    vehicleFactory = new CarFactory();
                    break;
                case 2:
                    vehicleFactory = new MotorCycleFactory();
                    break;
                default:
                    break;
            }

            IVehicle vehicle = vehicleFactory.OrderVehicle();
            Console.WriteLine($"Usted esta utilizando un {vehicle.GetType().Name}");
        }

        Console.WriteLine("Presione una tecla para continuar");
        Console.ReadKey();
    }
}
