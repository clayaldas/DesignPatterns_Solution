using DesignPatterns.Models;
using Microsoft.EntityFrameworkCore;

namespace DesignPatterns.RepositoryPattern
{
    public class ClientRepository : IClientRepository
    {
        private SalesContext _context;

        public ClientRepository(SalesContext salesContext)
        {
            _context = salesContext;
        }

        public void Add(Client client)
        {
            // Add: INSERT
            _context.Clients.Add(client);
        }

        public void Delete(int id)
        {
            // Buscar el registro a eliminar.
            var row = _context.Clients.Find(id);

            // Puede no encontrarse
            if (row != null)
            {
                // Remove: DELETE
                _context.Clients.Remove(row);
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
            _context.Entry(client).State = EntityState.Modified;
        }
        public void Save()
        {
            _context.SaveChanges();
        }        
    }
}
