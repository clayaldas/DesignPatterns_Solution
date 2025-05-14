using DesignPatterns.FactoryMethod;
using DesignPatterns.FactoryMethod.Factories;
using DesignPatterns.Singleton;

namespace DesignPatterns
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Singleton 

            /*
            Console.WriteLine("Patron Singleton!");
            //MySingleton singleton = MySingleton.GetInstance();
            MySingleton instance1 = MySingleton.GetInstance();
            Console.WriteLine($"Id de la instancia: {instance1.Id}");

            MySingleton instance2 = MySingleton.GetInstance();
            Console.WriteLine($"Id de la instancia: {instance2.Id}");

            MySingleton instance3 = MySingleton.GetInstance();
            Console.WriteLine($"Id de la instancia: {instance3.Id}");
            */
            #endregion

            #region Ejemplo de Singleton 

            /*
            Log log1 = Log.GetInstance();
            log1.SaveFile("Martes 28 de abril del 2025");
            log1.SaveFile("Esto es una prueba de el patron Singleton");

            Log log2 = Log.GetInstance();
            log2.SaveFile("Martes 29 de abril del 2025");
            log2.SaveFile("Esto es una prueba de el patron Singleton");

            Log log3 = Log.GetInstance();
            log3.SaveFile("Martes 30 de abril del 2025");
            log3.SaveFile("Esto es una prueba de el patron Singleton");

            Log log4 = Log.GetInstance();
            log4.SaveFile("Martes 31 de abril del 2025");
            log4.SaveFile("Esto es una prueba de el patron Singleton");
            */

            #endregion

            #region Factory Method

            Console.WriteLine("PATRON: Factory Method");
            Console.WriteLine();

            // Fabrica
            VehicleFactory vehicleFactory = null;

            while (true)
            {
                Console.WriteLine("Seleccione un tipo de vehículo: (1) Auto, (2) Moto, (3) Bicicleta, (4) Salir");

                int option = Convert.ToInt32(Console.ReadLine());

                switch (option)
                {
                    // Products
                    case 1:
                        vehicleFactory = new CarFactory();
                        break;
                        case 2:
                        vehicleFactory = new MotorCycleFactory();                        
                        break;
                        case 3:
                        vehicleFactory = new BikeFactory();
                        break;
                        case 4:
                        break;
                }

                // usar la clase concretas
                IVehicle vehicle = vehicleFactory.OrderVehicle();
                Console.WriteLine($"Selecciono el tipo: {vehicle.GetType().Name}");
                
            }

            #endregion
        }
    }
}
