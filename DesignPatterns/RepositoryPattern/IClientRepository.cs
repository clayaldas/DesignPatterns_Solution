using DesignPatterns.Models;

namespace DesignPatterns.RepositoryPattern
{
  public interface IClientRepository
  {
    IEnumerable<Client> Get();
    Client Get(int id);
    void Add(Client client);
    void Delete(int id);
    void Update(Client client);


    //  Este método permite realizar los cambios.
    //  Los cambios no se sabe si se van a enviar a una base de datos
    //  SQL, Non SQL, en una API, etc.
    void Save();
  }
}
