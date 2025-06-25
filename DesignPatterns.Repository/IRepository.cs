namespace DesignPatterns.Repository
{
  public interface IRepository<TEntity>
  {
    // Como no se sabe que tipo de objeto va a regresar ponemos de tipo: TEntity
    IEnumerable<TEntity> Get();

    TEntity Get(int id);
    void Add(TEntity entity);
    void Delete(int id);
    void Update(TEntity entity);

    //  Este método permite realizar los cambios.
    //  Los cambios no se sabe si se van a enviar a una base de datos
    //  SQL, Non SQL, en una API, etc.
    void Save();
  }
}
