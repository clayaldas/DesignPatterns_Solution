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

        // Este método permite guardar los cambios (INSERT, DELETE, UPDATE)
        // en la fuente de datos.
        // Los cambios no se sabe si se van enviar a una fuente relacional
        // (SQL), No SQL, una API, archivos, etc.
        void Save();
    }
}
