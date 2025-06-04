using DesignPatterns.Models;
using DesignPatterns.RepositoryPattern;

namespace DesignPatterns.UnitOfWorkPattern
{
    public interface IUnitOfWork
    {
        // Propiedades (método-get) para los tablas
        // Por cada tabla se crea un repository
        // Repositorio para manejar la tabla: Clients
        public IRepository<Client> Clients { get; }

        // Repositorio para manejar la tabla: Products
        public IRepository<Product> Products { get; }

        // Método para grabar los datos en la base datos
        public void Save();
    }
}
