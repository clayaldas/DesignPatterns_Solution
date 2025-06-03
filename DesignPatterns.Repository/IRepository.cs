namespace DesignPatterns.Repository
{
  public interface IRepository<TEntity>
  {
    // Como no se sabe que tipo de objeto va a regresar
    // los métodos entonces se debe utilizar el tipo: TEntity
    IEnumerable<TEntity> Get();
    TEntity Get(int id);
    void Add(TEntity entity);
    void Delete(int id);
    void Update(TEntity entity);
    void Save();
  }
}
