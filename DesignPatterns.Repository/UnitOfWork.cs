using DesignPatterns.Models.Data;

namespace DesignPatterns.Repository
{
  public class UnitOfWork : IUnitOfWork
  {
    // Como estamos trabajando con Entity Framework necesitamos un objeto Context.
    private SalesContext _context;

    // Para poder trabajar con las propiedades: Clients y Products
    public IRepository<Client> _clients;
    public IRepository<Product> _products;

    // Para la tabla "Categories" agregada como propiedad
    public IRepository<Category> _categories;

    // Inyectamos el context en el constructor
    public UnitOfWork(SalesContext context)
    {
      _context = context;
    }

    // Unit Of Work: Se puede trabajar como un SINGLETON es decir
    //               que se utilice una sola instancia.

    public IRepository<Client> Clients
    {
      get
      {
        // SINGLETON.
        // regresa el atributo de la clase llamado "_clients".
        // si es == null se regresa una instancia del repositorio Client
        // para esto se necesita el "Context".
        // Caso contrario regresa la instancia ya creada.
        //return _clients == null ? _clients = new Repository<Client>(_context) : _clients;

        if (_clients == null)
          _clients = new Repository<Client>(_context);

        return _clients;
      }
    }

    public IRepository<Product> Products
    {
      get
      {
        if (_products == null)
          _products = new Repository<Product>(_context);
        return _products;
      }
    }

    // Nueva propiedad implementada.
    public IRepository<Category> Categories
    {
      get
      {
        if (_categories == null)
          _categories = new Repository<Category>(_context);
        return _categories;
      }
    }


    public void Save()
    {
      // Guardar los datos en la base de datos.
      _context.SaveChanges();
    }
  }
}
