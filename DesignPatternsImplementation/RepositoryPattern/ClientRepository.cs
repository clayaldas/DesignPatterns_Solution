using DesignPatternsImplementation.Models;
using Microsoft.EntityFrameworkCore;

namespace DesignPatternsImplementation.RepositoryPattern;

public class ClientRepository : IClientRepository
{
    // 1. Necesitamos un DbContext (Contexto) que esta en la carpeta "Models"
    private SalesContext _context;

    // 2. Inyectar el DbContext (Contexto) por constructor
    // Inyeccíón de dependencias para poder utilizar el EntityFramework
    public ClientRepository(SalesContext context)
    {
        _context = context;
    }

    public void Add(Client client)
    {
        _context.Clients.Add(client);// Added
    }

    //public void Add(Client client) => _context.Clients.Add(client);


    public void Delete(int id)
    {
        var client = _context.Clients.Find(id);

        // Eliminar el registro
        if (client != null) 
        { 
            _context.Clients.Remove(client);// Deleted
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
        _context.Entry(client).State = EntityState.Modified;// Modified
    }

    public void Save()
    {
        _context.SaveChanges();
    }
}
