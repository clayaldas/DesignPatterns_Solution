using DesignPatterns.Models;
using DesignPatterns.RepositoryPattern;

namespace DesignPatterns.UnitOfWorkPattern
{
    public class UnitOfWork : IUnitOfWork
    {
        // Como estamos utilizando Entity Framework se necesita un DdbConext
        private SalesContext _context;

        // Para poder trabajar con las propiedades: Clients, Products
        public IRepository<Client> _clients;
        public IRepository<Product> _products;

        // Inyectar el context en el constructor
        public UnitOfWork(SalesContext context)
        {
            _context = context;
        }

        public IRepository<Client> Clients
        {
            get {
                // Retonar una sola instancia del repositorio.

                return _clients == null ? _clients = new Repository<Client>(_context) : _clients;
            }
        }

        public IRepository<Product> Products
        {
            get
            {
                if (_products == null)
                {
                    _products = new Repository<Product>(_context);
                }

                return _products;
            }
        }

        public void Save()
        {
            // Guardar en la Base de Datos.
            _context.SaveChanges();
        }
    }
}
