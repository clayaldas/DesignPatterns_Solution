using DesignPatterns.Models;
using DesignPatterns.RepositoryPattern;

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

            /*
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
            */
            #endregion

            #region Entity Framework
            /*
            using (var context = new SalesContext())
            {
                Console.WriteLine("Entity Framework");

                // Obtener todos los registros de la tabla: Clients
                var listClients = context.Clients.ToList();

                // Mostrar cada registro recuperado en ciclo.
                foreach (var row in listClients)
                {
                    Console.WriteLine(row.Id + "  " + row.Name +  
                        "   " + row.LastName + "   " + row.Age);
                }

            }
            */
            #endregion

            #region Repository Ejemplo 1
            /*
            using (var context = new SalesContext()) 
            {
                Console.WriteLine("Patron Repository");

                // Crear el repository
                var clientRepository = new ClientRepository(context);

                // Insertar un registro
                var client = new Client();
                //client.Id = 1;
                client.Name = "Test";
                client.LastName = "Test";
                client.Age = 34;

                clientRepository.Add(client);
                clientRepository.Save();

                // Refrescar los datos.
                foreach (var row in clientRepository.Get())
                {
                    Console.WriteLine(row.Id + " " + row.Name + " " + row.Age);
                }
            }
            */
            #endregion

            #region Repository con genericios Ejemplo 2

            // Utilizar la clase: Client
            using (var context = new SalesContext()) 
            { 
                var clientRepository = new Repository<Client>(context);

                // Insertar.
               var client = new Client() { Name = "Nombre", LastName = "Apellido", Age = 34 };

                clientRepository.Add(client);
                //clientRepository.Save();

                // Eliminar.
                clientRepository.Delete(6);

                // Actualizar.
                client.Id = 4;
                client.Name = "Actualizado";
                client.LastName = "Actualizado";
                client.Age = 30;
                clientRepository.Update(client);

                // Guardar los cambios en la Base de Datos.
                clientRepository.Save();

                foreach (var row in clientRepository.Get())
                {
                    Console.WriteLine($"{row.Id}  {row.Name} {row.LastName}  {row.Age}");
                }
            }            

            #endregion
        }
    }
}
