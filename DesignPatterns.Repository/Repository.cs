using DesignPatterns.Models.Data;
using Microsoft.EntityFrameworkCore;

namespace DesignPatterns.Repository
{
  // La interfaz "IRepository" recibe el tipo que recibe la clase una entidad "TEntity".
  // Esto permite que la clase Repository pueda ser reutilizada para cualquier tipo de entidad.
  // Por ejemplo, si se quiere crear un repositorio para una entidad "Product", se puede
  // hacer de la siguiente manera:
  // IRepository<Product> productRepository = new Repository<Product>();
  // Esto permite que la clase Repository pueda ser reutilizada para cualquier tipo de entidad(clase).
  // NOTA: where TEntity : class. Esto significa que TEntity (Generic) debe
  // ser una clase, no un tipo de valor.
  public class Repository<TEntity> : IRepository<TEntity>
      where TEntity : class
  {
    // 1. Necesitamos un Context que esta en Models.
    private SalesContext _context;

    //  Necesitamos un DbSet para trabajar con: TEntity
    private DbSet<TEntity> _dbSet;

    public Repository(SalesContext context)
    {
      _context = context;

      //  Inicializamos el DbSet y le pasamos "TEntity" es el
      //  objeto vamos a recibir (Client, Product).
      _dbSet = context.Set<TEntity>();
    }

    public IEnumerable<TEntity> Get()
    {
      return _dbSet.ToList();
    }

    public TEntity Get(int id)
    {
      return _dbSet.Find(id);
    }

    public void Add(TEntity entity)
    {
      _dbSet.Add(entity);
    }

    public void Delete(int id)
    {
      // Obtener el registro a eliminar.
      var rowToDelete = _dbSet.Find(id);

      if (rowToDelete != null)
      {
        _dbSet.Remove(rowToDelete);
      }
    }

    public void Update(TEntity entity)
    {
      // Adjuntar la fila a modificar.
      // El _dbSet localiza el elemento para actualizar.
      // entity: Representa la fila a modificar.
      //_dbSet.Attach(entity);

      // El elemento en el contexto sea modificado.
      // Cambiar el estado.
      _context.Entry(entity).State = EntityState.Modified;
    }

    public void Save()
    {
      _context.SaveChanges();
    }
  }
}

