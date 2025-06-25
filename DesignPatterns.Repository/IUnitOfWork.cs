using DesignPatterns.Models.Data;

namespace DesignPatterns.Repository
{
  public interface IUnitOfWork
  {
    // Propiedadades para las tablas.
    public IRepository<Client> Clients { get; }
    public IRepository<Product> Products { get; }

    //  Nueva propiedad para la tabla "Categories" 
    public IRepository<Category> Categories { get; }

    // Método para grabar los datos.
    public void Save();
  }
}
