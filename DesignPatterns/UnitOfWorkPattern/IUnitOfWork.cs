using DesignPatterns.Models;
using DesignPatterns.RepositoryPattern;

namespace DesignPatterns.UnitOfWorkPattern
{
  public interface IUnitOfWork
  {
    // Propiedadades para las tablas.
    public IRepository<Client> Clients { get; }
    public IRepository<Product> Products { get; }

    // Método para grabar los datos.
    public void Save();
  }
}
