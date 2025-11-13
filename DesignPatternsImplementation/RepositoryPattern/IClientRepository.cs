using DesignPatternsImplementation.Models;

namespace DesignPatternsImplementation.RepositoryPattern;

public interface IClientRepository
{
    // Regresar todos los datos
    IEnumerable<Client> Get();
    // Agregar un cliente
    void Add(Client client);
    // Eliminar un cliente
    void Delete(int id);
    // Actualizar un cliente
    void Update(Client client);

    // Este método permite actulizar la base de datos (INSERT, DELETE, UPDATE)
    void Save();
}
