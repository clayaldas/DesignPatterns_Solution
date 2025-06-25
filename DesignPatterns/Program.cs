using DesignPatterns.StrategyPattern;

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

      VehicleFactory vehicleFactory = null;

      while (true)
      {
        Console.WriteLine(
            "Seleccione un tipo de vehículo: (1) Auto, (2) Moto, (3) Bicicleta, (4) Salir"
        );

        int option = Convert.ToInt32(Console.ReadLine());

        switch (option)
        {
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
            return;
          default:
            break;
        }

        IVehicle vehicle = vehicleFactory.OrderVehicle();
        Console.WriteLine($"Vehículo creado: {vehicle.GetType().Name}");
      }
      */
      #endregion

      #region Dependency Injection

      /*
      // Esta responsabilidad va estar fuera (en el container)
      var client = new Client("Nombre", "Apellido");

      var store = new Store(client);
      store.WelcomeClient();

      */

      #endregion

      #region Repository ejemplo 1

      /*
      using (var context = new SalesContext())
      {
        Console.WriteLine("Entity Framework");

        // Obtener el listado de registros
        var listClients = context.Clients.ToList();

        if (listClients != null)
        {
          Console.WriteLine("Entity Framework no encontró datos");
        }
        // Mostrar los datos.
        foreach (var client in listClients)
        {
          Console.WriteLine(client.Id + " " + client.Name + " " + client.LastName);
        }
      }
      */
      #endregion

      #region Repository ejemplo 2
      /*
      try
      {
        // Creamos el contexto (DbContext).
        using (var context = new SalesContext())
        {
          Console.WriteLine("Entity Framework");

          // Creamos un "Repository" y le pasamos el Context.
          var clientRepository = new ClientRepository(context);

          // Insertar un nuevo registro.
          var client = new Client();
          // Agregamos los datos
          //client.Id = 100;
          client.Name = "Nuevo";
          client.LastName = "Registro insertado";
          client.Age = 70;
          // Agregar el objeto.
          clientRepository.Add(client);
          // Enviar los datos a la base de datos.
          clientRepository.Save();

          // Refrescar los datos.
          // Mostrar los datos con la colección que regresa el método"Get()".
          foreach (var rowClient in clientRepository.Get())
          {
            Console.WriteLine(rowClient.Id + " " + rowClient.Name + " " + rowClient.Age);
          }
        }

      }
      catch (DbUpdateException dbEx)
      {
        Console.WriteLine("Error de actualización de base de datos: " + dbEx.Message);
        //Console.WriteLine("Error: " + dbEx.InnerException?.Message);
        //Console.WriteLine("Error: " + dbEx.StackTrace);
        // Manejo de excepciones específicas de actualización de base de datos
        if (dbEx.InnerException is SqlException sqlEx)
        {
          Console.WriteLine("Error en SQL Server: " + sqlEx.Message);
        }
      }
      catch (Exception ex)
      {
        Console.WriteLine("Error: " + ex.Message);
        //Console.WriteLine("Error: " + ex.InnerException);
        Console.WriteLine("Error: " + ex.StackTrace);
        //Console.WriteLine("Error: " + ex.GetType());
      }
      */
      #endregion

      #region Repository usando Generics
      /*
      using (var context = new SalesContext())
      {
        var clientRepository = new Repository<Client>(context);

        // Insertar.
        var client = new Client()
        {
          Name = "Nombre",
          LastName = "Apellido",
          Age = 34,
        };
        clientRepository.Add(client);
        //clientRepository.Save();

        // Eliminar.
        clientRepository.Delete(9);

        // Actualizar.
        client.Id = 10;
        client.Name = "Actualizado";
        client.LastName = "Actualizado";
        client.Age = 700;
        clientRepository.Update(client);

        // Guardar los cambios en la Base de Datos.
        clientRepository.Save();

        // Recuperar datos.
        foreach (var row in clientRepository.Get())
        {
          Console.WriteLine($"{row.Id} {row.Name} {row.Age}");
        }
      }
      */
      #endregion

      #region Unit Of Work
      /*
      // Necesitamos un "Context".
      using (var context = new SalesContext())
      {
        //  using DesignPatterns.UnitOfWorkPattern;
        var unitOfWork = new UnitOfWork(context);

        // Regresar una instancia de "Clients" según "Unit Of Work".
        // Singleton: solo es una intancia.
        var clients = unitOfWork.Clients;

        // Crear un objeto de tipo: "Client".
        //  using DesignPatterns.Models;
        var client = new Client()
        {
          Name = "John",
          LastName = "Doe",
          Age = 34,
        };

        // Agregamos el regitro a la BD con el repositorio "Clients"
        // que es la propiedad de "Unit Of Work".
        clients.Add(client);

        // Repetimos el proceso con la tabla "Products".
        var products = unitOfWork.Products;

        var product = new Product()
        {
          Name = "Computadores",
          UnitsInStock = 700,
          UnitPrice = 700,
        };

        products.Add(product);

        // Guardar los cambios en la BD.
        unitOfWork.Save();
      }
      */

      #endregion

      #region Patron Strategy

      var context = new Context(new CarStrategy());
      context.ExecuteStrategy();

      context.Strategy = new MotoStrategy();
      context.ExecuteStrategy();

      context.Strategy = new BicycleStrategy();
      context.ExecuteStrategy();

      #endregion
    }
  }
}

