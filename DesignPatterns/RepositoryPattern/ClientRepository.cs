
using DesignPatterns.Models;
using Microsoft.EntityFrameworkCore;

namespace DesignPatterns.RepositoryPattern
{
  public class ClientRepository : IClientRepository
  {
    // 1. Necesitamos un Context que esta en Models.
    private SalesContext _context;

    // 2. Inyectamos el Context en el constructor
    //    para poder utilizar el Entity Framework.
    public ClientRepository(SalesContext context)
    {
      _context = context;
    }

    public void Add(Client client)
    {
      // Con el Context hacemos referencia a la clase "Clients"
      // que representa a la tabla "Clients" de la base de datos
      // y le pasamos el parámetro "Client".
      _context.Clients.Add(client);
    }

    // Usando expresiones Lamda.
    //public void Add(Client client) => _context.Clients.Add(client);

    public void Delete(int id)
    {
      // Obtener el registro de la tabla "Clients" que tenga el "Id"
      // el cual va a ser eliminado. Esto regresa un objeto de tipo "Client".
      var client = _context.Clients.Find(id);

      // Puede ser nulll.
      if (client != null)
      {
        // Eliminamos el registro utilizando el Contexto (Context).
        _context.Clients.Remove(client);
      }
    }

    public IEnumerable<Client> Get()
    {
      return _context.Clients.ToList();
    }

    public Client Get(int id)
    {
      return _context.Clients.Find(id);
    }

    public void Update(Client client)
    {
      // Cambiamos el estado con la enumeración "EntityState".
      //_context.Entry(client).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
      // Agregamos la libreria.
      _context.Entry(client).State = EntityState.Modified;
    }

    // Este método permite hacer el guardado de los datos.
    public void Save()
    {
      // En Entity Framework si no se ejecuta el método "SaveChanges"
      // los datos no se guardan en la base de datos.
      _context.SaveChanges();
    }
  }
}


