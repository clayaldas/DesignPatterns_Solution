
using DesignPatterns.Models;
using Microsoft.EntityFrameworkCore;

namespace DesignPatterns.RepositoryPattern
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private SalesContext _context;

        // Como se esta utilizando EntityFramework es necesario una 
        // variable de tipo: DbSet
        private DbSet<TEntity> _dbSet;

        public Repository(SalesContext context)
        {
           _context = context;

            // Inicializar el DbSet para esto le pasamo el generico "TEntity"
            // que representa la clase que vamos recibir (Client, Products, etc).
            _dbSet = context.Set<TEntity>();
        }
        public void Delete(int id)
        {
            // Buscar el registro a eliminar.
            var row = _dbSet.Find(id);

            // Puede no encontrarse
            if (row != null)
            {
                // Remove: DELETE
                _dbSet.Remove(row);                
            }
        }

        public IEnumerable<TEntity> Get()
        {
            //return _context.Clients.Find(id);
            return _dbSet.ToList();
        }

        public TEntity Get(int id)
        {
            //return _context.Clients.Find(id);
            return _dbSet.Find(id);
        }

        public void Add(TEntity entity)
        {
            //return _context.Clients.Find(id);
            _dbSet.Add(entity);
        }
        public void Update(TEntity entity)
        {
            //_context.Entry(client).State = EntityState.Modified;
            _dbSet.Entry(entity).State = EntityState.Modified;
        }

        public void Save()
        {
            //_context.SaveChanges();
            _context.SaveChanges();
        }

        
    }
}
