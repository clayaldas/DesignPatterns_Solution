using DesignPatterns.Models.Data;

namespace DesignPatterns.Repository
{
    public interface IUnitOfWork
    {
        // Propiedades (método-get) para los tablas
        // Por cada tabla se crea un repository
        // Repositorio para manejar la tabla: Clients
        public IRepository<Client> Clients { get; }

        // Repositorio para manejar la tabla: Products
        public IRepository<Product> Products { get; }

        // Repositorio para manejar la tabla: Categories
        public IRepository<Category> Categories { get; }

        // Método para grabar los datos en la base datos
        public void Save();
    }
}
